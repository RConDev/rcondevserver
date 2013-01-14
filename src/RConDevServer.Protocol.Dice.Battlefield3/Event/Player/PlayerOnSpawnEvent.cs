namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System;
    using System.Collections.Generic;

    public class PlayerOnSpawnEvent : IEvent
    {
        public PlayerOnSpawnEvent(string soldierName, int teamId)
        {
            this.SoldierName = soldierName;
            this.TeamId = teamId;
        }

        public string SoldierName { get; private set; }

        public int TeamId { get; private set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_SPAWN; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {this.Event, this.SoldierName, Convert.ToString(this.TeamId)};
        }
    }
}