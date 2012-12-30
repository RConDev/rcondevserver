using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using Util;

    public partial class ConsoleControl : UserControl
    {
        private ServerViewModel dataContext;

        #region Constructors

        public ConsoleControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        public ServerViewModel DataContext
        {
            get { return dataContext; }
            set
            {
                dataContext = value;
                if (dataContext != null)
                {
                    dbsServer.DataSource = dataContext;
                    dbsServer.ResetBindings(false);
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

        private void MitCloseSessionClick(object sender, System.EventArgs e)
        {
            var isDeleteResult = MessageBox.Show("Do you really want to close the selected session?", "Are you sure?",
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
            dgwPackets.FirstDisplayedScrollingRowIndex = dgwPackets.RowCount - 1;
        }

        #endregion
    }
}