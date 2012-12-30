using FluentNHibernate.Mapping;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    public class MapMapping : ClassMap<Map>
    {
        public MapMapping()
        {
            ReadOnly();
            Schema("bf3");
            Table("map");

            Id(x => x.Key, "id").GeneratedBy.Native();
            Map(x => x.Code, "code");
            Map(x => x.Display, "label");
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
