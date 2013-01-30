namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using Command;
    using Command.Vars;

    public class VarsRoundStartPlayerCountCommandFactory :
        VarsCommandFactoryBase<VarsRoundStartPlayerCountCommand, int?>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsRoundStartPlayerCountCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.IntFromWords(commandWords, CommandNames.VarsRoundStartPlayerCount);
        }
    }
}