namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Load list of VIP players from file
    /// </summary>
    /// <remarks>
    ///     1 line for each entry with player name
    /// </remarks>
    public class ReservedSlotsListLoadCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListLoad; }
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