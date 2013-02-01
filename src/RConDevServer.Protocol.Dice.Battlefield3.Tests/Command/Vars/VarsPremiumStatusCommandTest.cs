namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    public class VarsPremiumStatusCommandTest : VarsCommandTestBase<VarsPremiumStatusCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsPremiumStatus; }
        }

        public override VarsPremiumStatusCommand CreateCommandWithValue()
        {
            return new VarsPremiumStatusCommand(true);
        }

        public override VarsPremiumStatusCommand CreateCommandWithoutValue()
        {
            return new VarsPremiumStatusCommand();
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