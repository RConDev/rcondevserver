namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    using System;
    using System.Collections.Generic;

    public class ServerOnRoundOverEvent : IEvent
    {
        public ServerOnRoundOverEvent(int winningTeam)
        {
            this.WinningTeam = winningTeam;
        }

        public int WinningTeam { get; set; }

        public string Event
        {
            get { return Constants.EVENT_SERVER_ON_ROUND_OVER; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {this.Event, Convert.ToString(this.WinningTeam)};
        }
    }
}