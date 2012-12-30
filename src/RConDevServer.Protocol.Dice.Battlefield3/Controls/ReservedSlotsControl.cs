using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    public partial class ReservedSlotsControl : UserControl
    {
        private ReservedSlotsViewModel dataContext;

        public ReservedSlotsControl()
        {
            InitializeComponent();
        }

        public ReservedSlotsViewModel DataContext
        {
            get {
                return dataContext;
            }
            set {
                dataContext = value;
                if (dataContext != null)
                {
                    this.dataContext.PropertyChanged += DataContextOnPropertyChanged;
                    this.dbsReservedSlots.DataSource = dataContext;
                    this.dbsReservedSlots.ResetBindings(false);
                }
            }
        }

        #region Event Handler

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedPlayer = dbsPlayers.Current as ReservedSlot;
            if (selectedPlayer != null)
            {
                dataContext.ReservedSlots.Remove(selectedPlayer);
                this.dbsReservedSlots.ResetBindings(false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var playerName = this.tbxPlayerName.Text;
            var hasError = false;
            if (string.IsNullOrEmpty(playerName))
            {
                this.errProvider.SetError(this.tbxPlayerName, "Please state a player Name.");
                hasError = true;
            }
            if (this.dataContext.ReservedSlots.Any(x => x.PlayerName == playerName))
            {
                this.errProvider.SetError(this.tbxPlayerName, "Player already is listed.");
                hasError = true;
            }
            if (!hasError)
            {
                this.DataContext.ReservedSlots.Add(new ReservedSlot() {PlayerName = playerName});
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
