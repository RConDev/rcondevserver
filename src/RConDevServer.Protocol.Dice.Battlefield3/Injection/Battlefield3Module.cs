namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using Command.Admin;
    using CommandFactory;
    using CommandFactory.Admin;
    using DataStore;
    using Interface;

    /// <summary>
    ///     this module holds all "services" for
    /// </summary>
    public class Battlefield3Module
    {
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
            this.RegisterCommandFactories();
        }

        public IServiceLocator ServiceLocator { get; private set; }

        private void RegisterCommandFactories()
        {
            #region Admin Commands
            this.ServiceLocator.RegisterNamedService<ICommandFactory<EventsEnabledCommand>, EventsEnabledCommandFactory>
               (CommandNames.AdminEventsEnabled);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<HelpCommand>, HelpCommandFactory>(CommandNames.AdminHelp);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, KickPlayerCommandFactory>(
                CommandNames.AdminKickPlayer);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ListPlayersCommand>, ListPlayersCommandFactory>(
                CommandNames.AdminListPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<SayCommand>, SayCommandFactory>(
                CommandNames.AdminSay);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<YellCommand>, YellCommandFactory>(
                CommandNames.AdminYell);

            #endregion

            #region Not Authenticated Commands
            #endregion
        }
    }
}