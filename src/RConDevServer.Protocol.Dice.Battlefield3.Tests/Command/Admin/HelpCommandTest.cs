namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HelpCommandTest
    {
        [Test]
        public void ToWords_ReturnsWords()
        {
            var command = new AdminHelpCommand();
            var expectedWords = new[] {CommandNames.AdminHelp};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}