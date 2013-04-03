namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsCrossHairCommandTest : VarsCommandTestBase<VarsCrossHairCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsCrossHair; }
        }

        public override VarsCrossHairCommand CreateCommandWithValue()
        {
            return new VarsCrossHairCommand(true);
        }

        public override VarsCrossHairCommand CreateCommandWithoutValue()
        {
            return new VarsCrossHairCommand();
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