namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;

    public class SessionViewModel : ViewModelBase
    {
        #region Constructors

        /// <summary>
        ///     Creates a ViewModel for the <see cref="PacketSession" />
        /// </summary>
        /// <param name="session"></param>
        /// <param name="invoker"> </param>
        public SessionViewModel(PacketSession session, Action<Action> invoker)
            : base(invoker)
        {
            this.PacketSession = session;
            this.Packets = new PacketList();
            if (this.PacketSession != null)
            {
                this.PacketSession.PacketReceived += this.PacketSessionOnPacketReceived;
                this.PacketSession.PacketSent += this.PacketSessionOnPacketSent;
                this.PacketSession.SessionClosed += this.PacketSessionOnSessionClosed;
                this.PacketSession.ServerUpdated += this.PacketSessionOnServerUpdated;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     the <see cref="PacketSession" /> instance
        /// </summary>
        public PacketSession PacketSession { get; set; }

        /// <summary>
        ///     the console content to display
        /// </summary>
        public string Console { get; private set; }

        /// <summary>
        ///     the packets send accross the wire
        /// </summary>
        public PacketList Packets { get; private set; }

        public string SessionId
        {
            get { return this.PacketSession.Session.Uid.ToString(); }
        }

        #endregion

        #region Events

        /// <summary>
        ///     this event is invoked, when the wrapped Session is closed
        /// </summary>
        public event EventHandler<SessionViewModelEventArgs> SessionClosed;

        #endregion

        #region Invoke Events

        internal void InvokeSessionClosed(SessionViewModel session)
        {
            if (this.SessionClosed != null)
            {
                this.SessionClosed.Invoke(this, new SessionViewModelEventArgs(session));
            }
            this.InvokePropertyChanged("Packets");
        }

        #endregion

        #region Event Handler

        private void PacketSessionOnPacketReceived(object sender, PacketDataEventArgs packetDataEventArgs)
        {
            var packet = packetDataEventArgs.PacketData;
            this.Packets.Add(packet);
            this.InvokePropertyChanged("Packets");
        }

        private void PacketSessionOnPacketSent(object sender, PacketDataEventArgs packetDataEventArgs)
        {
            var packet = packetDataEventArgs.PacketData;
            this.Packets.Add(packet);
            this.InvokePropertyChanged("Packets");
        }

        private void PacketSessionOnSessionClosed(object sender, PacketSessionEventArgs sessionEventArgs)
        {
            this.InvokeSessionClosed(this);
        }

        private void PacketSessionOnServerUpdated(object sender, EventArgs eventArgs)
        {
        }

        #endregion
    }
}