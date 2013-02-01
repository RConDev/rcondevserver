namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using Data;

    public static class UnlockModeConvert
    {
        public static string ToString(UnlockMode unlockMode)
        {
            return unlockMode.ToString().ToLower();
        }

        public static UnlockMode? ToUnlockMode(string value)
        {
            switch (value)
            {
                case "all":
                    return UnlockMode.All;
                case "common":
                    return UnlockMode.Common;
                case "none":
                    return UnlockMode.None;
                case "stats":
                    return UnlockMode.Stats;
            }
            return null;
        }
    }
}