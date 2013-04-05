namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using CommandFactory;
    using CommandFactory.Admin;
    using CommandFactory.BanList;
    using CommandFactory.MapList;
    using CommandFactory.NotAuthenticated;
    using CommandFactory.PunkBuster;
    using CommandFactory.ReservedSlotsList;
    using CommandFactory.Vars;
    using Ninject.Modules;
    using ListPlayersCommandFactory = CommandFactory.NotAuthenticated.ListPlayersCommandFactory;

    public class CommandFactoryModule : NinjectModule
    {
        /// <summary>
        ///     Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            #region NotAuthenticated

            this.Bind<ISimpleCommandFactory>().To<VersionCommandFactory>().Named(CommandNames.Version);
            this.Bind<ISimpleCommandFactory>().To<ListPlayersCommandFactory>().Named(CommandNames.ListPlayers);
            this.Bind<ISimpleCommandFactory>().To<LoginHashedCommandFactory>().Named(CommandNames.LoginHashed);
            this.Bind<ISimpleCommandFactory>().To<LoginPlainTextCommandFactory>().Named(CommandNames.LoginPlainText);
            this.Bind<ISimpleCommandFactory>().To<LogoutCommandFactory>().Named(CommandNames.Logout);
            this.Bind<ISimpleCommandFactory>().To<QuitCommandFactory>().Named(CommandNames.Quit);
            this.Bind<ISimpleCommandFactory>().To<ServerInfoCommandFactory>().Named(CommandNames.ServerInfo);

            #endregion

            #region Admin

            this.Bind<ISimpleCommandFactory>()
                .To<EffectiveMaxPlayersCommandFactory>()
                .Named(CommandNames.AdminEffectiveMaxPlayers);
            this.Bind<ISimpleCommandFactory>().To<AdminEventsEnabledCommandFactory>().Named(CommandNames.AdminEventsEnabled);
            this.Bind<ISimpleCommandFactory>().To<HelpCommandFactory>().Named(CommandNames.AdminHelp);
            this.Bind<ISimpleCommandFactory>().To<AdminKickPlayerCommandFactory>().Named(CommandNames.AdminKickPlayer);
            this.Bind<ISimpleCommandFactory>().To<KillPlayerCommandFactory>().Named(CommandNames.AdminKillPlayer);
            this.Bind<ISimpleCommandFactory>()
                .To<CommandFactory.Admin.ListPlayersCommandFactory>()
                .Named(CommandNames.AdminListPlayers);
            this.Bind<ISimpleCommandFactory>().To<MovePlayerCommandFactory>().Named(CommandNames.AdminMovePlayer);
            this.Bind<ISimpleCommandFactory>().To<SayCommandFactory>().Named(CommandNames.AdminSay);
            this.Bind<ISimpleCommandFactory>().To<YellCommandFactory>().Named(CommandNames.AdminYell);

            #endregion

            #region BanList

            this.Bind<ISimpleCommandFactory>().To<BanListAddCommandFactory>().Named(CommandNames.BanListAdd);
            this.Bind<ISimpleCommandFactory>().To<BanListClearCommandFactory>().Named(CommandNames.BanListClear);
            this.Bind<ISimpleCommandFactory>().To<BanListListCommandFactory>().Named(CommandNames.BanListList);
            this.Bind<ISimpleCommandFactory>().To<BanListLoadCommandFactory>().Named(CommandNames.BanListLoad);
            this.Bind<ISimpleCommandFactory>().To<BanListRemoveCommandFactory>().Named(CommandNames.BanListRemove);
            this.Bind<ISimpleCommandFactory>().To<BanListSaveCommandFactory>().Named(CommandNames.BanListSave);

            #endregion

            #region MapList

            this.Bind<ISimpleCommandFactory>().To<MapListAddCommandFactory>().Named(CommandNames.MapListAdd);
            this.Bind<ISimpleCommandFactory>()
                .To<MapListAvailableMapsCommandFactory>()
                .Named(CommandNames.MapListAvailableMaps);
            this.Bind<ISimpleCommandFactory>().To<MapListClearCommandFactory>().Named(CommandNames.MapListClear);
            this.Bind<ISimpleCommandFactory>().To<MapListEndRoundCommandFactory>().Named(CommandNames.MapListEndRound);
            this.Bind<ISimpleCommandFactory>()
                .To<MapListGetMapIndicesCommandFactory>()
                .Named(CommandNames.MapListGetMapIndices);
            this.Bind<ISimpleCommandFactory>().To<MapListGetRoundsCommandFactory>().Named(CommandNames.MapListGetRounds);
            this.Bind<ISimpleCommandFactory>().To<MapListListCommandFactory>().Named(CommandNames.MapListList);
            this.Bind<ISimpleCommandFactory>().To<MapListLoadCommandFactory>().Named(CommandNames.MapListLoad);
            this.Bind<ISimpleCommandFactory>().To<MapListRemoveCommandFactory>().Named(CommandNames.MapListRemove);
            this.Bind<ISimpleCommandFactory>()
                .To<MapListRestartRoundCommandFactory>()
                .Named(CommandNames.MapListRestartRound);
            this.Bind<ISimpleCommandFactory>()
                .To<MapListRunNextRoundCommandFactory>()
                .Named(CommandNames.MapListRunNextRound);
            this.Bind<ISimpleCommandFactory>().To<MapListSaveCommandFactory>().Named(CommandNames.MapListSave);
            this.Bind<ISimpleCommandFactory>()
                .To<MapListSetNextMapIndexCommandFactory>()
                .Named(CommandNames.MapListSetNextMapIndex);

            #endregion

            #region PunkBuster

            this.Bind<ISimpleCommandFactory>()
                .To<PunkBusterActivateCommandFactory>()
                .Named(CommandNames.PunkBusterActivate);
            this.Bind<ISimpleCommandFactory>()
                .To<PunkBusterIsActiveCommandFactory>()
                .Named(CommandNames.PunkBusterIsActive);
            this.Bind<ISimpleCommandFactory>()
                .To<PunkBusterPbSvCommandFactory>()
                .Named(CommandNames.PunkBusterPbSvCommand);

            #endregion

            #region ReservedSlotsList

            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListAddCommandFactory>()
                .Named(CommandNames.ReservedSlotsListAdd);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListAggressiveJoinCommandFactory>()
                .Named(CommandNames.ReservedSlotsListAggressiveJoin);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListClearCommandFactory>()
                .Named(CommandNames.ReservedSlotsListClear);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListListCommandFactory>()
                .Named(CommandNames.ReservedSlotsListList);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListLoadCommandFactory>()
                .Named(CommandNames.ReservedSlotsListLoad);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListRemoveCommandFactory>()
                .Named(CommandNames.ReservedSlotsListRemove);
            this.Bind<ISimpleCommandFactory>()
                .To<ReservedSlotsListSaveCommandFactory>()
                .Named(CommandNames.ReservedSlotsListSave);

            #endregion

            #region Vars

            this.Bind<ISimpleCommandFactory>().To<Vars3DSpottingCommandFactory>().Named(CommandNames.Vars3DSpotting);
            this.Bind<ISimpleCommandFactory>().To<Vars3PCamCommandFactory>().Named(CommandNames.Vars3PCam);
            this.Bind<ISimpleCommandFactory>().To<VarsAutoBalanceCommandFactory>().Named(CommandNames.VarsAutoBalance);
            this.Bind<ISimpleCommandFactory>().To<VarsBulletDamageCommandFactory>().Named(CommandNames.VarsBulletDamage);
            this.Bind<ISimpleCommandFactory>().To<VarsCrossHairCommandFactory>().Named(CommandNames.VarsCrossHair);
            this.Bind<ISimpleCommandFactory>().To<VarsFriendlyFireCommandFactory>().Named(CommandNames.VarsFriendlyFire);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsGameModeCounterCommandFactory>()
                .Named(CommandNames.VarsGameModeCounter);
            this.Bind<ISimpleCommandFactory>().To<VarsGamePasswordCommandFactory>().Named(CommandNames.VarsGamePassword);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsGunMasterWeaponsPresetCommandFactory>()
                .Named(CommandNames.VarsGunMasterWeaponsPreset);
            this.Bind<ISimpleCommandFactory>().To<VarsHudCommandFactory>().Named(CommandNames.VarsHud);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsIdleBanRoundsCommandFactory>()
                .Named(CommandNames.VarsIdleBanRounds);
            this.Bind<ISimpleCommandFactory>().To<VarsIdleTimeoutCommandFactory>().Named(CommandNames.VarsIdleTimeout);
            this.Bind<ISimpleCommandFactory>().To<VarsKillCamCommandFactory>().Named(CommandNames.VarsKillCam);
            this.Bind<ISimpleCommandFactory>().To<VarsMaxPlayersCommandFactory>().Named(CommandNames.VarsMaxPlayers);
            this.Bind<ISimpleCommandFactory>().To<VarsMiniMapCommandFactory>().Named(CommandNames.VarsMiniMap);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsMiniMapSpottingCommandFactory>()
                .Named(CommandNames.VarsMiniMapSpotting);
            this.Bind<ISimpleCommandFactory>().To<VarsNameTagCommandFactory>().Named(CommandNames.VarsNameTag);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsOnlySquadLeaderSpawnCommandFactory>()
                .Named(CommandNames.VarsOnlySquadLeaderSpawn);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsPlayerManDownTimeCommandFactory>()
                .Named(CommandNames.VarsPlayerManDownTime);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsPlayerRespawnTimeCommandFactory>()
                .Named(CommandNames.VarsPlayerRespawnTime);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsPremiumStatusCommandFactory>()
                .Named(CommandNames.VarsPremiumStatus);
            this.Bind<ISimpleCommandFactory>().To<VarsRankedCommandFactory>().Named(CommandNames.VarsRanked);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsRegenerateHealthCommandFactory>()
                .Named(CommandNames.VarsRegenerateHealth);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsRoundRestartPlayerCountCommandFactory>()
                .Named(CommandNames.VarsRoundRestartPlayerCount);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsRoundStartPlayerCountCommandFactory>()
                .Named(CommandNames.VarsRoundStartPlayerCount);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsServerDescriptionCommandFactory>()
                .Named(CommandNames.VarsServerDescription);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsServerMessageCommandFactory>()
                .Named(CommandNames.VarsServerMessage);
            this.Bind<ISimpleCommandFactory>().To<VarsServerNameCommandFactory>().Named(CommandNames.VarsServerName);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsSoldierHealthCommandFactory>()
                .Named(CommandNames.VarsSoldierHealth);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsTeamKillCountForKickCommandFactory>()
                .Named(CommandNames.VarsTeamKillCountForKick);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsTeamKillKickForBanCommandFactory>()
                .Named(CommandNames.VarsTeamKillKickForBan);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsTeamKillValueDecreasePerSecondCommandFactory>()
                .Named(CommandNames.VarsTeamKillValueDecreasePerSecond);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsTeamKillValueForKickCommandFactory>()
                .Named(CommandNames.VarsTeamKillValueForKick);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsTeamKillValueIncreaseCommandFactory>()
                .Named(CommandNames.VarsTeamKillValueIncrease);
            this.Bind<ISimpleCommandFactory>().To<VarsUnlockModeCommandFactory>().Named(CommandNames.VarsUnlockMode);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsVehicleSpawnAllowedCommandFactory>()
                .Named(CommandNames.VarsVehicleSpawnAllowed);
            this.Bind<ISimpleCommandFactory>()
                .To<VarsVehicleSpawnDelayCommandFactory>()
                .Named(CommandNames.VarsVehicleSpawnDelay);

            #endregion
        }
    }
}