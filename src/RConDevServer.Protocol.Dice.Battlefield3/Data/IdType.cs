namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public enum IdTypeType
    {
        Name,
        IpAddress,
        Guid
    }

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

    public class IdType
    {
        public virtual long Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Display { get; set; }

        public virtual IdType Instance
        {
            get { return this; }
        }
    }
}