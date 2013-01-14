namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System.Collections.Generic;

    /// <summary>
    ///     Game server type and build ID uniquely identify the server, and the protocol it is running.
    /// </summary>
    public class VersionCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.Version; }
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