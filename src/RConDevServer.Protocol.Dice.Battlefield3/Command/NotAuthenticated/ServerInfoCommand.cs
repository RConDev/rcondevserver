namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System.Collections.Generic;

    /// <summary>
    ///     This command can be performed without being logged in.
    ///     Some of the return values will be empty or zero when the server
    ///     isn’t fully up and running or between levels. Some return values are not yet implemented,
    ///     and will therefore be zero.
    /// </summary>
    public class ServerInfoCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ServerInfo; }
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