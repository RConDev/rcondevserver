namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.NotAuthenticated;
    using Util;

    public class LoginPlainTextCommandFactory : CommandFactoryBase<LoginPlainTextCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override LoginPlainTextCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.Equal(words.Length, 2, "wordCount");
            Requires.Equal(words[0], CommandNames.LoginPlainText, "commandName");
            Requires.NotNullOrEmpty(words[1], "password");
            return new LoginPlainTextCommand(words[1]);
        }
    }
}