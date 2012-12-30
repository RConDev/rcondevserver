using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
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
