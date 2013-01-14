namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System;
    using System.Collections.Generic;

    public class PlayerOnKillEvent : IEvent
    {
        public PlayerOnKillEvent(string soldierName, string killedSoldier, string weapon, bool isHeadshot)
        {
            this.SoldierName = soldierName;
            this.KilledSoldier = killedSoldier;
            this.Weapon = weapon;
            this.IsHeadshot = isHeadshot;
        }

        public string SoldierName { get; private set; }

        public string KilledSoldier { get; private set; }

        public string Weapon { get; private set; }

        public bool IsHeadshot { get; private set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_KILL; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[]
                {this.Event, this.SoldierName, this.KilledSoldier, this.Weapon, Convert.ToString(this.IsHeadshot)};
        }
    }
}