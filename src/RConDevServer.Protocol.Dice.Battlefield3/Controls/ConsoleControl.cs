namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Windows.Forms;
    using Ui;
    using Util;

    public partial class ConsoleControl : UserControl
    {
        private ServerViewModel dataContext;

        #region Constructors

        public ConsoleControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public ServerViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.dbsServer.DataSource = this.dataContext;
                    this.dbsServer.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Event Handler

        private void UcPacketBuilderPacketCreated(object sender, PacketDataEventArgs e)
        {
            var selectedSession = this.dbsSessions.Current as SessionViewModel;
            if (selectedSession != null)
            {
                selectedSession.PacketSession.SendToClient(e.PacketData);
            }
        }

        private void UcPacketBuilderBuildError(object sender, PacketBuilderErrorEventArgs e)
        {
            MessageBox.Show(e.ExceptionInfo.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void MitCloseSessionClick(object sender, EventArgs e)
        {
            DialogResult isDeleteResult = MessageBox.Show("Do you really want to close the selected session?",
                                                          "Are you sure?",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isDeleteResult == DialogResult.Yes)
            {
                var currentSession = this.dbsSessions.Current as SessionViewModel;
                if (currentSession != null)
                {
                    currentSession.PacketSession.Dispose();
                }
            }
        }

        private void DgwPacketsRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.dgwPackets.FirstDisplayedScrollingRowIndex = this.dgwPackets.RowCount - 1;
        }

        #endregion
    }
}