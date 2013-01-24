namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if players health regeneration is active
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsRegenerateHealthCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsRegenerateHealthCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsRegenerateHealthCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsRegenerateHealth; }
        }
    }
}