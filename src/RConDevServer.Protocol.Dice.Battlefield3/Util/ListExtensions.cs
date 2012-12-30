using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    public static class StringListExtensions
    {
        public static void AddRange(this ICollection<string> list, IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }
    }
}
