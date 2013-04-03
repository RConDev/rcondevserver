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
    public class VarsAutoBalanceCommandTest : VarsCommandTestBase<VarsAutoBalanceCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsAutoBalance; }
        }

        public override VarsAutoBalanceCommand CreateCommandWithValue()
        {
            return new VarsAutoBalanceCommand(true);
        }

        public override VarsAutoBalanceCommand CreateCommandWithoutValue()
        {
            return new VarsAutoBalanceCommand();
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
