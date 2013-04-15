namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;
    using Common;

    public interface IPlayerSubset
    {
        /// <summary>
        /// the type the selection is of
        /// </summary>
        PlayerSubsetType Type { get; }

        /// <summary>
        /// the name of a selected player
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// the team id
        /// </summary>
        int? TeamId { get; }

        /// <summary>
        /// the squad id
        /// </summary>
        int? SquadId { get; }

        /// <summary>
        /// Generates the words used in <see cref="IPacket"/>
        /// </summary>
        /// <returns></returns>
        IList<string> ToWords();
    }
}