namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    public class KillPlayerCommandTest
    {
        [Test]
        public void Ctor_WithProperties_AllPropertiesSet()
        {
            var command = new KillPlayerCommand("soldier");
            Assert.IsNotNull(command);

            Assert.AreEqual(CommandNames.AdminKillPlayer, command.Command);
            Assert.AreEqual("soldier", command.SoldierName);
        }

        [Test]
        public void ToWords_ReturnsWords()
        {
            var command = new KillPlayerCommand("soldier");
            var expectedWords = new[] {CommandNames.AdminKillPlayer, "soldier"};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}