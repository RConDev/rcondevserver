namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;

    public class BanTypes : List<BanType>
    {
        #region Direct Access

        public static BanType Perm = new BanType
            {
                Code = "perm",
                Display = "Permanent"
            };

        public static BanType Rounds = new BanType
            {
                Code = "rounds",
                Display = "Rounds"
            };

        public static BanType Seconds = new BanType
            {
                Code = "seconds",
                Display = "Seconds"
            };

        #endregion

        #region Constructor

        public BanTypes()
        {
            this.Add(Perm);
            this.Add(Rounds);
            this.Add(Seconds);
        }

        #endregion
    }
}