namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsRoundRestartPlayerCountCommandTest : IntVarsCommandTestBase<VarsRoundRestartPlayerCountCommand>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsRoundRestartPlayerCount; }
        }
    }
}