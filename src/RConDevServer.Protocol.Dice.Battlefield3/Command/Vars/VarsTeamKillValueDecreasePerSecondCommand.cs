namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set how many teamkill-kicks will lead to permaban Set to 0 to disable feature
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsTeamKillValueDecreasePerSecondCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsTeamKillValueDecreasePerSecondCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsTeamKillValueDecreasePerSecondCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsTeamKillValueDecreasePerSecond; }
        }
    }
}