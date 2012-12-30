using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using DataStore;

    public class MapListStoreItem : IDataFileItem
    {
        private const string DataStringSeparator = ";";

        public string MapCode { get; set; }

        public string GameModeCode { get; set; }

        public string Rounds { get; set; }

        public string ToDataString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append(MapCode).Append(DataStringSeparator)
                .Append(GameModeCode).Append(DataStringSeparator)
                .Append(Rounds);
            return stringBuilder.ToString();
        }

        public static MapListStoreItem FromDataString(string dataString)
        {
            var parts = dataString.Split(DataStringSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return new MapListStoreItem
            {
                MapCode = parts[0],
                GameModeCode = parts[1],
                Rounds = parts[2]
            };
        }
    }
}
