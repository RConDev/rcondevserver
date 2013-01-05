using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnLeaveEvent : IEvent
    {
        public string SoldierName { get; set; }
        
        public PlayerInfo PlayerInfo { get; set; }

        public PlayerOnLeaveEvent(string soldierName, PlayerInfo playerInfo)
        {
            SoldierName = soldierName;
            PlayerInfo = playerInfo;
        }

        public string Event { get { return Constants.EVENT_PLAYER_ON_LEAVE; } }
        
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {Event, SoldierName};
            words.AddRange(PlayerInfo.ToWords());
            return words;
        }
    }
}
