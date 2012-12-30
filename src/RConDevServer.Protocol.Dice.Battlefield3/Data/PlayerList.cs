using System;
using System.Collections.Generic;
using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    /// <summary>
    /// this class encapsulates the current list of player on the server
    /// </summary>
    public class PlayerList
    {
        private readonly object syncRoot = new object();

        private readonly IList<Player> players = new List<Player>();

        /// <summary>
        /// Creates a new instance of the <see cref="PlayerList"/>
        /// </summary>
        public PlayerList()
        {
        }

        #region Public Properties

        /// <summary>
        /// Gets the current set of players on the server
        /// </summary>
        public IList<Player> Players
        {
            get
            {
                lock (syncRoot)
                {
                    return players.ToList();
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// adds a player to the collection
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            lock (syncRoot)
            {
                players.Add(player);
            }
        }

        /// <summary>
        /// Removes a player from the collection
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayer(Player player)
        {
            lock (syncRoot)
            {
                if (players.Contains(player))
                    players.Remove(player);
            }
        }

        /// <summary>
        /// converts the current player collection to the players list words 
        /// which can be send over the wire to the clients
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
            lock (syncRoot)
            {
                playersWords.Add(Convert.ToString(players.Count));
                foreach (var player in players)
                {
                    playersWords.AddRange(player.ToWords(showGuid));
                }
            }
            return playersWords;
        }

        #endregion

        public void Clear ()
        {
            this.players.Clear();
        }
    }
}