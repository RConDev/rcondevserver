namespace RConDevServer.Protocol.Dice.Battlefield3.Command.PunkBuster
{
    using System.Collections.Generic;

    /// <summary>
    ///     Attempt to activate PunkBuster server module if it currently is inactive
    /// </summary>
    public class PunkBusterActivateCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.PunkBusterActivate; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command};
        }
    }
}