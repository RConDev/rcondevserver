namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using Command;
    using Command.MapList;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListRestartRoundCommand" />
    /// </summary>
    public class MapListRestartRoundCommandFactory : SimpleCommandFactory<MapListRestartRoundCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListRestartRoundCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.SimpleCommandFromWords(commandWords, CommandNames.MapListRestartRound);
        }
    }
}