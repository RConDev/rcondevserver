namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class MapListDataFile : IMapListDataFile
    {
        public IDataFile DataFile { get; private set; }

        public IMapRepository MapRepository { get; set; }

        public IGameModeRepository GameModeRepository { get; set; }

        public IMapRepository Repository { get; private set; }

        public MapListDataFile(IDataFile dataFile, IMapRepository mapRepository, IGameModeRepository gameModeRepository)
        {
            this.DataFile = dataFile;
            MapRepository = mapRepository;
            GameModeRepository = gameModeRepository;
        }

        public void Add(MapListItem item)
        {
            var storeItem = item.ToMapListStoreItem();
            this.DataFile.AppendLine(storeItem.ToDataString());
        }

        public IList<MapListItem> GetAll()
        {
            var lines = this.DataFile.GetAllLines();
            var storeItems = lines.Select(MapListStoreItem.FromDataString).ToList();
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