namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.Admin
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandFactory.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminKickPlayerCommandFactoryTest
    {
        private AdminKickPlayerCommandFactory factory;

        #region Setup

        [SetUp]
        public void SetupTest()
        {
            this.factory = new AdminKickPlayerCommandFactory();
        }

        #endregion

        #region FromWords()

        [Test]
        public void FromWords_WithInvalidCommandName_ThrowsArgumentOutOfRangeException()
        {
            var words = new[] {CommandNames.AdminKillPlayer};
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.FromWords(words));
            Assert.AreEqual("\r\nParameter name: commandName\r\nActual value was admin.killPlayer.", exception.Message);
        }

        [Test]
        public void FromWords_WithInvalidWordCount_ThrowsArgumentOutOfRangeException()
        {
            var words = new[] { CommandNames.AdminKickPlayer };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => factory.FromWords(words));
            Assert.AreEqual("\r\nParameter name: commandWords.Length\r\nActual value was 1.", exception.Message);
        }

        [Test]
        public void FromWords_CommandWords_AdminKickPlayerCommand()
        {
            var words = new[] { CommandNames.AdminKickPlayer, "TestPlayer", "Reason" };
            var command = factory.FromWords(words);
            Assert.IsInstanceOf<AdminKickPlayerCommand>(command);
            Assert.AreEqual("TestPlayer", command.SoldierName);
            Assert.AreEqual("Reason", command.Reason);
        }

        #endregion
    }
}
