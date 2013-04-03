namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsTeamKillValueDecreasePerSecondCommandTest :
        VarsCommandTestBase<VarsTeamKillValueDecreasePerSecondCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsTeamKillValueDecreasePerSecond; }
        }

        public override VarsTeamKillValueDecreasePerSecondCommand CreateCommandWithValue()
        {
            return new VarsTeamKillValueDecreasePerSecondCommand(123);
        }

        public override VarsTeamKillValueDecreasePerSecondCommand CreateCommandWithoutValue()
        {
            return new VarsTeamKillValueDecreasePerSecondCommand();
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