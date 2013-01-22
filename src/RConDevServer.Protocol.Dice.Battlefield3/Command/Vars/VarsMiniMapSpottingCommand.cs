namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if spotted targets are visible on the minimap
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsMiniMapSpottingCommand : VarsCommandBase<bool?>
    {
        public VarsMiniMapSpottingCommand(bool? isEnabled)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsMiniMapSpotting; }
        }
    }
}