namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Tests.CommandFactory.NotAuthenticated;
    using Util;

    /// <summary>
    /// implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="LogoutCommand"/>
    /// </summary>
    public class LogoutCommandFactory : CommandFactoryBase<LogoutCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override LogoutCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.Logout, "commandName");
            return new LogoutCommand();
        }
    }
}