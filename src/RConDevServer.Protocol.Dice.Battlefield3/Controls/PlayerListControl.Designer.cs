using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class PlayerListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label deathsLabel;
            System.Windows.Forms.Label eaGuidLabel;
            System.Windows.Forms.Label killsLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label scoreLabel;
            System.Windows.Forms.Label squadIdLabel;
            System.Windows.Forms.Label teamIdLabel;
            this.spcPlayersMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbCreatePlayer = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.teamIdTextBox = new System.Windows.Forms.TextBox();
            this.dbsNewPlayer = new System.Windows.Forms.BindingSource(this.components);
            this.squadIdTextBox = new System.Windows.Forms.TextBox();
            this.deathsTextBox = new System.Windows.Forms.TextBox();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.eaGuidTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.killsTextBox = new System.Windows.Forms.TextBox();
            this.grbPlayerListStore = new System.Windows.Forms.GroupBox();
            this.btnSavePlayerList = new System.Windows.Forms.Button();
            this.lbSavedPlayerLists = new System.Windows.Forms.ListBox();
            this.dbsPlayerListStore = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoadPlayerList = new System.Windows.Forms.Button();
            this.tbxNewSavedPlayerList = new System.Windows.Forms.TextBox();
            this.grbPlayers = new System.Windows.Forms.GroupBox();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.teamIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.squadIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.killsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deathsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitPlayerRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.dbsPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttProvider = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            deathsLabel = new System.Windows.Forms.Label();
            eaGuidLabel = new System.Windows.Forms.Label();
            killsLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            scoreLabel = new System.Windows.Forms.Label();
            squadIdLabel = new System.Windows.Forms.Label();
            teamIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcPlayersMain)).BeginInit();
            this.spcPlayersMain.Panel1.SuspendLayout();
            this.spcPlayersMain.Panel2.SuspendLayout();
            this.spcPlayersMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbCreatePlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewPlayer)).BeginInit();
            this.grbPlayerListStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayerListStore)).BeginInit();
            this.grbPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.cmsPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deathsLabel
            // 
            deathsLabel.AutoSize = true;
            deathsLabel.Location = new System.Drawing.Point(18, 81);
            deathsLabel.Name = "deathsLabel";
            deathsLabel.Size = new System.Drawing.Size(44, 13);
            deathsLabel.TabIndex = 0;
            deathsLabel.Text = "Deaths:";
            // 
            // eaGuidLabel
            // 
            eaGuidLabel.AutoSize = true;
            eaGuidLabel.Location = new System.Drawing.Point(18, 55);
            eaGuidLabel.Name = "eaGuidLabel";
            eaGuidLabel.Size = new System.Drawing.Size(48, 13);
            eaGuidLabel.TabIndex = 99;
            eaGuidLabel.Text = "Ea Guid:";
            // 
            // killsLabel
            // 
            killsLabel.AutoSize = true;
            killsLabel.Location = new System.Drawing.Point(18, 107);
            killsLabel.Name = "killsLabel";
            killsLabel.Size = new System.Drawing.Size(28, 13);
            killsLabel.TabIndex = 99;
            killsLabel.Text = "Kills:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(18, 29);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 99;
            nameLabel.Text = "Name:";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new System.Drawing.Point(18, 133);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new System.Drawing.Size(38, 13);
            scoreLabel.TabIndex = 99;
            scoreLabel.Text = "Score:";
            // 
            // squadIdLabel
            // 
            squadIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            squadIdLabel.AutoSize = true;
            squadIdLabel.Location = new System.Drawing.Point(153, 81);
            squadIdLabel.Name = "squadIdLabel";
            squadIdLabel.Size = new System.Drawing.Size(53, 13);
            squadIdLabel.TabIndex = 99;
            squadIdLabel.Text = "Squad Id:";
            // 
            // teamIdLabel
            // 
            teamIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            teamIdLabel.AutoSize = true;
            teamIdLabel.Location = new System.Drawing.Point(153, 107);
            teamIdLabel.Name = "teamIdLabel";
            teamIdLabel.Size = new System.Drawing.Size(49, 13);
            teamIdLabel.TabIndex = 99;
            teamIdLabel.Text = "Team Id:";
            // 
            // spcPlayersMain
            // 
            this.spcPlayersMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPlayersMain.Location = new System.Drawing.Point(0, 0);
            this.spcPlayersMain.Name = "spcPlayersMain";
            this.spcPlayersMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcPlayersMain.Panel1
            // 
            this.spcPlayersMain.Panel1.Controls.Add(this.splitContainer1);
            // 
            // spcPlayersMain.Panel2
            // 
            this.spcPlayersMain.Panel2.AutoScroll = true;
            this.spcPlayersMain.Panel2.Controls.Add(this.grbPlayers);
            this.spcPlayersMain.Size = new System.Drawing.Size(603, 480);
            this.spcPlayersMain.SplitterDistance = 168;
            this.spcPlayersMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbCreatePlayer);
            this.splitContainer1.Panel1MinSize = 290;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbPlayerListStore);
            this.splitContainer1.Panel2MinSize = 290;
            this.splitContainer1.Size = new System.Drawing.Size(603, 168);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 3;
            // 
            // grbCreatePlayer
            // 
            this.grbCreatePlayer.Controls.Add(this.btnAdd);
            this.grbCreatePlayer.Controls.Add(nameLabel);
            this.grbCreatePlayer.Controls.Add(this.teamIdTextBox);
            this.grbCreatePlayer.Controls.Add(teamIdLabel);
            this.grbCreatePlayer.Controls.Add(deathsLabel);
            this.grbCreatePlayer.Controls.Add(this.squadIdTextBox);
            this.grbCreatePlayer.Controls.Add(this.deathsTextBox);
            this.grbCreatePlayer.Controls.Add(squadIdLabel);
            this.grbCreatePlayer.Controls.Add(eaGuidLabel);
            this.grbCreatePlayer.Controls.Add(this.scoreTextBox);
            this.grbCreatePlayer.Controls.Add(this.eaGuidTextBox);
            this.grbCreatePlayer.Controls.Add(scoreLabel);
            this.grbCreatePlayer.Controls.Add(killsLabel);
            this.grbCreatePlayer.Controls.Add(this.nameTextBox);
            this.grbCreatePlayer.Controls.Add(this.killsTextBox);
            this.grbCreatePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCreatePlayer.Location = new System.Drawing.Point(0, 0);
            this.grbCreatePlayer.Name = "grbCreatePlayer";
            this.grbCreatePlayer.Size = new System.Drawing.Size(291, 168);
            this.grbCreatePlayer.TabIndex = 2;
            this.grbCreatePlayer.TabStop = false;
            this.grbCreatePlayer.Text = "Create new PlayerInfo";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(198, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // teamIdTextBox
            // 
            this.teamIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.teamIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "TeamId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.teamIdTextBox.Location = new System.Drawing.Point(212, 104);
            this.teamIdTextBox.Name = "teamIdTextBox";
            this.teamIdTextBox.Size = new System.Drawing.Size(61, 20);
            this.teamIdTextBox.TabIndex = 7;
            // 
            // dbsNewPlayer
            // 
            this.dbsNewPlayer.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.PlayerInfo);
            // 
            // squadIdTextBox
            // 
            this.squadIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.squadIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "SquadId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.squadIdTextBox.Location = new System.Drawing.Point(212, 78);
            this.squadIdTextBox.Name = "squadIdTextBox";
            this.squadIdTextBox.Size = new System.Drawing.Size(61, 20);
            this.squadIdTextBox.TabIndex = 6;
            // 
            // deathsTextBox
            // 
            this.deathsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "Deaths", true));
            this.deathsTextBox.Location = new System.Drawing.Point(77, 78);
            this.deathsTextBox.Name = "deathsTextBox";
            this.deathsTextBox.Size = new System.Drawing.Size(73, 20);
            this.deathsTextBox.TabIndex = 3;
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "Score", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.scoreTextBox.Location = new System.Drawing.Point(77, 130);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(73, 20);
            this.scoreTextBox.TabIndex = 5;
            // 
            // eaGuidTextBox
            // 
            this.eaGuidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eaGuidTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "EaGuid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.eaGuidTextBox.Location = new System.Drawing.Point(77, 52);
            this.eaGuidTextBox.Name = "eaGuidTextBox";
            this.eaGuidTextBox.Size = new System.Drawing.Size(196, 20);
            this.eaGuidTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nameTextBox.Location = new System.Drawing.Point(77, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(196, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // killsTextBox
            // 
            this.killsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewPlayer, "Kills", true));
            this.killsTextBox.Location = new System.Drawing.Point(77, 104);
            this.killsTextBox.Name = "killsTextBox";
            this.killsTextBox.Size = new System.Drawing.Size(73, 20);
            this.killsTextBox.TabIndex = 4;
            // 
            // grbPlayerListStore
            // 
            this.grbPlayerListStore.Controls.Add(this.btnSavePlayerList);
            this.grbPlayerListStore.Controls.Add(this.lbSavedPlayerLists);
            this.grbPlayerListStore.Controls.Add(this.btnLoadPlayerList);
            this.grbPlayerListStore.Controls.Add(this.tbxNewSavedPlayerList);
            this.grbPlayerListStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPlayerListStore.Location = new System.Drawing.Point(0, 0);
            this.grbPlayerListStore.Name = "grbPlayerListStore";
            this.grbPlayerListStore.Size = new System.Drawing.Size(308, 168);
            this.grbPlayerListStore.TabIndex = 0;
            this.grbPlayerListStore.TabStop = false;
            this.grbPlayerListStore.Text = "Saved PlayerInfo Lists";
            // 
            // btnSavePlayerList
            // 
            this.btnSavePlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePlayerList.Location = new System.Drawing.Point(212, 23);
            this.btnSavePlayerList.Name = "btnSavePlayerList";
            this.btnSavePlayerList.Size = new System.Drawing.Size(75, 23);
            this.btnSavePlayerList.TabIndex = 103;
            this.btnSavePlayerList.Text = "Save";
            this.btnSavePlayerList.UseVisualStyleBackColor = true;
            this.btnSavePlayerList.Click += new System.EventHandler(this.btnSavePlayerList_Click);
            // 
            // lbSavedPlayerLists
            // 
            this.lbSavedPlayerLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSavedPlayerLists.DataSource = this.dbsPlayerListStore;
            this.lbSavedPlayerLists.DisplayMember = "Label";
            this.lbSavedPlayerLists.FormattingEnabled = true;
            this.lbSavedPlayerLists.Location = new System.Drawing.Point(6, 52);
            this.lbSavedPlayerLists.Name = "lbSavedPlayerLists";
            this.lbSavedPlayerLists.Size = new System.Drawing.Size(281, 82);
            this.lbSavedPlayerLists.TabIndex = 102;
            this.lbSavedPlayerLists.ValueMember = "Id";
            // 
            // dbsPlayerListStore
            // 
            this.dbsPlayerListStore.DataMember = "PlayerListStore";
            this.dbsPlayerListStore.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.PlayersViewModel);
            // 
            // btnLoadPlayerList
            // 
            this.btnLoadPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPlayerList.Location = new System.Drawing.Point(212, 140);
            this.btnLoadPlayerList.Name = "btnLoadPlayerList";
            this.btnLoadPlayerList.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPlayerList.TabIndex = 101;
            this.btnLoadPlayerList.Text = "Load";
            this.btnLoadPlayerList.UseVisualStyleBackColor = true;
            this.btnLoadPlayerList.Click += new System.EventHandler(this.btnLoadPlayerList_Click);
            // 
            // tbxNewSavedPlayerList
            // 
            this.tbxNewSavedPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewSavedPlayerList.Location = new System.Drawing.Point(6, 26);
            this.tbxNewSavedPlayerList.Name = "tbxNewSavedPlayerList";
            this.tbxNewSavedPlayerList.Size = new System.Drawing.Size(187, 20);
            this.tbxNewSavedPlayerList.TabIndex = 2;
            // 
            // grbPlayers
            // 
            this.grbPlayers.Controls.Add(this.dgvPlayers);
            this.grbPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPlayers.Location = new System.Drawing.Point(0, 0);
            this.grbPlayers.Name = "grbPlayers";
            this.grbPlayers.Size = new System.Drawing.Size(603, 308);
            this.grbPlayers.TabIndex = 1;
            this.grbPlayers.TabStop = false;
            this.grbPlayers.Text = "Players";
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToResizeRows = false;
            this.dgvPlayers.AutoGenerateColumns = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teamIdDataGridViewTextBoxColumn,
            this.squadIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.killsDataGridViewTextBoxColumn,
            this.deathsDataGridViewTextBoxColumn,
            this.scoreDataGridViewTextBoxColumn});
            this.dgvPlayers.ContextMenuStrip = this.cmsPlayers;
            this.dgvPlayers.DataSource = this.dbsPlayers;
            this.dgvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayers.Location = new System.Drawing.Point(3, 16);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersWidth = 30;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(597, 289);
            this.dgvPlayers.TabIndex = 0;
            // 
            // teamIdDataGridViewTextBoxColumn
            // 
            this.teamIdDataGridViewTextBoxColumn.DataPropertyName = "TeamId";
            this.teamIdDataGridViewTextBoxColumn.HeaderText = "TeamId";
            this.teamIdDataGridViewTextBoxColumn.Name = "teamIdDataGridViewTextBoxColumn";
            // 
            // squadIdDataGridViewTextBoxColumn
            // 
            this.squadIdDataGridViewTextBoxColumn.DataPropertyName = "SquadId";
            this.squadIdDataGridViewTextBoxColumn.HeaderText = "SquadId";
            this.squadIdDataGridViewTextBoxColumn.Name = "squadIdDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // killsDataGridViewTextBoxColumn
            // 
            this.killsDataGridViewTextBoxColumn.DataPropertyName = "Kills";
            this.killsDataGridViewTextBoxColumn.HeaderText = "Kills";
            this.killsDataGridViewTextBoxColumn.Name = "killsDataGridViewTextBoxColumn";
            // 
            // deathsDataGridViewTextBoxColumn
            // 
            this.deathsDataGridViewTextBoxColumn.DataPropertyName = "Deaths";
            this.deathsDataGridViewTextBoxColumn.HeaderText = "Deaths";
            this.deathsDataGridViewTextBoxColumn.Name = "deathsDataGridViewTextBoxColumn";
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            // 
            // cmsPlayers
            // 
            this.cmsPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitPlayerRemove});
            this.cmsPlayers.Name = "cmsPlayers";
            this.cmsPlayers.Size = new System.Drawing.Size(153, 26);
            // 
            // mitPlayerRemove
            // 
            this.mitPlayerRemove.Name = "mitPlayerRemove";
            this.mitPlayerRemove.Size = new System.Drawing.Size(152, 22);
            this.mitPlayerRemove.Text = "Remove PlayerInfo";
            this.mitPlayerRemove.Click += new System.EventHandler(this.mitPlayerRemove_Click);
            // 
            // dbsPlayers
            // 
            this.dbsPlayers.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.PlayerInfo);
            // 
            // errProvider
            // 
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.spcPlayersMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(603, 480);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(603, 505);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            // 
            // PlayerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "PlayerListControl";
            this.Size = new System.Drawing.Size(603, 505);
            this.spcPlayersMain.Panel1.ResumeLayout(false);
            this.spcPlayersMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPlayersMain)).EndInit();
            this.spcPlayersMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbCreatePlayer.ResumeLayout(false);
            this.grbCreatePlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewPlayer)).EndInit();
            this.grbPlayerListStore.ResumeLayout(false);
            this.grbPlayerListStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayerListStore)).EndInit();
            this.grbPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.cmsPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcPlayersMain;
        private System.Windows.Forms.BindingSource dbsPlayers;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn squadIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn killsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deathsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox deathsTextBox;
        private System.Windows.Forms.TextBox eaGuidTextBox;
        private System.Windows.Forms.TextBox killsTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.TextBox squadIdTextBox;
        private System.Windows.Forms.TextBox teamIdTextBox;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.ToolTip ttProvider;
        private System.Windows.Forms.BindingSource dbsNewPlayer;
        private ToolStripContainer toolStripContainer1;
        private GroupBox grbPlayers;
        private GroupBox grbCreatePlayer;
        private Button btnAdd;
        private ContextMenuStrip cmsPlayers;
        private ToolStripMenuItem mitPlayerRemove;
        private SplitContainer splitContainer1;
        private BindingSource dbsPlayerListStore;
        private GroupBox grbPlayerListStore;
        private TextBox tbxNewSavedPlayerList;
        private Button btnLoadPlayerList;
        private ListBox lbSavedPlayerLists;
        private Button btnSavePlayerList;
    }
}
