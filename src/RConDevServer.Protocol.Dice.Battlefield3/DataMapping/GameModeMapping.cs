using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    public class GameModeMapping : ClassMap<GameMode>
    {
        public GameModeMapping()
        {
            ReadOnly();
            Schema("bf3");
            Table("game_mode");
            Id(x => x.Key, "id").GeneratedBy.Assigned();
            Map(x => x.Code, "code");
            Map(x => x.Display, "label");
            Map(x => x.MaxPlayerCount, "max_player_count");

            
        }
    }
}
