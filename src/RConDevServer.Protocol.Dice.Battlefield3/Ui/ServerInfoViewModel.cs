using System;
using System.Collections.ObjectModel;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    /// <summary>
    /// ViewModel für die Anzeige der <see cref="ServerInfo"/> Informationen in der Ui, sowie der Editiermöglichkeit dieser
    /// Informationen
    /// </summary>
    public class ServerInfoViewModel : ViewModelBase
    {
        #region Public Properties

        public string ServerName
        {
            get { return this.ServerInfo.ServerName; }
            set
            {
                this.ServerInfo.ServerName = value;
                if (this.Server.Vars.ContainsKey(Constants.COMMAND_VARS_SERVERNAME))
                {
                    this.Server.Vars[Constants.COMMAND_VARS_SERVERNAME] = this.ServerInfo.ServerName;
                }
                InvokePropertyChanged("ServerName");
            }
        }

        protected Battlefield3Server Server { get; private set; }

        public ObservableCollection<Map> AvailableMaps { get; private set; }

        public ObservableCollection<GameMode> AvailableGameModes { get; private set; }

        public Map CurrentMap
        {
            get { return this.ServerInfo.CurrentMap; }
        }

        public GameMode CurrentGameMode
        {
            get { return this.ServerInfo.CurrentGameMode; }
        }

        public decimal CurrentPlayerCount
        {
            get { return this.Server.PlayerList.Players.Count; }
        }

        public decimal MaxPlayerCount
        {
            get { return this.ServerInfo.MaxPlayerCount; }
            set
            {
                this.ServerInfo.MaxPlayerCount = value;
                this.InvokePropertyChanged("MaxPlayerCount");
            }

        }

        public decimal RoundsPlayed
        {
            get { return this.ServerInfo.RoundsPlayed; }
            set
            {
                this.ServerInfo.RoundsPlayed = value;
                this.InvokePropertyChanged("RoundsPlayed");
            }

        }

        public decimal RoundsTotal
        {
            get { return this.ServerInfo.RoundsTotal; }
        }

        public bool IsRanked
        {
            get { return this.ServerInfo.IsRanked; }
            set
            {
                this.ServerInfo.IsRanked = value;
                InvokePropertyChanged("IsRanked");
            }
        }

        public bool IsPunkbuster
        {
            get { return this.ServerInfo.IsPunkbuster; }
            set
            {
                this.ServerInfo.IsPunkbuster = value;
                InvokePropertyChanged("IsPunkbuster");
            }
        }

        public decimal ServerUpTime
        {
            get { return this.ServerInfo.ServerUpTime; }
            set
            {
                this.ServerInfo.ServerUpTime = value;
                this.InvokePropertyChanged("ServerUpTime");
                this.InvokePropertyChanged("ServerUpTimeSpan");
            }
        }

        public TimeSpan ServerUpTimeSpan
        {
            get
            {
                var seconds = this.ServerInfo.ServerUpTime;
                var date = DateTime.Now;
                var nextDate = date.AddSeconds(Convert.ToDouble(seconds));
                return nextDate - date;
            }
        }

        public decimal RoundTime
        {
            get { return this.ServerInfo.RoundTime; }
            set
            {
                this.ServerInfo.RoundTime = value;
                this.InvokePropertyChanged("RoundTime");
                this.InvokePropertyChanged("RoundTimeSpan");
            }
        }

        public TimeSpan RoundTimeSpan
        {
            get
            {
                var seconds = this.ServerInfo.RoundTime;
                var date = DateTime.Now;
                var nextDate = date.AddSeconds(Convert.ToDouble(seconds));
                return nextDate - date;
            }
        }

        public bool HasGamePassword
        {
            get { return this.ServerInfo.HasGamePassword; }
            set
            {
                this.ServerInfo.HasGamePassword = value;
                this.InvokePropertyChanged("HasGamePassword");
            }

        }

        public string Ip
        {
            get { return this.ServerInfo.IpPortPair.Ip; }
            set
            {
                this.ServerInfo.IpPortPair.Ip = value;
                this.InvokePropertyChanged("Ip");
            }
        }

        public int Port
        {
            get { return this.ServerInfo.IpPortPair.Port; }
            set
            {
                this.ServerInfo.IpPortPair.Port = value;
                this.InvokePropertyChanged("Port");
            }
        }

        public TeamScoresViewModel TeamScores
        {
            get { return new TeamScoresViewModel(Server.TeamScores, SynchronousInvoker); }
        }

        public Country Country
        {
            get { return this.ServerInfo.Country; }
            set
            {
                this.ServerInfo.Country = value;
                InvokePropertyChanged("Country");
            }
        }

        public string ClosestPingSite
        {
            get { return this.ServerInfo.ClosestPingSite; }
            set
            {
                this.ServerInfo.ClosestPingSite = value;
                this.InvokePropertyChanged("ClosestPingSite");
            }
        }

        public string Region
        {
            get { return this.ServerInfo.Region; }
            set
            {
                this.ServerInfo.Region = value;
                this.InvokePropertyChanged("Region");
            }
        }

        public ServerInfo ServerInfo { get; private set; }

        #endregion

        #region Constructor

        public ServerInfoViewModel(ServerInfo serverInfo, Battlefield3Server server, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.ServerInfo = serverInfo;
            this.Server = server;
            this.AvailableMaps = new ObservableCollection<Map>(server.AvailableMaps);
            this.AvailableGameModes = new ObservableCollection<GameMode>(server.AvailableModes);
        }

        

        #endregion
    }
}