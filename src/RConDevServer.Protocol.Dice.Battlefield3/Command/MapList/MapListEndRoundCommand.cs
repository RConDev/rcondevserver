namespace RConDevServer.Protocol.Dice.Battlefield3.Command.MapList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     End the current round, declaring winnerId as the winning team
    /// </summary>
    public class MapListEndRoundCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="MapListEndRoundCommand" />
        /// </summary>
        /// <param name="winnerId"></param>
        public MapListEndRoundCommand(int winnerId)
        {
            this.WinnerId = winnerId;
        }

        /// <summary>
        ///     the team id of team that should win
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.MapListEndRound; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, Convert.ToString(this.WinnerId)};
        }
    }
}