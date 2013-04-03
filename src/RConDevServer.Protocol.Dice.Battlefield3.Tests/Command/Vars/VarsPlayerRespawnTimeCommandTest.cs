using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsPlayerRespawnTimeCommandTest : IntVarsCommandTestBase<VarsPlayerRespawnTimeCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsPlayerRespawnTime; }
        }
    }
}
