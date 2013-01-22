namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Vars;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VarsServerDescriptionCommand" />
    /// </summary>
    internal class VarsServerDescriptionCommandFactory : CommandFactoryBase<VarsServerDescriptionCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsServerDescriptionCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.VarsServerDescription, "commandName");
            string serverDescription = (words.Length == 1) ? null : words[1];
            return new VarsServerDescriptionCommand(serverDescription);
        }
    }
}