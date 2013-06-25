namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public static class IdTypeExtension
    {
        public static IdType? FromWord(string idTypeWord)
        {
            switch (idTypeWord)
            {
                case "name":
                    return IdType.Name;
                case "ip":
                    return IdType.IpAddress;
                case "guid":
                    return IdType.Guid;
            }

            return null;
        }

        public static string ToWord(this IdType idType)
        {
            switch (idType)
            {
                case IdType.Guid:
                    return "guid";
                case IdType.IpAddress:
                    return "ip";
                case IdType.Name:
                    return "name";
            }

            return null;
        }
    }
}