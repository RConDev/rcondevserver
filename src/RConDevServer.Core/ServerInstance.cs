using System.ComponentModel;
using System.Linq;
using RConDevServer.Protocol.Interface;
using RConDevServer.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace RConDevServer.Core
{
    /// <summary>
    /// the basic server instance for communicating with
    /// </summary>
    public class ServerInstance : IRconServer, INotifyPropertyChanged
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Constructor
        /// <summary>
        /// creates a server instance that listens on the specified port with a specified amount of max sessions
        /// </summary>
        /// <param name="port"></param>
        /// <param name="maxSessions"></param>
        public ServerInstance(int port, int maxSessions)
        {
            Port = port;
            MaxSessions = maxSessions;
            Sessions = new List<IRconSession>(MaxSessions);
        }

        #endregion

        #region Public Properties

        private int port;

        private int maxSessions;

        /// <summary>
        /// gets or sets the port number the server listens on, as long as the instance is not started
        /// </summary>
        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                InvokePropertyChanged("Port");
            }
        }
        
        /// <summary>
        /// gets or sets the maximum number of Session the instance can handle
        /// </summary>
        public int MaxSessions
        {
            get { return maxSessions; }
            set
            {
                maxSessions = value;
                InvokePropertyChanged("MaxSessions");
            }
        }

        /// <summary>
        /// gets the list of currently active sessions
        /// </summary>
        public IList<IRconSession> Sessions { get; private set; }

        /// <summary>
        /// gets the socket the server instance listens on
        /// </summary>
        public Socket ListeningSocket { get; private set; }

        /// <summary>
        /// gets the information of the protocol in use
        /// </summary>
        public IRconProtocol CurrentProtocol { get; private set; }

        /// <summary>
        /// gets the value, if the server is currently running / listening
        /// </summary>
        public bool IsRunning { get; private set; }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// this event is invoked, when a client connected to the server instance
        /// </summary>
        public event EventHandler<ClientEventArgs> ClientConnected;

        /// <summary>
        /// this event is invoked when the server instance is stopped
        /// </summary>
        public event EventHandler<EventArgs> Stopped;

        #endregion

        #region Public Methods

        /// <summary>
        /// starts the server instance, intiates the communication socket and begins listening for clients
        /// </summary>
        public void Start()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var localEndPoint = new IPEndPoint(ipAddress, Port);

            ListeningSocket = new Socket(AddressFamily.InterNetwork,
                                SocketType.Stream, ProtocolType.Tcp);
            ListeningSocket.Bind(localEndPoint);
            ListeningSocket.Listen(MaxSessions);

            ListeningSocket.BeginAccept(SocketAcceptCallback, ListeningSocket);
            this.IsRunning = true;
        }

        /// <summary>
        /// sends the bytes to all connected clients
        /// </summary>
        /// <param name="bytes"></param>
        public void SendToClients(byte[] bytes)
        {
            foreach (var session in Sessions)
            {
                session.SendToClient(bytes);
            }
        }

        /// <summary>
        /// stops the server instances and cleans up sessions and sockets
        /// </summary>
        public void Stop()
        {
            var sessionsToClose = Sessions.ToList();
            foreach (var session in sessionsToClose)
            {
                session.Close();
            }
            Sessions.Clear();
            ListeningSocket.Close();
            this.IsRunning = false;
        }

        public void SetProtocol(IRconProtocol rconProtocol)
        {
            if (this.CurrentProtocol != null)
            {
                ClientConnected -= CurrentProtocol.OnClientConnected;
                Stopped -= CurrentProtocol.OnStopped;
            }

            CurrentProtocol = rconProtocol;
            ClientConnected += rconProtocol.OnClientConnected;
            Stopped += rconProtocol.OnStopped;
        }

        #endregion

        #region Private Methods

        private void SocketAcceptCallback(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            if (socket != null)
            {
                try
                {
                    var clientSocket = socket.EndAccept(ar);
                    if (Sessions.Count == MaxSessions)
                    {
                        clientSocket.Close();
                    }
                    else
                    {
                        var session = new Session(clientSocket);
                        session.Closed += OnSessionClosed;

                        Sessions.Add(session);
                        InvokeClientConnected(session);
                        socket.BeginAccept(SocketAcceptCallback, socket);
                    }
                }
                catch (ObjectDisposedException)
                {
                    log.Debug("Listening socket was closed");
                    InvokeStopped();
                }
                catch (Exception ex)
                {
                    log.Debug("Exception occured while accepting a new client connection:",ex);
                    InvokeStopped();
                }
            }
        }

        private void InvokeClientConnected(IRconSession irConSession)
        {
            if (ClientConnected == null) return;

            ClientConnected.InvokeAll(this, new ClientEventArgs(irConSession));
        }

        private void InvokeStopped()
        {
            if (Stopped == null) return;

            Stopped.InvokeAll(this, new EventArgs());
        }

        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Event Handler

        private void OnSessionClosed(object sender, SessionEventArgs e)
        {
            var session = sender as IRconSession;
            if (session != null)
            {
                bool restartListening = Sessions.Count == MaxSessions;
                if (Sessions.Contains(session))
                {
                    Sessions.Remove(session);
                }

                if (restartListening)
                {
                    ListeningSocket.BeginAccept(SocketAcceptCallback, this.ListeningSocket);
                }
            }
        }

        #endregion
    }
}