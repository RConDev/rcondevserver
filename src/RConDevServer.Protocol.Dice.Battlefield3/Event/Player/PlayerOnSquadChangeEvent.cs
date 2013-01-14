namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System;
    using System.Collections.Generic;

    public class PlayerOnSquadChangeEvent : IEvent
    {
        public PlayerOnSquadChangeEvent(string soldierName, int teamId, int squadId)
        {
            this.SoldierName = soldierName;
            this.TeamId = teamId;
            this.SquadId = squadId;
        }

        public string SoldierName { get; private set; }

        public int TeamId { get; private set; }

        public int SquadId { get; private set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_SQUAD_CHANGE; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[] {this.Event, this.SoldierName, Convert.ToString(this.TeamId), Convert.ToString(this.TeamId)};
        }
    }
}