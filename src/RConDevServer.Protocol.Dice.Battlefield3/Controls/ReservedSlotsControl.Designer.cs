namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class ReservedSlotsControl
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
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.cbxIsAggressiveJoin = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbReservedSlots = new System.Windows.Forms.ListBox();
            this.dbsPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.dbsReservedSlots = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxPlayerName = new System.Windows.Forms.TextBox();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsReservedSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
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
            this.spcMain.Panel1.Controls.Add(this.cbxIsAggressiveJoin);
            this.spcMain.Panel1.Controls.Add(this.btnRemove);
            this.spcMain.Panel1.Controls.Add(this.lbReservedSlots);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.btnAdd);
            this.spcMain.Panel2.Controls.Add(this.tbxPlayerName);
            this.spcMain.Size = new System.Drawing.Size(327, 399);
            this.spcMain.SplitterDistance = 339;
            this.spcMain.TabIndex = 0;
            // 
            // cbxIsAggressiveJoin
            // 
            this.cbxIsAggressiveJoin.AutoSize = true;
            this.cbxIsAggressiveJoin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dbsReservedSlots, "IsAggressiveJoin", true));
            this.cbxIsAggressiveJoin.Location = new System.Drawing.Point(4, 302);
            this.cbxIsAggressiveJoin.Name = "cbxIsAggressiveJoin";
            this.cbxIsAggressiveJoin.Size = new System.Drawing.Size(95, 17);
            this.cbxIsAggressiveJoin.TabIndex = 2;
            this.cbxIsAggressiveJoin.Text = "Aggresive Join";
            this.cbxIsAggressiveJoin.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(249, 297);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbReservedSlots
            // 
            this.lbReservedSlots.DataSource = this.dbsPlayers;
            this.lbReservedSlots.DisplayMember = "PlayerName";
            this.lbReservedSlots.FormattingEnabled = true;
            this.lbReservedSlots.Location = new System.Drawing.Point(3, 3);
            this.lbReservedSlots.Name = "lbReservedSlots";
            this.lbReservedSlots.Size = new System.Drawing.Size(321, 290);
            this.lbReservedSlots.TabIndex = 0;
            this.lbReservedSlots.ValueMember = "PlayerName";
            // 
            // dbsPlayers
            // 
            this.dbsPlayers.DataMember = "ReservedSlots";
            this.dbsPlayers.DataSource = this.dbsReservedSlots;
            // 
            // dbsReservedSlots
            // 
            this.dbsReservedSlots.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.ReservedSlotsViewModel);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(249, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxPlayerName
            // 
            this.tbxPlayerName.Location = new System.Drawing.Point(3, 3);
            this.tbxPlayerName.Name = "tbxPlayerName";
            this.tbxPlayerName.Size = new System.Drawing.Size(292, 20);
            this.tbxPlayerName.TabIndex = 0;
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // ReservedSlotsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "ReservedSlotsControl";
            this.Size = new System.Drawing.Size(327, 399);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbsPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsReservedSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbReservedSlots;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxPlayerName;
        private System.Windows.Forms.BindingSource dbsReservedSlots;
        private System.Windows.Forms.BindingSource dbsPlayers;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.CheckBox cbxIsAggressiveJoin;
    }
}
