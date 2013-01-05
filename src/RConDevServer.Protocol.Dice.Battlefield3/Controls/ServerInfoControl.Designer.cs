using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class ServerInfoControl
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
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label serverNameLabel;
            System.Windows.Forms.Label currentMapLabel;
            System.Windows.Forms.Label currentGameModeLabel;
            System.Windows.Forms.Label maxPlayerCountLabel;
            System.Windows.Forms.Label roundsPlayedLabel;
            System.Windows.Forms.Label roundsTotalLabel;
            System.Windows.Forms.Label serverUpTimesLabel;
            System.Windows.Forms.Label roundTimeLabel;
            System.Windows.Forms.Label ipLabel;
            System.Windows.Forms.Label countryLabel;
            System.Windows.Forms.Label regionLabel;
            System.Windows.Forms.Label closestPingSiteLabel;
            this.dbsServer = new System.Windows.Forms.BindingSource(this.components);
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.isAutomaticResponseCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.gbServerInfo = new System.Windows.Forms.GroupBox();
            this.closestPingSiteTextBox = new System.Windows.Forms.TextBox();
            this.dbsServerInfo = new System.Windows.Forms.BindingSource(this.components);
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.dbsCountries = new System.Windows.Forms.BindingSource(this.components);
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.roundTimeSpanLabel1 = new System.Windows.Forms.Label();
            this.roundTimeTextBox = new System.Windows.Forms.TextBox();
            this.serverUpTimeSpanLabel1 = new System.Windows.Forms.Label();
            this.serverUpTimesTextBox = new System.Windows.Forms.TextBox();
            this.isPunkbusterCheckBox = new System.Windows.Forms.CheckBox();
            this.isRankedCheckBox = new System.Windows.Forms.CheckBox();
            this.roundsPlayedTextBox = new System.Windows.Forms.TextBox();
            this.maxPlayerCountTextBox = new System.Windows.Forms.TextBox();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.roundsTotalTextBox = new System.Windows.Forms.TextBox();
            this.currentGameModeComboBox = new System.Windows.Forms.ComboBox();
            this.dbsGameModes = new System.Windows.Forms.BindingSource(this.components);
            this.currentMapComboBox = new System.Windows.Forms.ComboBox();
            this.dbsMaps = new System.Windows.Forms.BindingSource(this.components);
            this.grbMapInformation = new System.Windows.Forms.GroupBox();
            passwordLabel = new System.Windows.Forms.Label();
            serverNameLabel = new System.Windows.Forms.Label();
            currentMapLabel = new System.Windows.Forms.Label();
            currentGameModeLabel = new System.Windows.Forms.Label();
            maxPlayerCountLabel = new System.Windows.Forms.Label();
            roundsPlayedLabel = new System.Windows.Forms.Label();
            roundsTotalLabel = new System.Windows.Forms.Label();
            serverUpTimesLabel = new System.Windows.Forms.Label();
            roundTimeLabel = new System.Windows.Forms.Label();
            ipLabel = new System.Windows.Forms.Label();
            countryLabel = new System.Windows.Forms.Label();
            regionLabel = new System.Windows.Forms.Label();
            closestPingSiteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbsServer)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.gbServerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsServerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsGameModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsMaps)).BeginInit();
            this.grbMapInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(6, 25);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(86, 13);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "RCon Password:";
            // 
            // serverNameLabel
            // 
            serverNameLabel.AutoSize = true;
            serverNameLabel.Location = new System.Drawing.Point(6, 30);
            serverNameLabel.Name = "serverNameLabel";
            serverNameLabel.Size = new System.Drawing.Size(72, 13);
            serverNameLabel.TabIndex = 0;
            serverNameLabel.Text = "Server Name:";
            // 
            // currentMapLabel
            // 
            currentMapLabel.AutoSize = true;
            currentMapLabel.Location = new System.Drawing.Point(6, 16);
            currentMapLabel.Name = "currentMapLabel";
            currentMapLabel.Size = new System.Drawing.Size(68, 13);
            currentMapLabel.TabIndex = 2;
            currentMapLabel.Text = "Current Map:";
            // 
            // currentGameModeLabel
            // 
            currentGameModeLabel.AutoSize = true;
            currentGameModeLabel.Location = new System.Drawing.Point(6, 43);
            currentGameModeLabel.Name = "currentGameModeLabel";
            currentGameModeLabel.Size = new System.Drawing.Size(105, 13);
            currentGameModeLabel.TabIndex = 4;
            currentGameModeLabel.Text = "Current Game Mode:";
            // 
            // maxPlayerCountLabel
            // 
            maxPlayerCountLabel.AutoSize = true;
            maxPlayerCountLabel.Location = new System.Drawing.Point(6, 82);
            maxPlayerCountLabel.Name = "maxPlayerCountLabel";
            maxPlayerCountLabel.Size = new System.Drawing.Size(93, 13);
            maxPlayerCountLabel.TabIndex = 8;
            maxPlayerCountLabel.Text = "Max PlayerInfo Count:";
            // 
            // roundsPlayedLabel
            // 
            roundsPlayedLabel.AutoSize = true;
            roundsPlayedLabel.Location = new System.Drawing.Point(6, 108);
            roundsPlayedLabel.Name = "roundsPlayedLabel";
            roundsPlayedLabel.Size = new System.Drawing.Size(82, 13);
            roundsPlayedLabel.TabIndex = 10;
            roundsPlayedLabel.Text = "Rounds Played:";
            // 
            // roundsTotalLabel
            // 
            roundsTotalLabel.AutoSize = true;
            roundsTotalLabel.Location = new System.Drawing.Point(6, 70);
            roundsTotalLabel.Name = "roundsTotalLabel";
            roundsTotalLabel.Size = new System.Drawing.Size(74, 13);
            roundsTotalLabel.TabIndex = 12;
            roundsTotalLabel.Text = "Rounds Total:";
            // 
            // serverUpTimesLabel
            // 
            serverUpTimesLabel.AutoSize = true;
            serverUpTimesLabel.Location = new System.Drawing.Point(6, 164);
            serverUpTimesLabel.Name = "serverUpTimesLabel";
            serverUpTimesLabel.Size = new System.Drawing.Size(84, 13);
            serverUpTimesLabel.TabIndex = 16;
            serverUpTimesLabel.Text = "Server Up Time:";
            // 
            // roundTimeLabel
            // 
            roundTimeLabel.AutoSize = true;
            roundTimeLabel.Location = new System.Drawing.Point(6, 190);
            roundTimeLabel.Name = "roundTimeLabel";
            roundTimeLabel.Size = new System.Drawing.Size(68, 13);
            roundTimeLabel.TabIndex = 19;
            roundTimeLabel.Text = "Round Time:";
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new System.Drawing.Point(6, 56);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new System.Drawing.Size(49, 13);
            ipLabel.TabIndex = 22;
            ipLabel.Text = "Ip / Port:";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(6, 268);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(46, 13);
            countryLabel.TabIndex = 25;
            countryLabel.Text = "Country:";
            // 
            // regionLabel
            // 
            regionLabel.AutoSize = true;
            regionLabel.Location = new System.Drawing.Point(6, 216);
            regionLabel.Name = "regionLabel";
            regionLabel.Size = new System.Drawing.Size(44, 13);
            regionLabel.TabIndex = 26;
            regionLabel.Text = "Region:";
            // 
            // closestPingSiteLabel
            // 
            closestPingSiteLabel.AutoSize = true;
            closestPingSiteLabel.Location = new System.Drawing.Point(6, 242);
            closestPingSiteLabel.Name = "closestPingSiteLabel";
            closestPingSiteLabel.Size = new System.Drawing.Size(89, 13);
            closestPingSiteLabel.TabIndex = 27;
            closestPingSiteLabel.Text = "Closest Ping Site:";
            // 
            // dbsServer
            // 
            this.dbsServer.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.ServerViewModel);
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.Controls.Add(this.isAutomaticResponseCheckBox);
            this.gbSettings.Controls.Add(passwordLabel);
            this.gbSettings.Controls.Add(this.passwordTextBox);
            this.gbSettings.Location = new System.Drawing.Point(3, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(490, 85);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // isAutomaticResponseCheckBox
            // 
            this.isAutomaticResponseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dbsServer, "IsAutomaticResponse", true));
            this.isAutomaticResponseCheckBox.Location = new System.Drawing.Point(120, 48);
            this.isAutomaticResponseCheckBox.Name = "isAutomaticResponseCheckBox";
            this.isAutomaticResponseCheckBox.Size = new System.Drawing.Size(217, 24);
            this.isAutomaticResponseCheckBox.TabIndex = 3;
            this.isAutomaticResponseCheckBox.Text = "Automatic Response";
            this.isAutomaticResponseCheckBox.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServer, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.passwordTextBox.Location = new System.Drawing.Point(120, 22);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(217, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // gbServerInfo
            // 
            this.gbServerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServerInfo.Controls.Add(closestPingSiteLabel);
            this.gbServerInfo.Controls.Add(this.closestPingSiteTextBox);
            this.gbServerInfo.Controls.Add(regionLabel);
            this.gbServerInfo.Controls.Add(this.regionTextBox);
            this.gbServerInfo.Controls.Add(countryLabel);
            this.gbServerInfo.Controls.Add(this.countryComboBox);
            this.gbServerInfo.Controls.Add(this.portTextBox);
            this.gbServerInfo.Controls.Add(ipLabel);
            this.gbServerInfo.Controls.Add(this.ipTextBox);
            this.gbServerInfo.Controls.Add(this.roundTimeSpanLabel1);
            this.gbServerInfo.Controls.Add(roundTimeLabel);
            this.gbServerInfo.Controls.Add(this.roundTimeTextBox);
            this.gbServerInfo.Controls.Add(this.serverUpTimeSpanLabel1);
            this.gbServerInfo.Controls.Add(serverUpTimesLabel);
            this.gbServerInfo.Controls.Add(this.serverUpTimesTextBox);
            this.gbServerInfo.Controls.Add(this.isPunkbusterCheckBox);
            this.gbServerInfo.Controls.Add(this.isRankedCheckBox);
            this.gbServerInfo.Controls.Add(roundsPlayedLabel);
            this.gbServerInfo.Controls.Add(this.roundsPlayedTextBox);
            this.gbServerInfo.Controls.Add(maxPlayerCountLabel);
            this.gbServerInfo.Controls.Add(this.maxPlayerCountTextBox);
            this.gbServerInfo.Controls.Add(serverNameLabel);
            this.gbServerInfo.Controls.Add(this.serverNameTextBox);
            this.gbServerInfo.Location = new System.Drawing.Point(3, 94);
            this.gbServerInfo.Name = "gbServerInfo";
            this.gbServerInfo.Size = new System.Drawing.Size(490, 295);
            this.gbServerInfo.TabIndex = 1;
            this.gbServerInfo.TabStop = false;
            this.gbServerInfo.Text = "Server Information";
            // 
            // closestPingSiteTextBox
            // 
            this.closestPingSiteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "ClosestPingSite", true));
            this.closestPingSiteTextBox.Location = new System.Drawing.Point(120, 239);
            this.closestPingSiteTextBox.Name = "closestPingSiteTextBox";
            this.closestPingSiteTextBox.Size = new System.Drawing.Size(217, 20);
            this.closestPingSiteTextBox.TabIndex = 28;
            // 
            // dbsServerInfo
            // 
            this.dbsServerInfo.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.ServerInfoViewModel);
            // 
            // regionTextBox
            // 
            this.regionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "Region", true));
            this.regionTextBox.Location = new System.Drawing.Point(120, 213);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(217, 20);
            this.regionTextBox.TabIndex = 27;
            // 
            // countryComboBox
            // 
            this.countryComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsServerInfo, "Country", true));
            this.countryComboBox.DataSource = this.dbsCountries;
            this.countryComboBox.DisplayMember = "Display";
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(120, 265);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(217, 21);
            this.countryComboBox.TabIndex = 26;
            this.countryComboBox.ValueMember = "Instance";
            // 
            // dbsCountries
            // 
            this.dbsCountries.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.Country);
            // 
            // portTextBox
            // 
            this.portTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "Port", true));
            this.portTextBox.Location = new System.Drawing.Point(285, 53);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(52, 20);
            this.portTextBox.TabIndex = 25;
            // 
            // ipTextBox
            // 
            this.ipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "Ip", true));
            this.ipTextBox.Location = new System.Drawing.Point(120, 53);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(159, 20);
            this.ipTextBox.TabIndex = 23;
            // 
            // roundTimeSpanLabel1
            // 
            this.roundTimeSpanLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "RoundTimeSpan", true));
            this.roundTimeSpanLabel1.Location = new System.Drawing.Point(237, 190);
            this.roundTimeSpanLabel1.Name = "roundTimeSpanLabel1";
            this.roundTimeSpanLabel1.Size = new System.Drawing.Size(100, 23);
            this.roundTimeSpanLabel1.TabIndex = 22;
            this.roundTimeSpanLabel1.Text = "label1";
            // 
            // roundTimeTextBox
            // 
            this.roundTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "RoundTime", true));
            this.roundTimeTextBox.Location = new System.Drawing.Point(120, 187);
            this.roundTimeTextBox.Name = "roundTimeTextBox";
            this.roundTimeTextBox.Size = new System.Drawing.Size(108, 20);
            this.roundTimeTextBox.TabIndex = 20;
            // 
            // serverUpTimeSpanLabel1
            // 
            this.serverUpTimeSpanLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "ServerUpTimeSpan", true));
            this.serverUpTimeSpanLabel1.Location = new System.Drawing.Point(237, 164);
            this.serverUpTimeSpanLabel1.Name = "serverUpTimeSpanLabel1";
            this.serverUpTimeSpanLabel1.Size = new System.Drawing.Size(100, 23);
            this.serverUpTimeSpanLabel1.TabIndex = 19;
            this.serverUpTimeSpanLabel1.Text = "label1";
            // 
            // serverUpTimesTextBox
            // 
            this.serverUpTimesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "ServerUpTime", true));
            this.serverUpTimesTextBox.Location = new System.Drawing.Point(120, 161);
            this.serverUpTimesTextBox.Name = "serverUpTimesTextBox";
            this.serverUpTimesTextBox.Size = new System.Drawing.Size(108, 20);
            this.serverUpTimesTextBox.TabIndex = 17;
            // 
            // isPunkbusterCheckBox
            // 
            this.isPunkbusterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dbsServerInfo, "IsPunkbuster", true));
            this.isPunkbusterCheckBox.Location = new System.Drawing.Point(233, 131);
            this.isPunkbusterCheckBox.Name = "isPunkbusterCheckBox";
            this.isPunkbusterCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isPunkbusterCheckBox.TabIndex = 16;
            this.isPunkbusterCheckBox.Text = "Punkbuster";
            this.isPunkbusterCheckBox.UseVisualStyleBackColor = true;
            // 
            // isRankedCheckBox
            // 
            this.isRankedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dbsServerInfo, "IsRanked", true));
            this.isRankedCheckBox.Location = new System.Drawing.Point(120, 131);
            this.isRankedCheckBox.Name = "isRankedCheckBox";
            this.isRankedCheckBox.Size = new System.Drawing.Size(84, 24);
            this.isRankedCheckBox.TabIndex = 15;
            this.isRankedCheckBox.Text = "Ranked";
            this.isRankedCheckBox.UseVisualStyleBackColor = true;
            // 
            // roundsPlayedTextBox
            // 
            this.roundsPlayedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "RoundsPlayed", true));
            this.roundsPlayedTextBox.Location = new System.Drawing.Point(120, 105);
            this.roundsPlayedTextBox.Name = "roundsPlayedTextBox";
            this.roundsPlayedTextBox.Size = new System.Drawing.Size(217, 20);
            this.roundsPlayedTextBox.TabIndex = 11;
            // 
            // maxPlayerCountTextBox
            // 
            this.maxPlayerCountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "MaxPlayerCount", true));
            this.maxPlayerCountTextBox.Location = new System.Drawing.Point(120, 79);
            this.maxPlayerCountTextBox.Name = "maxPlayerCountTextBox";
            this.maxPlayerCountTextBox.Size = new System.Drawing.Size(217, 20);
            this.maxPlayerCountTextBox.TabIndex = 9;
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServer, "ServerInfo.ServerName", true));
            this.serverNameTextBox.Location = new System.Drawing.Point(120, 27);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(217, 20);
            this.serverNameTextBox.TabIndex = 1;
            // 
            // roundsTotalTextBox
            // 
            this.roundsTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServerInfo, "RoundsTotal", true));
            this.roundsTotalTextBox.Location = new System.Drawing.Point(123, 67);
            this.roundsTotalTextBox.Name = "roundsTotalTextBox";
            this.roundsTotalTextBox.ReadOnly = true;
            this.roundsTotalTextBox.Size = new System.Drawing.Size(217, 20);
            this.roundsTotalTextBox.TabIndex = 13;
            // 
            // currentGameModeComboBox
            // 
            this.currentGameModeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsServerInfo, "CurrentGameMode", true));
            this.currentGameModeComboBox.DataSource = this.dbsGameModes;
            this.currentGameModeComboBox.DisplayMember = "Display";
            this.currentGameModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentGameModeComboBox.Enabled = false;
            this.currentGameModeComboBox.FormattingEnabled = true;
            this.currentGameModeComboBox.Location = new System.Drawing.Point(123, 40);
            this.currentGameModeComboBox.Name = "currentGameModeComboBox";
            this.currentGameModeComboBox.Size = new System.Drawing.Size(217, 21);
            this.currentGameModeComboBox.TabIndex = 5;
            this.currentGameModeComboBox.ValueMember = "Instance";
            // 
            // dbsGameModes
            // 
            this.dbsGameModes.DataMember = "AvailableGameModes";
            this.dbsGameModes.DataSource = this.dbsServerInfo;
            // 
            // currentMapComboBox
            // 
            this.currentMapComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsServerInfo, "CurrentMap", true));
            this.currentMapComboBox.DataSource = this.dbsMaps;
            this.currentMapComboBox.DisplayMember = "Display";
            this.currentMapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentMapComboBox.Enabled = false;
            this.currentMapComboBox.FormattingEnabled = true;
            this.currentMapComboBox.Location = new System.Drawing.Point(123, 13);
            this.currentMapComboBox.Name = "currentMapComboBox";
            this.currentMapComboBox.Size = new System.Drawing.Size(217, 21);
            this.currentMapComboBox.TabIndex = 3;
            this.currentMapComboBox.ValueMember = "Instance";
            // 
            // dbsMaps
            // 
            this.dbsMaps.DataMember = "AvailableMaps";
            this.dbsMaps.DataSource = this.dbsServerInfo;
            // 
            // grbMapInformation
            // 
            this.grbMapInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMapInformation.Controls.Add(currentMapLabel);
            this.grbMapInformation.Controls.Add(this.currentMapComboBox);
            this.grbMapInformation.Controls.Add(this.currentGameModeComboBox);
            this.grbMapInformation.Controls.Add(currentGameModeLabel);
            this.grbMapInformation.Controls.Add(roundsTotalLabel);
            this.grbMapInformation.Controls.Add(this.roundsTotalTextBox);
            this.grbMapInformation.Location = new System.Drawing.Point(3, 395);
            this.grbMapInformation.Name = "grbMapInformation";
            this.grbMapInformation.Size = new System.Drawing.Size(490, 98);
            this.grbMapInformation.TabIndex = 2;
            this.grbMapInformation.TabStop = false;
            this.grbMapInformation.Text = "Map Information";
            // 
            // ServerInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbMapInformation);
            this.Controls.Add(this.gbServerInfo);
            this.Controls.Add(this.gbSettings);
            this.Name = "ServerInfoControl";
            this.Size = new System.Drawing.Size(496, 501);
            ((System.ComponentModel.ISupportInitialize)(this.dbsServer)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbServerInfo.ResumeLayout(false);
            this.gbServerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsServerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsGameModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsMaps)).EndInit();
            this.grbMapInformation.ResumeLayout(false);
            this.grbMapInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dbsServer;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.GroupBox gbServerInfo;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.ComboBox currentMapComboBox;
        private System.Windows.Forms.BindingSource dbsServerInfo;
        private System.Windows.Forms.BindingSource dbsMaps;
        private System.Windows.Forms.ComboBox currentGameModeComboBox;
        private System.Windows.Forms.BindingSource dbsGameModes;
        private System.Windows.Forms.TextBox maxPlayerCountTextBox;
        private System.Windows.Forms.TextBox roundsTotalTextBox;
        private System.Windows.Forms.TextBox roundsPlayedTextBox;
        private System.Windows.Forms.CheckBox isRankedCheckBox;
        private System.Windows.Forms.CheckBox isPunkbusterCheckBox;
        private System.Windows.Forms.TextBox serverUpTimesTextBox;
        private System.Windows.Forms.Label serverUpTimeSpanLabel1;
        private System.Windows.Forms.Label roundTimeSpanLabel1;
        private System.Windows.Forms.TextBox roundTimeTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.CheckBox isAutomaticResponseCheckBox;
        private System.Windows.Forms.GroupBox grbMapInformation;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.BindingSource dbsCountries;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.TextBox closestPingSiteTextBox;
    }
}
