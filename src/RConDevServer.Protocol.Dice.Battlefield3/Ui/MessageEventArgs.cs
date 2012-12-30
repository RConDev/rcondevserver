namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;

    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            this.Message = message;
        }

        protected string Message { get; private set; }
    }
}