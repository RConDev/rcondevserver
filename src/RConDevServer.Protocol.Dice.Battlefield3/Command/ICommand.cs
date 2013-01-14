namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    using System.Collections.Generic;

    /// <summary>
    ///     Basic interface description of a Command within the Battlefield 3 Remote Administration
    ///     Console
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        string Command { get; }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ToWords();
    }
}