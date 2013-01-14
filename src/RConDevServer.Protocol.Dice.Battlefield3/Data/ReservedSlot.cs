namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using DataStore;

    public class ReservedSlot : IDataFileItem
    {
        public string PlayerName { get; set; }

        public string ToDataString()
        {
            return this.PlayerName;
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