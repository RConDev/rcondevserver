namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if spotted targets are visible in the 3d-world
    ///     Delay: Works after map switch
    /// </summary>
    public class Vars3DSpottingCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="Vars3DSpottingCommand" /> instance
        /// </summary>
        /// <param name="isEnabled"></param>
        public Vars3DSpottingCommand(bool? isEnabled)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.Vars3DSpotting; }
        }
    }
}