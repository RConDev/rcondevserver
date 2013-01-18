namespace RConDevServer.Protocol.Dice.Battlefield3.Command.BanList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Return a section of the list of banned players’ name/IPs/GUIDs.
    /// </summary>
    /// <remarks>
    ///     6 words (Id-type, id, ban-type, seconds left, rounds left, and reason) are received
    ///     for every ban in the list. If no startOffset is supplied, it is assumed to be 0.
    ///     At most 100 entries will be returned by the command. To retrieve the full list, perform several
    ///     banList.list calls with increasing offset until the server returns 0 entries.
    ///     (There is an unsolved synchronization problem hidden there: if a ban expires during this process,
    ///     then one other entry will be skipped during retrieval. There is no known workaround for this.)
    /// </remarks>
    public class ListCommand : ICommand
    {
        /// <summary>
        ///     the offset to skip at the beginning
        /// </summary>
        public int? Offset { get; private set; }

        /// <summary>
        ///     create a new <see cref="ListCommand" /> instance
        /// </summary>
        /// <param name="offset"></param>
        public ListCommand(int? offset)
        {
            this.Offset = offset;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.BanListList; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.Offset.HasValue)
            {
                words.Add(Convert.ToString(this.Offset));
            }
            return words;
        }
    }
}