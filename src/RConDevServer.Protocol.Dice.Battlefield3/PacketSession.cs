namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using CommandFactory;
    using CommandHandler;
    using CommandHandler.Admin;
    using CommandHandler.BanList;
    using CommandHandler.MapList;
    using CommandHandler.NotAuthenticated;
    using CommandHandler.ReservedSlots;
    using CommandHandler.Vars;
    using Common;
    using Event;
    using Interface;
    using RConDevServer.Util;

    public class PacketSession : IDisposable
    {
        private readonly object syncRoot = new object();

        #region Events

        /// <summary>
        ///     this event is invoked, when a packet is received from the client
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketReceived;

        /// <summary>
        ///     this event is invoked, when a packet containing a client command is received
        /// </summary>
        public event EventHandler<ClientCommandEventArgs> ClientCommandReceived;

        /// <summary>
        ///     this event is invoked, when a packet containing a client command is received
        /// </summary>
        public event EventHandler<PacketDataEventArgs> ServerEventResponseReceived;

        /// <summary>
        ///     this event is invoked, when a packet was sent to the client
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketSent;

        /// <summary>
        ///     this event is invoked, when the Session is closed
        /// </summary>
        public event EventHandler<PacketSessionEventArgs> SessionClosed;

        /// <summary>
        ///     this event is invoked, if the server is updated
        /// </summary>
        public event EventHandler<EventArgs> ServerUpdated;

        #endregion

        #region Public Properties

        /// <summary>
        ///     resolving needed services
        /// </summary>
        public IServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        ///     the serializer is responsible for convert to / from packet data
        /// </summary>
        public IPacketSerializer<IPacket> PacketSerializer { get; private set; }

        /// <summary>
        ///     the hashvalue needed for crypting the rcon password
        /// </summary>
        public string HashValue { get; private set; }

        /// <summary>
        ///     the server the Session is related to
        /// </summary>
        public Battlefield3Server Server { get; private set; }

        /// <summary>
        ///     the wrapped byte Session
        /// </summary>
        public IRconSession Session { get; private set; }

        /// <summary>
        ///     shows, if the current Session is admin authenticated
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        ///     shows, if the server sends events to the client
        /// </summary>
        public bool IsEventsEnabled { get; set; }

        /// <summary>
        ///     Handlers for all actions not requiring to be authenticated
        /// </summary>
        public CommandHandlersList CommandHandlersList { get; private set; }

        /// <summary>
        ///     Gets the Manager for the communications <see cref="RConDevServer.Protocol.Dice.Common.Packet.SequenceId" />
        /// </summary>
        public PacketSequence PacketSequence { get; private set; }

        /// <summary>
        ///     the collection of all unanswered events
        /// </summary>
        public IList<Packet> EventsSent { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     creates a wrapper around the core Session, which is able to convert the packet data used
        ///     in the battlefield 3 protocol into normal bytes
        /// </summary>
        /// <param name="session"></param>
        /// <param name="server"> </param>
        public PacketSession(IRconSession session, Battlefield3Server server)
        {
            this.ServiceLocator = server.ServiceLocator;
            this.Session = session;
            this.Server = server;
            this.PacketSerializer = new PacketSerializer();
            this.PacketSequence = new PacketSequence();
            this.EventsSent = new List<Packet>();

            // create the hash value for validating crypted password
            this.HashValue = Guid.NewGuid().ToString().Replace("-", string.Empty);

            this.CommandHandlersList = new CommandHandlersList(
                new CommandHandlers(this.ServiceLocator));

            this.ClientCommandReceived += this.CommandHandlersList.OnCommandReceived;
            this.ServerEventResponseReceived += this.OnServerEventResponseReceived;

            if (session == null)
            {
                return;
            }

            this.Session.DataReceived += this.OnDataReceived;
            this.Session.DataSent += this.OnDataSent;
            this.Session.Closed += this.SessionOnClosed;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Starts Listening for data
        /// </summary>
        public void StartReceiving()
        {
            this.Session.WaitForData(this.Session.Socket);
        }

        /// <summary>
        ///     sends a packet to the client
        /// </summary>
        /// <param name="packetData"></param>
        public void SendToClient(Packet packetData)
        {
            if (packetData.SequenceId < this.PacketSequence.CurrentSequenceId)
            {
                packetData.SequenceId = Convert.ToUInt32(this.PacketSequence.NextSequenceId);
            }
            byte[] bytes = this.PacketSerializer.Serialize(packetData);
            this.Session.SendToClient(bytes);
        }

        public void RaiseServerEvent(Packet eventPacket)
        {
            lock (this.syncRoot)
            {
                this.EventsSent.Add(eventPacket);
            }
            this.SendToClient(eventPacket);
        }

        public void RaiseServerEvent(IEvent serverEvent)
        {
            var packet = new Packet(PacketOrigin.Server, false, 0, serverEvent.ToWords());
            RaiseServerEvent(packet);
        }

        #endregion

        #region Private Methods

        private void OnDataReceived(object sender, ByteDataEventArgs e)
        {
            IEnumerable<Packet> packets = this.PacketSerializer.Deserialize(e.ByteData);

            if (packets != null)
            {
                foreach (Packet packet in packets)
                {
                    this.PacketSequence.CurrentSequenceId = Convert.ToInt32(packet.SequenceId);

                    this.InvokePacketReceived(packet);
                    if (packet.IsClientCommand)
                    {
                        this.InvokeClientCommandReceived(packet);
                    }
                    if (packet.IsServerEventResponse)
                    {
                        this.InvokeServerEventResponseReceived(packet);
                    }
                }
            }
        }

        private void OnDataSent(object sender, ByteDataEventArgs e)
        {
            IEnumerable<Packet> packets = this.PacketSerializer.Deserialize(e.ByteData);
            if (packets != null)
            {
                foreach (Packet packet in packets)
                {
                    this.InvokePacketSent(packet);
                }
            }
        }

        private void SessionOnClosed(object sender, SessionEventArgs sessionEventArgs)
        {
            this.InvokeSessionClosed(this);
        }

        private void OnServerEventResponseReceived(object sender, PacketDataEventArgs packetDataEventArgs)
        {
            lock (this.syncRoot)
            {
                Packet eventPacket =
                    this.EventsSent.FirstOrDefault(x => x.SequenceId == packetDataEventArgs.PacketData.SequenceId);
                if (eventPacket != null)
                {
                    this.EventsSent.Remove(eventPacket);
                }
            }
        }

        #endregion

        #region Invoke Events

        internal void InvokePacketReceived(Packet packet)
        {
            if (this.PacketReceived == null)
            {
                return;
            }

            this.PacketReceived.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        internal void InvokeClientCommandReceived(Packet packet)
        {
            if (this.ClientCommandReceived == null)
            {
                return;
            }

            ICommand command = null;
            if (packet.Words.Count > 0)
            {
                var commandFactory = ServiceLocator.GetService<ISimpleCommandFactory>(packet.Words[0]);
                if (commandFactory != null)
                {
                    command = commandFactory.FromWords(packet.Words);
                }
            }
            this.ClientCommandReceived.InvokeAll(this, new ClientCommandEventArgs(packet, command));
        }

        internal void InvokeServerEventResponseReceived(Packet packet)
        {
            if (this.ServerEventResponseReceived == null)
            {
                return;
            }

            this.ServerEventResponseReceived.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        internal void InvokePacketSent(Packet packet)
        {
            if (this.PacketSent == null)
            {
                return;
            }

            this.PacketSent.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        private void InvokeSessionClosed(PacketSession packetSession)
        {
            if (this.SessionClosed == null)
            {
                return;
            }

            this.SessionClosed.InvokeAll(this, new PacketSessionEventArgs(this));
        }

        internal void InvokeServerUpdated()
        {
            if (this.ServerUpdated == null)
            {
                return;
            }

            this.ServerUpdated.InvokeAll(this, new EventArgs());
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Session.Dispose();
        }

        #endregion
    }
}