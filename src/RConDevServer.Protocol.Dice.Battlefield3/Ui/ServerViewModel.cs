using System;
using System.Collections.ObjectModel;
using System.Text;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class ServerViewModel : ViewModelBase
    {
        #region Constructors

        public ServerViewModel(Battlefield3Server server, Action<Action> invoker)
            : base(invoker)
        {
            Sessions = new SessionCollection();
            Server = server;
            if (Server != null)
            {
                Server.ClientConnected += ServerOnClientConnected;
            }
            
            Players = new PlayersViewModel(server, this.SynchronousInvoker);
            MapList = new MapListViewModel(server, SynchronousInvoker);
            ReservedSlots = new ReservedSlotsViewModel(server.ReservedSlots, this.SynchronousInvoker);
            EventScript = new EventScriptViewModel(server, this.SynchronousInvoker);
            EventScript.EventRaised += EventScriptOnEventRaised;
            this.TeamScores = new TeamScoresViewModel(server.TeamScores, SynchronousInvoker);
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
                InvokePropertyChanged("Password");
            }
        }

        public ServerInfoViewModel ServerInfo
        {
            get
            {
                return new ServerInfoViewModel(Server.ServerInfo, Server, this.SynchronousInvoker);
            }
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

            var message = string.Format("{1}: Client connected with SessionID '{0}' ", session.Session.Uid, DateTime.Now);
            log.InfoFormat("Client connected with SessionID '{0}' ", session.Session.Uid);

            var serverConsoleBuilder = new StringBuilder(this.ServerConsole);
            serverConsoleBuilder.AppendLine(message);
            this.ServerConsole = serverConsoleBuilder.ToString();

            var sessionViewModel = new SessionViewModel(session, SynchronousInvoker);
            sessionViewModel.SessionClosed += SessionViewModelOnSessionClosed;
            Sessions.Add(sessionViewModel);

            InvokePropertyChanged("Sessions");
            InvokePropertyChanged("ServerConsole");

            session.StartReceiving();
        }

        private void SessionViewModelOnSessionClosed(object sender, SessionViewModelEventArgs sessionViewModelEventArgs)
        {
            var packetSession = sessionViewModelEventArgs.SessionViewModel.PacketSession;
            var message = string.Format("{1}: Client with SessionID '{0}' diconnected ", packetSession.Session.Uid,
                                        DateTime.Now);
            log.InfoFormat("Client with SessionID '{0}' diconnected ", packetSession.Session.Uid);

            var serverConsoleBuilder = new StringBuilder(this.ServerConsole);
            serverConsoleBuilder.AppendLine(message);
            this.ServerConsole = serverConsoleBuilder.ToString();

            if (Sessions.Contains(sessionViewModelEventArgs.SessionViewModel))
            {
                Sessions.Remove(sessionViewModelEventArgs.SessionViewModel);
            }

            InvokePropertyChanged("Sessions");
            InvokePropertyChanged("ServerConsole");
        }

        private void EventScriptOnEventRaised(object sender, EventSenderEventArgs eventSenderEventArgs)
        {
            var eventSender = eventSenderEventArgs.EventSender;
            if (eventSender != null)
            {
                eventSender.Send(Server);
                System.Console.WriteLine("EVENT GESENDET");
            }
        }

        #endregion
    }
}