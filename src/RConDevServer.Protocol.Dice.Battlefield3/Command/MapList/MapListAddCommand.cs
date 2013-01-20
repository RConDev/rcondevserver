namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     Adds the map, with gamemode , for rounds, to the
    ///     maplist. If index is not specified, it is appended to the end;
    ///     otherwise, it is inserted before the map which is currently at position index.
    /// </summary>
    public class MapListAddCommand : ICommand
    {
        /// <summary>
        ///     creates a new <see cref="MapListAddCommand" /> instance
        /// </summary>
        /// <param name="mapCode"></param>
        /// <param name="gameModeCode"></param>
        /// <param name="rounds"></param>
        /// <param name="index"></param>
        public MapListAddCommand(string mapCode, string gameModeCode, int rounds, int? index)
        {
            this.MapCode = mapCode;
            this.GameModeCode = gameModeCode;
            this.Rounds = rounds;
            this.Index = index;
        }

        /// <summary>
        ///     the map to be inserted
        /// </summary>
        public string MapCode { get; private set; }

        /// <summary>
        ///     the game mode to be played on the map
        /// </summary>
        public string GameModeCode { get; set; }

        /// <summary>
        ///     number of rounds for this map
        /// </summary>
        public int Rounds { get; set; }

        /// <summary>
        ///     (optional) the index the map should be inserted
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.MapListAdd; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string>
                {
                    this.Command,
                    this.MapCode,
                    this.GameModeCode,
                    Convert.ToString(this.Rounds)
                };
            if (this.Index.HasValue)
            {
                words.Add(Convert.ToString(this.Index.Value));
            }
            return words;
        }
    }
}