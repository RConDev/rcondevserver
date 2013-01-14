namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender
{
    using System.Collections.Generic;
    using Common;

    /// <summary>
    ///     this interface describes the basic functionality an object must implement to send server events to the client
    /// </summary>
    public interface ICanSendEvents
    {
        /// <summary>
        ///     the server command string for the event
        /// </summary>
        string EventCommand { get; }

        /// <summary>
        ///     retrieves the packet containing the event information
        /// </summary>
        Packet EventPacket { get; }

        /// <summary>
        ///     sends the event to all connected clients of the server
        /// </summary>
        /// <param name="server"></param>
        void Send(Battlefield3Server server);

        /// <summary>
        ///     Sets the Parameters of the Command
        /// </summary>
        /// <param name="commandParameterList"></param>
        bool SetParameters(IEnumerable<string> commandParameterList);
    }
}