namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Windows.Forms;
    using Data;
    using Ui;

    public partial class TeamScoresControl : UserControl
    {
        private TeamScoresViewModel dataContext;

        public TeamScoresControl()
        {
            this.InitializeComponent();
        }

        public TeamScoresViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.dbsTeamScores.DataSource = this.dataContext;
                    this.dbsTeamScores.ResetBindings(false);

                    this.dbsScoreValues.DataSource = this.dataContext.Scores;
                    this.dbsScoreValues.ResetBindings(false);
                }
            }
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            this.dbsScoreValues.AddNew();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            var currentItem = this.dbsScoreValues.Current as Score;
            if (currentItem != null)
            {
                this.dataContext.Scores.Remove(currentItem);
                this.dbsScoreValues.DataSource = this.dataContext.Scores;
                this.dbsScoreValues.ResetBindings(false);
            }
        }
    }
}