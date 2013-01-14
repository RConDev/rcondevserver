namespace RConDevServer.Protocol.Dice.Battlefield3.Command.NotAuthenticated
{
    using System.Collections.Generic;

    /// <summary>
    ///     Disconnect from server
    /// </summary>
    public class QuitCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.Quit; }
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