namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the minimum number of players for the round to restart in pre-round
    ///     Delay: Takes effect next round
    /// </summary>
    /// <remarks>
    ///     If the server is ranked, and the value gets clamped during a set operation, then the clamped value is
    ///     returned as part of the response
    /// </remarks>
    public class VarsRoundRestartPlayerCountCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsRoundRestartPlayerCountCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsRoundRestartPlayerCountCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsRoundRestartPlayerCount; }
        }
    }
}