using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerOnAuthenticatedEvent : IEvent
    {
        public string SoldierName { get; private set; }

        public PlayerOnAuthenticatedEvent(string soldierName)
        {
            SoldierName = soldierName;
        }

        public string Event { get { return Constants.EVENT_PLAYER_ON_AUTHENTICATED; } }
        
        public IEnumerable<string> ToWords()
        {
            return new List<string> {Event, SoldierName};
        }
    }
}
