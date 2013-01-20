namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    /// <summary>
    ///     Restarts the current round, without going through the end-of-round sequence.
    /// </summary>
    public class MapListRestartRoundCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.MapListRestartRound; }
        }
    }
}