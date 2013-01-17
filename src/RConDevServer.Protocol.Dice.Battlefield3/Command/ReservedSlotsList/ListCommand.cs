namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Return a section of the list of VIP players’ names.
    /// </summary>
    /// <remarks>
    ///     1 line for each player If no startOffset is supplied, it is assumed to be 0.
    ///     At most 100 entries will be returned by the command. To retrieve the full list,
    ///     perform several reservedSlots.list calls with increasing offset until the
    ///     server returns 0 entries.
    /// </remarks>
    public class ListCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="ListCommand" /> instance
        /// </summary>
        /// <param name="offset"></param>
        public ListCommand(int? offset = null)
        {
            this.Offset = offset;
        }

        /// <summary>
        ///     the offset for querying the list
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListList; }
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