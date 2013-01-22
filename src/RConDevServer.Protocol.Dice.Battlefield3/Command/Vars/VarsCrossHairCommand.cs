namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if crosshair for all weapons is enabled
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsCrossHairCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsCrossHairCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsCrossHairCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsCrossHair; }
        }
    }
}