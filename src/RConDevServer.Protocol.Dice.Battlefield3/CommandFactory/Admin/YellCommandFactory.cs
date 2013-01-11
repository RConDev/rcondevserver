namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Data;
    using Util;

    /// <summary>
    ///     implementation for <see cref="YellCommand" />
    /// </summary>
    public class YellCommandFactory : CommandFactoryBase<YellCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override YellCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.NotNullOrEmpty(words[1], "message");
            int? duration = null;
            PlayerSubset playerSubset = null;
            if (words.Length >= 3)
                duration = Int.SafeParse(words[2]);
            if (words.Length >= 4)
                playerSubset = PlayerSubset.FromWords(words.Skip(3));
            return new YellCommand(words[1], duration, playerSubset);
        }
    }
}