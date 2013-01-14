namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.NotAuthenticated;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VersionCommand" />
    /// </summary>
    public class VersionCommandFactory : CommandFactoryBase<VersionCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VersionCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.Version, "commandName");
            return new VersionCommand();
        }
    }
}