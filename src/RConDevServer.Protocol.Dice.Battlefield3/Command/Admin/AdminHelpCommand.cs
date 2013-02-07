namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    public class AdminHelpCommand : SimpleCommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminHelp; }
        }
    }
}