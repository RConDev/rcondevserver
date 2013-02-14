namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using DataStore;
    using Interface;

    /// <summary>
    ///     this module holds all "services" for
    /// </summary>
    public class Battlefield3Module
    {
        /// <summary>
        ///     creates a new <see cref="Battlefield3Module" /> instance
        /// </summary>
        /// <param name="serviceLocator"></param>
        public Battlefield3Module(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
            this.ServiceLocator.RegisterService(typeof (IDataContext), new Battlefield3DataContext(serviceLocator));
            this.ServiceLocator.RegisterService(typeof (IMapRepository), new MapRepository(serviceLocator));
            this.ServiceLocator.RegisterService(typeof (IGameModeRepository), new GameModeRepository(serviceLocator));
            this.ServiceLocator.RegisterService(typeof (IIdTypeRepository), new IdTypesRepository(serviceLocator));
            this.ServiceLocator.RegisterService(typeof (ICountryRepository), new CountryRepository(serviceLocator));
            this.ServiceLocator.RegisterService(typeof (IPlayerListStoreRepository),
                                                new PlayerListStoreRepository(serviceLocator));

            // Command Factories
            this.ServiceLocator.Load(new CommandFactoryModule());

            this.ServiceLocator.Load(new CommandHandlerModule(this.ServiceLocator));
        }

        public IServiceLocator ServiceLocator { get; private set; }
    }
}