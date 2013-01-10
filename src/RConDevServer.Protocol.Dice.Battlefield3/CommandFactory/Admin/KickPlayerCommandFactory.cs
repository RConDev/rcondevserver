namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for
    /// </summary>
    public class KickPlayerCommandFactory : CommandFactoryBase<KickPlayerCommand>
    {
        /// <summary>
        /// creates a command from the DICE <see cref="Packet"/> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override KickPlayerCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            ////Requires.Equal(words[0], CommandNames.AdminKickPlayer, "commandWords[0]");
            ////Requires.Equal(words.Length, 3, "commandWords.Length");
            return new KickPlayerCommand(words[1], words[2]);
        }

        /// <summary>
        /// parses the command out of a <see cref="string"/>
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>the <see cref="ICommand"/> implementation if found</returns>
        public override KickPlayerCommand Parse(string commandString)
        {
            Requires.NotNullOrEmpty(commandString, "commandString");
            Requires.StartsWith(commandString, CommandNames.AdminKickPlayer, "commandString");
            var words = this.ExtractCommandWords(commandString).ToArray();
            Requires.Equal(words.Length, 3, "commandString");
            return new KickPlayerCommand(words[1], words[2]);
        }
    }
}