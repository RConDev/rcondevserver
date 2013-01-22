namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Sets the server welcome message. This message will be displayed via an admin.yell to each player
    ///     the first time that player deploys in on the server. The message is displayed for 5 seconds.
    ///     This string must be less than 256 characters in length.
    /// </summary>
    public class VarsServerMessageCommand : VarsCommandBase<string>
    {
        /// <summary>
        /// creates a new <see cref="VarsServerMessageCommand"/> instance
        /// </summary>
        /// <param name="serverMessage"></param>
        public VarsServerMessageCommand(string serverMessage)
        {
            this.Value = serverMessage;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsServerMessage; }
        }
    }
}