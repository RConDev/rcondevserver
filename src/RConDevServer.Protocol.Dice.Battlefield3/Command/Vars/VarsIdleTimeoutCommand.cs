namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set how many seconds a player can be idle before he/she is kicked from server
    ///     Set to 0 to disable idle kick
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsIdleTimeoutCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates new <see cref="VarsIdleTimeoutCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsIdleTimeoutCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsIdleTimeout; }
        }
    }
}