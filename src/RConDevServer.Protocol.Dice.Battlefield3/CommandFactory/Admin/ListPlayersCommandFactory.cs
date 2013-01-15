namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Data;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="ListPlayersCommand" />
    /// </summary>
    public class ListPlayersCommandFactory : CommandFactoryBase<ListPlayersCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ListPlayersCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 2, "commandWords");
            Requires.Equal(words[0], CommandNames.AdminListPlayers, "commandName");
            PlayerSubset playerSubset = PlayerSubset.FromWords(words.Skip(1));
            return new ListPlayersCommand(playerSubset);
        }
    }
}