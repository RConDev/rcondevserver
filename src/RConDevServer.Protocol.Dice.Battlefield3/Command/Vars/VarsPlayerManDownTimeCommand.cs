namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set player man-down time scale factor, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsPlayerManDownTimeCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsPlayerManDownTimeCommand" /> command
        /// </summary>
        /// <param name="value"></param>
        public VarsPlayerManDownTimeCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsPlayerManDownTime; }
        }
    }
}