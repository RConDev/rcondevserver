namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using Command;
    using Command.Vars;

    public class VarsTeamKillValueDecreasePerSecondCommandFactory :
        VarsCommandFactoryBase<VarsTeamKillValueDecreasePerSecondCommand, int?>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override VarsTeamKillValueDecreasePerSecondCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.IntFromWords(commandWords, CommandNames.VarsTeamKillValueDecreasePerSecond);
        }
    }
}