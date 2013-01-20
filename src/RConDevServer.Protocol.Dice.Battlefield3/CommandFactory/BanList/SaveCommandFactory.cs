namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.BanList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.BanList;
    using Util;

    public class SaveCommandFactory : CommandFactoryBase<BanListSaveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override BanListSaveCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], CommandNames.BanListSave, "commandName");
            return new BanListSaveCommand();
        }
    }
}