namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    using Data;
    using FluentNHibernate.Mapping;

    public class PlayerListStoreItemMapping : ClassMap<PlayerListStoreItem>
    {
        public PlayerListStoreItemMapping()
        {
            this.Schema("bf3");
            this.Table("player_list");

            this.Id(x => x.Id).GeneratedBy.Native();
            this.Map(x => x.Label, "name").Unique();
            this.Map(x => x.Store, "player_list");
        }
    }
}