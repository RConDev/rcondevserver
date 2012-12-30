using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class BanList : List<BanListItem>
    {
        public const int MAX_ITEMS = 100;

        public IList<string> ToWords(int offset)
        {
            var words = new List<string>();
            if (offset >= Count)
            {
                return words;
            }
            var startIndex = offset;

            var itemsCount = 0;

            for (var i = startIndex;(i < Count) ; i++ )
            {
                if (itemsCount >= MAX_ITEMS)
                {
                    break;
                }
                var currentItem = this[i];
                words.AddRange(currentItem.ToWords());
                itemsCount++;
            }
            return words;
        } 
    
        public BanList() : base() {}

        public BanList(IEnumerable<BanListItem> items)
        {
            this.AddRange(items);
        }
    }
}
