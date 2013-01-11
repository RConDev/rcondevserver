namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    /// <summary>
    ///     helper methods for type <see cref="bool" />
    /// </summary>
    public static class Bool
    {
        public static bool? SafeParse(string stringValue)
        {
            bool value;
            if (bool.TryParse(stringValue, out value))
            {
                return value;
            }
            return null;
        }
    }
}