namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the value of a teamkill (adds to the player’s current kill-value)
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsTeamKillValueIncreaseCommand : VarsCommandBase<int?>
    {
        /// <summary>
        /// creates a new <see cref="VarsTeamKillValueIncreaseCommand"/> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsTeamKillValueIncreaseCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsTeamKillValueIncrease; }
        }
    }
}