namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListGetMapIndicesCommand" />
    /// </summary>
    public class MapListGetMapIndicesCommandFactory : CommandFactoryBase<MapListGetMapIndicesCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListGetMapIndicesCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.MapListGetMapIndices, "commandName");
            return new MapListGetMapIndicesCommand();
        }
    }
}