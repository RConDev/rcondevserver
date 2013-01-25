namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set how many rounds an idle-kick person should be banned
    ///     Set to 0 to disable ban mechanism
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsIdleBanRoundsCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsIdleBanRoundsCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsIdleBanRoundsCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsIdleBanRounds; }
        }
    }
}