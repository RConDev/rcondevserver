namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Server
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class ServerOnLevelLoadedEvent : IEvent
    {
        public ServerOnLevelLoadedEvent(Map map, GameMode gameMode, int roundsPlayed, int totalRounds)
        {
            this.Map = map;
            this.GameMode = gameMode;
            this.RoundsPlayed = roundsPlayed;
            this.TotalRounds = totalRounds;
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
                    this.Event,
                    this.Map.ToWord(),
                    this.GameMode.ToWord(),
                    Convert.ToString(this.RoundsPlayed),
                    Convert.ToString(this.TotalRounds)
                };
        }
    }
}