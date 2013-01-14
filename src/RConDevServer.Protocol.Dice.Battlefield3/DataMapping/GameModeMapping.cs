namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    using Data;
    using FluentNHibernate.Mapping;

    public class GameModeMapping : ClassMap<GameMode>
    {
        public GameModeMapping()
        {
            this.ReadOnly();
            this.Schema("bf3");
            this.Table("game_mode");
            this.Id(x => x.Key, "id").GeneratedBy.Assigned();
            this.Map(x => x.Code, "code");
            this.Map(x => x.Display, "label");
            this.Map(x => x.MaxPlayerCount, "max_player_count");
        }
    }
}