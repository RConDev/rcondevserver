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
    public class Vars3DSpottingCommandTest : VarsCommandTestBase<Vars3DSpottingCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.Vars3DSpotting; }
        }

        public override Vars3DSpottingCommand CreateCommandWithValue()
        {
            return new Vars3DSpottingCommand(true);
        }

        public override Vars3DSpottingCommand CreateCommandWithoutValue()
        {
            return new Vars3DSpottingCommand();
        }

        public override bool? GetValue()
        {
            return true;
        }

        public override string GetStringValue()
        {
            return "true";
        }
    }
}
