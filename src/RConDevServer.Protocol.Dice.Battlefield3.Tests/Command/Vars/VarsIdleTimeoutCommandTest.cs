namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsIdleTimeoutCommandTest : VarsCommandTestBase<VarsIdleTimeoutCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsIdleTimeout; }
        }

        public override VarsIdleTimeoutCommand CreateCommandWithValue()
        {
            return new VarsIdleTimeoutCommand(123);
        }

        public override VarsIdleTimeoutCommand CreateCommandWithoutValue()
        {
            return new VarsIdleTimeoutCommand();
        }

        public override int? GetValue()
        {
            return 123;
        }

        public override string GetStringValue()
        {
            return "123";
        }
    }
}