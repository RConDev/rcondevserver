namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// this interface describes the behavior of a ban list
    /// </summary>
    public interface IBanList : IEnumerable<BanListItem>
    {
        /// <summary>
        /// clears the ban list from all existing items
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds an <see cref="BanListItem"/> to the list
        /// </summary>
        /// <param name="banListItem"></param>
        void Add(BanListItem banListItem);

        /// <summary>
        /// Gets the number of <see cref="BanListItem"/>s in the list
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes the <see cref="BanListItem"/> from the list
        /// </summary>
        /// <param name="banListItem"></param>
        void Remove(BanListItem banListItem);

        IEnumerable<string> ToWords(int offset);
    }
}