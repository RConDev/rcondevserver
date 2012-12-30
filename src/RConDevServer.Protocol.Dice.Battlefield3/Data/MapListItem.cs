namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Text;
    using DataStore;

    public class MapListItem 
    {
        public const int PROPERTIES_COUNT = 3;

        public Map Map { get; set; }

        public GameMode Mode { get; set; }

        public int Rounds { get; set; }
        
        public MapListStoreItem ToMapListStoreItem()
        {
            return new MapListStoreItem
                {
                    GameModeCode = Mode.Code,
                    MapCode = Map.Code,
                    Rounds = Convert.ToString(Rounds)
                };
        }
    }
}
