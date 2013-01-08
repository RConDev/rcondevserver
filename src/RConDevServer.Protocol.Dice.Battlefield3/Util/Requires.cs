namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;

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
            if (!Equals(parameterValue, expectedValue))
            {
                throw new ArgumentOutOfRangeException(parameterName, parameterValue, string.Empty);
            }
        }
    }
}