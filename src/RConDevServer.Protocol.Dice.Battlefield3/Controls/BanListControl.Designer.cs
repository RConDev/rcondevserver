namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class BanListControl
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
            System.Windows.Forms.Label banTypeLabel;
            System.Windows.Forms.Label idTypeLabel;
            System.Windows.Forms.Label idValueLabel;
            System.Windows.Forms.Label reasonLabel;
            System.Windows.Forms.Label roundsLabel;
            System.Windows.Forms.Label secondsLabel;
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grbNewItem = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.dbsNewItem = new System.Windows.Forms.BindingSource(this.components);
            this.roundsTextBox = new System.Windows.Forms.TextBox();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.idValueTextBox = new System.Windows.Forms.TextBox();
            this.idTypeComboBox = new System.Windows.Forms.ComboBox();
            this.banTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dbsBanTypes = new System.Windows.Forms.BindingSource(this.components);
            this.grbItems = new System.Windows.Forms.GroupBox();
            this.banListItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.IdType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IdValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BanType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Rounds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.synchronousInvokerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsBanListItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbsBanListItems = new System.Windows.Forms.BindingSource(this.components);
            this.dbsBanList = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            banTypeLabel = new System.Windows.Forms.Label();
            idTypeLabel = new System.Windows.Forms.Label();
            idValueLabel = new System.Windows.Forms.Label();
            reasonLabel = new System.Windows.Forms.Label();
            roundsLabel = new System.Windows.Forms.Label();
            secondsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grbNewItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanTypes)).BeginInit();
            this.grbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banListItemsDataGridView)).BeginInit();
            this.cmsBanListItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanListItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanList)).BeginInit();
            this.SuspendLayout();
            // 
            // banTypeLabel
            // 
            banTypeLabel.AutoSize = true;
            banTypeLabel.Location = new System.Drawing.Point(6, 16);
            banTypeLabel.Name = "banTypeLabel";
            banTypeLabel.Size = new System.Drawing.Size(56, 13);
            banTypeLabel.TabIndex = 0;
            banTypeLabel.Text = "Ban Type:";
            // 
            // idTypeLabel
            // 
            idTypeLabel.AutoSize = true;
            idTypeLabel.Location = new System.Drawing.Point(6, 43);
            idTypeLabel.Name = "idTypeLabel";
            idTypeLabel.Size = new System.Drawing.Size(46, 13);
            idTypeLabel.TabIndex = 2;
            idTypeLabel.Text = "Id Type:";
            // 
            // idValueLabel
            // 
            idValueLabel.AutoSize = true;
            idValueLabel.Location = new System.Drawing.Point(6, 70);
            idValueLabel.Name = "idValueLabel";
            idValueLabel.Size = new System.Drawing.Size(49, 13);
            idValueLabel.TabIndex = 4;
            idValueLabel.Text = "Id Value:";
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new System.Drawing.Point(6, 96);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new System.Drawing.Size(47, 13);
            reasonLabel.TabIndex = 6;
            reasonLabel.Text = "Reason:";
            // 
            // roundsLabel
            // 
            roundsLabel.AutoSize = true;
            roundsLabel.Location = new System.Drawing.Point(6, 122);
            roundsLabel.Name = "roundsLabel";
            roundsLabel.Size = new System.Drawing.Size(47, 13);
            roundsLabel.TabIndex = 8;
            roundsLabel.Text = "Rounds:";
            // 
            // secondsLabel
            // 
            secondsLabel.AutoSize = true;
            secondsLabel.Location = new System.Drawing.Point(6, 148);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new System.Drawing.Size(52, 13);
            secondsLabel.TabIndex = 10;
            secondsLabel.Text = "Seconds:";
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
            this.spcMain.Size = new System.Drawing.Size(429, 522);
            this.spcMain.SplitterDistance = 210;
            this.spcMain.TabIndex = 0;
            // 
            // grbNewItem
            // 
            this.grbNewItem.Controls.Add(this.btnAddItem);
            this.grbNewItem.Controls.Add(secondsLabel);
            this.grbNewItem.Controls.Add(this.secondsTextBox);
            this.grbNewItem.Controls.Add(roundsLabel);
            this.grbNewItem.Controls.Add(this.roundsTextBox);
            this.grbNewItem.Controls.Add(reasonLabel);
            this.grbNewItem.Controls.Add(this.reasonTextBox);
            this.grbNewItem.Controls.Add(idValueLabel);
            this.grbNewItem.Controls.Add(this.idValueTextBox);
            this.grbNewItem.Controls.Add(idTypeLabel);
            this.grbNewItem.Controls.Add(this.idTypeComboBox);
            this.grbNewItem.Controls.Add(banTypeLabel);
            this.grbNewItem.Controls.Add(this.banTypeComboBox);
            this.grbNewItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNewItem.Location = new System.Drawing.Point(0, 0);
            this.grbNewItem.Name = "grbNewItem";
            this.grbNewItem.Size = new System.Drawing.Size(429, 210);
            this.grbNewItem.TabIndex = 0;
            this.grbNewItem.TabStop = false;
            this.grbNewItem.Text = "Create New BanList Item";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(253, 171);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 12;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewItem, "Seconds", true));
            this.secondsTextBox.Location = new System.Drawing.Point(125, 145);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.Size = new System.Drawing.Size(203, 20);
            this.secondsTextBox.TabIndex = 11;
            // 
            // dbsNewItem
            // 
            this.dbsNewItem.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.BanListItemViewModel);
            // 
            // roundsTextBox
            // 
            this.roundsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewItem, "Rounds", true));
            this.roundsTextBox.Location = new System.Drawing.Point(125, 119);
            this.roundsTextBox.Name = "roundsTextBox";
            this.roundsTextBox.Size = new System.Drawing.Size(203, 20);
            this.roundsTextBox.TabIndex = 9;
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewItem, "Reason", true));
            this.reasonTextBox.Location = new System.Drawing.Point(125, 93);
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(203, 20);
            this.reasonTextBox.TabIndex = 7;
            // 
            // idValueTextBox
            // 
            this.idValueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsNewItem, "IdValue", true));
            this.idValueTextBox.Location = new System.Drawing.Point(125, 67);
            this.idValueTextBox.Name = "idValueTextBox";
            this.idValueTextBox.Size = new System.Drawing.Size(203, 20);
            this.idValueTextBox.TabIndex = 5;
            // 
            // idTypeComboBox
            // 
            this.idTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsNewItem, "IdType", true));
            this.idTypeComboBox.FormattingEnabled = true;
            this.idTypeComboBox.Location = new System.Drawing.Point(125, 40);
            this.idTypeComboBox.Name = "idTypeComboBox";
            this.idTypeComboBox.Size = new System.Drawing.Size(203, 21);
            this.idTypeComboBox.TabIndex = 3;
            this.idTypeComboBox.ValueMember = "Instance";
            // 
            // banTypeComboBox
            // 
            this.banTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbsNewItem, "BanType", true));
            this.banTypeComboBox.DataSource = this.dbsBanTypes;
            this.banTypeComboBox.DisplayMember = "Display";
            this.banTypeComboBox.FormattingEnabled = true;
            this.banTypeComboBox.Location = new System.Drawing.Point(125, 13);
            this.banTypeComboBox.Name = "banTypeComboBox";
            this.banTypeComboBox.Size = new System.Drawing.Size(203, 21);
            this.banTypeComboBox.TabIndex = 1;
            this.banTypeComboBox.ValueMember = "Instance";
            // 
            // dbsBanTypes
            // 
            this.dbsBanTypes.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Data.BanType);
            // 
            // grbItems
            // 
            this.grbItems.Controls.Add(this.banListItemsDataGridView);
            this.grbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbItems.Location = new System.Drawing.Point(0, 0);
            this.grbItems.Name = "grbItems";
            this.grbItems.Size = new System.Drawing.Size(429, 308);
            this.grbItems.TabIndex = 0;
            this.grbItems.TabStop = false;
            this.grbItems.Text = "BanList Items";
            // 
            // banListItemsDataGridView
            // 
            this.banListItemsDataGridView.AutoGenerateColumns = false;
            this.banListItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.banListItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdType,
            this.IdValue,
            this.BanType,
            this.Rounds,
            this.Seconds,
            this.Reason,
            this.itemDataGridViewTextBoxColumn,
            this.synchronousInvokerDataGridViewTextBoxColumn});
            this.banListItemsDataGridView.ContextMenuStrip = this.cmsBanListItems;
            this.banListItemsDataGridView.DataSource = this.dbsBanListItems;
            this.banListItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.banListItemsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.banListItemsDataGridView.Name = "banListItemsDataGridView";
            this.banListItemsDataGridView.Size = new System.Drawing.Size(423, 289);
            this.banListItemsDataGridView.TabIndex = 0;
            // 
            // IdType
            // 
            this.IdType.DataPropertyName = "IdType";
            this.IdType.HeaderText = "Id Type";
            this.IdType.Name = "IdType";
            this.IdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IdValue
            // 
            this.IdValue.DataPropertyName = "IdValue";
            this.IdValue.HeaderText = "IdValue";
            this.IdValue.Name = "IdValue";
            // 
            // BanType
            // 
            this.BanType.DataPropertyName = "BanType";
            this.BanType.DataSource = this.dbsBanTypes;
            this.BanType.DisplayMember = "Display";
            this.BanType.HeaderText = "BanType";
            this.BanType.Name = "BanType";
            this.BanType.ValueMember = "Instance";
            // 
            // Rounds
            // 
            this.Rounds.DataPropertyName = "Rounds";
            this.Rounds.HeaderText = "Rounds";
            this.Rounds.Name = "Rounds";
            // 
            // Seconds
            // 
            this.Seconds.DataPropertyName = "Seconds";
            this.Seconds.HeaderText = "Seconds";
            this.Seconds.Name = "Seconds";
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.HeaderText = "Reason";
            this.Reason.Name = "Reason";
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Visible = false;
            // 
            // synchronousInvokerDataGridViewTextBoxColumn
            // 
            this.synchronousInvokerDataGridViewTextBoxColumn.DataPropertyName = "SynchronousInvoker";
            this.synchronousInvokerDataGridViewTextBoxColumn.HeaderText = "SynchronousInvoker";
            this.synchronousInvokerDataGridViewTextBoxColumn.Name = "synchronousInvokerDataGridViewTextBoxColumn";
            this.synchronousInvokerDataGridViewTextBoxColumn.ReadOnly = true;
            this.synchronousInvokerDataGridViewTextBoxColumn.Visible = false;
            // 
            // cmsBanListItems
            // 
            this.cmsBanListItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitRemoveItem});
            this.cmsBanListItems.Name = "contextMenuStrip1";
            this.cmsBanListItems.Size = new System.Drawing.Size(145, 26);
            // 
            // mitRemoveItem
            // 
            this.mitRemoveItem.Name = "mitRemoveItem";
            this.mitRemoveItem.Size = new System.Drawing.Size(144, 22);
            this.mitRemoveItem.Text = "Remove Item";
            this.mitRemoveItem.Click += new System.EventHandler(this.mitRemoveItem_Click);
            // 
            // dbsBanListItems
            // 
            this.dbsBanListItems.DataMember = "BanListItems";
            this.dbsBanListItems.DataSource = this.dbsBanList;
            // 
            // dbsBanList
            // 
            this.dbsBanList.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.BanListViewModel);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn1.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn2.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn3.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn4.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn5
            // 
            this.dataGridViewComboBoxColumn5.DataPropertyName = "BanType";
            this.dataGridViewComboBoxColumn5.HeaderText = "BanType";
            this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
            // 
            // dataGridViewComboBoxColumn6
            // 
            this.dataGridViewComboBoxColumn6.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn6.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn6.Name = "dataGridViewComboBoxColumn6";
            this.dataGridViewComboBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn7
            // 
            this.dataGridViewComboBoxColumn7.DataPropertyName = "BanType";
            this.dataGridViewComboBoxColumn7.HeaderText = "BanType";
            this.dataGridViewComboBoxColumn7.Name = "dataGridViewComboBoxColumn7";
            // 
            // dataGridViewComboBoxColumn8
            // 
            this.dataGridViewComboBoxColumn8.DataPropertyName = "IdType";
            this.dataGridViewComboBoxColumn8.HeaderText = "Id Type";
            this.dataGridViewComboBoxColumn8.Name = "dataGridViewComboBoxColumn8";
            this.dataGridViewComboBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn9
            // 
            this.dataGridViewComboBoxColumn9.DataPropertyName = "BanType";
            this.dataGridViewComboBoxColumn9.HeaderText = "BanType";
            this.dataGridViewComboBoxColumn9.Name = "dataGridViewComboBoxColumn9";
            // 
            // BanListControl
            // 
            this.Controls.Add(this.spcMain);
            this.Name = "BanListControl";
            this.Size = new System.Drawing.Size(429, 522);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grbNewItem.ResumeLayout(false);
            this.grbNewItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsNewItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanTypes)).EndInit();
            this.grbItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.banListItemsDataGridView)).EndInit();
            this.cmsBanListItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanListItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsBanList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox grbNewItem;
        private System.Windows.Forms.GroupBox grbItems;
        private System.Windows.Forms.BindingSource dbsBanList;
        private System.Windows.Forms.DataGridView banListItemsDataGridView;
        private System.Windows.Forms.BindingSource dbsBanListItems;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
        private System.Windows.Forms.BindingSource dbsBanTypes;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn BanType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn synchronousInvokerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn8;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn9;
        private System.Windows.Forms.BindingSource dbsNewItem;
        private System.Windows.Forms.TextBox idValueTextBox;
        private System.Windows.Forms.ComboBox idTypeComboBox;
        private System.Windows.Forms.ComboBox banTypeComboBox;
        private System.Windows.Forms.TextBox secondsTextBox;
        private System.Windows.Forms.TextBox roundsTextBox;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ContextMenuStrip cmsBanListItems;
        private System.Windows.Forms.ToolStripMenuItem mitRemoveItem;

    }
}
