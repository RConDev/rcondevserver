namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Data;
    using Ui;

    public partial class ReservedSlotsControl : UserControl
    {
        private ReservedSlotsViewModel dataContext;

        public ReservedSlotsControl()
        {
            this.InitializeComponent();
        }

        public ReservedSlotsViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.dataContext.PropertyChanged += this.DataContextOnPropertyChanged;
                    this.dbsReservedSlots.DataSource = this.dataContext;
                    this.dbsReservedSlots.ResetBindings(false);
                }
            }
        }

        #region Event Handler

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedPlayer = this.dbsPlayers.Current as ReservedSlot;
            if (selectedPlayer != null)
            {
                this.dataContext.ReservedSlots.Remove(selectedPlayer);
                this.dbsReservedSlots.ResetBindings(false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string playerName = this.tbxPlayerName.Text;
            bool hasError = false;
            if (string.IsNullOrEmpty(playerName))
            {
                this.errProvider.SetError(this.tbxPlayerName, "Please state a player Name.");
                hasError = true;
            }
            if (this.dataContext.ReservedSlots.Any(x => x.PlayerName == playerName))
            {
                this.errProvider.SetError(this.tbxPlayerName, "PlayerInfo already is listed.");
                hasError = true;
            }
            if (!hasError)
            {
                this.DataContext.ReservedSlots.Add(new ReservedSlot {PlayerName = playerName});
                this.dbsReservedSlots.ResetBindings(false);
                this.tbxPlayerName.Clear();
                this.errProvider.Clear();
            }
        }

        private void DataContextOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == null)
            {
                this.dbsReservedSlots.DataSource = this.dataContext;
                this.dbsReservedSlots.ResetBindings(false);
            }
        }

        #endregion
    }
}