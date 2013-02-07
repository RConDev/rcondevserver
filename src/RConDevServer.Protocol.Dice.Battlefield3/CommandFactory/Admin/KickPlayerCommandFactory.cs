namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command.Admin;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for
    /// </summary>
    public class KickPlayerCommandFactory : CommandFactoryBase<AdminKickPlayerCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminKickPlayerCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            ////Requires.Equal(words[0], CommandNames.AdminKickPlayer, "commandWords[0]");
            ////Requires.Equal(words.Length, 3, "commandWords.Length");
            return new AdminKickPlayerCommand(words[1], words[2]);
        }
    }
}