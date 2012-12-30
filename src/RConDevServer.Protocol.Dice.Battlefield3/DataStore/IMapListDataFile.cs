namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using System.Collections.Generic;
    using Data;

    public interface IMapListDataFile
    {
        IDataFile DataFile { get; }
        IMapRepository MapRepository { get; set; }
        IGameModeRepository GameModeRepository { get; set; }
        IMapRepository Repository { get; }
        void Add(MapListItem item);
        IList<MapListItem> GetAll();
        void Clear();
    }
}