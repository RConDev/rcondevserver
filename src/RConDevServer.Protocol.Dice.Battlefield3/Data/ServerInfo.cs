namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;

    public class ServerInfo
    {
        private readonly Battlefield3Server server;

        public ServerInfo(Battlefield3Server battlefield3Server)
        {
            this.server = battlefield3Server;
        }

        public string ServerName { get; set; }

        public decimal CurrentPlayerCount
        {
            get { return this.server.PlayerList.Players.Count; }
        }

        public decimal MaxPlayerCount { get; set; }

        public GameMode CurrentGameMode
        {
            get { return this.server.CurrentMapListItem.Mode; }
        }

        public Map CurrentMap
        {
            get { return this.server.CurrentMapListItem.Map; }
        }

        public decimal RoundsPlayed { get; set; }

        public decimal RoundsTotal
        {
            get { return this.server.CurrentMapListItem.Rounds; }
        }

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
            words.Add(this.CurrentPlayerCount.ToString());
            words.Add(this.MaxPlayerCount.ToString());
            words.Add(this.CurrentGameMode.ToWord());
            words.Add(this.CurrentMap.ToWord());
            words.Add(this.RoundsPlayed.ToString());
            words.Add(this.RoundsTotal.ToString());
            words.AddRange(this.server.TeamScores.ToWords());
            words.Add(this.OnlineState);
            words.Add(this.IsRanked.ToString());
            words.Add(this.IsPunkbuster.ToString());
            words.Add(this.HasGamePassword.ToString());
            words.Add(Convert.ToInt32(this.ServerUpTime).ToString());
            words.Add(Convert.ToInt32(this.RoundTime).ToString());
            words.Add(this.IpPortPair.ToWord());
            words.Add(this.PunkbusterVersion);
            words.Add(this.IsJoinQueueEnabled.ToString());
            words.Add(this.Region);
            words.Add(this.ClosestPingSite);
            words.Add(this.Country.CodeAlpha2);
            return words;
        }
    }
}