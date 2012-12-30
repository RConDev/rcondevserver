using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    public partial class TeamScoresControl : UserControl
    {
        private TeamScoresViewModel dataContext;

        public TeamScoresControl()
        {
            InitializeComponent();
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

        private void BtnAddClick(object sender, System.EventArgs e)
        {
            this.dbsScoreValues.AddNew();
        }

        private void BtnRemoveClick(object sender, System.EventArgs e)
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
