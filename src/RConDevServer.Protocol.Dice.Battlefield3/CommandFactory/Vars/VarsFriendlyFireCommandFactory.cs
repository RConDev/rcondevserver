namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using Command;
    using Command.Vars;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="VarsFriendlyFireCommand" />
    /// </summary>
    public class VarsFriendlyFireCommandFactory : VarsCommandFactoryBase<VarsFriendlyFireCommand, bool?>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsFriendlyFireCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.BoolFromWords(commandWords, CommandNames.VarsFriendlyFire);
        }
    }
}