namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsMaxPlayersCommandTest : VarsCommandTestBase<VarsMaxPlayersCommand, int?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsMaxPlayers; }
        }

        public override VarsMaxPlayersCommand CreateCommandWithValue()
        {
            return new VarsMaxPlayersCommand(123);
        }

        public override VarsMaxPlayersCommand CreateCommandWithoutValue()
        {
            return new VarsMaxPlayersCommand();
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