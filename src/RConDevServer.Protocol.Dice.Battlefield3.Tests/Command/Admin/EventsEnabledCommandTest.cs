namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EventsEnabledCommandTest
    {
        [Test]
        public void ToWords_WithIsEnabledSet_ReturnsWords()
        {
            var command = new AdminEventsEnabledCommand(true);
            var expectedWords = new[] {CommandNames.AdminEventsEnabled, "true"};
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }

        [Test]
        public void ToWords_WithIsEnabledNotSet_ReturnsWords()
        {
            var command = new AdminEventsEnabledCommand();
            var expectedWords = new[] {CommandNames.AdminEventsEnabled};
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }
    }
}