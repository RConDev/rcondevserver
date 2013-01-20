namespace RConDevServer.Protocol.Dice.Battlefield3
{
    public static class Constants
    {
        public const string PROTOCOL_CODE = "BF3";
        public const string PROTOCOL_NAME = "Battlefield 3";
        public const string PROTOCOL_VERSION = "R29";
        public const string PROTOCOL_BUILD_NUM = "1000930";

        public const string DEFAULT_KICK_REASON = "Kicked by administrator";

        #region Response Values

        public const string RESPONSE_SUCCESS = "OK";
        public const string RESPONSE_INVALID_ARGUMENTS = "InvalidArguments";
        public const string RESPONSE_UNKNOWN_COMMAND = "UnknownCommand";
        public const string RESPONSE_TOO_LONG_NAME = "TooLongName";
        public const string RESPONSE_NOT_FOUND = "NotFound";
        public const string RESPONSE_INVALID_MAP = "InvalidMap";
        public const string RESPONSE_INVALID_GAME_MODE_ON_MAP = "InvalidGameModeOnMap";
        public const string RESPONSE_INVALID_ROUNDS_PER_MAP = "InvalidRoundsPerMap";
        public const string RESPONSE_INVALID_MAP_INDEX = "InvalidMapIndex";
        public const string RESPONSE_TOO_LONG_MESSAGE = "TooLongMessage";
        public const string RESPONSE_INVALID_TEAM = "InvalidTeam";
        public const string RESPONSE_INVALID_TEAM_ID = "InvalidTeamId";
        public const string RESPONSE_INVALID_SQUAD = "InvalidSquad";
        public const string RESPONSE_INVALID_SQUAD_ID = "InvalidSquadId";
        public const string RESPONSE_PLAYER_NOT_FOUND = "PlayerNotFound";
        public const string RESPONSE_INVALID_PLAYER_NAME = "InvalidPlayerName";
        public const string RESPONSE_INVALID_NAME = "InvalidName";
        public const string RESPONSE_PLAYER_ALREADY_IN_LIST = "PlayerAlreadyInList";
        public const string RESPONSE_PLAYER_NOT_IN_LIST = "PlayerNotInList";

        #endregion

        #region Not Authenticated Commands

        public const string COMMAND_VERSION = "version";
        public const string COMMAND_SERVER_INFO = "serverInfo";
        public const string COMMAND_LOGIN_PLAIN_TEXT = "login.plainText";
        public const string COMMAND_LOGIN_HASHED = "login.hashed";
        public const string COMMAND_LIST_PLAYERS = "listPlayers";
        public const string COMMAND_LOGOUT = "logout";
        public const string COMMAND_QUIT = "quit";

        #endregion

        #region Map List Commands

        public const string COMMAND_MAP_LIST_LIST = "mapList.list";
        public const string COMMAND_MAP_LIST_LOAD = "mapList.load";
        public const string COMMAND_MAP_LIST_SAVE = "mapList.save";
        public const string COMMAND_MAP_LIST_ADD = "mapList.add";
        public const string COMMAND_MAP_LIST_REMOVE = "mapList.remove";
        public const string COMMAND_MAP_LIST_CLEAR = "mapList.clear";
        public const string COMMAND_MAP_LIST_SET_NEXT_MAP_INDEX = "mapList.setNextMapIndex";
        public const string COMMAND_MAP_LIST_GET_MAP_INDICES = "mapList.getMapIndices";
        public const string COMMAND_MAP_LIST_GET_ROUNDS = "mapList.getRounds";
        public const string COMMAND_MAP_LIST_RUN_NEXT_ROUND = "mapList.runNextRound";
        public const string COMMAND_MAP_LIST_END_ROUND = "mapList.endRound";

        #endregion

        #region Ban List Commands

        //public const string COMMAND_BAN_LIST_LIST = "banList.list";
        //public const string COMMAND_BAN_LIST_ADD = "banList.add";
        //public const string COMMAND_BAN_LIST_REMOVE = "banList.remove";
        //public const string COMMAND_BAN_LIST_CLEAR = "banList.clear";
        //public const string COMMAND_BAN_LIST_LOAD = "banList.load";
        //public const string COMMAND_BAN_LIST_SAVE = "banList.save";

        #endregion

        #region Vars Commands

        public const string COMMAND_VARS_GAMEPASSWORD = "vars.gamePassword";
        public const string COMMAND_VARS_SERVERNAME = "vars.serverName";
        public const string COMMAND_VARS_RANKED = "vars.ranked";
        public const string COMMAND_VARS_BANNER_URL = "vars.bannerUrl";
        public const string COMMAND_VARS_AUTO_BALANCE = "vars.autoBalance";
        public const string COMMAND_VARS_FRIENDLY_FIRE = "vars.friendlyFire";
        public const string COMMAND_VARS_SERVER_DESCRIPTION = "vars.serverDescription";
        public const string COMMAND_VARS_MAX_PLAYERS = "vars.maxPlayers";
        public const string COMMAND_VARS_IDLE_TIMEOUT = "vars.idleTimeout";
        public const string COMMAND_VARS_SERVER_MESSAGE = "vars.serverMessage";
        public const string COMMAND_VARS_KILLCAM = "vars.killCam";
        public const string COMMAND_VARS_MINIMAP = "vars.miniMap";
        public const string COMMAND_VARS_HUD = "vars.hud";
        public const string COMMAND_VARS_CROSS_HAIR = "vars.crossHair";
        public const string COMMAND_VARS_3_D_SPOTTING = "vars.3dSpotting";
        public const string COMMAND_VARS_MINI_MAP_SPOTTING = "vars.miniMapSpotting";
        public const string COMMAND_VARS_NAME_TAG = "vars.nameTag";
        public const string COMMAND_VARS_3_P_CAM = "vars.3pCam";
        public const string COMMAND_VARS_REGENERATE_HEALTH = "vars.regenerateHealth";
        public const string COMMAND_VARS_TEAM_KILL_COUNT_FOR_KICK = "vars.teamKillCountForKick";
        public const string COMMAND_VARS_TEAM_KILL_VALUE_FOR_KICK = "vars.teamKillValueForKick";
        public const string COMMAND_VARS_TEAM_KILL_VALUE_INCREASE = "vars.teamKillValueIncrease";
        public const string COMMAND_VARS_TEAM_KILL_VALUE_DECREASE = "vars.teamKillValueDecreasePerSecond";
        public const string COMMAND_VARS_TEAM_KILL_KICK_FOR_BAN = "vars.teamKillKickForBan";
        public const string COMMAND_VARS_IDLE_BAN_ROUNDS = "vars.idleBanRounds";
        public const string COMMAND_VARS_ROUND_START_PLAYER_COUNT = "vars.roundStartPlayerCount";
        public const string COMMAND_VARS_ROUND_RESTART_PLAYER_COUNT = "vars.roundRestartPlayerCount";
        public const string COMMAND_VARS_ROUND_LOCKDOWN_COUNTDOWN = "vars.roundLockdownCountdown";
        public const string COMMAND_VARS_VEHICLE_SPAWN_ALLOWED = "vars.vehicleSpawnAllowed";
        public const string COMMAND_VARS_VEHICLE_SPAWN_DELAY = "vars.vehicleSpawnDelay";
        public const string COMMAND_VARS_SOLDIER_HEALTH = "vars.soldierHealth";
        public const string COMMAND_VARS_PLAYER_RESPAWN_TIME = "vars.playerRespawnTime";
        public const string COMMAND_VARS_PLAYER_MAN_DOWN_TIME = "vars.playerManDownTime";
        public const string COMMAND_VARS_BULLET_DAMAGE = "vars.bulletDamage";
        public const string COMMAND_VARS_GAME_MODE_COUNTER = "vars.gameModeCounter";
        public const string COMMAND_VARS_ONLY_SQUAD_LEADER_SPAWN = "vars.onlySquadLeaderSpawn";
        public const string COMMAND_VARS_UNLOCK_MODE = "vars.unlockMode";
        public const string COMMAND_VARS_PREMIUM_STATUS = "vars.premiumStatus";

        #endregion

        #region Event Commands

        public const string EVENT_PLAYER_ON_AUTHENTICATED = "player.onAuthenticated";
        public const string EVENT_PLAYER_ON_JOIN = "player.onJoin";
        public const string EVENT_PLAYER_ON_LEAVE = "player.onLeave";
        public const string EVENT_PLAYER_ON_SPAWN = "player.onSpawn";
        public const string EVENT_PLAYER_ON_KILL = "player.onKill";
        public const string EVENT_PLAYER_ON_CHAT = "player.onChat";
        public const string EVENT_PLAYER_ON_SQUAD_CHANGE = "player.onSquadChange";
        public const string EVENT_PLAYER_ON_TEAM_CHANGE = "player.onTeamChange";
        public const string EVENT_PUNKBUSTER_ON_MESSAGE = "punkBuster.onMessage";
        public const string EVENT_SERVER_ON_LEVEL_LOADED = "server.onLevelLoaded";
        public const string EVENT_SERVER_ON_ROUND_OVER = "server.onRoundOver";
        public const string EVENT_SERVER_ON_MAX_PLAYER_COUNT_CHANGE = "server.onMaxPlayerCountChange";

        #endregion
    }
}