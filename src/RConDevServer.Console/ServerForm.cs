using System.Net.Sockets;
using RConDevServer.Protocol.Interface;
using System.Windows.Forms;
using RConDevServer.Resource.Properties;

namespace RConDevServer.Console
{
    public sealed partial class ServerForm : Form
    {
        private ServerFormViewModel dataContext;

        #region Constructors

        public ServerForm()
        {
            InitializeComponent();
            
            Icon = Resources.RConDevServer;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public ServerFormViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;

                this.dbsServerInstance.DataSource = this.DataContext.ServerInstance;
                this.dbsServerInstance.ResetBindings(false);

                this.dbsAvailableProtocols.DataSource = this.DataContext.AvailableProtocols;
                this.dbsAvailableProtocols.ResetBindings(false);

                Text = DataContext.AssemblyProduct;

            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the control provided by the selected protocol
        /// </summary>
        /// <param name="mainControl"></param>
        public void SetProtocolControl(Control mainControl)
        {
            spcMain.Panel2.Controls.Add(mainControl);
            mainControl.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Enables or disables the Settings for the server
        /// </summary>
        /// <param name="enabled"></param>
        public void SettingsEnabled(bool enabled)
        {
            tbxMaxSessions.Enabled = enabled;
            tbxPort.Enabled = enabled;
            cmbProtocol.Enabled = enabled;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Handles the click on Button "Start" / "Stop"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick(object sender, System.EventArgs e)
        {
            // check if the server i not running
            if (!DataContext.ServerInstance.IsRunning)
            {
                if (DataContext.ServerInstance.MaxSessions < 1)
                {
                    ShowMessage("Maximal number of session must exceed '0'.");
                    return;
                }

                try
                {
                    var currentProtocol = dbsAvailableProtocols.Current as IRconProtocol;
                    if (currentProtocol != null)
                    {
                        currentProtocol.Initialize();
                        SetProtocolControl(currentProtocol.MainControl);
                        DataContext.ServerInstance.SetProtocol(currentProtocol);
                        DataContext.ServerInstance.Start();
                        btnStart.Text = Resources.TXT_STOP;
                        SettingsEnabled(false);
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                    {
                        ShowMessage(string.Format("Port '{0}' is currently in use by another process.",
                                                  DataContext.ServerInstance.Port));
                    }
                    else
                    {
                        ShowMessage(string.Format("Exception: {0}", ex.Message));
                    }
                    ClearProtocolControl();
                }
            }
            else
            {
                btnStart.Text = Resources.TXT_START;
                DataContext.ServerInstance.Stop();
                ClearProtocolControl();
                SettingsEnabled(true);
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, DataContext.AssemblyProduct, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Cleans the region for diplaying the protocol ui
        /// </summary>
        private void ClearProtocolControl()
        {
            spcMain.Panel2.Controls.Clear();
        }

        #endregion
    }
}