using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.ReservedSlotsList
{
    using Command;
    using Command.ReservedSlotsList;
    using Util;

    /// <summary>
    /// implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="ReservedSlotsListAggressiveJoinCommand"/>
    /// </summary>
    public class AggressiveJoinCommandFactory : CommandFactoryBase<ReservedSlotsListAggressiveJoinCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ReservedSlotsListAggressiveJoinCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.ReservedSlotsListAggressiveJoin, "commandName");

            bool? enabled = null;
            if (words.Length > 1)
                enabled = Bool.SafeParse(words[1]);

            return new ReservedSlotsListAggressiveJoinCommand(enabled);
        }
    }
}
