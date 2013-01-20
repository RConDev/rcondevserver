namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.ReservedSlotsList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.ReservedSlotsList;
    using Util;

    public class LoadCommandFactory : CommandFactoryBase<ReservedSlotsListLoadCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ReservedSlotsListLoadCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.ReservedSlotsListLoad, "commandName");
            return new ReservedSlotsListLoadCommand();
        }
    }
}