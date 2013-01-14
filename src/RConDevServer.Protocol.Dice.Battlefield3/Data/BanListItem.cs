namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;

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
                    this.IdType.Code,
                    this.IdValue,
                    this.BanType.Code,
                    Convert.ToString(this.Seconds),
                    Convert.ToString(this.Rounds),
                    this.Reason
                };
            return words;
        }
    }
}