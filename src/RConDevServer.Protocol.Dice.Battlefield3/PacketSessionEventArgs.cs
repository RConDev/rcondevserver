namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;

    public class PacketSessionEventArgs : EventArgs
    {
        public PacketSessionEventArgs(PacketSession session)
        {
            this.PacketSession = session;
        }

        public PacketSession PacketSession { get; private set; }
    }
}