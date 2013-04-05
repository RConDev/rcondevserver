namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;
    using System.Collections.Generic;
    using CommandHandler;
    using Common;
    using Event;
    using Interface;

    /// <summary>
    /// this interface describes a session in which <see cref="IPacket"/> instance are sent
    /// </summary>
    public interface IPacketSession : IDisposable
    {
        /// <summary>
        ///     this event is invoked, when a packet is received from the client
        /// </summary>
        event EventHandler<PacketDataEventArgs> PacketReceived;

        /// <summary>
        ///     this event is invoked, when a packet containing a client command is received
        /// </summary>
        event EventHandler<ClientCommandEventArgs> ClientCommandReceived;

        /// <summary>
        ///     this event is invoked, when a packet containing a client command is received
        /// </summary>
        event EventHandler<PacketDataEventArgs> ServerEventResponseReceived;

        /// <summary>
        ///     this event is invoked, when a packet was sent to the client
        /// </summary>
        event EventHandler<PacketDataEventArgs> PacketSent;

        /// <summary>
        ///     this event is invoked, when the Session is closed
        /// </summary>
        event EventHandler<PacketSessionEventArgs> SessionClosed;

        /// <summary>
        ///     this event is invoked, if the server is updated
        /// </summary>
        event EventHandler<EventArgs> ServerUpdated;

        /// <summary>
        ///     resolving needed services
        /// </summary>
        IServiceLocator ServiceLocator { get; }

        /// <summary>
        ///     the serializer is responsible for convert to / from packet data
        /// </summary>
        IPacketSerializer<IPacket> PacketSerializer { get; }

        /// <summary>
        ///     the hashvalue needed for crypting the rcon password
        /// </summary>
        string HashValue { get; }

        /// <summary>
        ///     the server the Session is related to
        /// </summary>
        IBattlefield3Server Server { get; }

        /// <summary>
        ///     the wrapped byte Session
        /// </summary>
        IRconSession Session { get; }

        /// <summary>
        ///     shows, if the current Session is admin authenticated
        /// </summary>
        bool IsAuthenticated { get; set; }

        /// <summary>
        ///     shows, if the server sends events to the client
        /// </summary>
        bool IsEventsEnabled { get; set; }

        /// <summary>
        ///     Handlers for all actions not requiring to be authenticated
        /// </summary>
        CommandHandlersList CommandHandlersList { get; }

        /// <summary>
        ///     Gets the Manager for the communications <see cref="RConDevServer.Protocol.Dice.Common.Packet.SequenceId" />
        /// </summary>
        PacketSequence PacketSequence { get; }

        /// <summary>
        ///     the collection of all unanswered events
        /// </summary>
        IList<Packet> EventsSent { get; }

        /// <summary>
        ///     Starts Listening for data
        /// </summary>
        void StartReceiving();

        /// <summary>
        ///     sends a packet to the client
        /// </summary>
        /// <param name="packetData"></param>
        void SendToClient(Packet packetData);

        void RaiseServerEvent(Packet eventPacket);

        void RaiseServerEvent(IEvent serverEvent);
    }
}