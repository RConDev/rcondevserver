namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Text;
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
                .Append(this.MapCode).Append(DataStringSeparator)
                .Append(this.GameModeCode).Append(DataStringSeparator)
                .Append(this.Rounds);
            return stringBuilder.ToString();
        }

        public static MapListStoreItem FromDataString(string dataString)
        {
            string[] parts = dataString.Split(DataStringSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return new MapListStoreItem
                {
                    MapCode = parts[0],
                    GameModeCode = parts[1],
                    Rounds = parts[2]
                };
        }
    }
}