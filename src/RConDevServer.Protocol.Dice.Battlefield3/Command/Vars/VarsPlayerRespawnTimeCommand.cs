namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set player respawn time scale factor, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsPlayerRespawnTimeCommand : VarsCommandBase<int?>
    {
        /// <summary>
        /// creates a new <see cref="VarsPlayerRespawnTimeCommand"/> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsPlayerRespawnTimeCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsPlayerRespawnTime; }
        }
    }
}