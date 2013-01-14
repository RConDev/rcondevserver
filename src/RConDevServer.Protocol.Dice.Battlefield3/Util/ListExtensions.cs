namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System.Collections.Generic;

    public static class StringListExtensions
    {
        public static void AddRange(this ICollection<string> list, IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                list.Add(item);
            }
        }
    }
}