using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
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
            Add(Perm);
            Add(Rounds);
            Add(Seconds);
        }

        #endregion

    }
}
