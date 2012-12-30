namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class MapListControl
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
            System.Windows.Forms.Label mapLabel;
            System.Windows.Forms.Label gameModeLabel;
            System.Windows.Forms.Label roundsLabel;
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grbNewItem = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.roundsTextBox = new System.Windows.Forms.TextBox();
            this.dbsNewItem = new System.Windows.Forms.BindingSource(this.components);
            this.gameModeComboBox = new System.Windows.Forms.ComboBox();
            this.dbsAvailableModes = new System.Windows.Forms.BindingSource(this.components);
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.dbsAvailableMaps = new System.Windows.Forms.BindingSource(this.components);
            this.grbItems = new System.Windows.Forms.GroupBox();
            this.spcListActions = new System.Windows.Forms.SplitContainer();
            this.dgwMapListItems = new System.Windows.Forms.DataGridView();
            this.Map = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GameMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Rounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.synchronousInvokerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMapList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitSetAsCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbsMapListItems = new System.Windows.Forms.BindingSource(this.components);
            this.dbsMapList = new System.Windows.Forms.BindingSource(this.components);
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            mapLabel = new System.Windows.Forms.Label();
            gameModeLabel = new System.Windows.Forms.Label();
            roundsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grbNewItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsAvailableModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsAvailableMaps)).BeginInit();
            this.grbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcListActions)).BeginInit();
            this.spcListActions.Panel1.SuspendLayout();
            this.spcListActions.Panel2.SuspendLayout();
            this.spcListActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMapListItems)).BeginInit();
            this.cmsMapList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsMapListItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsMapList)).BeginInit();
            this.SuspendLayout();
            // 
            // mapLabel
            // 
            mapLabel.AutoSize = true;
            mapLabel.Location = new System.Drawing.Point(6, 22);
            mapLabel.Name = "mapLabel";
            mapLabel.Size = new System.Drawing.Size(31, 13);
            mapLabel.TabIndex = 0;
            mapLabel.Text = "Map:";
            // 
            // gameModeLabel
            // 
            gameModeLabel.AutoSize = true;
            gameModeLabel.Location = new System.Drawing.Point(6, 49);
            gameModeLabel.Name = "gameModeLabel";
            gameModeLabel.Size = new System.Drawing.Size(68, 13);
            gameModeLabel.TabIndex = 2;
            gameModeLabel.Text = "Game Mode:";
            // 
            // roundsLabel
            // 
            roundsLabel.AutoSize = true;
            roundsLabel.Location = new System.Drawing.Point(6, 76);
            roundsLabel.Name = "roundsLabel";
            roundsLabel.Size = new System.Drawing.Size(47, 13);
            roundsLabel.TabIndex = 4;
            roundsLabel.Text = "Rounds:";
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.grbNewItem);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.grbItems);
            this.spcMain.Size = new System.Drawing.Size(491, 471);
            this.spcMain.SplitterDistance = 138;
            this.spcMain.TabIndex = 0;
            // 
            // grbNewItem
            // 
            this.grbNewItem.Controls.Add(this.btnAdd);
            this.grbNewItem.Controls.Add(roundsLabel);
            this.grbNewItem.Controls.Add(this.roundsTextBox);
            this.grbNewItem.Controls.Add(gameModeLabel);
            this.grbNewItem.Controls.Add(this.gameModeComboBox);
            this.grbNewItem.Controls.Add(mapLabel);
            this.grbNewItem.Controls.Add(this.mapComboBox);
            this.grbNewItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNewItem.Location = new System.Drawing.Point(0, 0);
            this.grbNewItem.Name = "grbNewItem";
            this.grbNewItem.Size = new System.Drawing.Size(491, 138);
            this.grbNewItem.TabIndex = 0;
            this.grbNewItem.TabStop = false;
            this.grbNewItem.Text = "Create new item";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(307, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // roundsTextBox
            // 
            this.roundsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewItem, "Rounds", true));
            this.roundsTextBox.Location = new System.Drawing.Point(103, 73);
            this.roundsTextBox.Name = "roundsTextBox";
            this.roundsTextBox.Size = new System.Drawing.Size(279, 20);
            this.roundsTextBox.TabIndex = 5;
            // 
            // dbsNewItem
            // 
            this.dbsNewItem.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.MapListItemViewModel);
            // 
            // gameModeComboBox
            // 
            this.gameModeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsNewItem, "GameMode", true));
            this.gameModeComboBox.DataSource = this.dbsAvailableModes;
            this.gameModeComboBox.DisplayMember = "Display";
            this.gameModeComboBox.FormattingEnabled = true;
            this.gameModeComboBox.Location = new System.Drawing.Point(103, 46);
            this.gameModeComboBox.Name = "gameModeComboBox";
            this.gameModeComboBox.Size = new System.Drawing.Size(279, 21);
            this.gameModeComboBox.TabIndex = 3;
            this.gameModeComboBox.ValueMember = "Instance";
            // 
            // dbsAvailableModes
            // 
            this.dbsAvailableModes.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.GameMode);
            // 
            // mapComboBox
            // 
            this.mapComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsNewItem, "Map", true));
            this.mapComboBox.DataSource = this.dbsAvailableMaps;
            this.mapComboBox.DisplayMember = "Display";
            this.mapComboBox.FormattingEnabled = true;
            this.mapComboBox.Location = new System.Drawing.Point(103, 19);
            this.mapComboBox.Name = "mapComboBox";
            this.mapComboBox.Size = new System.Drawing.Size(279, 21);
            this.mapComboBox.TabIndex = 1;
            this.mapComboBox.ValueMember = "Instance";
            // 
            // dbsAvailableMaps
            // 
            this.dbsAvailableMaps.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.Map);
            // 
            // grbItems
            // 
            this.grbItems.Controls.Add(this.spcListActions);
            this.grbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbItems.Location = new System.Drawing.Point(0, 0);
            this.grbItems.Name = "grbItems";
            this.grbItems.Size = new System.Drawing.Size(491, 329);
            this.grbItems.TabIndex = 0;
            this.grbItems.TabStop = false;
            this.grbItems.Text = "Map List items";
            // 
            // spcListActions
            // 
            this.spcListActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcListActions.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcListActions.Location = new System.Drawing.Point(3, 16);
            this.spcListActions.Name = "spcListActions";
            // 
            // spcListActions.Panel1
            // 
            this.spcListActions.Panel1.Controls.Add(this.dgwMapListItems);
            // 
            // spcListActions.Panel2
            // 
            this.spcListActions.Panel2.Controls.Add(this.btnDown);
            this.spcListActions.Panel2.Controls.Add(this.btnUp);
            this.spcListActions.Size = new System.Drawing.Size(485, 310);
            this.spcListActions.SplitterDistance = 449;
            this.spcListActions.TabIndex = 0;
            // 
            // dgwMapListItems
            // 
            this.dgwMapListItems.AutoGenerateColumns = false;
            this.dgwMapListItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwMapListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMapListItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Map,
            this.GameMode,
            this.Rounds,
            this.itemDataGridViewTextBoxColumn,
            this.mapDataGridViewTextBoxColumn,
            this.gameModeDataGridViewTextBoxColumn,
            this.roundsDataGridViewTextBoxColumn,
            this.synchronousInvokerDataGridViewTextBoxColumn});
            this.dgwMapListItems.ContextMenuStrip = this.cmsMapList;
            this.dgwMapListItems.DataSource = this.dbsMapListItems;
            this.dgwMapListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMapListItems.Location = new System.Drawing.Point(0, 0);
            this.dgwMapListItems.Name = "dgwMapListItems";
            this.dgwMapListItems.Size = new System.Drawing.Size(449, 310);
            this.dgwMapListItems.TabIndex = 0;
            // 
            // Map
            // 
            this.Map.DataPropertyName = "Map";
            this.Map.DataSource = this.dbsAvailableMaps;
            this.Map.DisplayMember = "Display";
            this.Map.HeaderText = "Map";
            this.Map.Name = "Map";
            this.Map.ValueMember = "Instance";
            // 
            // GameMode
            // 
            this.GameMode.DataPropertyName = "GameMode";
            this.GameMode.DataSource = this.dbsAvailableModes;
            this.GameMode.DisplayMember = "Display";
            this.GameMode.HeaderText = "GameMode";
            this.GameMode.Name = "GameMode";
            this.GameMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GameMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GameMode.ValueMember = "Instance";
            // 
            // Rounds
            // 
            this.Rounds.DataPropertyName = "Rounds";
            this.Rounds.HeaderText = "Rounds";
            this.Rounds.Name = "Rounds";
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.Visible = false;
            // 
            // mapDataGridViewTextBoxColumn
            // 
            this.mapDataGridViewTextBoxColumn.DataPropertyName = "Map";
            this.mapDataGridViewTextBoxColumn.HeaderText = "Map";
            this.mapDataGridViewTextBoxColumn.Name = "mapDataGridViewTextBoxColumn";
            this.mapDataGridViewTextBoxColumn.Visible = false;
            // 
            // gameModeDataGridViewTextBoxColumn
            // 
            this.gameModeDataGridViewTextBoxColumn.DataPropertyName = "GameMode";
            this.gameModeDataGridViewTextBoxColumn.HeaderText = "GameMode";
            this.gameModeDataGridViewTextBoxColumn.Name = "gameModeDataGridViewTextBoxColumn";
            this.gameModeDataGridViewTextBoxColumn.Visible = false;
            // 
            // roundsDataGridViewTextBoxColumn
            // 
            this.roundsDataGridViewTextBoxColumn.DataPropertyName = "Rounds";
            this.roundsDataGridViewTextBoxColumn.HeaderText = "Rounds";
            this.roundsDataGridViewTextBoxColumn.Name = "roundsDataGridViewTextBoxColumn";
            this.roundsDataGridViewTextBoxColumn.Visible = false;
            // 
            // synchronousInvokerDataGridViewTextBoxColumn
            // 
            this.synchronousInvokerDataGridViewTextBoxColumn.DataPropertyName = "SynchronousInvoker";
            this.synchronousInvokerDataGridViewTextBoxColumn.HeaderText = "SynchronousInvoker";
            this.synchronousInvokerDataGridViewTextBoxColumn.Name = "synchronousInvokerDataGridViewTextBoxColumn";
            this.synchronousInvokerDataGridViewTextBoxColumn.ReadOnly = true;
            this.synchronousInvokerDataGridViewTextBoxColumn.Visible = false;
            // 
            // cmsMapList
            // 
            this.cmsMapList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitSetAsCurrent,
            this.toolStripSeparator1,
            this.mitRemoveItem});
            this.cmsMapList.Name = "cmsMapList";
            this.cmsMapList.Size = new System.Drawing.Size(148, 54);
            // 
            // mitSetAsCurrent
            // 
            this.mitSetAsCurrent.Name = "mitSetAsCurrent";
            this.mitSetAsCurrent.Size = new System.Drawing.Size(147, 22);
            this.mitSetAsCurrent.Text = "Set as Current";
            this.mitSetAsCurrent.Click += new System.EventHandler(this.MitSetAsCurrentClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // mitRemoveItem
            // 
            this.mitRemoveItem.Name = "mitRemoveItem";
            this.mitRemoveItem.Size = new System.Drawing.Size(147, 22);
            this.mitRemoveItem.Text = "Remove Item";
            this.mitRemoveItem.Click += new System.EventHandler(this.MitRemoveItemClick);
            // 
            // dbsMapListItems
            // 
            this.dbsMapListItems.DataMember = "MapListItems";
            this.dbsMapListItems.DataSource = this.dbsMapList;
            // 
            // dbsMapList
            // 
            this.dbsMapList.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.MapListViewModel);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(7, 31);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 25);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(7, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 25);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn1.HeaderText = "Map";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn2.HeaderText = "Map";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn3.HeaderText = "Map";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn4.HeaderText = "Map";
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            // 
            // dataGridViewComboBoxColumn5
            // 
            this.dataGridViewComboBoxColumn5.DataPropertyName = "GameMode";
            this.dataGridViewComboBoxColumn5.HeaderText = "GameMode";
            this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
            this.dataGridViewComboBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn6
            // 
            this.dataGridViewComboBoxColumn6.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn6.HeaderText = "Map";
            this.dataGridViewComboBoxColumn6.Name = "dataGridViewComboBoxColumn6";
            // 
            // dataGridViewComboBoxColumn7
            // 
            this.dataGridViewComboBoxColumn7.DataPropertyName = "GameMode";
            this.dataGridViewComboBoxColumn7.HeaderText = "GameMode";
            this.dataGridViewComboBoxColumn7.Name = "dataGridViewComboBoxColumn7";
            this.dataGridViewComboBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn8
            // 
            this.dataGridViewComboBoxColumn8.DataPropertyName = "Map";
            this.dataGridViewComboBoxColumn8.HeaderText = "Map";
            this.dataGridViewComboBoxColumn8.Name = "dataGridViewComboBoxColumn8";
            this.dataGridViewComboBoxColumn8.Width = 113;
            // 
            // dataGridViewComboBoxColumn9
            // 
            this.dataGridViewComboBoxColumn9.DataPropertyName = "GameMode";
            this.dataGridViewComboBoxColumn9.HeaderText = "GameMode";
            this.dataGridViewComboBoxColumn9.Name = "dataGridViewComboBoxColumn9";
            this.dataGridViewComboBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn9.Width = 113;
            // 
            // MapListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "MapListControl";
            this.Size = new System.Drawing.Size(491, 471);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grbNewItem.ResumeLayout(false);
            this.grbNewItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsAvailableModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsAvailableMaps)).EndInit();
            this.grbItems.ResumeLayout(false);
            this.spcListActions.Panel1.ResumeLayout(false);
            this.spcListActions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcListActions)).EndInit();
            this.spcListActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMapListItems)).EndInit();
            this.cmsMapList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsMapListItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsMapList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox grbNewItem;
        private System.Windows.Forms.GroupBox grbItems;
        private System.Windows.Forms.BindingSource dbsMapList;
        private System.Windows.Forms.SplitContainer spcListActions;
        private System.Windows.Forms.DataGridView dgwMapListItems;
        private System.Windows.Forms.BindingSource dbsMapListItems;
        private System.Windows.Forms.BindingSource dbsAvailableMaps;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.BindingSource dbsAvailableModes;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn7;
        private System.Windows.Forms.TextBox roundsTextBox;
        private System.Windows.Forms.ComboBox gameModeComboBox;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn8;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn9;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.BindingSource dbsNewItem;
        private System.Windows.Forms.ContextMenuStrip cmsMapList;
        private System.Windows.Forms.ToolStripMenuItem mitRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem mitSetAsCurrent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Map;
        private System.Windows.Forms.DataGridViewComboBoxColumn GameMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roundsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn synchronousInvokerDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}
