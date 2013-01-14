namespace RConDevServer.Protocol.Dice.Battlefield3.Event.PunkBuster
{
    using System.Collections.Generic;

    public class PunkBusterOnMessageEvent : IEvent
    {
        public PunkBusterOnMessageEvent(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }

        public string Event
        {
            get { return EventNames.PunkBusterOnMessage; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {this.Event, this.Message};
        }
    }
}