﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.ReservedSlotsList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.ReservedSlotsList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="ReservedSlotsListRemoveCommand" />
    /// </summary>
    public class ReservedSlotsListRemoveCommandFactory : CommandFactoryBase<ReservedSlotsListRemoveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override ReservedSlotsListRemoveCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.ReservedSlotsListAdd, "commandName");

            string id = words[1];
            Requires.NotNullOrEmpty(id, "id");

            return new ReservedSlotsListRemoveCommand(id);
        }
    }
}