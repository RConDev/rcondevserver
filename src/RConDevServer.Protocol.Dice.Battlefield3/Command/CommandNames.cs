namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    /// <summary>
    ///     Repository of command names
    /// </summary>
    public static class CommandNames
    {
        public const string MapListAvailableMaps = "mapList.availableMaps";
    
        public const string MapListEndRound = "mapList.endRound";

        public const string MapListRestartRound = "mapList.restartRound";

        public const string MapListRunNextRound = "mapList.runNextRound";

        public const string MapListGetRounds = "mapList.getRounds";

        public const string MapListGetMapIndices = "mapList.getMapIndices";

        public const string MapListSetNextMapIndex = "mapList.setNextMapIndex";

        public const string MapListList = "mapList.list";

        public const string MapListClear = "mapList.clear";

        public const string MapListRemove = "mapList.remove";

        public const string MapListAdd = "mapList.add";

        public const string MapListSave = "mapList.save";

        public const string MapListLoad = "mapList.load";

        #region Admin

        /// <summary>
        ///     Query the effective maximum number of players
        /// </summary>
        public const string AdminEffectiveMaxPlayers = "admin.effectiveMaxPlayers";

        public const string AdminEventsEnabled = "admin.eventsEnabled";

        public const string AdminHelp = "admin.help";

        public const string AdminKickPlayer = "admin.kickPlayer";

        public const string AdminKillPlayer = "admin.killPlayer";

        public const string AdminListPlayers = "admin.listPlayers";

        public const string AdminMovePlayer = "admin.movePlayer";

        public const string AdminSay = "admin.say";

        public const string AdminYell = "admin.yell";

        #endregion

        #region Ban List

        public const string BanListAdd = "banList.add";

        public const string BanListClear = "banList.clear";

        public const string BanListList = "banList.list";

        public const string BanListLoad = "banList.load";

        public const string BanListRemove = "banList.remove";

        public const string BanListSave = "banList.save";

        #endregion
       
        public const string VarsRanked = "vars.ranked";

        public const string PunkBusterPbSvCommand = "punkBuster.pb_sv_command";

        public const string PunkBusterActivate = "punkBuster.activate";

        public const string PunkBusterIsActive = "punkBuster.isActive";

        public const string ServerInfo = "serverInfo";

        public const string ListPlayers = "listPlayers";

        public const string Version = "version";

        public const string Quit = "quit";

        public const string Logout = "logout";

        public const string LoginHashed = "login.hashed";

        public const string LoginPlainText = "login.plainText";

        public const string ReservedSlotsListAdd = "reservedSlotsList.add";

        public const string ReservedSlotsListAggressiveJoin = "reservedSlotsList.aggressiveJoin";

        public const string ReservedSlotsListClear = "reservedSlotsList.clear";

        public const string ReservedSlotsListList = "reservedSlotsList.list";

        public const string ReservedSlotsListLoad = "reservedSlotsList.load";

        public const string ReservedSlotsListRemove = "reservedSlotsList.remove";
        
        public const string ReservedSlotsListSave = "reservedSlotsList.save";


    
    }
}