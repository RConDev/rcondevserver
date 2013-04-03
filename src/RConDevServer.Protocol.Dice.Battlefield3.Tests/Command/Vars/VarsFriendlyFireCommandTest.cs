namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsFriendlyFireCommandTest : VarsCommandTestBase<VarsFriendlyFireCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsFriendlyFire; }
        }

        public override VarsFriendlyFireCommand CreateCommandWithValue()
        {
            return new VarsFriendlyFireCommand(false);
        }

        public override VarsFriendlyFireCommand CreateCommandWithoutValue()
        {
            return new VarsFriendlyFireCommand();
        }

        public override bool? GetValue()
        {
            return false;
        }

        public override string GetStringValue()
        {
            return "false";
        }
    }
}