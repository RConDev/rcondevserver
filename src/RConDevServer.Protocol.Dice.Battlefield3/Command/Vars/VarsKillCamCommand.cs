namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if killcam is enabled
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsKillCamCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new instance of <see cref="VarsKillCamCommand" />
        /// </summary>
        /// <param name="isEnabled"></param>
        public VarsKillCamCommand(bool? isEnabled = null)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsKillCam; }
        }
    }
}