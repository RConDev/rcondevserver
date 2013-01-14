namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    /// <summary>
    /// </summary>
    public static class Int
    {
        public static int? SafeParse(string stringValue)
        {
            int value;
            if (int.TryParse(stringValue, out value))
            {
                return value;
            }
            return null;
        }
    }
}