namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.PunkBuster
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.PunkBuster;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="PunkBusterIsActiveCommand" />
    /// </summary>
    public class PunkBusterIsActiveCommandFactory : CommandFactoryBase<PunkBusterIsActiveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override PunkBusterIsActiveCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.PunkBusterIsActive, "commandName");
            return new PunkBusterIsActiveCommand();
        }
    }
}