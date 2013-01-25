namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsTeamKillKickForBanCommandTest : VarsCommandTestBase<VarsTeamKillKickForBanCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsTeamKillKickForBan; }
        }

        public override VarsTeamKillKickForBanCommand CreateCommandWithValue()
        {
            return new VarsTeamKillKickForBanCommand(123);
        }

        public override VarsTeamKillKickForBanCommand CreateCommandWithoutValue()
        {
            return new VarsTeamKillKickForBanCommand();
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