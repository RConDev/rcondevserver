using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnKillEvent : IEvent
    {
        public PlayerOnKillEvent(string soldierName, string killedSoldier, string weapon, bool isHeadshot)
        {
            SoldierName = soldierName;
            KilledSoldier = killedSoldier;
            Weapon = weapon;
            IsHeadshot = isHeadshot;
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
            return new[] {Event, SoldierName, KilledSoldier, Weapon, Convert.ToString(IsHeadshot)};
        }
    }
}