namespace RConDevServer.Protocol.Dice.Battlefield3
{
    /// <summary>
    /// This class manages the <see cref="Packet.SequenceId"/> within a PacketSession to a client.
    /// </summary>
    public class PacketSequence
    {
        /// <summary>
        /// Gets or sets the current <see cref="Packet.SequenceId"/> for the communication to the client
        /// </summary>
        public int CurrentSequenceId { get; set; }

        /// <summary>
        /// Gets the next <see cref="Packet.SequenceId"/> for sending server originated events to the client
        /// </summary>
        public int NextSequenceId { get { return ++this.CurrentSequenceId; } }
    }
}
