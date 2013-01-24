namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if nametags should be displayed
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsNameTagCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsNameTagCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsNameTagCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsNameTag; }
        }
    }
}