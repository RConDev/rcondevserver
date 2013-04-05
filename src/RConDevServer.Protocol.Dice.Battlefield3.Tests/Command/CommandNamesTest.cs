namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CommandNamesTest
    {
        #region GetAll()

        [Test]
        public void GetAll_ReturnsAllCommands()
        {
            var commands = CommandNames.GetAll();
            var expected = new[]
                {
                    CommandNames.AdminEffectiveMaxPlayers,
                    CommandNames.AdminEventsEnabled,
                    CommandNames.AdminHelp,
                    CommandNames.AdminKickPlayer,
                    CommandNames.AdminKillPlayer,
                    CommandNames.AdminListPlayers,
                    CommandNames.AdminMovePlayer,
                    CommandNames.AdminSay,
                    CommandNames.AdminYell,
                    CommandNames.BanListAdd,
                    CommandNames.BanListClear,
                    CommandNames.BanListList,
                    CommandNames.BanListLoad,
                    CommandNames.BanListRemove,
                    CommandNames.BanListSave,
                    CommandNames.ListPlayers,
                    CommandNames.LoginHashed,
                    CommandNames.LoginPlainText,
                    CommandNames.Logout,
                    CommandNames.MapListAdd,
                    CommandNames.MapListAvailableMaps,
                    CommandNames.MapListClear,
                    CommandNames.MapListEndRound,
                    CommandNames.MapListGetMapIndices,
                    CommandNames.MapListGetRounds,
                    CommandNames.MapListList,
                    CommandNames.MapListLoad,
                    CommandNames.MapListRemove,
                    CommandNames.MapListRestartRound,
                    CommandNames.MapListRunNextRound,
                    CommandNames.MapListSave,
                    CommandNames.MapListSetNextMapIndex,
                    CommandNames.PunkBusterActivate,
                    CommandNames.PunkBusterIsActive,
                    CommandNames.PunkBusterPbSvCommand,
                    CommandNames.Quit,
                    CommandNames.ReservedSlotsListAdd,
                    CommandNames.ReservedSlotsListAggressiveJoin,
                    CommandNames.ReservedSlotsListClear,
                    CommandNames.ReservedSlotsListList,
                    CommandNames.ReservedSlotsListLoad,
                    CommandNames.ReservedSlotsListRemove,
                    CommandNames.ReservedSlotsListSave,
                    CommandNames.ServerInfo,
                    CommandNames.Vars3DSpotting,
                    CommandNames.Vars3PCam,
                    CommandNames.VarsAutoBalance,
                    CommandNames.VarsBulletDamage,
                    CommandNames.VarsCrossHair,
                    CommandNames.VarsFriendlyFire,
                    CommandNames.VarsGameModeCounter,
                    CommandNames.VarsGamePassword,
                    CommandNames.VarsGunMasterWeaponsPreset,
                    CommandNames.VarsHud,
                    CommandNames.VarsIdleBanRounds,
                    CommandNames.VarsIdleTimeout,
                    CommandNames.VarsKillCam,
                    CommandNames.VarsMaxPlayers,
                    CommandNames.VarsMiniMap,
                    CommandNames.VarsMiniMapSpotting,
                    CommandNames.VarsNameTag,
                    CommandNames.VarsOnlySquadLeaderSpawn,
                    CommandNames.VarsPlayerManDownTime,
                    CommandNames.VarsPlayerRespawnTime,
                    CommandNames.VarsPremiumStatus,
                    CommandNames.VarsRanked,
                    CommandNames.VarsRegenerateHealth,
                    CommandNames.VarsRoundLockdownCountdown,
                    CommandNames.VarsRoundRestartPlayerCount,
                    CommandNames.VarsRoundStartPlayerCount,
                    CommandNames.VarsServerDescription,
                    CommandNames.VarsServerMessage,
                    CommandNames.VarsServerName,
                    CommandNames.VarsSoldierHealth,
                    CommandNames.VarsTeamKillCountForKick,
                    CommandNames.VarsTeamKillKickForBan,
                    CommandNames.VarsTeamKillValueDecreasePerSecond,
                    CommandNames.VarsTeamKillValueForKick,
                    CommandNames.VarsTeamKillValueIncrease,
                    CommandNames.VarsUnlockMode,
                    CommandNames.VarsVehicleSpawnAllowed,
                    CommandNames.VarsVehicleSpawnDelay,
                    CommandNames.Version
                };
            Assert.AreEqual(expected, commands);
        }

        #endregion
    }
}
