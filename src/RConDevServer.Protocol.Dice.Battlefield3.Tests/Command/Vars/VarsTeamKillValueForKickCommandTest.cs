namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsTeamKillValueForKickCommandTest : VarsCommandTestBase<VarsTeamKillValueForKickCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsTeamKillValueForKick; }
        }

        public override VarsTeamKillValueForKickCommand CreateCommandWithValue()
        {
            return new VarsTeamKillValueForKickCommand(123);
        }

        public override VarsTeamKillValueForKickCommand CreateCommandWithoutValue()
        {
            return new VarsTeamKillValueForKickCommand();
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