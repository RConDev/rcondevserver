namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsRegenerateHealthCommandTest : VarsCommandTestBase<VarsRegenerateHealthCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsRegenerateHealth; }
        }

        public override VarsRegenerateHealthCommand CreateCommandWithValue()
        {
            return new VarsRegenerateHealthCommand(true);
        }

        public override VarsRegenerateHealthCommand CreateCommandWithoutValue()
        {
            return new VarsRegenerateHealthCommand();
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