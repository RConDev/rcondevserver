namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListAddCommand" />
    /// </summary>
    public class MapListAddCommandFactory : CommandFactoryBase<MapListAddCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListAddCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 4, "words");
            Requires.Equal(words[0], CommandNames.MapListAdd, "commandName");

            string mapCode = words[1];
            Requires.NotNullOrEmpty(mapCode, "map");

            string gameMode = words[2];
            Requires.NotNullOrEmpty(gameMode, "gameMode");

            int? rounds = Int.SafeParse(words[3]);
            Requires.NotNull(rounds, "rounds");

            int? index = null;
            if (words.Length > 4)
            {
                index = Int.SafeParse(words[5]);
            }

            return new MapListAddCommand(mapCode, gameMode, rounds.Value, index);
        }
    }
}