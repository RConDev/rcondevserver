namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListSetNextMapIndexCommand" />
    /// </summary>
    public class MapListSetNextMapIndexCommandFactory : CommandFactoryBase<MapListSetNextMapIndexCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListSetNextMapIndexCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 2, "words");
            Requires.Equal(words[0], CommandNames.MapListSetNextMapIndex, "commandName");

            int? index = Int.SafeParse(words[1]);
            Requires.NotNull(index, "index");

            return new MapListSetNextMapIndexCommand(index.Value);
        }
    }
}