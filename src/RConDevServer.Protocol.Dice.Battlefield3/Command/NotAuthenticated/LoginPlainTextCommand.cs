namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Attempt to login to game server with password in plain text
    /// </summary>
    /// <remarks>
    ///     If you are connecting to the admin interface over the internet,
    ///     then use login.hashed instead to avoid having evildoers sniff the admin password
    /// </remarks>
    [Obsolete("the login.plainText command should only be used in LAN")]
    public class LoginPlainTextCommand : ICommand
    {
        /// <summary>
        ///     create a new instance of <see cref="LoginPlainTextCommand" />
        /// </summary>
        /// <param name="password"></param>
        public LoginPlainTextCommand(string password)
        {
            this.Password = password;
        }

        /// <summary>
        ///     the password to login in plain text
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.LoginPlainText; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.Password};
        }
    }
}