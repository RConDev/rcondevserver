using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    /// <summary>
    /// one score item
    /// </summary>
    public class Score
    {
        /// <summary>
        /// the id of the team the item belongs to
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// the current score value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Converts the value to words for communication
        /// </summary>
        /// <returns></returns>
        public string ToWord()
        {
            return Convert.ToString(this.Value);
        }
    }
}
