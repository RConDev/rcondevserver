namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class MapListDataFile : IMapListDataFile
    {
        public MapListDataFile(IDataFile dataFile, IMapRepository mapRepository, IGameModeRepository gameModeRepository)
        {
            this.DataFile = dataFile;
            this.MapRepository = mapRepository;
            this.GameModeRepository = gameModeRepository;
        }

        public IDataFile DataFile { get; private set; }

        public IMapRepository MapRepository { get; set; }

        public IGameModeRepository GameModeRepository { get; set; }

        public IMapRepository Repository { get; private set; }

        public void Add(MapListItem item)
        {
            MapListStoreItem storeItem = item.ToMapListStoreItem();
            this.DataFile.AppendLine(storeItem.ToDataString());
        }

        public IList<MapListItem> GetAll()
        {
            IEnumerable<string> lines = this.DataFile.GetAllLines();
            List<MapListStoreItem> storeItems = lines.Select(MapListStoreItem.FromDataString).ToList();
            return storeItems.Select(x => new MapListItem
                {
                    Map = this.MapRepository.FindByCode(x.MapCode),
                    Mode = this.GameModeRepository.FindByCode(x.GameModeCode),
                    Rounds = Convert.ToInt32(x.Rounds)
                }).ToList();
        }

        public void Clear()
        {
            this.DataFile.Clear();
        }
    }
}