namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     this class encapsulates the current list of PlayerInfo on the server
    /// </summary>
    public class PlayerList
    {
        private readonly IList<PlayerInfo> players = new List<PlayerInfo>();
        private readonly object syncRoot = new object();

        /// <summary>
        ///     Creates a new instance of the <see cref="PlayerList" />
        /// </summary>
        public PlayerList()
        {
        }

        public PlayerList(IEnumerable<PlayerInfo> initialPlayers)
        {
            foreach (PlayerInfo initialPlayer in initialPlayers)
            {
                this.AddPlayer(initialPlayer);
            }
        }

        #region Public Properties

        /// <summary>
        ///     Gets the current set of players on the server
        /// </summary>
        public IList<PlayerInfo> Players
        {
            get
            {
                lock (this.syncRoot)
                {
                    return this.players.ToList();
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     adds a PlayerInfo to the collection
        /// </summary>
        /// <param name="playerInfo"></param>
        public void AddPlayer(PlayerInfo playerInfo)
        {
            lock (this.syncRoot)
            {
                this.players.Add(playerInfo);
            }
        }

        /// <summary>
        ///     Removes a PlayerInfo from the collection
        /// </summary>
        /// <param name="playerInfo"></param>
        public void RemovePlayer(PlayerInfo playerInfo)
        {
            lock (this.syncRoot)
            {
                if (this.players.Contains(playerInfo))
                {
                    this.players.Remove(playerInfo);
                }
            }
        }

        /// <summary>
        ///     converts the current PlayerInfo collection to the players list words
        ///     which can be send over the wire to the clients
        /// </summary>
        /// <returns></returns>
        public IList<string> ToWords(bool showGuid = true)
        {
            var playersWords = new List<string>
                {
                    "7",
                    "name",
                    "guid",
                    "teamId",
                    "squadId",
                    "kills",
                    "deaths",
                    "score",
                };
            lock (this.syncRoot)
            {
                playersWords.Add(Convert.ToString(this.players.Count));
                foreach (PlayerInfo player in this.players)
                {
                    playersWords.AddRange(player.ToWords(showGuid));
                }
            }
            return playersWords;
        }

        #endregion

        public void Clear()
        {
            this.players.Clear();
        }
    }
}