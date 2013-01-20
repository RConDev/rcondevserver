namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Save list of VIP player names to file
    /// </summary>
    /// <remarks>
    ///     1 line for each player name Every line break has windows “\r\n” characters.
    /// </remarks>
    public class ReservedSlotsListSaveCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListSave; }
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