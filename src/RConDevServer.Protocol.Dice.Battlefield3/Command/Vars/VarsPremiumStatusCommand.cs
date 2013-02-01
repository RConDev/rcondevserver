namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if server should be exclusive to Premium players
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsPremiumStatusCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsPremiumStatusCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsPremiumStatusCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsPremiumStatus; }
        }
    }
}