namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System.ComponentModel;
    using Common;

    public class PacketViewModel : INotifyPropertyChanged
    {
        public PacketViewModel(Packet packet)
        {
            this.Packet = packet;
        }

        public Packet Packet { get; private set; }

        public uint? SequenceId
        {
            get { return this.Packet.SequenceId; }
            set
            {
                this.Packet.SequenceId = value;
                this.InvokePropertyChanged("SequenceId");
            }
        }

        public bool IsServerOriginated
        {
            get { return this.Packet.Origin == PacketOrigin.Server; }
            set
            {
                this.Packet.Origin = value ? PacketOrigin.Server : PacketOrigin.Client;
                this.InvokePropertyChanged("IsServerOriginated");
            }
        }

        public bool IsResponse
        {
            get { return this.Packet.IsResponse; }
            set
            {
                this.Packet.IsResponse = value;
                this.InvokePropertyChanged("IsResponse");
            }
        }

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Invoke Events

        internal void InvokePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.BeginInvoke(this, new PropertyChangedEventArgs(propertyName),
                                                 this.PropertyChanged.EndInvoke,
                                                 null);
            }
        }

        #endregion
    }
}