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
    public class VarsGamePasswordCommandTest : VarsCommandTestBase<VarsGamePasswordCommand, string>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsGamePassword; }
        }

        public override VarsGamePasswordCommand CreateCommandWithValue()
        {
            return new VarsGamePasswordCommand("a password");
        }

        public override VarsGamePasswordCommand CreateCommandWithoutValue()
        {
            return new VarsGamePasswordCommand();
        }

        public override string GetValue()
        {
            return "a password";
        }

        public override string GetStringValue()
        {
            return "a password";
        }
    }
}
