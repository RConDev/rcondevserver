namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Returns a section of the map list. If no startOffset is supplied,
    ///     it is assumed to be 0. At most 100 entries will be returned by the command.
    ///     To retrieve the full list, perform several mapList.list calls with increasing
    ///     offset until the server returns 0 entries.
    ///     (There is an unsolved synchronization problem hidden there: if the map list is
    ///     edited by another RCON client during this process, then entries may be missed
    ///     during retrieval. There is no known workaround for this.)
    /// </summary>
    public class MapListListCommand : ICommand
    {
        /// <summary>
        /// the offset
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// creates a new <see cref="MapListListCommand"/>
        /// </summary>
        /// <param name="offset"></param>
        public MapListListCommand(int? offset)
        {
            this.Offset = offset;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.MapListList; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {Command};
            if (Offset.HasValue)
            {
                words.Add(Convert.ToString(Offset));
            }
            return words;
        }
    }
}