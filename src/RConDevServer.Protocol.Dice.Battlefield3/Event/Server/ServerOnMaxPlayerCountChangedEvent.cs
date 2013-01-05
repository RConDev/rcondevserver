using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnMaxPlayerCountChangedEvent : IEvent
    {
        public ServerOnMaxPlayerCountChangedEvent(int maxPlayerCount)
        {
            MaxPlayerCount = maxPlayerCount;
        }

        public int MaxPlayerCount { get; set; }

        public string Event
        {
            get { return Constants.EVENT_SERVER_ON_MAX_PLAYER_COUNT_CHANGE; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {Event, Convert.ToString(MaxPlayerCount)};
        }
    }
}