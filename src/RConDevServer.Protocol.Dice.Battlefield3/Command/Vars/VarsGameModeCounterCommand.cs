namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set scale factor for number of tickets to end round, in percent
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsGameModeCounterCommand : VarsCommandBase<int?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsGameModeCounterCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsGameModeCounterCommand(int? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsGameModeCounter; }
        }
    }
}