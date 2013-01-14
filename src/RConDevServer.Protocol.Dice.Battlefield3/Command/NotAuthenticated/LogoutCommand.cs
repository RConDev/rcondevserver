namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.NotAuthenticated
{
    using System.Collections.Generic;
    using Command;

    /// <summary>
    ///     Logout from game server
    /// </summary>
    public class LogoutCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.Logout; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command};
        }
    }
}