namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System.Collections.Generic;

    public class LoginHashedCommand : ICommand
    {
        /// <summary>
        ///     creates a new <see cref="LoginHashedCommand" /> instance
        /// </summary>
        /// <param name="passwordHash"></param>
        public LoginHashedCommand(string passwordHash = null)
        {
            this.PasswordHash = passwordHash;
        }

        /// <summary>
        ///     the current password hash to login
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.LoginHashed; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.PasswordHash != null)
            {
                words.Add(this.PasswordHash);
            }
            return words;
        }
    }
}