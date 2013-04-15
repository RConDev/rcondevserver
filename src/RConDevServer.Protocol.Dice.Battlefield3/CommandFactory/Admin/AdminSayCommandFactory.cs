namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command.Admin;
    using Data;

    /// <summary>
    /// Implementation of <see cref="ICommandFactory{TCommand}"/> for <see cref="AdminSayCommand"/>
    /// </summary>
    public class AdminSayCommandFactory : CommandFactoryBase<AdminSayCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminSayCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            var subsetWords = PlayerSubset.FromWords(words.Skip(2));
            return new AdminSayCommand(words[1], subsetWords);
        }
    }
}