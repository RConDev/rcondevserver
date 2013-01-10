namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;
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
        /// ensures the <param name="value"/> starts with <param name="expectedStart"/> 
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

            var message = string.Format(Resources.EXC_MSG_NOT_STARTS_WITH, expectedStart);
            throw new ArgumentOutOfRangeException(parameterName, value, message);
        }
    }
}