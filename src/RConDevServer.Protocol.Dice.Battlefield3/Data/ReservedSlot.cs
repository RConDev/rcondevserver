using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RConDevServer.Protocol.Dice.Battlefield3.DataStore;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class ReservedSlot : IDataFileItem
    {
        public string PlayerName { get; set; }

        public string ToDataString()
        {
            return PlayerName;
        }

        public static ReservedSlot FromDataString(string dataString)
        {
            return new ReservedSlot
                {
                    PlayerName = dataString
                };
        }
    }
}
