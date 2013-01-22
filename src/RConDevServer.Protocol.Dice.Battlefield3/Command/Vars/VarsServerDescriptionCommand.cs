namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Sets the server description. This string is displayed on the server’s detail page on Battlelog.
    ///     This string must be less than 256 characters in length.
    /// </summary>
    public class VarsServerDescriptionCommand : VarsCommandBase<string>
    {
        /// <summary>
        ///     creates a new <see cref="VarsServerDescriptionCommand" /> instance
        /// </summary>
        /// <param name="serverDescription"></param>
        public VarsServerDescriptionCommand(string serverDescription = null)
        {
            this.Value = serverDescription;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsServerDescription; }
        }
    }
}