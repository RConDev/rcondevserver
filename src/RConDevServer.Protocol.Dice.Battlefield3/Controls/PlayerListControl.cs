namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Data;
    using Ui;

    public partial class PlayerListControl : UserControl
    {
        private PlayersViewModel dataContext;

        public PlayerListControl()
        {
            this.InitializeComponent();
        }

        #region Pubic Properties

        public PlayersViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext == null)
                {
                    return;
                }

                this.dbsPlayers.DataSource = this.dataContext.Players;
                this.dbsNewPlayer.DataSource = this.dataContext.NewPlayerInfo;
                this.dbsPlayers.ResetBindings(false);

                this.dataContext.Initialize();
                this.dbsPlayerListStore.DataSource = this.dataContext.PlayerListStore;
                this.dbsPlayerListStore.ResetBindings(false);
            }
        }

        #endregion

        #region Event Handler

        private void mitPlayerRemove_Click(object sender, EventArgs e)
        {
            var current = this.dbsPlayers.Current as PlayerInfo;
            if (current != null)
            {
                if (this.dataContext.Players.Contains(current))
                {
                    this.dataContext.Players.Remove(current);
                    this.dbsPlayers.DataSource = this.dataContext.Players;
                    this.dbsPlayers.ResetBindings(false);

                    this.dbsPlayerListStore.DataSource = this.dataContext.PlayerListStore;
                    this.dbsPlayerListStore.ResetBindings(false);
                }
            }
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            if (!this.AreFieldsValid())
            {
                return;
            }

            this.errProvider.Clear();
            this.dataContext.Players.Add(this.dataContext.NewPlayerInfo);
            this.dbsPlayers.ResetBindings(false);
            this.dataContext.NewPlayerInfo = new PlayerInfo();
            this.dbsNewPlayer.DataSource = this.dataContext.NewPlayerInfo;
            this.dbsPlayers.ResetBindings(false);
        }

        private bool AreFieldsValid()
        {
            string playerName = this.dataContext.NewPlayerInfo.Name;
            int teamId = this.dataContext.NewPlayerInfo.TeamId;
            int squadId = this.dataContext.NewPlayerInfo.SquadId;
            int kills = this.dataContext.NewPlayerInfo.Kills;
            int deaths = this.dataContext.NewPlayerInfo.Deaths;
            int score = this.dataContext.NewPlayerInfo.Score;
            bool isValid = true;

            #region Name

            if (string.IsNullOrEmpty(playerName))
            {
                this.errProvider.SetError(this.nameTextBox, "Value may not be null or empty");
                isValid = false;
            }
            if (this.dataContext.Players.Any(x => x.Name == playerName))
            {
                this.errProvider.SetError(this.nameTextBox, "PlayerInfo allready exists");
                isValid = false;
            }

            #endregion

            #region TeamID

            if (teamId <= 0)
            {
                this.errProvider.SetError(this.teamIdTextBox, "Team Id must be set > 0");
                isValid = false;
            }

            #endregion

            #region SquadId

            if (squadId < 0)
            {
                this.errProvider.SetError(this.squadIdTextBox, "Squad Id must be set  >= 0 ");
                isValid = false;
            }

            #endregion

            #region Kills

            if (kills < 0)
            {
                this.errProvider.SetError(this.killsTextBox, "Kills must be set >= 0 ");
                isValid = false;
            }

            #endregion

            #region Deaths

            if (deaths < 0)
            {
                this.errProvider.SetError(this.deathsTextBox, "Deaths must be set >= 0");
                isValid = false;
            }

            #endregion

            #region Deaths

            if (score < 0)
            {
                this.errProvider.SetError(this.scoreTextBox, "Score must be set >= 0");
                isValid = false;
            }

            #endregion

            return isValid;
        }

        private void btnSavePlayerList_Click(object sender, EventArgs e)
        {
            string listName = this.tbxNewSavedPlayerList.Text;
            if (string.IsNullOrEmpty(listName))
            {
                MessageBox.Show("A list cannot be saved without a unique name.");
                return;
            }

            bool overrideExisting = false;
            if (this.dataContext.PlayerListStore.Any(x => x.Label == listName))
            {
                DialogResult dialogResult = MessageBox.Show("The List already exists. Override it?", "",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                overrideExisting = dialogResult == DialogResult.Yes;
            }

            this.dataContext.SavePlayerList(listName, overrideExisting);
            this.tbxNewSavedPlayerList.Clear();
            this.dataContext.Initialize();
            this.dbsPlayerListStore.DataSource = this.dataContext.PlayerListStore;
            this.dbsPlayerListStore.ResetBindings(false);
        }

        private void btnLoadPlayerList_Click(object sender, EventArgs e)
        {
            var selectedListItem = this.dbsPlayerListStore.Current as PlayerListStoreItem;
            if (selectedListItem != null)
            {
                this.dataContext.LoadPlayerList(selectedListItem);
                this.dbsPlayers.DataSource = this.dataContext.Players;
                this.dbsPlayers.ResetBindings(false);
            }
        }

        #endregion
    }
}