namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System.Collections.Generic;
    using Data;

    public class PlayerOnLeaveEvent : IEvent
    {
        public PlayerOnLeaveEvent(string soldierName, PlayerInfo playerInfo)
        {
            this.SoldierName = soldierName;
            this.PlayerInfo = playerInfo;
        }

        public string SoldierName { get; set; }

        public PlayerInfo PlayerInfo { get; set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_LEAVE; }
        }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Event, this.SoldierName};
            words.AddRange(this.PlayerInfo.ToWords());
            return words;
        }
    }
}