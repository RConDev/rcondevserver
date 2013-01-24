namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsNameTagCommandTest : VarsCommandTestBase<VarsNameTagCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsNameTag; }
        }

        public override VarsNameTagCommand CreateCommandWithValue()
        {
            return new VarsNameTagCommand(true);
        }

        public override VarsNameTagCommand CreateCommandWithoutValue()
        {
            return new VarsNameTagCommand();
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