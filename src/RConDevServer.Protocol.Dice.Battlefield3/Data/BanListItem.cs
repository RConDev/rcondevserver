using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class BanListItem
    {
        public IdType IdType { get; set; }

        public string IdValue { get; set; }

        public BanType BanType { get; set; }

        public int Rounds { get; set; }

        public int Seconds { get; set; }

        public string Reason { get; set; }

        public IList<string> ToWords()
        {
            var words = new List<string>
                            {
                                IdType.Code,
                                IdValue,
                                BanType.Code,
                                Convert.ToString(Seconds),
                                Convert.ToString(Rounds),
                                Reason
                            };
            return words;
        }
    }
}