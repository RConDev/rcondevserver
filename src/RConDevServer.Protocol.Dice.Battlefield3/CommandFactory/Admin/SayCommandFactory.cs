﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Data;

    public class SayCommandFactory : CommandFactoryBase<SayCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override SayCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            var subsetWords = PlayerSubset.FromWords(words.Skip(2));
            return new SayCommand(words[1], subsetWords);
        }
    }
}