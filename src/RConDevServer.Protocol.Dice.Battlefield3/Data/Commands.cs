﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.Collections.Generic;

    public class Commands : List<string>
    {
        public Commands()
        {
            var list = new List<string>
                {
                    "admin.eventsEnabled",
                    "admin.help",
                    "admin.kickPlayer",
                    "admin.killPlayer",
                    "admin.listPlayers",
                    "admin.movePlayer",
                    "admin.password",
                    "admin.say",
                    "admin.shutDown",
                    "admin.teamSwitchPlayer",
                    "admin.yell",
                    "banList.add",
                    "banList.clear",
                    "banList.list",
                    "banList.load",
                    "banList.remove",
                    "banList.save",
                    "currentLevel",
                    "gameAdmin.add",
                    "gameAdmin.clear",
                    "gameAdmin.list",
                    "gameAdmin.load",
                    "gameAdmin.remove",
                    "gameAdmin.save",
                    "listPlayers",
                    "login.hashed",
                    "login.plainText",
                    "logout",
                    "mapList.add",
                    "mapList.availableMaps",
                    "mapList.clear",
                    "mapList.endRound",
                    "mapList.getMapIndices",
                    "mapList.getRounds",
                    "mapList.list",
                    "mapList.load",
                    "mapList.remove",
                    "mapList.restartRound",
                    "mapList.runNextRound",
                    "mapList.save",
                    "mapList.setNextMapIndex",
                    "punkBuster.activate",
                    "punkBuster.isActive",
                    "punkBuster.pb_sv_command",
                    "quit",
                    "reservedSlotsList.add",
                    "reservedSlotsList.aggressiveJoin",
                    "reservedSlotsList.clear",
                    "reservedSlotsList.list",
                    "reservedSlotsList.load",
                    "reservedSlotsList.remove",
                    "reservedSlotsList.save",
                    "serverInfo",
                    "unlockList.add",
                    "unlockList.clear",
                    "unlockList.list",
                    "unlockList.remove",
                    "unlockList.save",
                    "unlockList.set",
                    "vars.3dSpotting",
                    "vars.3pCam",
                    "vars.autoBalance",
                    "vars.bannerUrl",
                    "vars.bulletDamage",
                    "vars.friendlyFire",
                    "vars.gameModeCounter",
                    "vars.gamePassword",
                    "vars.hud",
                    "vars.idleBanRounds",
                    "vars.idleTimeout",
                    "vars.killCam",
                    "vars.killRotation",
                    "vars.maxPlayers",
                    "vars.minimap",
                    "vars.miniMapSpotting",
                    "vars.nameTag",
                    "vars.onlySquadLeaderSpawn",
                    "vars.playerManDownTime",
                    "vars.playerRespawnTime",
                    "vars.ranked",
                    "vars.regenerateHealth",
                    "vars.roundLockdownCountdown",
                    "vars.roundRestartPlayerCount",
                    "vars.roundsPerMap",
                    "vars.roundStartPlayerCount",
                    "vars.roundWarmupTimeout",
                    "vars.serverDescription",
                    "vars.serverMessage",
                    "vars.serverName",
                    "vars.soldierHealth",
                    "vars.teamKillCountForKick",
                    "vars.teamKillKickForBan",
                    "vars.teamKillValueDecreasePerSecond",
                    "vars.teamKillValueForKick",
                    "vars.teamKillValueIncrease",
                    "vars.unlockMode",
                    "vars.vehicleSpawnAllowed",
                    "vars.vehicleSpawnDelay",
                    "version",
                };
            this.AddRange(list);
        }
    }
}