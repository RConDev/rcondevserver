namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;

    public class PacketBuilderErrorEventArgs : EventArgs
    {
        public PacketBuilderErrorEventArgs(Exception exception)
        {
            this.ExceptionInfo = exception;
        }

        public Exception ExceptionInfo { get; private set; }
    }
}