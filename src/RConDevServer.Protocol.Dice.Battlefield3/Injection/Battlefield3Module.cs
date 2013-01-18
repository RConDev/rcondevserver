namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using Command.Admin;
    using Command.ReservedSlotsList;
    using CommandFactory;
    using CommandFactory.Admin;
    using CommandFactory.ReservedSlotsList;
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
            this.ServiceLocator.RegisterNamedService<ICommandFactory<HelpCommand>, HelpCommandFactory>(
                CommandNames.AdminHelp);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, KickPlayerCommandFactory>(
                CommandNames.AdminKickPlayer);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ListPlayersCommand>, ListPlayersCommandFactory>(
                CommandNames.AdminListPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<SayCommand>, SayCommandFactory>(
                CommandNames.AdminSay);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<YellCommand>, YellCommandFactory>(
                CommandNames.AdminYell);
            this.ServiceLocator
                .RegisterNamedService<ICommandFactory<EffectiveMaxPlayersCommand>, EffectiveMaxPlayersCommandFactory>(
                    CommandNames.AdminEffectiveMaxPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<MovePlayerCommand>, MovePlayerCommandFactory>(
                CommandNames.AdminMovePlayer);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<KillPlayerCommand>, KillPlayerCommandFactory>(
                CommandNames.AdminKillPlayer);

            #endregion

            #region Reserved Slots

            this.ServiceLocator
                .RegisterNamedService<ICommandFactory<LoadCommand>, LoadCommandFactory>(CommandNames.ReservedSlotsListLoad);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<SaveCommand>, SaveCommandFactory>(
                CommandNames.ReservedSlotsListSave);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<AddCommand>, AddCommandFactory>(
                CommandNames.ReservedSlotsListAdd);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<RemoveCommand>, RemoveCommandFactory>(
                CommandNames.ReservedSlotsListRemove);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ClearCommand>, ClearCommandFactory>(
                CommandNames.ReservedSlotsListClear);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ListCommand>, ListCommandFactory>(
                CommandNames.ReservedSlotsListList);
            this.ServiceLocator
                .RegisterNamedService<ICommandFactory<AggressiveJoinCommand>, AggressiveJoinCommandFactory>(
                    CommandNames.ReservedSlotsListAggressiveJoin);

            #endregion

            #region Ban List

            this.ServiceLocator
                .RegisterNamedService<ICommandFactory<Command.BanList.LoadCommand>,
                    CommandFactory.BanList.LoadCommandFactory>(CommandNames.BanListLoad);
            this.ServiceLocator
                .RegisterNamedService
                <ICommandFactory<Command.BanList.SaveCommand>, CommandFactory.BanList.SaveCommandFactory>(
                    CommandNames.BanListSave);
            this.ServiceLocator
                .RegisterNamedService
                <ICommandFactory<Command.BanList.AddCommand>, CommandFactory.BanList.AddCommandFactory>(
                    CommandNames.BanListAdd);
            this.ServiceLocator
                .RegisterNamedService
                <ICommandFactory<Command.BanList.RemoveCommand>, CommandFactory.BanList.RemoveCommandFactory>(
                    CommandNames.BanListRemove);
            this.ServiceLocator
                .RegisterNamedService
                <ICommandFactory<Command.BanList.ClearCommand>, CommandFactory.BanList.ClearCommandFactory>(
                    CommandNames.BanListClear);
            this.ServiceLocator
                .RegisterNamedService
                <ICommandFactory<Command.BanList.ListCommand>, CommandFactory.BanList.ListCommandFactory>(
                    CommandNames.BanListClear);

            #endregion

            #region Not Authenticated Commands

            #endregion
        }
    }
}