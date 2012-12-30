namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;

    public class PacketDataEventArgs : EventArgs
    {
        public PacketDataEventArgs(Packet packet)
        {
            this.PacketData = packet;
        }

        public Packet PacketData { get; private set; }
    }
}