namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using Command;
    using Common;

    public class ClientCommandEventArgs : PacketDataEventArgs
    {
        /// <summary>
        /// creates a new <see cref="ClientCommandEventArgs"/> instance
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="command"></param>
        /// <param name="isFaulted"></param>
        public ClientCommandEventArgs(Packet packet, ICommand command = null, bool isFaulted = false) : base(packet)
        {
            this.Command = command;
            IsFaulted = isFaulted;
        }

        /// <summary>
        /// gets the <see cref="ICommand"/> instance for further processing
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// Shows, if the generation of the <see cref="ICommand"/> instance was successfull.
        /// if not, an <see cref="InvalidArgumentResponse"/> will be sent to the client
        /// </summary>
        public bool IsFaulted { get; set; }
    }
}