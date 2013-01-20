namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.ReservedSlotsList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.ReservedSlotsList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="ReservedSlotsListListCommand" />
    /// </summary>
    public class ListCommandFactory : CommandFactoryBase<ReservedSlotsListListCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ReservedSlotsListListCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.ReservedSlotsListList, "commandName");
            
            int? offset = null;
            if (words.Length > 1) 
                offset = Int.SafeParse(words[1]);

            return new ReservedSlotsListListCommand(offset);
        }
    }
}