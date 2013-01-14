namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class PlayerOnAuthenticatedEvent : IEvent
    {
        public PlayerOnAuthenticatedEvent(string soldierName)
        {
            this.SoldierName = soldierName;
        }

        public string SoldierName { get; private set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_AUTHENTICATED; }
        }

        public IEnumerable<string> ToWords()
        {
            return new List<string> {this.Event, this.SoldierName};
        }
    }
}