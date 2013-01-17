namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Properties;

    public static class Requires
    {
        public static void NotNullOrEmpty(string parameterValue, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterValue))
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void Equal<T>(T parameterValue, T expectedValue, string parameterName)
        {
            if (Equals(parameterValue, expectedValue))
            {
                return;
            }

            throw new ArgumentOutOfRangeException(parameterName, parameterValue, string.Empty);
        }

        /// <summary>
        ///     ensures the
        ///     <param name="value" />
        ///     starts with
        ///     <param name="expectedStart" />
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expectedStart"></param>
        /// <param name="parameterName"></param>
        public static void StartsWith(string value, string expectedStart, string parameterName)
        {
            if (value.StartsWith(expectedStart))
            {
                return;
            }

            string message = string.Format(Resources.EXC_MSG_NOT_STARTS_WITH, expectedStart);
            throw new ArgumentOutOfRangeException(parameterName, value, message);
        }

        /// <summary>
        ///     ensures the sequence has at minimum the sequence lenth expected
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sequenceLength"></param>
        /// <param name="sequenceName"></param>
        public static void MinSequenceLength<T>(IEnumerable<T> sequence, int sequenceLength, string sequenceName)
        {
            T[] sequenceArray = sequence.ToArray();
            if (sequenceArray.Length >= sequenceLength)
            {
                return;
            }
            string message = string.Format(Resources.EXC_MSG_MIN_SEQUENCE_LENGTH_NOT_SET, sequenceName, sequenceLength);
            throw new ArgumentException(message, sequenceName);
        }

        /// <summary>
        ///     ensures the sequence has the lenth expected
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sequenceLength"></param>
        /// <param name="sequenceName"></param>
        public static void SequenceLength<T>(IEnumerable<T> sequence, int sequenceLength, string sequenceName)
        {
            T[] sequenceArray = sequence.ToArray();
            if (sequenceArray.Length == sequenceLength)
            {
                return;
            }
            string message = string.Format(Resources.EXC_MSG_SEQUENCE_LENGTH_NOT_SET, sequenceName, sequenceLength);
            throw new ArgumentException(message, sequenceName);
        }

        public static void NotNull<T>(T? parameterValue, string parameterName) where T : struct
        {
            if (parameterValue == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}