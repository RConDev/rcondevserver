namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using Command;
    using Common;

    public class ClientCommandEventArgs : PacketDataEventArgs
    {
        public ClientCommandEventArgs(Packet packet, ICommand command = null) : base(packet)
        {
            this.Command = command;
        }

        public ICommand Command { get; private set; }
    }
}