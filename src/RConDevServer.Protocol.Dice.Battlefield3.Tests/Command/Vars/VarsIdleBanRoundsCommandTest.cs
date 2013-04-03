namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsIdleBanRoundsCommandTest : VarsCommandTestBase<VarsIdleBanRoundsCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsIdleBanRounds; }
        }

        public override VarsIdleBanRoundsCommand CreateCommandWithValue()
        {
            return new VarsIdleBanRoundsCommand(123);
        }

        public override VarsIdleBanRoundsCommand CreateCommandWithoutValue()
        {
            return new VarsIdleBanRoundsCommand();
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