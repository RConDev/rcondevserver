namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class Vars3PCamCommandTest : VarsCommandTestBase<Vars3PCamCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.Vars3PCam; }
        }

        public override Vars3PCamCommand CreateCommandWithValue()
        {
            return new Vars3PCamCommand(true);
        }

        public override Vars3PCamCommand CreateCommandWithoutValue()
        {
            return new Vars3PCamCommand();
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