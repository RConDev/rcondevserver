using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class IdTypes : List<IdType>
    {
        #region Direct Access

        ////public static IdType SoldierName = new IdType
        ////                                       {
        ////                                           Code = "name",
        ////                                           Display = "Soldier Name"
        ////                                       };

        ////public static IdType Ip = new IdType
        ////                              {
        ////                                  Code = "ip",
        ////                                  Display = "IP Address"
        ////                              };

        ////public static IdType Guid = new IdType
        ////                                {
        ////                                    Code = "guid",
        ////                                    Display = "Player GUID"
        ////                                };

        #endregion

        #region Constructor

        public IdTypes(IEnumerable<IdType> getAll)
        {
            this.AddRange(getAll);
            ////Add(SoldierName);
            ////Add(Ip);
            ////Add(Guid);
        }

        #endregion
    }
}