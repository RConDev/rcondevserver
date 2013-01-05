using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnSquadChangeEvent : IEvent
    {
        public PlayerOnSquadChangeEvent(string soldierName, int teamId, int squadId)
        {
            SoldierName = soldierName;
            TeamId = teamId;
            SquadId = squadId;
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
            return new[] {Event, SoldierName, Convert.ToString(TeamId), Convert.ToString(TeamId)};
        }
    }
}