namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class KillPlayerCommandTest
    {
        [Test]
        public void Ctor_WithProperties_AllPropertiesSet()
        {
            var command = new AdminKillPlayerCommand("soldier");
            Assert.IsNotNull(command);

            Assert.AreEqual(CommandNames.AdminKillPlayer, command.Command);
            Assert.AreEqual("soldier", command.SoldierName);
        }

        [Test]
        public void ToWords_ReturnsWords()
        {
            var command = new AdminKillPlayerCommand("soldier");
            var expectedWords = new[] {CommandNames.AdminKillPlayer, "soldier"};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}