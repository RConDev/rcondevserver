namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsMiniMapCommandTest : VarsCommandTestBase<VarsMiniMapCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsMiniMap; }
        }

        public override VarsMiniMapCommand CreateCommandWithValue()
        {
            return new VarsMiniMapCommand(true);
        }

        public override VarsMiniMapCommand CreateCommandWithoutValue()
        {
            return new VarsMiniMapCommand();
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