namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using System.Collections.Generic;
    using Command;

    /// <summary>
    ///     description of the interface for creating <see cref="ICommand" /> implementations
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandFactory<out TCommand> where TCommand : class
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        TCommand FromWords(IEnumerable<string> commandWords);

        /// <summary>
        ///     parses the command out of a <see cref="string" />
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>
        ///     the <see cref="ICommand" /> implementation if found
        /// </returns>
        TCommand Parse(string commandString);
    }
}