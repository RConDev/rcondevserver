using System;
using System.Windows.Forms;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using Ui;
    using Util;

    public partial class PacketBuilderControl : UserControl
    {
        public PacketBuilderControl()
        {
            InitializeComponent();
            ViewModel = new PacketViewModel(new Packet());
            packetViewModelBindingSource.DataSource = ViewModel;
        }

        #region Public Properties

        public PacketViewModel ViewModel { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// this event is invoked, when a packet is created and sent
        /// </summary>
        public event EventHandler<PacketDataEventArgs> PacketCreated;

        /// <summary>
        /// this event is invoked, when entered values are not complete or wrong
        /// </summary>
        public event EventHandler<PacketBuilderErrorEventArgs> BuildError;

        #endregion

        #region Invoke Events

        /// <summary>
        /// invokes the event <see cref="PacketCreated"/> with the given packet information
        /// </summary>
        /// <param name="packet"></param>
        internal void InvokePacketCreated(Packet packet)
        {
            if (PacketCreated != null)
            {
                PacketCreated.Invoke(this, new PacketDataEventArgs(packet));
            }
        }

        internal void InvokeBuildError(Exception exception)
        {
            if (BuildError != null)
            {
                BuildError.Invoke(this, new PacketBuilderErrorEventArgs(exception));
            }
        }

        #endregion

        #region Event Handler

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                Packet packet = ViewModel.Packet;

                packet.Words.Clear();
                foreach (string line in wordsTextBox.Lines)
                {
                    packet.Words.Add(line);
                }
                InvokePacketCreated(packet);
            }
            catch (Exception ex)
            {
                InvokeBuildError(ex);
            }
            finally
            {
                ViewModel = new PacketViewModel(new Packet());
                packetViewModelBindingSource.DataSource = ViewModel;
                packetViewModelBindingSource.ResetBindings(false);
            }
        }

        #endregion
    }
}