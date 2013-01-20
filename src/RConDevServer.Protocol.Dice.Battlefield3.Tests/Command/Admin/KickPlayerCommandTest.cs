namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    public class KickPlayerCommandTest
    {
        [Test]
        public void Ctor_WithParameters_ReturnsCommand()
        {
            var command = new KickPlayerCommand("soldier", "the reason");
            Assert.AreEqual("soldier", command.SoldierName);
            Assert.AreEqual("the reason", command.Reason);
            Assert.AreEqual(CommandNames.AdminKickPlayer, command.Command);
        }

        [Test]
        public void ToWords_ReturnsWords()
        {
            var command = new KickPlayerCommand("soldier", "the reason");
            var expectedWords = new[] {CommandNames.AdminKickPlayer, "soldier", "the reason"};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}