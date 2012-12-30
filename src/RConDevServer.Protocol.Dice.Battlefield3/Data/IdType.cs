namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
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
