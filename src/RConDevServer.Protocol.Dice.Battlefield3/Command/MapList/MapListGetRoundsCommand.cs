namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Returns the (1-based) current round number, and total number of rounds before switching map.
    /// </summary>
    public class MapListGetRoundsCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListGetRounds; }
        }
    }
}