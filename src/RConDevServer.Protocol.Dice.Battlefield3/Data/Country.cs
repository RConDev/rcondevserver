namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public class Country
    {
        public virtual long Id { get; set; }

        public virtual string CodeAlpha2 { get; set; }

        public virtual string Display { get; set; }

        public virtual Country Instance
        {
            get { return this; }
        }
    }
}