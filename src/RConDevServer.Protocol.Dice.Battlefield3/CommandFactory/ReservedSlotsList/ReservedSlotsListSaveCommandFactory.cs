namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.ReservedSlotsList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.ReservedSlotsList;
    using Util;

    /// <summary>
    ///     Implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="ReservedSlotsListSaveCommand" />
    /// </summary>
    public class ReservedSlotsListSaveCommandFactory : CommandFactoryBase<ReservedSlotsListSaveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ReservedSlotsListSaveCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.ReservedSlotsListSave, "commandName");
            return new ReservedSlotsListSaveCommand();
        }
    }
}