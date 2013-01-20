namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    using System.Collections.Generic;

    /// <summary>
    /// base class for a simple command, which only contains
    /// the command name without any additional information
    /// </summary>
    public abstract class SimpleCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public abstract string Command { get; }

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