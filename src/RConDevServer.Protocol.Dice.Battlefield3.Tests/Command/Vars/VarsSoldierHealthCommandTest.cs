namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsSoldierHealthCommandTest : IntVarsCommandTestBase<VarsSoldierHealthCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsSoldierHealth; }
        }
    }
}