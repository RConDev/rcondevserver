namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Specifies which map to switch to once the current round completes.
    ///     If there are rounds remaining on the current map, those rounds will be skipped.
    /// </summary>
    public class MapListSetNextMapIndexCommand : ICommand
    {
        /// <summary>
        ///     creates a new <see cref="MapListSetNextMapIndexCommand" /> instance
        /// </summary>
        /// <param name="index"></param>
        public MapListSetNextMapIndexCommand(int index)
        {
            this.Index = index;
        }

        /// <summary>
        /// the next index to be set
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command { get { return CommandNames.MapListSetNextMapIndex; } }

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