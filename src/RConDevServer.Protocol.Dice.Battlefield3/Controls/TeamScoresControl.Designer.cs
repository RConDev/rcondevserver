using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    partial class TeamScoresControl
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
            System.Windows.Forms.Label targetScoreLabel;
            this.targetScoreTextBox = new System.Windows.Forms.TextBox();
            this.dbsScoreValues = new System.Windows.Forms.BindingSource(this.components);
            this.dgwTeamScores = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dbsTeamScores = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            targetScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbsScoreValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTeamScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTeamScores)).BeginInit();
            this.SuspendLayout();
            // 
            // targetScoreLabel
            // 
            targetScoreLabel.AutoSize = true;
            targetScoreLabel.Location = new System.Drawing.Point(3, 13);
            targetScoreLabel.Name = "targetScoreLabel";
            targetScoreLabel.Size = new System.Drawing.Size(72, 13);
            targetScoreLabel.TabIndex = 0;
            targetScoreLabel.Text = "Target Score:";
            // 
            // targetScoreTextBox
            // 
            this.targetScoreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsTeamScores, "TargetScore", true));
            this.targetScoreTextBox.Location = new System.Drawing.Point(81, 10);
            this.targetScoreTextBox.Name = "targetScoreTextBox";
            this.targetScoreTextBox.Size = new System.Drawing.Size(301, 20);
            this.targetScoreTextBox.TabIndex = 1;
            // 
            // dbsScoreValues
            // 
            this.dbsScoreValues.DataMember = "Scores";
            this.dbsScoreValues.DataSource = this.dbsTeamScores;
            // 
            // dgwTeamScores
            // 
            this.dgwTeamScores.AllowUserToAddRows = false;
            this.dgwTeamScores.AllowUserToDeleteRows = false;
            this.dgwTeamScores.AutoGenerateColumns = false;
            this.dgwTeamScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwTeamScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTeamScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1});
            this.dgwTeamScores.DataSource = this.dbsScoreValues;
            this.dgwTeamScores.Location = new System.Drawing.Point(6, 36);
            this.dgwTeamScores.Name = "dgwTeamScores";
            this.dgwTeamScores.RowHeadersWidth = 25;
            this.dgwTeamScores.Size = new System.Drawing.Size(376, 163);
            this.dgwTeamScores.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(226, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(307, 205);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // dbsTeamScores
            // 
            this.dbsTeamScores.DataSource = typeof(RConDevServer.Protocol.Dice.Battlefield3.Ui.TeamScoresViewModel);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TeamId";
            this.Column1.HeaderText = "Team";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // TeamScoresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgwTeamScores);
            this.Controls.Add(targetScoreLabel);
            this.Controls.Add(this.targetScoreTextBox);
            this.Name = "TeamScoresControl";
            this.Size = new System.Drawing.Size(400, 239);
            ((System.ComponentModel.ISupportInitialize)(this.dbsScoreValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTeamScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsTeamScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dbsTeamScores;
        private System.Windows.Forms.TextBox targetScoreTextBox;
        private System.Windows.Forms.BindingSource dbsScoreValues;
        private System.Windows.Forms.DataGridView dgwTeamScores;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
