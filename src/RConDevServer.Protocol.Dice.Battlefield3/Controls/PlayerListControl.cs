using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System.IO;
    using System.Runtime.Serialization;
    using Resource.Properties;

    public partial class PlayerListControl : UserControl
    {
        private PlayersViewModel dataContext;

        public PlayerListControl()
        {
            InitializeComponent();
        }

        #region Pubic Properties

        public PlayersViewModel DataContext
        {
            get { return dataContext; }
            set
            {
                dataContext = value;
                if (dataContext == null) return;

                dbsPlayers.DataSource = dataContext.Players;
                dbsNewPlayer.DataSource = dataContext.NewPlayerInfo;
                dbsPlayers.ResetBindings(false);

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
                return;

            this.errProvider.Clear();
            dataContext.Players.Add(dataContext.NewPlayerInfo);
            dbsPlayers.ResetBindings(false);
            dataContext.NewPlayerInfo = new PlayerInfo();
            dbsNewPlayer.DataSource = dataContext.NewPlayerInfo;
            this.dbsPlayers.ResetBindings(false);
        }

        private bool AreFieldsValid()
        {
            var playerName = dataContext.NewPlayerInfo.Name;
            var teamId = dataContext.NewPlayerInfo.TeamId;
            var squadId = dataContext.NewPlayerInfo.SquadId;
            var kills = dataContext.NewPlayerInfo.Kills;
            var deaths = dataContext.NewPlayerInfo.Deaths;
            var score = dataContext.NewPlayerInfo.Score;
            var isValid = true;

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

        private void TsbSavePlayerListClick(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnSavePlayerList_Click(object sender, EventArgs e)
        {
            var listName = this.tbxNewSavedPlayerList.Text;
            if (string.IsNullOrEmpty(listName))
            {
                MessageBox.Show("A list cannot be saved without a unique name.");
                return;
            }

            bool overrideExisting = false;
            if (this.dataContext.PlayerListStore.Any(x => x.Label == listName))
            {
                var dialogResult = MessageBox.Show("The List already exists. Override it?", "",
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
    }
}