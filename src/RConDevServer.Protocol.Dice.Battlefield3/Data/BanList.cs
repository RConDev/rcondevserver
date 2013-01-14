namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;

    public class BanList : List<BanListItem>
    {
        public const int MAX_ITEMS = 100;

        public BanList()
        {
        }

        public BanList(IEnumerable<BanListItem> items)
        {
            this.AddRange(items);
        }

        public IList<string> ToWords(int offset)
        {
            var words = new List<string>();
            if (offset >= this.Count)
            {
                return words;
            }
            int startIndex = offset;

            int itemsCount = 0;

            for (int i = startIndex; (i < this.Count); i++)
            {
                if (itemsCount >= MAX_ITEMS)
                {
                    break;
                }
                BanListItem currentItem = this[i];
                words.AddRange(currentItem.ToWords());
                itemsCount++;
            }
            return words;
        }
    }
}