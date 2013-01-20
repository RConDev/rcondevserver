namespace RConDevServer.Protocol.Dice.Battlefield3.Command.BanList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Save list of banned players/IPs/GUIDs to file
    /// </summary>
    /// <remarks>
    ///     6 lines (Id-type, id, ban-type, seconds left, rounds left, and reason) are stored for every ban in the list.
    ///     Every line break has windows “\r\n” characters.
    /// </remarks>
    public class BanListSaveCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.BanListSave; }
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