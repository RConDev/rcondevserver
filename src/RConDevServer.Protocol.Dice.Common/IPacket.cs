namespace RConDevServer.Protocol.Dice.Common
{
    using System.Collections.Generic;

    public interface IPacket
    {
        /// <summary>
        /// the unique sequence id in the client-server-session
        /// </summary>
        uint? SequenceId { get; set; }

        /// <summary>
        /// shows on which side the packet was created
        /// </summary>
        PacketOrigin Origin { get; set; }

        /// <summary>
        /// shows if this packet is a response to another packet
        /// </summary>
        bool IsResponse { get; set; }

        /// <summary>
        /// shows the complete size in bytes of this packet
        /// </summary>
        uint PacketSize { get; set; }

        /// <summary>
        /// gets the count of words within this packet
        /// </summary>
        uint WordCount { get; }

        /// <summary>
        /// shows the words within the packet
        /// </summary>
        IList<string> Words { get; }
    }
}