namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    public class HelpCommandFactory : CommandFactoryBase<HelpCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override HelpCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.Equal(words.Length, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.AdminHelp, "commandName");
            return new HelpCommand();
        }
    }
}