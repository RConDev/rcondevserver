namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set how many teamkill-kicks will lead to permaban Set to 0 to disable feature
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsTeamKillKickForBanCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsTeamKillKickForBanCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsTeamKillKickForBanCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsTeamKillKickForBan; }
        }
    }
}