﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.BanList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.BanList;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="BanListClearCommand" />
    /// </summary>
    public class BanListClearCommandFactory : CommandFactoryBase<BanListClearCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override BanListClearCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.BanListClear, "commandName");
            return new BanListClearCommand();
        }
    }
}