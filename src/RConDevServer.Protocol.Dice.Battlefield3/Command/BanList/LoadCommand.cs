namespace RConDevServer.Protocol.Dice.Battlefield3.Command.BanList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Load list of banned players/IPs/GUIDs from file
    /// </summary>
    /// <remarks>
    ///     6 lines (Id-type, id, ban-type, seconds left, rounds left, and reason)
    ///     are retrieved for every ban in the list.
    ///     Entries read before getting InvalidIdType, InvalidBanType, InvalidTimeStamp and
    ///     IncompleteBan is still loaded.
    /// </remarks>
    public class LoadCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.BanListLoad; }
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