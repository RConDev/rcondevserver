namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set server name
    /// </summary>
    public class VarsServerNameCommand : VarsCommandBase<string>
    {
        /// <summary>
        /// creates a new <see cref="VarsServerNameCommand"/> instance
        /// </summary>
        /// <param name="serverName"></param>
        public VarsServerNameCommand(string serverName)
        {
            this.Value = serverName;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsServerName; }
        }
    }
}