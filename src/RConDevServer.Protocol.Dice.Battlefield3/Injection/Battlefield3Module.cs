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

            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, EventsEnabledCommandFactory>
                (CommandNames.AdminEventsEnabled);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, HelpCommandFactory>(
                CommandNames.AdminHelp);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, KickPlayerCommandFactory>(
                CommandNames.AdminKickPlayer);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ListPlayersCommandFactory>(
                CommandNames.AdminListPlayers);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, SayCommandFactory>(
                CommandNames.AdminSay);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, YellCommandFactory>(
                CommandNames.AdminYell);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, EffectiveMaxPlayersCommandFactory>(
                CommandNames.AdminEffectiveMaxPlayers);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MovePlayerCommandFactory>(
                CommandNames.AdminMovePlayer);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, KillPlayerCommandFactory>(
                CommandNames.AdminKillPlayer);

            #endregion

            #region Reserved Slots

            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListLoadCommandFactory>(
                CommandNames.ReservedSlotsListLoad);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListSaveCommandFactory>(
                CommandNames.ReservedSlotsListSave);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListAddCommandFactory>(
                CommandNames.ReservedSlotsListAdd);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListRemoveCommandFactory>(
                CommandNames.ReservedSlotsListRemove);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListClearCommandFactory>(
                CommandNames.ReservedSlotsListClear);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListListCommandFactory>(
                CommandNames.ReservedSlotsListList);
            this.ServiceLocator
                .RegisterNamedService<ISimpleCommandFactory, ReservedSlotsListAggressiveJoinCommandFactory>(
                    CommandNames.ReservedSlotsListAggressiveJoin);

            #endregion

            #region Ban List

            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListLoadCommandFactory>(
                CommandNames.BanListLoad);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListSaveCommandFactory>(
                CommandNames.BanListSave);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListAddCommandFactory>(
                CommandNames.BanListAdd);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListRemoveCommandFactory>(
                CommandNames.BanListRemove);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListClearCommandFactory>(
                CommandNames.BanListClear);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, BanListListCommandFactory>(
                CommandNames.BanListClear);

            #endregion

            #region Map List

            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListLoadCommandFactory>(
                CommandNames.MapListLoad);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListSaveCommandFactory>(
                CommandNames.MapListSave);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListAddCommandFactory>(
                CommandNames.MapListAdd);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListRemoveCommandFactory>
                (CommandNames.MapListRemove);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListListCommandFactory>(
                CommandNames.MapListList);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListSetNextMapIndexCommandFactory>(
                CommandNames.MapListSetNextMapIndex);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListGetMapIndicesCommandFactory>(
                CommandNames.MapListGetMapIndices);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListGetRoundsCommandFactory>(
                CommandNames.MapListGetRounds);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListRunNextRoundCommandFactory>(
                CommandNames.MapListRunNextRound);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListRestartRoundCommandFactory>(
                CommandNames.MapListRestartRound);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListEndRoundCommandFactory>(
                CommandNames.MapListEndRound);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, MapListAvailableMapsCommandFactory>(
                CommandNames.MapListAvailableMaps);

            #endregion

            #region Vars

            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsRankedCommandFactory>(
                CommandNames.VarsRanked);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsServerNameCommandFactory>(
                CommandNames.VarsServerName);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsGamePasswordCommandFactory>(
                CommandNames.VarsGamePassword);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsAutoBalanceCommandFactory>(
                CommandNames.VarsAutoBalance);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsFriendlyFireCommandFactory>(
                CommandNames.VarsFriendlyFire);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsMaxPlayersCommandFactory>(
                CommandNames.VarsMaxPlayers);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsServerDescriptionCommandFactory>(
                CommandNames.VarsServerDescription);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsServerMessageCommandFactory>(
                CommandNames.VarsServerMessage);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsKillCamCommandFactory>(
                CommandNames.VarsKillCam);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsMiniMapCommandFactory>(
                CommandNames.VarsMiniMap);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsHudCommandFactory>(
                CommandNames.VarsHud);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsCrossHairCommandFactory>(
                CommandNames.VarsCrossHair);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, Vars3DSpottingCommandFactory>(
                CommandNames.Vars3DSpotting);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsMiniMapSpottingCommandFactory>(
                CommandNames.VarsMiniMapSpotting);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsNameTagCommandFactory>(
                CommandNames.VarsNameTag);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, Vars3PCamCommandFactory>(
                CommandNames.Vars3PCam);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsRegenerateHealthCommandFactory>(
                CommandNames.VarsRegenerateHealth);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsTeamKillCountForKickCommandFactory>(
                CommandNames.VarsTeamKillCountForKick);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsTeamKillValueForKickCommandFactory>(
                CommandNames.VarsTeamKillValueForKick);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsTeamKillValueIncreaseCommandFactory>
                (
                    CommandNames.VarsTeamKillValueIncrease);
            this.ServiceLocator
                .RegisterNamedService<ISimpleCommandFactory, VarsTeamKillValueDecreasePerSecondCommandFactory>(
                    CommandNames.VarsTeamKillValueDecreasePerSecond);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsIdleTimeoutCommandFactory>(
                CommandNames.VarsIdleTimeout);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsTeamKillKickForBanCommandFactory>(
                CommandNames.VarsTeamKillKickForBan);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsIdleBanRoundsCommandFactory>(
                CommandNames.VarsIdleBanRounds);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsRoundStartPlayerCountCommandFactory>
                (
                    CommandNames.VarsRoundRestartPlayerCount);
            this.ServiceLocator
                .RegisterNamedService<ISimpleCommandFactory, VarsRoundRestartPlayerCountCommandFactory>(
                    CommandNames.VarsRoundRestartPlayerCount);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsVehicleSpawnAllowedCommandFactory>(
                CommandNames.VarsVehicleSpawnAllowed);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsVehicleSpawnDelayCommandFactory>(
                CommandNames.VarsVehicleSpawnDelay);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsSoldierHealthCommandFactory>(
                CommandNames.VarsSoldierHealth);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsPlayerRespawnTimeCommandFactory>(
                CommandNames.VarsPlayerRespawnTime);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsPlayerManDownTimeCommandFactory>(
                CommandNames.VarsPlayerManDownTime);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsBulletDamageCommandFactory>(
                CommandNames.VarsBulletDamage);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsGameModeCounterCommandFactory>(
                CommandNames.VarsGameModeCounter);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsOnlySquadLeaderSpawnCommandFactory>(
                CommandNames.VarsOnlySquadLeaderSpawn);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsUnlockModeCommandFactory>(
                CommandNames.VarsUnlockMode);
            this.ServiceLocator.RegisterNamedService<ISimpleCommandFactory, VarsPremiumStatusCommandFactory>(
                CommandNames.VarsPremiumStatus);
            this.ServiceLocator
                .RegisterNamedService<ISimpleCommandFactory, VarsGunMasterWeaponsPresetCommandFactory>(
                    CommandNames.VarsGunMasterWeaponsPreset);

            #endregion

            #region Not Authenticated Commands

            #endregion
        }
    }
}