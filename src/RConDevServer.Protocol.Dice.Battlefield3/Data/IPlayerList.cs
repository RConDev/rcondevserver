namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface describes a player list currently active on the server
    /// </summary>
    public interface IPlayerList
    {
        /// <summary>
        ///     Gets the current set of players on the server
        /// </summary>
        IList<PlayerInfo> Players { get; }

        /// <summary>
        ///     adds a PlayerInfo to the collection
        /// </summary>
        /// <param name="playerInfo"></param>
        void AddPlayer(PlayerInfo playerInfo);

        /// <summary>
        ///     Removes a PlayerInfo from the collection
        /// </summary>
        /// <param name="playerInfo"></param>
        void RemovePlayer(PlayerInfo playerInfo);

        /// <summary>
        ///     converts the current PlayerInfo collection to the players list words
        ///     which can be send over the wire to the clients
        /// </summary>
        /// <returns></returns>
        IList<string> ToWords(bool showGuid = true);

        void Clear();
    }
}