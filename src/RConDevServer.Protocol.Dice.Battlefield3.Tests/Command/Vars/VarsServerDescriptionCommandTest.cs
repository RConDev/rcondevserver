namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsServerDescriptionCommandTest : VarsCommandTestBase<VarsServerDescriptionCommand, string>
    {
        public override string CommandName
        {
            get { return CommandNames.VarsServerDescription; }
        }

        public override VarsServerDescriptionCommand CreateCommandWithValue()
        {
            return new VarsServerDescriptionCommand("a description");
        }

        public override VarsServerDescriptionCommand CreateCommandWithoutValue()
        {
            return new VarsServerDescriptionCommand();
        }

        public override string GetValue()
        {
            return "a description";
        }

        public override string GetStringValue()
        {
            return "a description";
        }
    }
}