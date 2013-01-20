namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListRemoveCommand" />
    /// </summary>
    public class MapListRemoveCommandFactory : CommandFactoryBase<MapListRemoveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListRemoveCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 2, "words");
            Requires.Equal(words[0], CommandNames.MapListRemove, "commandName");

            int? index = Int.SafeParse(words[1]);
            Requires.NotNull(index, "index");

            return new MapListRemoveCommand(index.Value);
        }
    }
}