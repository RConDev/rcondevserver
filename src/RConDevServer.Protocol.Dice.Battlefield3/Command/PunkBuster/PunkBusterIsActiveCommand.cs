namespace RConDevServer.Protocol.Dice.Battlefield3.Command.PunkBuster
{
    using System.Collections.Generic;

    /// <summary>
    ///     Query whether the PunkBuster server module is active
    /// </summary>
    public class PunkBusterIsActiveCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.PunkBusterIsActive; }
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