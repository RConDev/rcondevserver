﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    ///     Implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="AdminKillPlayerCommand" />
    /// </summary>
    public class AdminKillPlayerCommandFactory : CommandFactoryBase<AdminKillPlayerCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminKillPlayerCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 2, "words");
            Requires.Equal(words[0], CommandNames.AdminKillPlayer, "commandName");
            string soldierName = words[1];
            Requires.NotNullOrEmpty(soldierName, "soldierName");
            return new AdminKillPlayerCommand(soldierName);
        }
    }
}