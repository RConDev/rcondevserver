namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     Return list of all players on the server; including guids
    /// </summary>
    public class ListPlayersCommand : ICommand
    {
        /// <summary>
        ///     create a new instance of <see cref="ListPlayersCommand" />
        /// </summary>
        /// <param name="playerSubset"></param>
        public ListPlayersCommand(PlayerSubset playerSubset)
        {
            this.PlayerSubset = playerSubset;
        }

        /// <summary>
        ///     the players selection to be listed
        /// </summary>
        public PlayerSubset PlayerSubset { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminListPlayers; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            words.AddRange(this.PlayerSubset.ToWords());
            return words;
        }
    }
}