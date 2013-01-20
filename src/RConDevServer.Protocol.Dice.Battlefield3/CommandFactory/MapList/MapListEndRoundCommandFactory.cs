namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListEndRoundCommand" />
    /// </summary>
    public class MapListEndRoundCommandFactory : CommandFactoryBase<MapListEndRoundCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListEndRoundCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.SequenceLength(words, 2, "words");
            Requires.Equal(words[0], CommandNames.MapListEndRound, "commandName");

            var winnerTeamId = Int.SafeParse(words[1]);
            Requires.NotNull(winnerTeamId, "winnerId");

            return new MapListEndRoundCommand(winnerTeamId.Value);
        }
    }
}