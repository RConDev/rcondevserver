namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set soldier max health scale factor, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsSoldierHealthCommand : VarsCommandBase<int?>
    {
        /// <summary>
        /// creates a new <see cref="VarsSoldierHealthCommand"/> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsSoldierHealthCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsSoldierHealth; }
        }
    }
}