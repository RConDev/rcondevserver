namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.MapList
{
    using System.Collections.Generic;
    using Command;
    using Command.MapList;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="MapListGetRoundsCommand" />
    /// </summary>
    public class MapListGetRoundsCommandFactory : SimpleCommandFactory<MapListGetRoundsCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override MapListGetRoundsCommand FromWords(IEnumerable<string> commandWords)
        {
            return this.SimpleCommandFromWords(commandWords, CommandNames.MapListGetRounds);
        }
    }
}