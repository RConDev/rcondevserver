namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if players should be allowed to switch to third-person vehicle cameras
    ///     Delay: Unknown
    /// </summary>
    public class Vars3PCamCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="Vars3PCamCommand" />
        /// </summary>
        /// <param name="isEnabled"></param>
        public Vars3PCamCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.Vars3PCam; }
        }
    }
}