namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsTeamKillCountForKickCommandTest : VarsCommandTestBase<VarsTeamKillCountForKickCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsTeamKillCountForKick; }
        }

        public override VarsTeamKillCountForKickCommand CreateCommandWithValue()
        {
            return new VarsTeamKillCountForKickCommand(123);
        }

        public override VarsTeamKillCountForKickCommand CreateCommandWithoutValue()
        {
            return new VarsTeamKillCountForKickCommand();
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