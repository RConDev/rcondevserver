using System;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    public partial class ServerInfoControl : UserControl
    {
        private ServerViewModel dataContext;

        public ServerInfoControl()
        {
            InitializeComponent();
        }

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
                    dataContext.Server.MapList.Updated += MapListOnUpdated;
                    dbsServer.ResetBindings(false);

                    dbsServerInfo.DataSource = dataContext.ServerInfo;
                    dbsServerInfo.ResetBindings(false);

                    dbsCountries.DataSource = dataContext.Server.Countries;
                    dbsCountries.ResetBindings(false);
                }
            }
        }

        private void MapListOnUpdated(object sender, EventArgs eventArgs)
        {
            this.dbsServerInfo.DataSource = dataContext.ServerInfo;
            this.dbsServerInfo.ResetBindings(false);
        }

        #endregion
    }
}
