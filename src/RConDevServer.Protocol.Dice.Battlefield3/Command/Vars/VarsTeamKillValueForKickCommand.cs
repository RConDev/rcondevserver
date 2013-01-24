namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the highest kill-value allowed before a player is kicked for teamkilling
    ///     Set to 0 to disable kill value mechanism
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsTeamKillValueForKickCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsTeamKillValueForKickCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsTeamKillValueForKickCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsTeamKillValueForKick; }
        }
    }
}