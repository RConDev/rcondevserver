namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsRankedCommandTest : VarsCommandTestBase<VarsRankedCommand, bool?>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsRanked; }
        }

        public override VarsRankedCommand CreateCommandWithValue()
        {
            return new VarsRankedCommand(true);
        }

        public override VarsRankedCommand CreateCommandWithoutValue()
        {
            return new VarsRankedCommand();
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