﻿using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    public class PlayerOnTeamChangeEvent : IEvent
    {
        public PlayerOnTeamChangeEvent(string soldierName, int teamId, int squadId)
        {
            SoldierName = soldierName;
            TeamId = teamId;
            SquadId = squadId;
        }

        public string SoldierName { get; set; }

        public int TeamId { get; set; }

        public int SquadId { get; set; }

        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_TEAM_CHANGE; }
        }

        public IEnumerable<string> ToWords()
        {
            return new[]
                {
                    Event,
                    SoldierName,
                    Convert.ToString(TeamId),
                    Convert.ToString(SquadId)
                };
        }
    }
}