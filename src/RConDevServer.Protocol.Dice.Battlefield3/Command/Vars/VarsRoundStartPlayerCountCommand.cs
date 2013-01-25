namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the minimum number of players required to begin a round
    ///     Delay: Takes effect next round
    /// </summary>
    /// <remarks>
    ///     If the server is ranked, and the value gets clamped during a set operation,
    ///     then the clamped value is returned as part of the response
    /// </remarks>
    public class VarsRoundStartPlayerCountCommand : VarsCommandBase<int?>
    {
        public VarsRoundStartPlayerCountCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsRoundStartPlayerCount; }
        }
    }
}