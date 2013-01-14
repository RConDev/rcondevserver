namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using Data;

    public class TeamScoresViewModel : ViewModelBase
    {
        #region Public Properties

        public decimal TargetScore
        {
            get { return this.TeamScores.TargetScore; }
            set
            {
                this.TeamScores.TargetScore = value;
                this.InvokePropertyChanged("TargetScore");
            }
        }

        public TeamScores TeamScores { get; private set; }

        public ObservableCollection<Score> Scores { get; private set; }

        #endregion

        #region Constructor

        public TeamScoresViewModel(TeamScores teamScores, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.TeamScores = teamScores;
            this.Scores = new ObservableCollection<Score>(this.TeamScores.Scores);
            this.Scores.CollectionChanged += this.ScoresOnCollectionChanged;
        }

        private void ScoresOnCollectionChanged(object sender,
                                               NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Score newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        this.TeamScores.Scores.Add(newItem);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Score newItem in notifyCollectionChangedEventArgs.OldItems)
                    {
                        this.TeamScores.Scores.Remove(newItem);
                    }

                    break;
            }
        }

        #endregion
    }
}