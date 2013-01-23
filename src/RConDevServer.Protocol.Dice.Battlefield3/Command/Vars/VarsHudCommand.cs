namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if players hud is available
    ///     Delay: Works after round restart
    /// </summary>
    public class VarsHudCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     create a new <see cref="VarsHudCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsHudCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsHud; }
        }
    }
}