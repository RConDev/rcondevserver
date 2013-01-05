using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnRoundOverEvent : IEvent
    {
        public int WinningTeam { get; set; }

        public ServerOnRoundOverEvent(int winningTeam)
        {
            WinningTeam = winningTeam;
        }

        public string Event { get { return Constants.EVENT_SERVER_ON_ROUND_OVER; } }

        public IEnumerable<string> ToWords()
        {
            return new[] {Event, Convert.ToString(WinningTeam)};
        }
    }
}
