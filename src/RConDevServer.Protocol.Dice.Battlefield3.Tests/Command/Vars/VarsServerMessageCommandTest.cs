namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsServerMessageCommandTest : VarsCommandTestBase<VarsServerMessageCommand, string>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsServerMessage; }
        }

        public override VarsServerMessageCommand CreateCommandWithValue()
        {
            return new VarsServerMessageCommand("my message");
        }

        public override VarsServerMessageCommand CreateCommandWithoutValue()
        {
            return new VarsServerMessageCommand();
        }

        public override string GetValue()
        {
            return "my message";
        }

        public override string GetStringValue()
        {
            return "my message";
        }
    }
}