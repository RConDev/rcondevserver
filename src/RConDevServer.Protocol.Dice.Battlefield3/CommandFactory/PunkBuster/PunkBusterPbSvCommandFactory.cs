namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.PunkBuster
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.PunkBuster;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="PunkBusterPbSvCommand" />
    /// </summary>
    public class PunkBusterPbSvCommandFactory : CommandFactoryBase<PunkBusterPbSvCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override PunkBusterPbSvCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 2, "words");
            Requires.Equal(words[0], CommandNames.PunkBusterPbSvCommand, "commandName");
            return new PunkBusterPbSvCommand(words[1]);
        }
    }
}