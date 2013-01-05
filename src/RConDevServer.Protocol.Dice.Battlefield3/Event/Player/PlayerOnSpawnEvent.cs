using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnSpawnEvent : IEvent
    {
        public string SoldierName { get; private set; }

        public int TeamId { get; private set; }

        public PlayerOnSpawnEvent(string soldierName, int teamId)
        {
            SoldierName = soldierName;
            TeamId = teamId;
        }

        public string Event { get { return Constants.EVENT_PLAYER_ON_SPAWN; } }

        public IEnumerable<string> ToWords()
        {
            return new[] {Event, SoldierName, Convert.ToString(TeamId)};
        }
    }
}
