using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataStore
{
    using Data;
    using Interface;

    public interface IPlayerListStoreRepository
    {
        IServiceLocator ServiceLocator { get; }
        IEnumerable<PlayerListStoreItem> GetAll();
        void Save(PlayerListStoreItem item);
        PlayerListStoreItem Get(long playerListStoreId);
    }
}
