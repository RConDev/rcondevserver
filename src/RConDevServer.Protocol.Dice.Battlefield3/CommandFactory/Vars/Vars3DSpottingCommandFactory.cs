namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Vars
{
    using System.Collections.Generic;
    using Command;
    using Command.Vars;

    public class Vars3DSpottingCommandFactory : VarsCommandFactoryBase<Vars3DSpottingCommand, bool?>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override Vars3DSpottingCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.BoolFromWords(commandWords, CommandNames.Vars3DSpotting);
        }
    }
}