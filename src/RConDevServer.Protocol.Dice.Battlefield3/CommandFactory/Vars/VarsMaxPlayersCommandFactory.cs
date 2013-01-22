namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Vars;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VarsMaxPlayersCommand" />
    /// </summary>
    public class VarsMaxPlayersCommandFactory : CommandFactoryBase<VarsMaxPlayersCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsMaxPlayersCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.VarsMaxPlayers, "commandName");
            int? maxPlayers = (words.Length == 1) ? null : Int.SafeParse(words[1]);
            return new VarsMaxPlayersCommand(maxPlayers);
        }
    }
}