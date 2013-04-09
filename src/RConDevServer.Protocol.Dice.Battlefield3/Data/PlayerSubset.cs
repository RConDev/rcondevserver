namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// selection of players / groups to be addressed in messagíng
    /// </summary>
    public class PlayerSubset
    {
        public PlayerSubset(PlayerSubsetType type, 
            string playerName = null, 
            int? teamId = null, 
            int? squadId = null)
        {
            this.Type = type;
            this.PlayerName = playerName;
            this.TeamId = teamId;
            this.SquadId = squadId;
        }

        /// <summary>
        /// the type the selection is of
        /// </summary>
        public PlayerSubsetType Type { get; private set; }

        public string PlayerName { get; private set; }

        public int? TeamId { get; private set; }

        public int? SquadId { get; private set; }

        #region Public Methods

        public IList<string> ToWords()
        {
            var words = new List<string>();
            switch (this.Type)
            {
                case PlayerSubsetType.All:
                    words.Add("all");
                    break;

                case PlayerSubsetType.Team:
                    words.Add("team");
                    words.Add(Convert.ToString(this.TeamId));
                    break;

                case PlayerSubsetType.Squad:
                    words.Add("squad");
                    words.Add(Convert.ToString(this.TeamId));
                    words.Add(Convert.ToString(this.SquadId));
                    break;

                case PlayerSubsetType.Player:
                    words.Add("player");
                    words.Add(this.PlayerName);
                    break;
            }
            return words;
        }

        #endregion

        #region Public Static Methods

        public static PlayerSubset FromWords(IEnumerable<string> subsetWords)
        {
            var words = subsetWords.ToList();
            PlayerSubset playerSubset = null;
            if (words.Count == 1 && words[0] == "all")
            {
                playerSubset = new PlayerSubset(PlayerSubsetType.All);

            }

            if (words.Count == 2)
            {
                if (words[0] == "player")
                {
                    playerSubset= new PlayerSubset( PlayerSubsetType.Player);
                    playerSubset.PlayerName = words[1];
                }

                if (words[0] == "team")
                {
                    playerSubset=new PlayerSubset( PlayerSubsetType.Team);
                    playerSubset.TeamId = Convert.ToInt32(words[1]);
                }
            }

            if (words.Count == 3 && words[0] == "squad")
            {
                playerSubset = new PlayerSubset(PlayerSubsetType.Squad);
                playerSubset.TeamId = Convert.ToInt32(words[1]);
                playerSubset.SquadId = Convert.ToInt32(words[2]);
            }

            return  playerSubset;
        }

        #endregion
    }
}