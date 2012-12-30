namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class MainControl
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
            this.tbpServer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucServerInfo = new RConDevServer.Protocol.Dice.Battlefield3.Controls.ServerInfoControl();
            this.tbpPlayers = new System.Windows.Forms.TabPage();
            this.ucPlayers = new RConDevServer.Protocol.Dice.Battlefield3.Controls.PlayerListControl();
            this.tbpMapList = new System.Windows.Forms.TabPage();
            this.uscMapList = new RConDevServer.Protocol.Dice.Battlefield3.Controls.MapListControl();
            this.tbpTickets = new System.Windows.Forms.TabPage();
            this.teamScoresControl1 = new RConDevServer.Protocol.Dice.Battlefield3.Controls.TeamScoresControl();
            this.tbpReservedSlots = new System.Windows.Forms.TabPage();
            this.uscReservedSlots = new RConDevServer.Protocol.Dice.Battlefield3.Controls.ReservedSlotsControl();
            this.tbpEventScript = new System.Windows.Forms.TabPage();
            this.ucEventScript = new RConDevServer.Protocol.Dice.Battlefield3.Controls.EventScriptControl();
            this.tbpConsole = new System.Windows.Forms.TabPage();
            this.ucConsole = new RConDevServer.Protocol.Dice.Battlefield3.Controls.ConsoleControl();
            this.tbpBanList = new System.Windows.Forms.TabPage();
            this.ucBanList = new RConDevServer.Protocol.Dice.Battlefield3.Controls.BanListControl();
            this.tbpServer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbpPlayers.SuspendLayout();
            this.tbpMapList.SuspendLayout();
            this.tbpTickets.SuspendLayout();
            this.tbpReservedSlots.SuspendLayout();
            this.tbpEventScript.SuspendLayout();
            this.tbpConsole.SuspendLayout();
            this.tbpBanList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpServer
            // 
            this.tbpServer.Controls.Add(this.tabPage1);
            this.tbpServer.Controls.Add(this.tbpPlayers);
            this.tbpServer.Controls.Add(this.tbpMapList);
            this.tbpServer.Controls.Add(this.tbpTickets);
            this.tbpServer.Controls.Add(this.tbpReservedSlots);
            this.tbpServer.Controls.Add(this.tbpBanList);
            this.tbpServer.Controls.Add(this.tbpEventScript);
            this.tbpServer.Controls.Add(this.tbpConsole);
            this.tbpServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpServer.Location = new System.Drawing.Point(0, 0);
            this.tbpServer.Name = "tbpServer";
            this.tbpServer.SelectedIndex = 0;
            this.tbpServer.Size = new System.Drawing.Size(485, 598);
            this.tbpServer.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucServerInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 572);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucServerInfo
            // 
            this.ucServerInfo.DataContext = null;
            this.ucServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServerInfo.Location = new System.Drawing.Point(3, 3);
            this.ucServerInfo.Name = "ucServerInfo";
            this.ucServerInfo.Size = new System.Drawing.Size(471, 566);
            this.ucServerInfo.TabIndex = 0;
            // 
            // tbpPlayers
            // 
            this.tbpPlayers.Controls.Add(this.ucPlayers);
            this.tbpPlayers.Location = new System.Drawing.Point(4, 22);
            this.tbpPlayers.Name = "tbpPlayers";
            this.tbpPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPlayers.Size = new System.Drawing.Size(477, 572);
            this.tbpPlayers.TabIndex = 3;
            this.tbpPlayers.Text = "Players";
            this.tbpPlayers.UseVisualStyleBackColor = true;
            // 
            // ucPlayers
            // 
            this.ucPlayers.DataContext = null;
            this.ucPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayers.Location = new System.Drawing.Point(3, 3);
            this.ucPlayers.Name = "ucPlayers";
            this.ucPlayers.Size = new System.Drawing.Size(471, 566);
            this.ucPlayers.TabIndex = 0;
            // 
            // tbpMapList
            // 
            this.tbpMapList.Controls.Add(this.uscMapList);
            this.tbpMapList.Location = new System.Drawing.Point(4, 22);
            this.tbpMapList.Name = "tbpMapList";
            this.tbpMapList.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMapList.Size = new System.Drawing.Size(477, 572);
            this.tbpMapList.TabIndex = 5;
            this.tbpMapList.Text = "Map List";
            this.tbpMapList.UseVisualStyleBackColor = true;
            // 
            // uscMapList
            // 
            this.uscMapList.DataContext = null;
            this.uscMapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscMapList.Location = new System.Drawing.Point(3, 3);
            this.uscMapList.Name = "uscMapList";
            this.uscMapList.Size = new System.Drawing.Size(471, 566);
            this.uscMapList.TabIndex = 0;
            // 
            // tbpTickets
            // 
            this.tbpTickets.Controls.Add(this.teamScoresControl1);
            this.tbpTickets.Location = new System.Drawing.Point(4, 22);
            this.tbpTickets.Name = "tbpTickets";
            this.tbpTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTickets.Size = new System.Drawing.Size(477, 572);
            this.tbpTickets.TabIndex = 6;
            this.tbpTickets.Text = "Tickets / Team Scores";
            this.tbpTickets.UseVisualStyleBackColor = true;
            // 
            // teamScoresControl1
            // 
            this.teamScoresControl1.DataContext = null;
            this.teamScoresControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamScoresControl1.Location = new System.Drawing.Point(3, 3);
            this.teamScoresControl1.Name = "teamScoresControl1";
            this.teamScoresControl1.Size = new System.Drawing.Size(471, 566);
            this.teamScoresControl1.TabIndex = 0;
            // 
            // tbpReservedSlots
            // 
            this.tbpReservedSlots.Controls.Add(this.uscReservedSlots);
            this.tbpReservedSlots.Location = new System.Drawing.Point(4, 22);
            this.tbpReservedSlots.Name = "tbpReservedSlots";
            this.tbpReservedSlots.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReservedSlots.Size = new System.Drawing.Size(477, 572);
            this.tbpReservedSlots.TabIndex = 4;
            this.tbpReservedSlots.Text = "Reserved Slots";
            this.tbpReservedSlots.UseVisualStyleBackColor = true;
            // 
            // uscReservedSlots
            // 
            this.uscReservedSlots.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uscReservedSlots.DataContext = null;
            this.uscReservedSlots.Location = new System.Drawing.Point(66, 45);
            this.uscReservedSlots.Name = "uscReservedSlots";
            this.uscReservedSlots.Size = new System.Drawing.Size(327, 399);
            this.uscReservedSlots.TabIndex = 0;
            // 
            // tbpEventScript
            // 
            this.tbpEventScript.Controls.Add(this.ucEventScript);
            this.tbpEventScript.Location = new System.Drawing.Point(4, 22);
            this.tbpEventScript.Name = "tbpEventScript";
            this.tbpEventScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEventScript.Size = new System.Drawing.Size(477, 572);
            this.tbpEventScript.TabIndex = 2;
            this.tbpEventScript.Text = "Event Script";
            this.tbpEventScript.UseVisualStyleBackColor = true;
            // 
            // ucEventScript
            // 
            this.ucEventScript.AutoScroll = true;
            this.ucEventScript.DataContext = null;
            this.ucEventScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEventScript.Location = new System.Drawing.Point(3, 3);
            this.ucEventScript.Name = "ucEventScript";
            this.ucEventScript.Size = new System.Drawing.Size(471, 566);
            this.ucEventScript.TabIndex = 0;
            // 
            // tbpConsole
            // 
            this.tbpConsole.Controls.Add(this.ucConsole);
            this.tbpConsole.Location = new System.Drawing.Point(4, 22);
            this.tbpConsole.Name = "tbpConsole";
            this.tbpConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConsole.Size = new System.Drawing.Size(477, 572);
            this.tbpConsole.TabIndex = 1;
            this.tbpConsole.Text = "Console";
            this.tbpConsole.UseVisualStyleBackColor = true;
            // 
            // ucConsole
            // 
            this.ucConsole.DataContext = null;
            this.ucConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConsole.Location = new System.Drawing.Point(3, 3);
            this.ucConsole.Name = "ucConsole";
            this.ucConsole.Size = new System.Drawing.Size(471, 566);
            this.ucConsole.TabIndex = 0;
            // 
            // tbpBanList
            // 
            this.tbpBanList.Controls.Add(this.ucBanList);
            this.tbpBanList.Location = new System.Drawing.Point(4, 22);
            this.tbpBanList.Name = "tbpBanList";
            this.tbpBanList.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBanList.Size = new System.Drawing.Size(477, 572);
            this.tbpBanList.TabIndex = 7;
            this.tbpBanList.Text = "Ban List";
            this.tbpBanList.UseVisualStyleBackColor = true;
            // 
            // ucBanList
            // 
            this.ucBanList.DataContext = null;
            this.ucBanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBanList.Location = new System.Drawing.Point(3, 3);
            this.ucBanList.Name = "ucBanList";
            this.ucBanList.Size = new System.Drawing.Size(471, 566);
            this.ucBanList.TabIndex = 0;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbpServer);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(485, 598);
            this.tbpServer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tbpPlayers.ResumeLayout(false);
            this.tbpMapList.ResumeLayout(false);
            this.tbpTickets.ResumeLayout(false);
            this.tbpReservedSlots.ResumeLayout(false);
            this.tbpEventScript.ResumeLayout(false);
            this.tbpConsole.ResumeLayout(false);
            this.tbpBanList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbpServer;
        private System.Windows.Forms.TabPage tabPage1;
        private ServerInfoControl ucServerInfo;
        private System.Windows.Forms.TabPage tbpEventScript;
        private EventScriptControl ucEventScript;
        private System.Windows.Forms.TabPage tbpConsole;
        private ConsoleControl ucConsole;
        private System.Windows.Forms.TabPage tbpPlayers;
        private PlayerListControl ucPlayers;
        private System.Windows.Forms.TabPage tbpReservedSlots;
        private ReservedSlotsControl uscReservedSlots;
        private System.Windows.Forms.TabPage tbpMapList;
        private MapListControl uscMapList;
        private System.Windows.Forms.TabPage tbpTickets;
        private TeamScoresControl teamScoresControl1;
        private System.Windows.Forms.TabPage tbpBanList;
        private BanListControl ucBanList;
    }
}
