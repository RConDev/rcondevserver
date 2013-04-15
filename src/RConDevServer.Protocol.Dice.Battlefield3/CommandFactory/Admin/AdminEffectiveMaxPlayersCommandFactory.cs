namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    /// Implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="AdminEffectiveMaxPlayersCommand"/>
    /// </summary>
    public class AdminEffectiveMaxPlayersCommandFactory : CommandFactoryBase<AdminEffectiveMaxPlayersCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminEffectiveMaxPlayersCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.AdminEffectiveMaxPlayers, "commandName");
            return new AdminEffectiveMaxPlayersCommand();
        }
    }
}