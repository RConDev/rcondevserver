using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using Util;

    partial class ConsoleControl
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
            this.spcSessions = new System.Windows.Forms.SplitContainer();
            this.dgwSessions = new System.Windows.Forms.DataGridView();
            this.cmsSessions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitCloseSession = new System.Windows.Forms.ToolStripMenuItem();
            this.dbsSessions = new System.Windows.Forms.BindingSource(this.components);
            this.spcConsole = new System.Windows.Forms.SplitContainer();
            this.dgwPackets = new System.Windows.Forms.DataGridView();
            this.dbsPackets = new System.Windows.Forms.BindingSource(this.components);
            this.spcServer = new System.Windows.Forms.SplitContainer();
            this.rtbServerConsole = new System.Windows.Forms.RichTextBox();
            this.dbsServer = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequenceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isResponseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.packetSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wordCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isClientCommandDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isServerEventResponseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wordsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucPacketBuilder = new RConDevServer.Protocol.Dice.Battlefield3.Controls.PacketBuilderControl();
            ((System.ComponentModel.ISupportInitialize)(this.spcSessions)).BeginInit();
            this.spcSessions.Panel1.SuspendLayout();
            this.spcSessions.Panel2.SuspendLayout();
            this.spcSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSessions)).BeginInit();
            this.cmsSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsSessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcConsole)).BeginInit();
            this.spcConsole.Panel1.SuspendLayout();
            this.spcConsole.Panel2.SuspendLayout();
            this.spcConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPackets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPackets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcServer)).BeginInit();
            this.spcServer.Panel1.SuspendLayout();
            this.spcServer.Panel2.SuspendLayout();
            this.spcServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsServer)).BeginInit();
            this.SuspendLayout();
            // 
            // spcSessions
            // 
            this.spcSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSessions.Location = new System.Drawing.Point(0, 0);
            this.spcSessions.Name = "spcSessions";
            // 
            // spcSessions.Panel1
            // 
            this.spcSessions.Panel1.AutoScroll = true;
            this.spcSessions.Panel1.Controls.Add(this.dgwSessions);
            // 
            // spcSessions.Panel2
            // 
            this.spcSessions.Panel2.Controls.Add(this.spcConsole);
            this.spcSessions.Size = new System.Drawing.Size(647, 448);
            this.spcSessions.SplitterDistance = 196;
            this.spcSessions.TabIndex = 0;
            // 
            // dgwSessions
            // 
            this.dgwSessions.AutoGenerateColumns = false;
            this.dgwSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.dgwSessions.ContextMenuStrip = this.cmsSessions;
            this.dgwSessions.DataSource = this.dbsSessions;
            this.dgwSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwSessions.Location = new System.Drawing.Point(0, 0);
            this.dgwSessions.MultiSelect = false;
            this.dgwSessions.Name = "dgwSessions";
            this.dgwSessions.RowHeadersVisible = false;
            this.dgwSessions.Size = new System.Drawing.Size(196, 448);
            this.dgwSessions.TabIndex = 0;
            // 
            // cmsSessions
            // 
            this.cmsSessions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitCloseSession});
            this.cmsSessions.Name = "cmsSessions";
            this.cmsSessions.Size = new System.Drawing.Size(146, 26);
            // 
            // mitCloseSession
            // 
            this.mitCloseSession.Name = "mitCloseSession";
            this.mitCloseSession.Size = new System.Drawing.Size(145, 22);
            this.mitCloseSession.Text = "Close Session";
            this.mitCloseSession.Click += new System.EventHandler(this.MitCloseSessionClick);
            // 
            // dbsSessions
            // 
            this.dbsSessions.DataMember = "Sessions";
            this.dbsSessions.DataSource = this.dbsServer;
            // 
            // spcConsole
            // 
            this.spcConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcConsole.Location = new System.Drawing.Point(0, 0);
            this.spcConsole.Name = "spcConsole";
            this.spcConsole.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcConsole.Panel1
            // 
            this.spcConsole.Panel1.Controls.Add(this.dgwPackets);
            // 
            // spcConsole.Panel2
            // 
            this.spcConsole.Panel2.Controls.Add(this.ucPacketBuilder);
            this.spcConsole.Size = new System.Drawing.Size(447, 448);
            this.spcConsole.SplitterDistance = 210;
            this.spcConsole.TabIndex = 0;
            // 
            // dgwPackets
            // 
            this.dgwPackets.AllowUserToAddRows = false;
            this.dgwPackets.AllowUserToDeleteRows = false;
            this.dgwPackets.AllowUserToResizeRows = false;
            this.dgwPackets.AutoGenerateColumns = false;
            this.dgwPackets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPackets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sequenceIdDataGridViewTextBoxColumn,
            this.originDataGridViewTextBoxColumn,
            this.isResponseDataGridViewCheckBoxColumn,
            this.packetSizeDataGridViewTextBoxColumn,
            this.wordCountDataGridViewTextBoxColumn,
            this.isClientCommandDataGridViewCheckBoxColumn,
            this.isServerEventResponseDataGridViewCheckBoxColumn,
            this.wordsDataGridViewTextBoxColumn});
            this.dgwPackets.DataSource = this.dbsPackets;
            this.dgwPackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwPackets.Location = new System.Drawing.Point(0, 0);
            this.dgwPackets.MultiSelect = false;
            this.dgwPackets.Name = "dgwPackets";
            this.dgwPackets.ReadOnly = true;
            this.dgwPackets.Size = new System.Drawing.Size(447, 210);
            this.dgwPackets.TabIndex = 2;
            this.dgwPackets.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DgwPacketsRowsAdded);
            // 
            // dbsPackets
            // 
            this.dbsPackets.DataMember = "Packets";
            this.dbsPackets.DataSource = this.dbsSessions;
            // 
            // spcServer
            // 
            this.spcServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcServer.Location = new System.Drawing.Point(0, 0);
            this.spcServer.Name = "spcServer";
            this.spcServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcServer.Panel1
            // 
            this.spcServer.Panel1.Controls.Add(this.rtbServerConsole);
            // 
            // spcServer.Panel2
            // 
            this.spcServer.Panel2.Controls.Add(this.spcSessions);
            this.spcServer.Size = new System.Drawing.Size(647, 581);
            this.spcServer.SplitterDistance = 129;
            this.spcServer.TabIndex = 1;
            // 
            // rtbServerConsole
            // 
            this.rtbServerConsole.BackColor = System.Drawing.SystemColors.Desktop;
            this.rtbServerConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbServerConsole.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsServer, "ServerConsole", true));
            this.rtbServerConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbServerConsole.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbServerConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbServerConsole.Location = new System.Drawing.Point(0, 0);
            this.rtbServerConsole.Name = "rtbServerConsole";
            this.rtbServerConsole.ReadOnly = true;
            this.rtbServerConsole.Size = new System.Drawing.Size(647, 129);
            this.rtbServerConsole.TabIndex = 2;
            this.rtbServerConsole.Text = "";
            // 
            // dbsServer
            // 
            this.dbsServer.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.ServerViewModel);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SessionId";
            this.dataGridViewTextBoxColumn3.HeaderText = "SessionId";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // sequenceIdDataGridViewTextBoxColumn
            // 
            this.sequenceIdDataGridViewTextBoxColumn.DataPropertyName = "SequenceId";
            this.sequenceIdDataGridViewTextBoxColumn.FillWeight = 50F;
            this.sequenceIdDataGridViewTextBoxColumn.HeaderText = "Sequence";
            this.sequenceIdDataGridViewTextBoxColumn.Name = "sequenceIdDataGridViewTextBoxColumn";
            this.sequenceIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // originDataGridViewTextBoxColumn
            // 
            this.originDataGridViewTextBoxColumn.DataPropertyName = "Origin";
            this.originDataGridViewTextBoxColumn.FillWeight = 50F;
            this.originDataGridViewTextBoxColumn.HeaderText = "Origin";
            this.originDataGridViewTextBoxColumn.Name = "originDataGridViewTextBoxColumn";
            this.originDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isResponseDataGridViewCheckBoxColumn
            // 
            this.isResponseDataGridViewCheckBoxColumn.DataPropertyName = "IsResponse";
            this.isResponseDataGridViewCheckBoxColumn.FillWeight = 62.86789F;
            this.isResponseDataGridViewCheckBoxColumn.HeaderText = "IsResponse";
            this.isResponseDataGridViewCheckBoxColumn.Name = "isResponseDataGridViewCheckBoxColumn";
            this.isResponseDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // packetSizeDataGridViewTextBoxColumn
            // 
            this.packetSizeDataGridViewTextBoxColumn.DataPropertyName = "PacketSize";
            this.packetSizeDataGridViewTextBoxColumn.HeaderText = "PacketSize";
            this.packetSizeDataGridViewTextBoxColumn.Name = "packetSizeDataGridViewTextBoxColumn";
            this.packetSizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.packetSizeDataGridViewTextBoxColumn.Visible = false;
            // 
            // wordCountDataGridViewTextBoxColumn
            // 
            this.wordCountDataGridViewTextBoxColumn.DataPropertyName = "WordCount";
            this.wordCountDataGridViewTextBoxColumn.HeaderText = "WordCount";
            this.wordCountDataGridViewTextBoxColumn.Name = "wordCountDataGridViewTextBoxColumn";
            this.wordCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.wordCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // isClientCommandDataGridViewCheckBoxColumn
            // 
            this.isClientCommandDataGridViewCheckBoxColumn.DataPropertyName = "IsClientCommand";
            this.isClientCommandDataGridViewCheckBoxColumn.HeaderText = "IsClientCommand";
            this.isClientCommandDataGridViewCheckBoxColumn.Name = "isClientCommandDataGridViewCheckBoxColumn";
            this.isClientCommandDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isClientCommandDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isServerEventResponseDataGridViewCheckBoxColumn
            // 
            this.isServerEventResponseDataGridViewCheckBoxColumn.DataPropertyName = "IsServerEventResponse";
            this.isServerEventResponseDataGridViewCheckBoxColumn.HeaderText = "IsServerEventResponse";
            this.isServerEventResponseDataGridViewCheckBoxColumn.Name = "isServerEventResponseDataGridViewCheckBoxColumn";
            this.isServerEventResponseDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isServerEventResponseDataGridViewCheckBoxColumn.Visible = false;
            // 
            // wordsDataGridViewTextBoxColumn
            // 
            this.wordsDataGridViewTextBoxColumn.DataPropertyName = "WordsString";
            this.wordsDataGridViewTextBoxColumn.FillWeight = 150F;
            this.wordsDataGridViewTextBoxColumn.HeaderText = "Words";
            this.wordsDataGridViewTextBoxColumn.Name = "wordsDataGridViewTextBoxColumn";
            this.wordsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ucPacketBuilder
            // 
            this.ucPacketBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPacketBuilder.Location = new System.Drawing.Point(0, 0);
            this.ucPacketBuilder.Name = "ucPacketBuilder";
            this.ucPacketBuilder.Size = new System.Drawing.Size(447, 234);
            this.ucPacketBuilder.TabIndex = 0;
            this.ucPacketBuilder.PacketCreated += new System.EventHandler<PacketDataEventArgs>(this.UcPacketBuilderPacketCreated);
            this.ucPacketBuilder.BuildError += new System.EventHandler<PacketBuilderErrorEventArgs>(this.UcPacketBuilderBuildError);
            // 
            // ConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcServer);
            this.Name = "ConsoleControl";
            this.Size = new System.Drawing.Size(647, 581);
            this.spcSessions.Panel1.ResumeLayout(false);
            this.spcSessions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSessions)).EndInit();
            this.spcSessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSessions)).EndInit();
            this.cmsSessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsSessions)).EndInit();
            this.spcConsole.Panel1.ResumeLayout(false);
            this.spcConsole.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcConsole)).EndInit();
            this.spcConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPackets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPackets)).EndInit();
            this.spcServer.Panel1.ResumeLayout(false);
            this.spcServer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcServer)).EndInit();
            this.spcServer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsServer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcSessions;
        private System.Windows.Forms.BindingSource dbsServer;
        private System.Windows.Forms.DataGridView dgwSessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource dbsSessions;
        private System.Windows.Forms.SplitContainer spcServer;
        private System.Windows.Forms.SplitContainer spcConsole;
        private System.Windows.Forms.RichTextBox rtbServerConsole;
        private PacketBuilderControl ucPacketBuilder;
        private System.Windows.Forms.ContextMenuStrip cmsSessions;
        private System.Windows.Forms.ToolStripMenuItem mitCloseSession;
        private System.Windows.Forms.DataGridView dgwPackets;
        private System.Windows.Forms.BindingSource dbsPackets;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequenceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isResponseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isClientCommandDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isServerEventResponseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordsDataGridViewTextBoxColumn;
    }
}
