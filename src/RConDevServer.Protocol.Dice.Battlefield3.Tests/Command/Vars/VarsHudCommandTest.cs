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
    public class VarsHudCommandTest : VarsCommandTestBase<VarsHudCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsHud; }
        }

        public override VarsHudCommand CreateCommandWithValue()
        {
            return new VarsHudCommand(true);
        }

        public override VarsHudCommand CreateCommandWithoutValue()
        {
            return new VarsHudCommand();
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
