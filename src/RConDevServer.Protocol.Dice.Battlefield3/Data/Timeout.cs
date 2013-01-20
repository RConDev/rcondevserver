namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Util;

    /// <summary>
    ///     the ban duration the ban is valid
    /// </summary>
    public class Timeout
    {
        /// <summary>
        ///     Create a new <see cref="Timeout" /> instance
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public Timeout(TimeoutType type, int? value = null)
        {
            this.Type = type;
            this.Value = value;
        }

        private const string TimeoutTypePermanent = "perm";

        private const string TimeoutTypeRounds = "rounds";

        private const string TimeoutTypeSeconds = "seconds";

        /// <summary>
        ///     identifies the type of the ban timeout
        /// </summary>
        public TimeoutType Type { get; private set; }

        /// <summary>
        ///     if not permanent, the value is set
        /// </summary>
        public int? Value { get; set; }

        public IEnumerable<string> ToWords()
        {
            var words = new List<string>();
            switch (this.Type)
            {
                case TimeoutType.Permanent:
                    words.Add(TimeoutTypePermanent);
                    break;
                case TimeoutType.Rounds:
                    words.Add(TimeoutTypeRounds);
                    words.Add(Convert.ToString(this.Value));
                    break;
                case TimeoutType.Seconds:
                    words.Add(TimeoutTypeSeconds);
                    words.Add(Convert.ToString(this.Value));
                    break;
            }
            return words;
        }

        /// <summary>
        ///     create a new <see cref="Timeout" /> instance based on words
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static Timeout FromWords(IEnumerable<string> words)
        {
            var wordArray = words.ToArray();
            Requires.MinSequenceLength(wordArray, 1, "timeoutWords");

            var timeoutType = wordArray[0];
            switch (timeoutType)
            {
                case TimeoutTypePermanent:
                    return new Timeout(TimeoutType.Permanent);

                case TimeoutTypeRounds:
                    Requires.MinSequenceLength(wordArray, 2, "timeoutWords");
                    return CreateTimeout(TimeoutType.Rounds, wordArray[1]);

                case TimeoutTypeSeconds:
                    Requires.MinSequenceLength(wordArray, 2, "timeoutWords");
                    return CreateTimeout(TimeoutType.Seconds, wordArray[1]);
            }

            throw new ArgumentException();
        }

        private static Timeout CreateTimeout(TimeoutType type, string countValue)
        {
            var value = Int.SafeParse(countValue);
            Requires.NotNull(value, "count");

            return new Timeout(type, value);
        }
    }
}