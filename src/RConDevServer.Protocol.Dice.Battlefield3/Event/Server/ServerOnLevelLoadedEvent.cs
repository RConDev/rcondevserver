using System;
using System.Collections.Generic;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    public class ServerOnLevelLoadedEvent : IEvent
    {
        public ServerOnLevelLoadedEvent(Map map, GameMode gameMode, int roundsPlayed, int totalRounds)
        {
            Map = map;
            GameMode = gameMode;
            RoundsPlayed = roundsPlayed;
            TotalRounds = totalRounds;
        }

        public Map Map { get; private set; }

        public GameMode GameMode { get; private set; }

        public int RoundsPlayed { get; private set; }

        public int TotalRounds { get; private set; }

        public string Event
        {
            get { return Constants.EVENT_SERVER_ON_LEVEL_LOADED; }
        }

        public IEnumerable<string> ToWords()
        {
            return new List<string>
                {
                    Event,
                    Map.ToWord(),
                    GameMode.ToWord(),
                    Convert.ToString(RoundsPlayed),
                    Convert.ToString(TotalRounds)
                };
        }
    }
}