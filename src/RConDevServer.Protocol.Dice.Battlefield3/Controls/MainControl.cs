namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System.Windows.Forms;
    using Ui;

    public partial class MainControl : UserControl
    {
        private ServerViewModel dataContext;

        public MainControl()
        {
            this.InitializeComponent();
        }

        public ServerViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.ucConsole.DataContext = this.dataContext;
                    this.ucServerInfo.DataContext = this.dataContext;
                    this.ucEventScript.DataContext = this.dataContext.EventScript;
                    this.ucPlayers.DataContext = this.dataContext.Players;
                    this.uscReservedSlots.DataContext = this.dataContext.ReservedSlots;
                    this.uscMapList.DataContext = this.dataContext.MapList;
                    this.teamScoresControl1.DataContext = this.dataContext.TeamScores;
                    this.ucBanList.DataContext = this.dataContext.BanList;
                }
            }
        }
    }
}