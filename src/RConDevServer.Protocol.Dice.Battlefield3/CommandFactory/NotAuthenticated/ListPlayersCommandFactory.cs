namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.NotAuthenticated;
    using Data;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="ListPlayersCommand" />
    /// </summary>
    public class ListPlayersCommandFactory : CommandFactoryBase<ListPlayersCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ListPlayersCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 2, "wordCount");
            Requires.Equal(words[0], CommandNames.ListPlayers, "commandName");
            PlayerSubset playerSubset = PlayerSubset.FromWords(words.Skip(1));
            return new ListPlayersCommand(playerSubset);
        }
    }
}