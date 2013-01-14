namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using EventSender;

    public class ServerViewModel : ViewModelBase
    {
        #region Constructors

        public ServerViewModel(Battlefield3Server server, Action<Action> invoker)
            : base(invoker)
        {
            this.Sessions = new SessionCollection();
            this.Server = server;
            if (this.Server != null)
            {
                this.Server.ClientConnected += this.ServerOnClientConnected;
            }

            this.Players = new PlayersViewModel(server, this.SynchronousInvoker);
            this.MapList = new MapListViewModel(server, this.SynchronousInvoker);
            this.ReservedSlots = new ReservedSlotsViewModel(server.ReservedSlots, this.SynchronousInvoker);
            this.EventScript = new EventScriptViewModel(server, this.SynchronousInvoker);
            this.EventScript.EventRaised += this.EventScriptOnEventRaised;
            this.TeamScores = new TeamScoresViewModel(server.TeamScores, this.SynchronousInvoker);
            this.BanList = new BanListViewModel(server.BanList, server.IdTypes, server.BanTypes, this.SynchronousInvoker);
        }

        #endregion

        #region Public Properties

        public MapListViewModel MapList { get; private set; }

        public ReservedSlotsViewModel ReservedSlots { get; private set; }

        public Battlefield3Server Server { get; private set; }

        public string ServerConsole { get; private set; }

        public string Password
        {
            get { return this.Server.Password; }
            set
            {
                this.Server.Password = value;
                this.InvokePropertyChanged("Password");
            }
        }

        public ServerInfoViewModel ServerInfo
        {
            get { return new ServerInfoViewModel(this.Server.ServerInfo, this.Server, this.SynchronousInvoker); }
        }

        public EventScriptViewModel EventScript { get; private set; }

        public PlayersViewModel Players { get; private set; }

        public TeamScoresViewModel TeamScores { get; private set; }

        public bool IsAutomaticResponse
        {
            get { return this.Server.IsAutomaticResponse; }
            set
            {
                this.Server.IsAutomaticResponse = value;
                this.InvokePropertyChanged("IsAutomaticResponse");
            }
        }

        public ObservableCollection<SessionViewModel> Sessions { get; private set; }

        public BanListViewModel BanList { get; private set; }

        #endregion

        #region Event Handler

        private void ServerOnClientConnected(object sender, PacketSessionEventArgs packetSessionEventArgs)
        {
            PacketSession session = packetSessionEventArgs.PacketSession;

            string message = string.Format("{1}: Client connected with SessionID '{0}' ", session.Session.Uid,
                                           DateTime.Now);
            log.InfoFormat("Client connected with SessionID '{0}' ", session.Session.Uid);

            var serverConsoleBuilder = new StringBuilder(this.ServerConsole);
            serverConsoleBuilder.AppendLine(message);
            this.ServerConsole = serverConsoleBuilder.ToString();

            var sessionViewModel = new SessionViewModel(session, this.SynchronousInvoker);
            sessionViewModel.SessionClosed += this.SessionViewModelOnSessionClosed;
            this.Sessions.Add(sessionViewModel);

            this.InvokePropertyChanged("Sessions");
            this.InvokePropertyChanged("ServerConsole");

            session.StartReceiving();
        }

        private void SessionViewModelOnSessionClosed(object sender, SessionViewModelEventArgs sessionViewModelEventArgs)
        {
            PacketSession packetSession = sessionViewModelEventArgs.SessionViewModel.PacketSession;
            string message = string.Format("{1}: Client with SessionID '{0}' diconnected ", packetSession.Session.Uid,
                                           DateTime.Now);
            log.InfoFormat("Client with SessionID '{0}' diconnected ", packetSession.Session.Uid);

            var serverConsoleBuilder = new StringBuilder(this.ServerConsole);
            serverConsoleBuilder.AppendLine(message);
            this.ServerConsole = serverConsoleBuilder.ToString();

            if (this.Sessions.Contains(sessionViewModelEventArgs.SessionViewModel))
            {
                this.Sessions.Remove(sessionViewModelEventArgs.SessionViewModel);
            }

            this.InvokePropertyChanged("Sessions");
            this.InvokePropertyChanged("ServerConsole");
        }

        private void EventScriptOnEventRaised(object sender, EventSenderEventArgs eventSenderEventArgs)
        {
            ICanSendEvents eventSender = eventSenderEventArgs.EventSender;
            if (eventSender != null)
            {
                eventSender.Send(this.Server);
                Console.WriteLine("EVENT GESENDET");
            }
        }

        #endregion
    }
}