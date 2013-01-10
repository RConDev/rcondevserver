using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Linq;

    public class PlayerSubset
    {
        public PlayerSubsetType Type { get; set; }

        public string PlayerName { get; set; }

        public int TeamId { get; set; }

        public int SquadId { get; set; }

        #region Public Methods

        public IList<string> ToWords()
        {
            var words = new List<string>();
            switch (Type)
            {
                case PlayerSubsetType.All:
                    words.Add("all");
                    break;

                case PlayerSubsetType.Team:
                    words.Add("team");
                    words.Add(Convert.ToString(TeamId));
                    break;

                case PlayerSubsetType.Squad:
                    words.Add("squad");
                    words.Add(Convert.ToString(TeamId));
                    words.Add(Convert.ToString(SquadId));
                    break;

                case PlayerSubsetType.Player:
                    words.Add("player");
                    words.Add(PlayerName);
                    break;
            }
            return words;
        }

        #endregion

        #region Public Static Methods

        public static PlayerSubset FromWords(IEnumerable<string> subsetWords)
        {
            var words = subsetWords.ToList();
            var playerSubset = new PlayerSubset();
            if (words.Count == 1 && words[0] == "all")
            {
                playerSubset.Type = PlayerSubsetType.All;
            }

            if (words.Count == 2)
            {
                if (words[0] == "player")
                {
                    playerSubset.Type = PlayerSubsetType.Player;
                    playerSubset.PlayerName = words[1];
                }

                if (words[0] == "team")
                {
                    playerSubset.Type = PlayerSubsetType.Team;
                    playerSubset.TeamId = Convert.ToInt32(words[1]);
                }
            }

            if (words.Count == 3 && words[0] == "squad")
            {
                playerSubset.Type = PlayerSubsetType.Squad;
                playerSubset.TeamId = Convert.ToInt32(words[1]);
                playerSubset.SquadId = Convert.ToInt32(words[2]);
            }

            return playerSubset;
        }

        #endregion
    }
}