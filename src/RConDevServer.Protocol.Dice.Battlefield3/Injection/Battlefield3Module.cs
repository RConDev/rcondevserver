namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using CommandFactory;
    using CommandFactory.Admin;
    using CommandFactory.BanList;
    using CommandFactory.MapList;
    using CommandFactory.ReservedSlotsList;
    using CommandFactory.Vars;
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
            this.RegisterCommandFactories();
        }

        public IServiceLocator ServiceLocator { get; private set; }

        private void RegisterCommandFactories()
        {
            #region Admin Commands

            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, EventsEnabledCommandFactory>
                (CommandNames.AdminEventsEnabled);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, HelpCommandFactory>(
                CommandNames.AdminHelp);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, KickPlayerCommandFactory>(
                CommandNames.AdminKickPlayer);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ListPlayersCommandFactory>(
                CommandNames.AdminListPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, SayCommandFactory>(
                CommandNames.AdminSay);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, YellCommandFactory>(
                CommandNames.AdminYell);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, EffectiveMaxPlayersCommandFactory>(
                CommandNames.AdminEffectiveMaxPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MovePlayerCommandFactory>(
                CommandNames.AdminMovePlayer);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, KillPlayerCommandFactory>(
                CommandNames.AdminKillPlayer);

            #endregion

            #region Reserved Slots

            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListLoadCommandFactory>(
                CommandNames.ReservedSlotsListLoad);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListSaveCommandFactory>(
                CommandNames.ReservedSlotsListSave);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListAddCommandFactory>(
                CommandNames.ReservedSlotsListAdd);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListRemoveCommandFactory>(
                CommandNames.ReservedSlotsListRemove);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListClearCommandFactory>(
                CommandNames.ReservedSlotsListClear);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListListCommandFactory>(
                CommandNames.ReservedSlotsListList);
            this.ServiceLocator
                .RegisterNamedService<ICommandFactory<ICommand>, ReservedSlotsListAggressiveJoinCommandFactory>(
                    CommandNames.ReservedSlotsListAggressiveJoin);

            #endregion

            #region Ban List

            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListLoadCommandFactory>(
                CommandNames.BanListLoad);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListSaveCommandFactory>(
                CommandNames.BanListSave);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListAddCommandFactory>(
                CommandNames.BanListAdd);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListRemoveCommandFactory>(
                CommandNames.BanListRemove);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListClearCommandFactory>(
                CommandNames.BanListClear);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, BanListListCommandFactory>(
                CommandNames.BanListClear);

            #endregion

            #region Map List

            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListLoadCommandFactory>(
                CommandNames.MapListLoad);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListSaveCommandFactory>(
                CommandNames.MapListSave);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListAddCommandFactory>(
                CommandNames.MapListAdd);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListRemoveCommandFactory>
                (CommandNames.MapListRemove);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListListCommandFactory>(
                CommandNames.MapListList);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListSetNextMapIndexCommandFactory>(
                CommandNames.MapListSetNextMapIndex);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListGetMapIndicesCommandFactory>(
                CommandNames.MapListGetMapIndices);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListGetRoundsCommandFactory>(
                CommandNames.MapListGetRounds);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListRunNextRoundCommandFactory>(
                CommandNames.MapListRunNextRound);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListRestartRoundCommandFactory>(
                CommandNames.MapListRestartRound);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListEndRoundCommandFactory>(
                CommandNames.MapListEndRound);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, MapListAvailableMapsCommandFactory>(
                CommandNames.MapListAvailableMaps);

            #endregion

            #region Vars

            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsRankedCommandFactory>(
                CommandNames.VarsRanked);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsServerNameCommandFactory>(
                CommandNames.VarsServerName);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsGamePasswordCommandFactory>(
                CommandNames.VarsGamePassword);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsAutoBalanceCommandFactory>(
                CommandNames.VarsAutoBalance);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsFriendlyFireCommandFactory>(
                CommandNames.VarsFriendlyFire);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsMaxPlayersCommandFactory>(
                CommandNames.VarsMaxPlayers);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsServerDescriptionCommandFactory>(
                CommandNames.VarsServerDescription);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsServerMessageCommandFactory>(
                CommandNames.VarsServerMessage);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsKillCamCommandFactory>(
                CommandNames.VarsKillCam);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsMiniMapCommandFactory>(
                CommandNames.VarsMiniMap);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsHudCommandFactory>(
                CommandNames.VarsHud);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsCrossHairCommandFactory>(
                CommandNames.VarsCrossHair);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, Vars3DSpottingCommandFactory>(
                CommandNames.Vars3DSpotting);
            this.ServiceLocator.RegisterNamedService<ICommandFactory<ICommand>, VarsMiniMapSpottingCommandFactory>(
                CommandNames.VarsMiniMapSpotting);

            #endregion

            #region Not Authenticated Commands

            #endregion
        }
    }
}