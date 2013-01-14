namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    using Data;
    using FluentNHibernate.Mapping;

    public class IdTypeMapping : ClassMap<IdType>
    {
        public IdTypeMapping()
        {
            this.ReadOnly();
            this.Schema("bf3");
            this.Table("id_type");

            this.Id(x => x.Id, "id").GeneratedBy.Native();
            this.Map(x => x.Code, "code");
            this.Map(x => x.Display, "label");
        }
    }
}