using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class VarsUnlockModeCommandTest : VarsCommandTestBase<VarsUnlockModeCommand, Battlefield3.Data.UnlockMode?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsUnlockMode; }
        }

        public override VarsUnlockModeCommand CreateCommandWithValue()
        {
            return new VarsUnlockModeCommand(UnlockMode.Common);
        }

        public override VarsUnlockModeCommand CreateCommandWithoutValue()
        {
            return new VarsUnlockModeCommand();
        }

        public override UnlockMode? GetValue()
        {
            return UnlockMode.Common;
        }

        public override string GetStringValue()
        {
            return "common";
        }
    }
}
