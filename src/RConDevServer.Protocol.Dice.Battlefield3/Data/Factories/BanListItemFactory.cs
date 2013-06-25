namespace RConDevServer.Protocol.Dice.Battlefield3.Data.Factories
{
    using Util;

    /// <summary>
    /// A factory class responsible for creating <see cref="BanListItem"/> instances
    /// </summary>
    public static class BanListItemFactory
    {
        /// <summary>
        /// Creates a new <see cref="BanListItem"/> instance
        /// </summary>
        /// <returns></returns>
        public static BanListItem Create()
        {
            return null;
        }

        public static BanListItem Create(IdType idType, string idValue, Timeout timeout)
        {
            Requires.NotNullOrEmpty(idValue, "idValue");
            Requires.NotNull(timeout, "timeout");

           
            return null;
        }
    }
}
