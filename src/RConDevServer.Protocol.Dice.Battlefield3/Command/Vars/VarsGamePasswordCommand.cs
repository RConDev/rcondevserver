namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set the game password for the server, use it with an empty string("") to reset
    /// </summary>
    public class VarsGamePasswordCommand : VarsCommandBase<string>
    {
        /// <summary>
        ///     creates a new <see cref="VarsGamePasswordCommand" /> instance
        /// </summary>
        /// <param name="password"></param>
        public VarsGamePasswordCommand(string password = null)
        {
            this.Value = password;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsGamePassword; }
        }
    }
}