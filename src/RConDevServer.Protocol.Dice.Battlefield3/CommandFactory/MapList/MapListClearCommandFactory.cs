namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListClearCommand" />
    /// </summary>
    public class MapListClearCommandFactory : CommandFactoryBase<MapListClearCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListClearCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.MapListClear, "commandName");
            return new MapListClearCommand();
        }
    }
}