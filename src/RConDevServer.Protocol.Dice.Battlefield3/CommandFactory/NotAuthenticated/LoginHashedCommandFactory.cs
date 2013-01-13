namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.NotAuthenticated;
    using Util;

    public class LoginHashedCommandFactory : CommandFactoryBase<LoginHashedCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override LoginHashedCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.LoginHashed, "commandName");
            string hash = words.Length == 2
                              ? words[1]
                              : null;
            return new LoginHashedCommand(hash);
        }
    }
}