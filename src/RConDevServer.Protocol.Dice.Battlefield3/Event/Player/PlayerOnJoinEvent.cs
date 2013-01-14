namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System.Collections.Generic;

    public class PlayerOnJoinEvent : IEvent
    {
        public PlayerOnJoinEvent(string soldierName, string guid)
        {
            this.SoldierName = soldierName;
            this.Guid = guid;
        }

        public string SoldierName { get; private set; }
        public string Guid { get; set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_JOIN; }
        }

        public IEnumerable<string> ToWords()
        {
            return new List<string> {this.Event, this.SoldierName, this.Guid};
        }
    }
}