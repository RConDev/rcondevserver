using System.Collections.Generic;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui.Util
{
    /// <summary>
    /// Extension Methods for <see>
    ///                         <cref>IEnumerable{string}</cref>
    ///                       </see>
    /// </summary>
    public static class StringEnumerableExtensions
    {
        public static string DisplayWords(this IEnumerable<string> words)
        {
            var stringBuilder = new StringBuilder();
            foreach (string word in words)
            {
                stringBuilder.Append(string.Concat(" [", word, "]"));
            }
            return stringBuilder.ToString();
        }
    }
}