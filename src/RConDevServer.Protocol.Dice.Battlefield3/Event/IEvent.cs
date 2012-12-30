namespace RConDevServer.Protocol.Dice.Battlefield3.Event
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface describes an event which can be send to a connected client
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Returns the event name
        /// </summary>
        string Event { get; }

        /// <summary>
        /// Creates a words representation for sending a packet to the client
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ToWords();
    }
}
