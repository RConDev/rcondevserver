namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Windows.Forms;
    using Common;
    using Ui;
    using Util;

    public partial class PacketBuilderControl : UserControl
    {
        public PacketBuilderControl()
        {
            this.InitializeComponent();
            this.ViewModel = new PacketViewModel(new Packet());
            this.packetViewModelBindingSource.DataSource = this.ViewModel;
        }

        #region Public Properties

        public PacketViewModel ViewModel { get; private set; }

        #endregion

        #region Events

        /// <summary>
        ///     this event is invoked, when a packet is created and sent
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketCreated;

        /// <summary>
        ///     this event is invoked, when entered values are not complete or wrong
        /// </summary>
        public event EventHandler<PacketBuilderErrorEventArgs> BuildError;

        #endregion

        #region Invoke Events

        /// <summary>
        ///     invokes the event <see cref="PacketCreated" /> with the given packet information
        /// </summary>
        /// <param name="packet"></param>
        internal void InvokePacketCreated(Packet packet)
        {
            if (this.PacketCreated != null)
            {
                this.PacketCreated.Invoke(this, new PacketDataEventArgs(packet));
            }
        }

        internal void InvokeBuildError(Exception exception)
        {
            if (this.BuildError != null)
            {
                this.BuildError.Invoke(this, new PacketBuilderErrorEventArgs(exception));
            }
        }

        #endregion

        #region Event Handler

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                Packet packet = this.ViewModel.Packet;

                packet.Words.Clear();
                foreach (string line in this.wordsTextBox.Lines)
                {
                    packet.Words.Add(line);
                }
                this.InvokePacketCreated(packet);
            }
            catch (Exception ex)
            {
                this.InvokeBuildError(ex);
            }
            finally
            {
                this.ViewModel = new PacketViewModel(new Packet());
                this.packetViewModelBindingSource.DataSource = this.ViewModel;
                this.packetViewModelBindingSource.ResetBindings(false);
            }
        }

        #endregion
    }
}