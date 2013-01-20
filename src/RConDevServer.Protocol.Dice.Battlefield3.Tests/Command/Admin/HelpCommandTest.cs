namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    public class HelpCommandTest
    {
        [Test]
        public void ToWords_ReturnsWords()
        {
            var command = new HelpCommand();
            var expectedWords = new[] {CommandNames.AdminHelp};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}