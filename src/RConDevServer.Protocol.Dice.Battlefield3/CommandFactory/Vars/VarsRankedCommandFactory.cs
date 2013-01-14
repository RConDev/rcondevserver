﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Vars;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VarsRankedCommand" />
    /// </summary>
    public class VarsRankedCommandFactory : CommandFactoryBase<VarsRankedCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsRankedCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.VarsRanked, "commandName");
            bool? isRanked = (words.Length == 1) ? null : Bool.SafeParse(words[1]);
            return new VarsRankedCommand(isRanked);
        }
    }
}
