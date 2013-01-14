namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using EventSender;

    public class EventSenderEventArgs : EventArgs
    {
        public EventSenderEventArgs(ICanSendEvents eventSender)
        {
            this.EventSender = eventSender;
        }

        public ICanSendEvents EventSender { get; private set; }
    }
}