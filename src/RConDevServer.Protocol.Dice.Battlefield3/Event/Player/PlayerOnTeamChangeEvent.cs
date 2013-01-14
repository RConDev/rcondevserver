namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System;
    using System.Collections.Generic;

    public class PlayerOnTeamChangeEvent : IEvent
    {
        public PlayerOnTeamChangeEvent(string soldierName, int teamId, int squadId)
        {
            this.SoldierName = soldierName;
            this.TeamId = teamId;
            this.SquadId = squadId;
        }

        public string SoldierName { get; set; }

        public int TeamId { get; set; }

        public int SquadId { get; set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_TEAM_CHANGE; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[]
                {
                    this.Event,
                    this.SoldierName,
                    Convert.ToString(this.TeamId),
                    Convert.ToString(this.SquadId)
                };
        }
    }
}