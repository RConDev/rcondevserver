using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsPlayerRespawnTimeCommandTest : IntVarsCommandTestBase<VarsPlayerRespawnTimeCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsPlayerRespawnTime; }
        }
    }
}
