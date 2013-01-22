namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Vars;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VarsServerMessageCommand" />
    /// </summary>
    public class VarsServerMessageCommandFactory : VarsCommandFactoryBase<VarsServerMessageCommand, string>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsServerMessageCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.StringFromWords(commandWords, CommandNames.VarsServerMessage);
        }
    }
}