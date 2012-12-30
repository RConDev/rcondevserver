using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class EventScriptControl
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
            this.pbRunScript = new System.Windows.Forms.PictureBox();
            this.rtbScript = new System.Windows.Forms.RichTextBox();
            this.toolTipProvider = new System.Windows.Forms.ToolTip(this.components);
            this.dbsEventScript = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRunScript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsEventScript)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pbRunScript);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.rtbScript);
            this.spcMain.Size = new System.Drawing.Size(548, 367);
            this.spcMain.SplitterDistance = 35;
            this.spcMain.TabIndex = 0;
            // 
            // pbRunScript
            // 
            this.pbRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRunScript.Location = new System.Drawing.Point(515, 3);
            this.pbRunScript.Name = "pbRunScript";
            this.pbRunScript.Size = new System.Drawing.Size(30, 27);
            this.pbRunScript.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRunScript.TabIndex = 0;
            this.pbRunScript.TabStop = false;
            this.toolTipProvider.SetToolTip(this.pbRunScript, "Run Script");
            this.pbRunScript.Click += new System.EventHandler(this.PbRunScriptClick);
            // 
            // rtbScript
            // 
            this.rtbScript.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsEventScript, "Script", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rtbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbScript.Location = new System.Drawing.Point(0, 0);
            this.rtbScript.Name = "rtbScript";
            this.rtbScript.Size = new System.Drawing.Size(548, 328);
            this.rtbScript.TabIndex = 0;
            this.rtbScript.Text = "";
            // 
            // dbsEventScript
            // 
            this.dbsEventScript.DataSource = typeof(EventScriptViewModel);
            // 
            // EventScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "EventScriptControl";
            this.Size = new System.Drawing.Size(548, 367);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRunScript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsEventScript)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.PictureBox pbRunScript;
        private System.Windows.Forms.ToolTip toolTipProvider;
        private System.Windows.Forms.RichTextBox rtbScript;
        private System.Windows.Forms.BindingSource dbsEventScript;
    }
}
