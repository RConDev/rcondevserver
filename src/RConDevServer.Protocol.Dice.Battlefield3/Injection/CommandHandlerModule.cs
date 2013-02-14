namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using CommandHandler;
    using CommandHandler.Admin;
    using CommandHandler.BanList;
    using CommandHandler.MapList;
    using CommandHandler.NotAuthenticated;
    using CommandHandler.ReservedSlots;
    using CommandHandler.Vars;
    using Interface;
    using Ninject.Modules;

    /// <summary>
    /// the ninject module responsible for putting all <see cref="IHandleClientCommands"/> instances together
    /// </summary>
    public class CommandHandlerModule : NinjectModule
    {
        public IServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        /// creates a new <see cref="CommandHandlerModule"/> instance
        /// </summary>
        /// <param name="serviceLocator"></param>
        public CommandHandlerModule(IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        /// <summary>
        ///     Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            #region Admin

            this.Bind<IHandleClientCommands>().To<AdminEffectiveMaxPlayersCommandHandler>().Named(CommandNames.AdminEffectiveMaxPlayers);
            this.Bind<IHandleClientCommands>().To<AdminEventsEnabledCommandHandler>().Named(CommandNames.AdminEventsEnabled);
            this.Bind<IHandleClientCommands>().To<AdminHelpCommandHandler>().Named(CommandNames.AdminHelp);
            this.Bind<IHandleClientCommands>().To<AdminKickPlayerCommandHandler>().Named(CommandNames.AdminKickPlayer);
            this.Bind<IHandleClientCommands>().To<AdminKillPlayerCommandHandler>().Named(CommandNames.AdminKillPlayer);
            this.Bind<IHandleClientCommands>().To<AdminListPlayersCommandHandler>().Named(CommandNames.AdminListPlayers);
            this.Bind<IHandleClientCommands>().To<AdminMovePlayerCommandHandler>().Named(CommandNames.AdminMovePlayer);
            this.Bind<IHandleClientCommands>().To<AdminSayCommandHandler>().Named(CommandNames.AdminSay);
            this.Bind<IHandleClientCommands>().To<AdminYellCommandHandler>().Named(CommandNames.AdminYell);

            #endregion

            #region BanList

            this.Bind<IHandleClientCommands>().To<BanListAddCommandHandler>().Named(CommandNames.BanListAdd);
            this.Bind<IHandleClientCommands>().To<BanListClearCommandHandler>().Named(CommandNames.BanListClear);
            this.Bind<IHandleClientCommands>().To<BanListListCommandHandler>().Named(CommandNames.BanListList);
            this.Bind<IHandleClientCommands>().To<BanListLoadCommandHandler>().Named(CommandNames.BanListLoad);
            this.Bind<IHandleClientCommands>().To<BanListRemoveCommandHandler>().Named(CommandNames.BanListRemove);
            this.Bind<IHandleClientCommands>().To<BanListSaveCommandHandler>().Named(CommandNames.BanListSave);

            #endregion

            #region MapList

            this.Bind<IHandleClientCommands>().To<MapListAddCommandHandler>().Named(CommandNames.MapListAdd);
            this.Bind<IHandleClientCommands>().To<MapListClearCommandHandler>().Named(CommandNames.MapListClear);
            this.Bind<IHandleClientCommands>().To<MapListEndRoundCommandHandler>().Named(CommandNames.MapListEndRound);
            this.Bind<IHandleClientCommands>().To<MapListGetMapIndicesCommandHandler>().Named(CommandNames.MapListGetMapIndices);
            this.Bind<IHandleClientCommands>().To<MapListGetRoundsCommandHandler>().Named(CommandNames.MapListGetRounds);
            this.Bind<IHandleClientCommands>().To<MapListListCommandHandler>().Named(CommandNames.MapListList);
            this.Bind<IHandleClientCommands>().To<MapListLoadCommandHandler>().Named(CommandNames.MapListLoad);
            this.Bind<IHandleClientCommands>().To<MapListRemoveCommandHandler>().Named(CommandNames.MapListRemove);
            this.Bind<IHandleClientCommands>().To<MapListRunNextRoundCommandHandler>().Named(CommandNames.MapListRunNextRound);
            this.Bind<IHandleClientCommands>().To<MapListSaveCommandHandler>().Named(CommandNames.MapListSave);
            this.Bind<IHandleClientCommands>().To<MapListSetNextMapIndexCommandHandler>().Named(CommandNames.MapListSetNextMapIndex);

            #endregion

            #region NotAuthenticated

            this.Bind<IHandleClientCommands>().To<ListPlayersCommandHandler>().Named(CommandNames.ListPlayers);
            this.Bind<IHandleClientCommands>().To<LoginHashedHandler>().Named(CommandNames.LoginHashed);
            this.Bind<IHandleClientCommands>().To<LoginPlainTextHandler>().Named(CommandNames.LoginPlainText);
            this.Bind<IHandleClientCommands>().To<LogoutCommandHandler>().Named(CommandNames.Logout);
            this.Bind<IHandleClientCommands>().To<QuitCommandHandler>().Named(CommandNames.Quit);
            this.Bind<IHandleClientCommands>().ToConstructor<ServerInfoCommandHandler>(
                x => new ServerInfoCommandHandler(this.ServiceLocator)).Named(CommandNames.ServerInfo);
            this.Bind<IHandleClientCommands>().To<VersionCommandHandler>().Named(CommandNames.Version);

            #endregion

            #region ReservedSlotsList

            this.Bind<IHandleClientCommands>().To<ReservedSlotsListAddCommandHandler>().Named(CommandNames.ReservedSlotsListAdd);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListAggressiveJoinCommandHandler>().Named(CommandNames.ReservedSlotsListAggressiveJoin);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListClearCommandHandler>().Named(CommandNames.ReservedSlotsListClear);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListListCommandHandler>().Named(CommandNames.ReservedSlotsListList);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListLoadCommandHandler>().Named(CommandNames.ReservedSlotsListLoad);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListRemoveCommandHandler>().Named(CommandNames.ReservedSlotsListRemove);
            this.Bind<IHandleClientCommands>().To<ReservedSlotsListSaveCommandHandler>().Named(CommandNames.ReservedSlotsListSave);
            
            #endregion

            #region Vars

            this.Bind<IHandleClientCommands>().To<Vars3DSpottingCommandHandler>().Named(CommandNames.Vars3DSpotting);
            this.Bind<IHandleClientCommands>().To<Vars3PCamCommandHandler>().Named(CommandNames.Vars3PCam);
            this.Bind<IHandleClientCommands>().To<VarsAutoBalanceCommandHandler>().Named(CommandNames.VarsAutoBalance);
            this.Bind<IHandleClientCommands>().To<VarsBulletDamageCommandHandler>().Named(CommandNames.VarsBulletDamage);
            this.Bind<IHandleClientCommands>().To<VarsCrossHairCommandHandler>().Named(CommandNames.VarsCrossHair);
            this.Bind<IHandleClientCommands>().To<VarsFriendlyFireCommandHandler>().Named(CommandNames.VarsFriendlyFire);
            this.Bind<IHandleClientCommands>().To<VarsGameModeCounterCommandHandler>().Named(CommandNames.VarsGameModeCounter);
            this.Bind<IHandleClientCommands>().To<VarsGamePasswordCommandHandler>().Named(CommandNames.VarsGamePassword);
            this.Bind<IHandleClientCommands>().To<VarsHudCommandHandler>().Named(CommandNames.VarsHud);
            this.Bind<IHandleClientCommands>().To<VarsIdleBanRoundsCommandHandler>().Named(CommandNames.VarsIdleBanRounds);
            this.Bind<IHandleClientCommands>().To<VarsIdleTimeoutCommandHandler>().Named(CommandNames.VarsIdleTimeout);
            this.Bind<IHandleClientCommands>().To<VarsKillCamCommandHandler>().Named(CommandNames.VarsKillCam);
            this.Bind<IHandleClientCommands>().To<VarsMaxPlayersCommandHandler>().Named(CommandNames.VarsMaxPlayers);
            this.Bind<IHandleClientCommands>().To<VarsMiniMapCommandHandler>().Named(CommandNames.VarsMiniMap);
            this.Bind<IHandleClientCommands>().To<VarsMiniMapSpottingCommandHandler>().Named(CommandNames.VarsMiniMapSpotting);
            this.Bind<IHandleClientCommands>().To<VarsNameTagCommandHandler>().Named(CommandNames.VarsNameTag);
            this.Bind<IHandleClientCommands>().To<VarsOnlySquadLeaderSpawnCommandHandler>().Named(CommandNames.VarsOnlySquadLeaderSpawn);
            this.Bind<IHandleClientCommands>().To<VarsPlayerManDownTimeCommandHandler>().Named(CommandNames.VarsPlayerManDownTime);
            this.Bind<IHandleClientCommands>().To<VarsPlayerRespawnTimeCommandHandler>().Named(CommandNames.VarsPlayerRespawnTime);
            this.Bind<IHandleClientCommands>().To<VarsPremiumStatusCommandHandler>().Named(CommandNames.VarsPremiumStatus);
            this.Bind<IHandleClientCommands>().To<VarsRankedCommandHandler>().Named(CommandNames.VarsRanked);
            this.Bind<IHandleClientCommands>().To<VarsRegenerateHealthCommandHandler>().Named(CommandNames.VarsRegenerateHealth);
            this.Bind<IHandleClientCommands>().To<VarsRoundLockdownCountdownCommandHandler>().Named(CommandNames.VarsRoundLockdownCountdown);
            this.Bind<IHandleClientCommands>().To<VarsRoundRestartPlayerCountCommandHandler>().Named(CommandNames.VarsRoundRestartPlayerCount);
            this.Bind<IHandleClientCommands>().To<VarsRoundStartPlayerCountCommandHandler>().Named(CommandNames.VarsRoundStartPlayerCount);
            this.Bind<IHandleClientCommands>().To<VarsServerDescriptionCommandHandler>().Named(CommandNames.VarsServerDescription);
            this.Bind<IHandleClientCommands>().To<VarsServerMessageCommandHandler>().Named(CommandNames.VarsServerMessage);
            this.Bind<IHandleClientCommands>().To<VarsServerNameCommandHandler>().Named(CommandNames.VarsServerName);
            this.Bind<IHandleClientCommands>().To<VarsSoldierHealthCommandHandler>().Named(CommandNames.VarsSoldierHealth);
            this.Bind<IHandleClientCommands>().To<VarsTeamKillCountForKickCommandHandler>().Named(CommandNames.VarsTeamKillCountForKick);
            this.Bind<IHandleClientCommands>().To<VarsTeamKillKickForBanCommandHandler>().Named(CommandNames.VarsTeamKillKickForBan);
            this.Bind<IHandleClientCommands>().To<VarsTeamKillValueDecreaseCommandHandler>().Named(CommandNames.VarsTeamKillValueDecreasePerSecond);
            this.Bind<IHandleClientCommands>().To<VarsTeamKillValueForKickCommandHandler>().Named(CommandNames.VarsTeamKillValueForKick);
            this.Bind<IHandleClientCommands>().To<VarsTeamKillValueIncreaseCommandHandler>().Named(CommandNames.VarsTeamKillValueIncrease);
            this.Bind<IHandleClientCommands>().To<VarsUnlockModeCommandHandler>().Named(CommandNames.VarsUnlockMode);
            this.Bind<IHandleClientCommands>().To<VarsVehicleSpawnAllowedCommandHandler>().Named(CommandNames.VarsVehicleSpawnAllowed);
            this.Bind<IHandleClientCommands>().To<VarsVehicleSpawnDelayCommandHandler>().Named(CommandNames.VarsVehicleSpawnDelay);
            this.Bind<IHandleClientCommands>().To<VarsGunMasterWeaponsPresetCommandHandler>().Named(CommandNames.VarsGunMasterWeaponsPreset);

            #endregion
        }
    }
}