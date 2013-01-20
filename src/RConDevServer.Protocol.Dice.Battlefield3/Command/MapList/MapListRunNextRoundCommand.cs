namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Switches immediately to the next round, without going through the end-of-round sequence.
    /// </summary>
    public class MapListRunNextRoundCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListRunNextRound; }
        }
    }
}