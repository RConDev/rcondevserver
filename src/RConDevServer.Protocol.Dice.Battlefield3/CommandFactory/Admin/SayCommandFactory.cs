namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command.Admin;
    using Data;

    public class SayCommandFactory : CommandFactoryBase<AdminSayCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminSayCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            PlayerSubset subsetWords = PlayerSubset.FromWords(words.Skip(2));
            return new AdminSayCommand(words[1], subsetWords);
        }
    }
}