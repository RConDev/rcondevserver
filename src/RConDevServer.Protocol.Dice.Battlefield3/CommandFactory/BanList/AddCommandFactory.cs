namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.BanList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.BanList;
    using Data;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="BanListAddCommand" />
    /// </summary>
    public class AddCommandFactory : CommandFactoryBase<BanListAddCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override BanListAddCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 4, "words");
            Requires.Equal(words[0], CommandNames.BanListAdd, "commandName");
            var idType = words[1];
            var idTypeType = IdTypeExtension.FromWord(idType);
            Requires.NotNull(idTypeType, "idType");
            var id = words[2];
            var timeout = Timeout.FromWords(words.Skip(3));

            var reason = timeout.Type == TimeoutType.Permanent
                             ? ((words.Length == 5) ? words[4] : null)
                             : ((words.Length == 6) ? words[5] : null);

            return new BanListAddCommand(idTypeType.Value, id, timeout, reason);
        }
    }
}