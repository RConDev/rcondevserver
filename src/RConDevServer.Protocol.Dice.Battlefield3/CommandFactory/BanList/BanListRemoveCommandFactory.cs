namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.BanList
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.BanList;
    using Data;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="BanListRemoveCommand" />
    /// </summary>
    public class BanListRemoveCommandFactory : CommandFactoryBase<BanListRemoveCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override BanListRemoveCommand FromWords(IEnumerable<string> commandWords)
        {
            var words = commandWords.ToArray();
            Requires.SequenceLength(words, 3, "words");
            Requires.Equal(words[0], CommandNames.BanListRemove, "commandName");

            var idTypeString = words[1];
            Requires.NotNullOrEmpty(idTypeString, "idTypeString");

            var id = words[2];
            Requires.NotNullOrEmpty(id, "id");

            var idType = IdTypeExtension.FromWord(idTypeString);
            Requires.NotNull(idType, "idType");

            return new BanListRemoveCommand(idType.Value, id);
        }
    }
}