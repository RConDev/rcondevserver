namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamScores
    {
        #region Constructors

        /// <summary>
        ///     creates a new instance of <see cref="TeamScores" />
        /// </summary>
        public TeamScores()
        {
            this.Scores = new List<Score>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     the current count of scores in the list
        /// </summary>
        public int ScoreCount
        {
            get { return this.Scores.Count; }
        }

        /// <summary>
        ///     the target score players have to achieve
        /// </summary>
        public decimal TargetScore { get; set; }

        /// <summary>
        ///     the collection of scores
        /// </summary>
        public IList<Score> Scores { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     converts the values to words for communication
        /// </summary>
        /// <returns></returns>
        public IList<string> ToWords()
        {
            var words = new List<string> {Convert.ToString(this.ScoreCount)};
            words.AddRange(this.Scores.Select(x => Convert.ToString(Convert.ToInt32(x.Value))));
            words.Add(Convert.ToString(this.TargetScore));
            return words;
        }

        #endregion
    }
}