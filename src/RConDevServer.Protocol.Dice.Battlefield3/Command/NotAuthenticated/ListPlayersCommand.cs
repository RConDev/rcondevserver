namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     Return list of all players on the server, but with zeroed out GUIDs
    /// </summary>
    public class ListPlayersCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="ListPlayersCommand" /> instance
        /// </summary>
        /// <param name="playerSubset"></param>
        public ListPlayersCommand(PlayerSubset playerSubset)
        {
            this.PlayerSubset = playerSubset;
        }

        /// <summary>
        ///     the subset of players to be delievered
        /// </summary>
        public PlayerSubset PlayerSubset { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ListPlayers; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            words.AddRange(this.PlayerSubset.ToWords());
            return words.ToArray();
        }
    }
}