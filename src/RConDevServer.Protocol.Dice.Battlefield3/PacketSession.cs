using System.Collections.Generic;
using System.Linq;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.MapList;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.NotAuthenticated;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.ReservedSlots;
using RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars;
using RConDevServer.Protocol.Dice.Battlefield3.Event;
using RConDevServer.Protocol.Interface;
using System;
using RConDevServer.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3
{
    public class PacketSession : IDisposable
    {
        private readonly object syncRoot = new object();

        #region Events

        /// <summary>
        /// this event is invoked, when a packet is received from the client
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketReceived;

        /// <summary>
        /// this event is invoked, when a packet containing a client command is received
        /// </summary>
        public event EventHandler<PacketDataEventArgs> ClientCommandReceived;

        /// <summary>
        /// this event is invoked, when a packet containing a client command is received
        /// </summary>
        public event EventHandler<PacketDataEventArgs> ServerEventResponseReceived;

        /// <summary>
        /// this event is invoked, when a packet was sent to the client
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketSent;

        /// <summary>
        /// this event is invoked, when the Session is closed
        /// </summary>
        public event EventHandler<PacketSessionEventArgs> SessionClosed;

        /// <summary>
        /// this event is invoked, if the server is updated
        /// </summary>
        public event EventHandler<EventArgs> ServerUpdated;

        #endregion

        #region Public Properties

        /// <summary>
        /// the serializer is responsible for convert to / from packet data
        /// </summary>
        public IPacketSerializer<IPacket> PacketSerializer { get; private set; }

        /// <summary>
        /// the hashvalue needed for crypting the rcon password
        /// </summary>
        public string HashValue { get; private set; }

        /// <summary>
        /// the server the Session is related to
        /// </summary>
        public Battlefield3Server Server { get; private set; }

        /// <summary>
        /// the wrapped byte Session
        /// </summary>
        public IRconSession Session { get; private set; }

        /// <summary>
        /// shows, if the current Session is admin authenticated
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// shows, if the server sends events to the client
        /// </summary>
        public bool IsEventsEnabled { get; set; }

        /// <summary>
        /// Handlers for all actions not requiring to be authenticated
        /// </summary>
        public CommandHandlersList CommandHandlersList { get; private set; }

        /// <summary>
        /// Gets the Manager for the communications <see cref="Packet.SequenceId"/>
        /// </summary>
        public PacketSequence PacketSequence { get; private set; }

        /// <summary>
        /// the collection of all unanswered events
        /// </summary>
        public IList<Packet> EventsSent { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// creates a wrapper around the core Session, which is able to convert the packet data used
        /// in the battlefield 3 protocol into normal bytes
        /// </summary>
        /// <param name="session"></param>
        /// <param name="server"> </param>
        public PacketSession(IRconSession session, Battlefield3Server server)
        {
            Session = session;
            Server = server;
            PacketSerializer = new PacketSerializer();
            PacketSequence = new PacketSequence();
            EventsSent = new List<Packet>();

            // create the hash value for validating crypted password
            HashValue = Guid.NewGuid().ToString().Replace("-", string.Empty);


            this.CommandHandlersList = new CommandHandlersList();
            this.CommandHandlersList.Add(new MapListCommandHandlers());
            this.CommandHandlersList.Add(new BanListCommandHandlers());
            this.CommandHandlersList.Add(new VarsCommandHandlers());
            this.CommandHandlersList.Add(new ReservedSlotsListCommandHandlers());
            this.CommandHandlersList.Add(new AdminCommandHandlers());
            this.CommandHandlersList.Add(new NotAuthenticatedCommandHandlers(server.ServiceLocator));

            this.ClientCommandReceived += CommandHandlersList.OnCommandReceived;
            this.ServerEventResponseReceived += OnServerEventResponseReceived;

            if (session != null)
            {
                Session.DataReceived += OnDataReceived;
                Session.DataSent += OnDataSent;
                Session.Closed += SessionOnClosed;
            }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Starts Listening for data
        /// </summary>
        public void StartReceiving()
        {
            Session.WaitForData(Session.Socket);
        }

        /// <summary>
        /// sends a packet to the client
        /// </summary>
        /// <param name="packetData"></param>
        public void SendToClient(Packet packetData)
        {
            if (packetData.SequenceId < PacketSequence.CurrentSequenceId)
            {
                packetData.SequenceId = Convert.ToUInt32(PacketSequence.NextSequenceId);
            }
            var bytes = this.PacketSerializer.Serialize(packetData);
            this.Session.SendToClient(bytes);
        }

        public void RaiseServerEvent(Packet eventPacket)
        {
            lock (syncRoot)
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
            var packets = PacketSerializer.Deserialize(e.ByteData);

            if (packets != null)
            {
                foreach (var packet in packets)
                {
                    PacketSequence.CurrentSequenceId = Convert.ToInt32(packet.SequenceId);

                    InvokePacketReceived(packet);
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
            var packets = PacketSerializer.Deserialize(e.ByteData);
            if (packets != null)
            {
                foreach (var packet in packets)
                {
                    InvokePacketSent(packet);
                }
            }
        }

        private void SessionOnClosed(object sender, SessionEventArgs sessionEventArgs)
        {
            InvokeSessionClosed(this);
        }

        private void OnServerEventResponseReceived(object sender, PacketDataEventArgs packetDataEventArgs)
        {
            lock (syncRoot)
            {
                var eventPacket = EventsSent.FirstOrDefault(x => x.SequenceId == packetDataEventArgs.PacketData.SequenceId);
                if (eventPacket != null)
                {
                    EventsSent.Remove(eventPacket);
                }
            }
        }

        #endregion

        #region Invoke Events

        internal void InvokePacketReceived(Packet packet)
        {
            if (PacketReceived == null) return;

            PacketReceived.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        internal void InvokeClientCommandReceived(Packet packet)
        {
            if (ClientCommandReceived == null) return;

            ClientCommandReceived.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        internal void InvokeServerEventResponseReceived(Packet packet)
        {
            if (ServerEventResponseReceived == null) return;

            ServerEventResponseReceived.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        internal void InvokePacketSent(Packet packet)
        {
            if (PacketSent == null) return;

            PacketSent.InvokeAll(this, new PacketDataEventArgs(packet));
        }

        private void InvokeSessionClosed(PacketSession packetSession)
        {
            if (SessionClosed == null) return;

            SessionClosed.InvokeAll(this, new PacketSessionEventArgs(this));
        }

        internal void InvokeServerUpdated()
        {
            if (ServerUpdated == null) return;

            ServerUpdated.InvokeAll(this, new EventArgs());
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Session.Dispose();
        }

        #endregion
    }
}