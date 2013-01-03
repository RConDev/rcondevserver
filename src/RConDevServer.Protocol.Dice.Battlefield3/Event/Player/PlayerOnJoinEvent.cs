using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnJoinEvent : IEvent
    {
        public string SoldierName { get; private set; }
        public string Guid { get; set; }

        public PlayerOnJoinEvent(string soldierName, string guid)
        {
            SoldierName = soldierName;
            Guid = guid;
        }

        public string Event { get { return Constants.EVENT_PLAYER_ON_JOIN; } }
        
        public IEnumerable<string> ToWords()
        {
            return new List<string> {Event, SoldierName, Guid};
        }
    }
}
