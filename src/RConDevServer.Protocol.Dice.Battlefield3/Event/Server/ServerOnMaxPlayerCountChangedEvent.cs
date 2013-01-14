namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    using System;
    using System.Collections.Generic;

    public class ServerOnMaxPlayerCountChangedEvent : IEvent
    {
        public ServerOnMaxPlayerCountChangedEvent(int maxPlayerCount)
        {
            this.MaxPlayerCount = maxPlayerCount;
        }

        public int MaxPlayerCount { get; set; }

        public string Event
        {
            get { return Constants.EVENT_SERVER_ON_MAX_PLAYER_COUNT_CHANGE; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {this.Event, Convert.ToString(this.MaxPlayerCount)};
        }
    }
}