using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    public partial class MainControl : UserControl
    {
        private ServerViewModel dataContext;

        public MainControl()
        {
            InitializeComponent();
        }

        public ServerViewModel DataContext
        {
            get { return this.dataContext; }
            set 
            { 
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    ucConsole.DataContext = dataContext;
                    ucServerInfo.DataContext = dataContext;
                    ucEventScript.DataContext = dataContext.EventScript;
                    ucPlayers.DataContext = dataContext.Players;
                    uscReservedSlots.DataContext = dataContext.ReservedSlots;
                    uscMapList.DataContext = dataContext.MapList;
                    teamScoresControl1.DataContext = dataContext.TeamScores;
                    ucBanList.DataContext = dataContext.BanList;
                }
            }
        }
    }
}
