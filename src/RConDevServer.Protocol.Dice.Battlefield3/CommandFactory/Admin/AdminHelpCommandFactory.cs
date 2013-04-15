namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    /// Implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="AdminHelpCommand"/>
    /// </summary>
    public class AdminHelpCommandFactory : CommandFactoryBase<AdminHelpCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminHelpCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.Equal(words.Length, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.AdminHelp, "commandName");
            return new AdminHelpCommand();
        }
    }
}