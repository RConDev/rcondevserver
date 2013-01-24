namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set number of teamkills allowed during one round, before the game kicks the player
    ///     in question Set to 0 to disable kill counting
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsTeamKillCountForKickCommand : VarsCommandBase<int?>
    {
        /// <summary>
        /// creates a new <see cref="VarsTeamKillCountForKickCommand"/> instance
        /// </summary>
        /// <param name="countValue"></param>
        public VarsTeamKillCountForKickCommand(int? countValue = null)
        {
            this.Value = countValue;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsTeamKillCountForKick; }
        }
    }
}