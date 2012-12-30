using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using RConDevServer.Protocol.Dice.Battlefield3.DataStore;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    /// <summary>
    /// this module holds all "services" for 
    /// </summary>
    public class Battlefield3Module 
    {
        public IServiceLocator ServiceLocator { get; private set; }

        public Battlefield3Module(IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            ServiceLocator.RegisterService(typeof (IDataContext), new Battlefield3DataContext(serviceLocator));
            ServiceLocator.RegisterService(typeof (IMapRepository), new MapRepository(serviceLocator));
            ServiceLocator.RegisterService(typeof (IGameModeRepository), new GameModeRepository(serviceLocator));
            ServiceLocator.RegisterService(typeof (IIdTypeRepository), new IdTypesRepository(serviceLocator));
            ServiceLocator.RegisterService(typeof (ICountryRepository), new CountryRepository(serviceLocator));
            ServiceLocator.RegisterService(typeof (IPlayerListStoreRepository),
                                           new PlayerListStoreRepository(serviceLocator));
        }
    }
}
