namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the duration of pre-round
    ///     Delay: Takes effect next round
    /// </summary>
    /// <remarks>
    ///     Allowed durations are between 15 and 30 seconds for ranked servers, and between 10 and 900 seconds for
    ///     unranked servers. If the value gets clamped during a set operation,
    ///     then the clamped value is returned as part of the response
    /// </remarks>
    public class VarsRoundLockdownCountdownCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     create a new <see cref="VarsRoundLockdownCountdownCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsRoundLockdownCountdownCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsRoundLockdownCountdown; }
        }
    }
}