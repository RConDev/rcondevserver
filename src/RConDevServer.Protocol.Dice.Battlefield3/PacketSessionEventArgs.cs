namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;

    public class PacketSessionEventArgs : EventArgs
    {
        public PacketSession PacketSession { get; private set; }

        public PacketSessionEventArgs(PacketSession session)
        {
            this.PacketSession = session;
        }
    }
}