using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class ServerInfo
    {
        private readonly Battlefield3Server server;

        public ServerInfo(Battlefield3Server battlefield3Server)
        {
            this.server = battlefield3Server;
        }

        public string ServerName { get; set; }

        public decimal CurrentPlayerCount { get { return this.server.PlayerList.Players.Count; } }

        public decimal MaxPlayerCount { get; set; }

        public GameMode CurrentGameMode { get { return this.server.CurrentMapListItem.Mode; } }

        public Map CurrentMap { get { return this.server.CurrentMapListItem.Map; } }

        public decimal RoundsPlayed { get; set; }

        public decimal RoundsTotal { get { return this.server.CurrentMapListItem.Rounds; } }

        public string OnlineState { get; set; }

        public bool IsRanked { get; set; }

        public bool IsPunkbuster { get; set; }

        public bool HasGamePassword { get; set; }

        public decimal ServerUpTime { get; set; }

        public decimal RoundTime { get; set; }

        public IpPortPair IpPortPair { get; set; }

        public string PunkbusterVersion { get; set; }

        public bool IsJoinQueueEnabled { get; set; }

        public string Region { get; set; }

        public string ClosestPingSite { get; set; }

        public Country Country { get; set; }

        public IList<string> ToWords()
        {
            var words = new List<string>();
            words.Add(this.ServerName);
            words.Add(CurrentPlayerCount.ToString());
            words.Add(MaxPlayerCount.ToString());
            words.Add(CurrentGameMode.ToWord());
            words.Add(CurrentMap.ToWord());
            words.Add(RoundsPlayed.ToString());
            words.Add(RoundsTotal.ToString());
            words.AddRange(server.TeamScores.ToWords());
            words.Add(OnlineState);
            words.Add(IsRanked.ToString());
            words.Add(IsPunkbuster.ToString());
            words.Add(HasGamePassword.ToString());
            words.Add(Convert.ToInt32(ServerUpTime).ToString());
            words.Add(Convert.ToInt32(RoundTime).ToString());
            words.Add(IpPortPair.ToWord());
            words.Add(PunkbusterVersion);
            words.Add(IsJoinQueueEnabled.ToString());
            words.Add(Region);
            words.Add(ClosestPingSite);
            words.Add(Country.CodeAlpha2);
            return words;
        }
    }
}