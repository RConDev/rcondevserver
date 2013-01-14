namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    using Data;
    using FluentNHibernate.Mapping;

    public class MapMapping : ClassMap<Map>
    {
        public MapMapping()
        {
            this.ReadOnly();
            this.Schema("bf3");
            this.Table("map");

            this.Id(x => x.Key, "id").GeneratedBy.Native();
            this.Map(x => x.Code, "code");
            this.Map(x => x.Display, "label");
            HasManyToMany(x => x.SupportedModes)
                .ParentKeyColumn("map_id")
                .ChildKeyColumn("mode_id")
                .Table("map_modes")
                .Schema("bf3")
                .Not.LazyLoad()
                .Inverse();
        }
    }
}