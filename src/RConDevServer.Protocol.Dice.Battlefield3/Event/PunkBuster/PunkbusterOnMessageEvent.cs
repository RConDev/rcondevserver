using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.PunkBuster
{
    public class PunkBusterOnMessageEvent : IEvent
    {
        public string Message { get; private set; }

        public PunkBusterOnMessageEvent(string message)
        {
            Message = message;
        }

        public string Event { get { return EventNames.PunkBusterOnMessage; } }

        public IEnumerable<string> ToWords()
        {
            return new[] {Event, Message};
        }
    }
}
