using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.DataMapping
{
    public class CountryMapping : ClassMap<Country>
    {
        public CountryMapping()
        {
            this.ReadOnly();
            this.Schema("bf3");
            this.Table("country");
            this.Id(x => x.Id, "id").GeneratedBy.Assigned();
            this.Map(x => x.CodeAlpha2, "code_alpha2");
            this.Map(x => x.Display, "label");
        }
    }
}
