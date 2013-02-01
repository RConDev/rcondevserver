namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Vars;
    using Data;
    using Util;

    public class VarsUnlockModeCommandFactory : VarsCommandFactoryBase<VarsUnlockModeCommand, UnlockMode?>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsUnlockModeCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "commandWords");
            Requires.Equal(words[0], CommandNames.VarsUnlockMode, "commandName");
            UnlockMode? value = (words.Length > 1) ? UnlockModeConvert.ToUnlockMode(words[1]) : null;
            return new VarsUnlockModeCommand(value);
        }
    }
}