namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsTeamKillValueIncreaseCommandTest : VarsCommandTestBase<VarsTeamKillValueIncreaseCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsTeamKillValueIncrease; }
        }

        public override VarsTeamKillValueIncreaseCommand CreateCommandWithValue()
        {
            return new VarsTeamKillValueIncreaseCommand(123);
        }

        public override VarsTeamKillValueIncreaseCommand CreateCommandWithoutValue()
        {
            return new VarsTeamKillValueIncreaseCommand();
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