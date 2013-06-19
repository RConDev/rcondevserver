namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data;
    using DataStore;
    using Event;
    using Injection;
    using Interface;
    using Properties;

    public class Battlefield3Server : IBattlefield3Server
    {
        private readonly object syncRoot = new object();
        public IServiceLocator ServiceLocator { get; set; }

        public Battlefield3Protocol Battlefield3Protocol { get; set; }

        public IReservedSlotsDataFile ReservedSlotsStore { get; private set; }

        public IMapListDataFile MapListStore { get; private set; }

        #region Events

        public event EventHandler<PacketSessionEventArgs> ClientConnected;

        public event EventHandler Stopped;

        #endregion

        #region Public Properties

        public IList<PacketSession> PacketSessions { get; private set; }

        /// <summary>
        ///     the rcon password for the server
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     the data for serverInfo Command
        /// </summary>
        public ServerInfo ServerInfo { get; set; }

        /// <summary>
        ///     gets or sets the value for active automatic responses to client commands
        /// </summary>
        public bool IsAutomaticResponse { get; set; }

        public string ServerDescription { get; set; }

        public MapList MapList { get; private set; }

        public IBanList BanList { get; private set; }

        public Vars Vars { get; private set; }

        public MapListItem CurrentMapListItem
        {
            get { return this.MapList.CurrentItem; }
        }

        public IPlayerList PlayerList { get; private set; }

        public ReservedSlots ReservedSlots { get; private set; }

        public TeamScores TeamScores { get; private set; }

        protected Battlefield3DataContext EfContext { get; set; }

        public Maps AvailableMaps { get; private set; }

        public GameModes AvailableModes { get; private set; }

        public IdTypes IdTypes { get; private set; }

        public BanTypes BanTypes { get; private set; }

        public IList<Country> Countries { get; private set; }

        #endregion

        #region Constructors

        public Battlefield3Server(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
            this.Battlefield3Module = new Battlefield3Module(serviceLocator);
        }

        protected Battlefield3Module Battlefield3Module { get; private set; }

        public int EffectiveMaxPlayerCount { get; set; }

        public void Initialize()
        {
            this.AvailableMaps = new Maps(this.ServiceLocator.GetService<IMapRepository>().GetAll());
            this.AvailableModes = new GameModes(this.ServiceLocator.GetService<IGameModeRepository>().GetAll());

            this.IsAutomaticResponse = true;
            this.PacketSessions = new List<PacketSession>();
            this.Password = "test123";
            this.ServerDescription = "RCon Test Server";

            this.InitializeServerInfo();
            this.InitializePlayerList();
            this.InitializeMapList();
            this.InitializeBanList();
            this.InitializeReservedSlots();
            this.InitializeTeamScores();
            this.InitializeVars();
        }

        #endregion

        #region Event Handler

        public void PublishEvents(IEnumerable<IEvent> events)
        {
            foreach (IEvent anEvent in events)
            {
                this.PublishEvent(anEvent);
            }
        }

        public void PublishEvent(IEvent anEvent)
        {
            var packet = new Packet(PacketOrigin.Server, false, 0, anEvent.ToWords());
            foreach (PacketSession session in this.PacketSessions)
            {
                session.SendToClient(packet);
            }
        }

        public void OnClientConnected(object sender, ClientEventArgs e)
        {
            var packetSession = new PacketSession(e.Session, this);
            lock (this.syncRoot)
            {
                this.PacketSessions.Add(packetSession);
            }
            this.InvokeClientConnected(packetSession);
        }

        public void OnStopped(object sender, EventArgs e)
        {
            this.InvokeStopped();
        }

        #endregion

        #region Private Methods

        private void InitializeServerInfo()
        {
            this.Countries = this.ServiceLocator.GetService<ICountryRepository>().GetAll().ToList();

            this.ServerInfo = new ServerInfo(this)
                {
                    ServerName = "My Test Server",
                    HasGamePassword = false,
                    MaxPlayerCount = 16,
                    IsJoinQueueEnabled = true,
                    RoundsPlayed = 1,
                    IpPortPair = new IpPortPair
                        {
                            Ip = "127.0.0.1",
                            Port = 25200
                        },
                    ClosestPingSite = string.Empty,
                    Country = this.Countries.FirstOrDefault(x => x.CodeAlpha2 == "DE"),
                    IsPunkbuster = true,
                    IsRanked = true,
                    OnlineState = string.Empty,
                    PunkbusterVersion = string.Empty,
                    Region = string.Empty,
                    RoundTime = Convert.ToDecimal(new TimeSpan(0, 0, 15, 0).TotalSeconds),
                    ServerUpTime = Convert.ToDecimal(new TimeSpan(15, 16, 15, 0).TotalSeconds),
                };
        }

        private void InitializeTeamScores()
        {
            this.TeamScores = new TeamScores
                {
                    TargetScore = 500,
                };
            this.TeamScores.Scores.Add(new Score {TeamId = 1, Value = 100});
            this.TeamScores.Scores.Add(new Score {TeamId = 2, Value = 100});
        }

        private void InitializeReservedSlots()
        {
            this.ReservedSlots = new ReservedSlots {"TestPlayer"};
            this.ReservedSlots.IsAggressiveJoin = true;
            this.ReservedSlotsStore = new ReservedSlotsDataFile(new DataFile(Settings.Default.ReservedSlotsDataFile));
        }

        private void InitializePlayerList()
        {
            this.PlayerList = new PlayerList();
            this.PlayerList.AddPlayer(new PlayerInfo
                {
                    Name = "JohnDoe21",
                    Deaths = 5,
                    Kills = 10,
                    Score = 150,
                    SquadId = 0,
                    TeamId = 1
                });
        }

        private void InitializeBanList()
        {
            var idTypeRepository = this.ServiceLocator.GetService<IIdTypeRepository>();
            this.IdTypes = new IdTypes(idTypeRepository.GetAll());
            this.BanTypes = new BanTypes();
            this.BanList = new BanList
                {
                    new BanListItem
                        {
                            IdType = this.IdTypes.FirstOrDefault(x => x.Code == "name"),
                            IdValue = "TestPlayer",
                            BanType = BanTypes.Perm,
                            Rounds = 0,
                            Seconds = 0,
                            Reason = "No reason, really"
                        }
                };
        }

        private void InitializeMapList()
        {
            this.MapList = new MapList();
            this.MapList.Add(new MapListItem
                {
                    Map = this.AvailableMaps[1],
                    Mode = this.AvailableModes[1],
                    Rounds = 2
                });
            this.MapList.CurrentIndex = -1;
            this.MapList.NextMap();
            var mapRepository = this.ServiceLocator.GetService<IMapRepository>();
            var gameModeRepository = this.ServiceLocator.GetService<IGameModeRepository>();
            this.MapListStore = new MapListDataFile(new DataFile(Settings.Default.MapListDataFile), mapRepository,
                                                    gameModeRepository);
        }

        private void InitializeVars()
        {
            this.Vars = new Vars
                {
                    {Constants.COMMAND_VARS_GAMEPASSWORD, string.Empty},
                    {Constants.COMMAND_VARS_SERVERNAME, this.ServerInfo.ServerName},
                    {Constants.COMMAND_VARS_AUTO_BALANCE, true},
                    {Constants.COMMAND_VARS_FRIENDLY_FIRE, true},
                    {Constants.COMMAND_VARS_IDLE_TIMEOUT, 300},
                    {Constants.COMMAND_VARS_SERVER_MESSAGE, "Welcome to this RCon Test Server"},
                    {Constants.COMMAND_VARS_KILLCAM, true},
                    {Constants.COMMAND_VARS_MINIMAP, true},
                    {Constants.COMMAND_VARS_HUD, true},
                    {Constants.COMMAND_VARS_CROSS_HAIR, true},
                    {Constants.COMMAND_VARS_3_D_SPOTTING, true},
                    {Constants.COMMAND_VARS_MINI_MAP_SPOTTING, true},
                    {Constants.COMMAND_VARS_NAME_TAG, true},
                    {Constants.COMMAND_VARS_3_P_CAM, true},
                    {Constants.COMMAND_VARS_REGENERATE_HEALTH, true},
                    {Constants.COMMAND_VARS_TEAM_KILL_COUNT_FOR_KICK, 5},
                    {Constants.COMMAND_VARS_TEAM_KILL_VALUE_FOR_KICK, 0},
                    {Constants.COMMAND_VARS_TEAM_KILL_VALUE_INCREASE, 0},
                    {Constants.COMMAND_VARS_TEAM_KILL_VALUE_DECREASE, 0},
                    {Constants.COMMAND_VARS_TEAM_KILL_KICK_FOR_BAN, 0},
                    {Constants.COMMAND_VARS_IDLE_BAN_ROUNDS, 0},
                    {Constants.COMMAND_VARS_ROUND_START_PLAYER_COUNT, 1},
                    {Constants.COMMAND_VARS_ROUND_RESTART_PLAYER_COUNT, 1},
                    {Constants.COMMAND_VARS_ROUND_LOCKDOWN_COUNTDOWN, 40},
                    {Constants.COMMAND_VARS_VEHICLE_SPAWN_ALLOWED, true},
                    {Constants.COMMAND_VARS_VEHICLE_SPAWN_DELAY, 100},
                    {Constants.COMMAND_VARS_SOLDIER_HEALTH, 100},
                    {Constants.COMMAND_VARS_PLAYER_RESPAWN_TIME, 100},
                    {Constants.COMMAND_VARS_PLAYER_MAN_DOWN_TIME, 100},
                    {Constants.COMMAND_VARS_BULLET_DAMAGE, 100},
                    {Constants.COMMAND_VARS_GAME_MODE_COUNTER, 100},
                    {Constants.COMMAND_VARS_ONLY_SQUAD_LEADER_SPAWN, true},
                    {Constants.COMMAND_VARS_UNLOCK_MODE, "all"},
                    {Constants.COMMAND_VARS_PREMIUM_STATUS, false}
                };
        }

        private void InvokeClientConnected(PacketSession packetSession)
        {
            if (this.ClientConnected != null)
            {
                Delegate[] invList = this.ClientConnected.GetInvocationList();
                foreach (Delegate invDelegate in invList)
                {
                    invDelegate.DynamicInvoke(this, new PacketSessionEventArgs(packetSession));
                }
            }
        }

        private void InvokeStopped()
        {
            if (this.Stopped != null)
            {
                this.Stopped.BeginInvoke(this, new EventArgs(), this.Stopped.EndInvoke, null);
            }
        }

        #endregion
    }
}