namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Removes the map at offset index from the maplist.
    /// </summary>
    public class MapListRemoveCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="MapListRemoveCommand" /> instance
        /// </summary>
        /// <param name="index"></param>
        public MapListRemoveCommand(int index)
        {
            this.Index = index;
        }

        /// <summary>
        ///     the index the map located should be removed
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.MapListRemove; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, Convert.ToString(this.Index)};
        }
    }
}