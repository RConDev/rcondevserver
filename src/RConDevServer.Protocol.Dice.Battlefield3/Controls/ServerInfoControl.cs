namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Windows.Forms;
    using Ui;

    public partial class ServerInfoControl : UserControl
    {
        private ServerViewModel dataContext;

        public ServerInfoControl()
        {
            this.InitializeComponent();
        }

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
                    this.dataContext.Server.MapList.Updated += this.MapListOnUpdated;
                    this.dbsServer.ResetBindings(false);

                    this.dbsServerInfo.DataSource = this.dataContext.ServerInfo;
                    this.dbsServerInfo.ResetBindings(false);

                    this.dbsCountries.DataSource = this.dataContext.Server.Countries;
                    this.dbsCountries.ResetBindings(false);
                }
            }
        }

        private void MapListOnUpdated(object sender, EventArgs eventArgs)
        {
            this.dbsServerInfo.DataSource = this.dataContext.ServerInfo;
            this.dbsServerInfo.ResetBindings(false);
        }

        #endregion
    }
}