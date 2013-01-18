namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    public class EventsEnabledCommandTest
    {
        [Test]
        public void ToWords_WithIsEnabledSet_ReturnsWords()
        {
            var command = new EventsEnabledCommand(true);
            var expectedWords = new[] {CommandNames.AdminEventsEnabled, "true"};
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }

        [Test]
        public void ToWords_WithIsEnabledNotSet_ReturnsWords()
        {
            var command = new EventsEnabledCommand();
            var expectedWords = new[] {CommandNames.AdminEventsEnabled};
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }
    }
}