namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.NotAuthenticated;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="QuitCommand" />
    /// </summary>
    public class QuitCommandFactory : CommandFactoryBase<QuitCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override QuitCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "wordCount");
            Requires.Equal(words[0], CommandNames.Quit, "commandName");
            return new QuitCommand();
        }
    }
}