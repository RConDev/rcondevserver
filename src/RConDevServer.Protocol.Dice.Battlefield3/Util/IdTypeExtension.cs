namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using Data;

    public static class IdTypeExtension
    {
        public static IdTypeType? FromWord(string idTypeWord)
        {
            switch (idTypeWord)
            {
                case "name":
                    return IdTypeType.Name;
                case "ip":
                    return IdTypeType.IpAddress;
                case "guid":
                    return IdTypeType.Guid;
            }

            return null;
        }

        public static string ToWord(IdTypeType idType)
        {
            switch (idType)
            {
                case IdTypeType.Guid:
                    return "guid";
                case IdTypeType.IpAddress:
                    return "ip";
                case IdTypeType.Name:
                    return "name";
            }

            return null;
        }
    }
}