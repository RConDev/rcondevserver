namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.BanList
{
    using Battlefield3.Command;
    using Battlefield3.Command.BanList;
    using Battlefield3.CommandFactory.BanList;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class AddCommandFactoryTest
    {
        [Test]
        public void FromWords_WithPermanentBanWithReason_ReturnsCommand()
        {
            var words = new[] {CommandNames.BanListAdd, "name", "soldier", "perm", "the reason"};
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Permanent, command.Timeout.Type);
            Assert.AreEqual("the reason", command.Reason);
        }

        [Test]
        public void FromWords_WithPermanentBanWithoutReason_ReturnsCommand()
        {
            var words = new[] {CommandNames.BanListAdd, "name", "soldier", "perm"};
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Permanent, command.Timeout.Type);
            Assert.IsNull(command.Timeout.Value);
            Assert.IsNull(command.Reason);
        }

        [Test]
        public void FromWords_WithRoundBanWithoutReason_ReturnsCommand()
        {
            var words = new[] { CommandNames.BanListAdd, "name", "soldier", "rounds", "1" };
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Rounds, command.Timeout.Type);
            Assert.AreEqual(1, command.Timeout.Value);
            Assert.IsNull(command.Reason);
        }

        [Test]
        public void FromWords_WithRoundBanWithoReason_ReturnsCommand()
        {
            var words = new[] { CommandNames.BanListAdd, "name", "soldier", "rounds", "1", "the reason" };
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Rounds, command.Timeout.Type);
            Assert.AreEqual(1, command.Timeout.Value);
            Assert.AreEqual("the reason", command.Reason);
        }

        [Test]
        public void FromWords_WithSeconddBanWithoutReason_ReturnsCommand()
        {
            var words = new[] { CommandNames.BanListAdd, "name", "soldier", "seconds", "1" };
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Seconds, command.Timeout.Type);
            Assert.AreEqual(1, command.Timeout.Value);
            Assert.IsNull(command.Reason);
        }

        [Test]
        public void FromWords_WithSecondBanWithoReason_ReturnsCommand()
        {
            var words = new[] { CommandNames.BanListAdd, "name", "soldier", "seconds", "1", "the reason" };
            var commandFactory = new AddCommandFactory();
            AddCommand command = commandFactory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.AreEqual("name", command.IdType);
            Assert.AreEqual("soldier", command.Id);
            Assert.AreEqual(TimeoutType.Seconds, command.Timeout.Type);
            Assert.AreEqual(1, command.Timeout.Value);
            Assert.AreEqual("the reason", command.Reason);
        }
    }
}