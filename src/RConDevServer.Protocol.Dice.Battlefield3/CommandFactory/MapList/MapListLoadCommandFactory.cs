namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListLoadCommand" />
    /// </summary>
    public class MapListLoadCommandFactory : CommandFactoryBase<MapListLoadCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListLoadCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.MapListLoad, "commandName");
            return new MapListLoadCommand();
        }
    }
}