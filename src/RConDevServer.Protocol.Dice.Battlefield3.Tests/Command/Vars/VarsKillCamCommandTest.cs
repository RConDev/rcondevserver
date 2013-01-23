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
    public class VarsKillCamCommandTest : VarsCommandTestBase<VarsKillCamCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsKillCam; }
        }

        public override VarsKillCamCommand CreateCommandWithValue()
        {
            return new VarsKillCamCommand(true);
        }

        public override VarsKillCamCommand CreateCommandWithoutValue()
        {
            return new VarsKillCamCommand();
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
