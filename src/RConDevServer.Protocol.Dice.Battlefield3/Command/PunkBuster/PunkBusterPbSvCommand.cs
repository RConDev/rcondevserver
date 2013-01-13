namespace RConDevServer.Protocol.Dice.Battlefield3.Command.PunkBuster
{
    using System.Collections.Generic;

    /// <summary>
    ///     Send a raw PunkBuster command to the PunkBuster server
    /// </summary>
    /// <remarks>
    ///     The entire command is to be sent as a single string. Don’t split it into multiple words.
    /// </remarks>
    public class PunkBusterPbSvCommand : ICommand
    {
        /// <summary>
        ///     creates a new <see cref="PunkBusterPbSvCommand" /> instance
        /// </summary>
        /// <param name="commandString"></param>
        public PunkBusterPbSvCommand(string commandString)
        {
            this.CommandString = commandString;
        }

        /// <summary>
        ///     the raw command string to be sent to punkbuster server
        /// </summary>
        public string CommandString { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.PunkBusterPbSvCommand; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.CommandString};
        }
    }
}