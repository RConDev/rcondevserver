namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using RConDevServer.Protocol.Dice.Battlefield3.EventSender;

    public class EventSenderEventArgs : EventArgs
    {
        public ICanSendEvents EventSender { get; private set; }

        public EventSenderEventArgs(ICanSendEvents eventSender)
        {
            this.EventSender = eventSender;
        }
    }
}
