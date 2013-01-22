namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if minimap is enabled
    ///     Delay: Works after map switch
    /// </summary>
    public class VarsMiniMapCommand : VarsCommandBase<bool?>
    {
        public VarsMiniMapCommand(bool? isEnabled)
        {
            this.Value = isEnabled;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsMiniMap; }
        }
    }
}