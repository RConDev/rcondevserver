namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if the server should autobalance
    /// </summary>
    public class VarsAutoBalanceCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        /// create a new <see cref="VarsAutoBalanceCommand"/> instance
        /// </summary>
        /// <param name="isAutoBalance"></param>
        public VarsAutoBalanceCommand(bool? isAutoBalance = null)
        {
            this.Value = isAutoBalance;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsAutoBalance; }
        }
    }
}