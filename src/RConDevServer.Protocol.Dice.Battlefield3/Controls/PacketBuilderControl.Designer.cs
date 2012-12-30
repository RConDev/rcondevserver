namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using Ui;

    partial class PacketBuilderControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketBuilderControl));
            System.Windows.Forms.Label sequenceIdLabel;
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.sendButton = new System.Windows.Forms.Button();
            this.spcSequenceWords = new System.Windows.Forms.SplitContainer();
            this.wordsTextBox = new System.Windows.Forms.TextBox();
            this.packetViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sequenceIdTextBox = new System.Windows.Forms.TextBox();
            this.isServerOriginatedCheckBox = new System.Windows.Forms.CheckBox();
            this.isResponseCheckBox = new System.Windows.Forms.CheckBox();
            sequenceIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSequenceWords)).BeginInit();
            this.spcSequenceWords.Panel1.SuspendLayout();
            this.spcSequenceWords.Panel2.SuspendLayout();
            this.spcSequenceWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            resources.ApplyResources(this.spcMain, "spcMain");
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcSequenceWords);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.sendButton);
            // 
            // sendButton
            // 
            resources.ApplyResources(this.sendButton, "sendButton");
            this.sendButton.Name = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // spcSequenceWords
            // 
            resources.ApplyResources(this.spcSequenceWords, "spcSequenceWords");
            this.spcSequenceWords.Name = "spcSequenceWords";
            // 
            // spcSequenceWords.Panel1
            // 
            resources.ApplyResources(this.spcSequenceWords.Panel1, "spcSequenceWords.Panel1");
            this.spcSequenceWords.Panel1.Controls.Add(this.isResponseCheckBox);
            this.spcSequenceWords.Panel1.Controls.Add(this.isServerOriginatedCheckBox);
            this.spcSequenceWords.Panel1.Controls.Add(sequenceIdLabel);
            this.spcSequenceWords.Panel1.Controls.Add(this.sequenceIdTextBox);
            // 
            // spcSequenceWords.Panel2
            // 
            this.spcSequenceWords.Panel2.Controls.Add(this.wordsTextBox);
            // 
            // wordsTextBox
            // 
            resources.ApplyResources(this.wordsTextBox, "wordsTextBox");
            this.wordsTextBox.Name = "wordsTextBox";
            // 
            // packetViewModelBindingSource
            // 
            this.packetViewModelBindingSource.DataSource = typeof(PacketViewModel);
            // 
            // sequenceIdLabel
            // 
            resources.ApplyResources(sequenceIdLabel, "sequenceIdLabel");
            sequenceIdLabel.Name = "sequenceIdLabel";
            // 
            // sequenceIdTextBox
            // 
            this.sequenceIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packetViewModelBindingSource, "SequenceId", true));
            resources.ApplyResources(this.sequenceIdTextBox, "sequenceIdTextBox");
            this.sequenceIdTextBox.Name = "sequenceIdTextBox";
            // 
            // isServerOriginatedCheckBox
            // 
            this.isServerOriginatedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.packetViewModelBindingSource, "IsServerOriginated", true));
            resources.ApplyResources(this.isServerOriginatedCheckBox, "isServerOriginatedCheckBox");
            this.isServerOriginatedCheckBox.Name = "isServerOriginatedCheckBox";
            this.isServerOriginatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isResponseCheckBox
            // 
            this.isResponseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.packetViewModelBindingSource, "IsResponse", true));
            resources.ApplyResources(this.isResponseCheckBox, "isResponseCheckBox");
            this.isResponseCheckBox.Name = "isResponseCheckBox";
            this.isResponseCheckBox.UseVisualStyleBackColor = true;
            // 
            // PacketBuilderControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "PacketBuilderControl";
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcSequenceWords.Panel1.ResumeLayout(false);
            this.spcSequenceWords.Panel1.PerformLayout();
            this.spcSequenceWords.Panel2.ResumeLayout(false);
            this.spcSequenceWords.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSequenceWords)).EndInit();
            this.spcSequenceWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.packetViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.SplitContainer spcSequenceWords;
        private System.Windows.Forms.TextBox wordsTextBox;
        private System.Windows.Forms.CheckBox isServerOriginatedCheckBox;
        private System.Windows.Forms.BindingSource packetViewModelBindingSource;
        private System.Windows.Forms.TextBox sequenceIdTextBox;
        private System.Windows.Forms.CheckBox isResponseCheckBox;
    }
}
