using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command
{
    using Battlefield3.Command;
    using NUnit.Framework;

    [TestFixture]
    public class CommandStringTest
    {
        [Test]
        public void GetParts_WithSimpleWords_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 the-reason";
            var commandString = new CommandString(aString);
            var parts = commandString.CommandWords();
            var expectedParts = new[] {"admin.kickPlayer", "soldier1", "the-reason"};
            Assert.IsTrue(expectedParts.SequenceEqual(parts));
        }

        [Test]
        public void GetParts_WithQuotesAndSpace_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 \"the reason\"";
            var expectedParts = new[] { "admin.kickPlayer", "soldier1", "the reason" };
            var commandString = new CommandString(aString);
            var parts = commandString.CommandWords();
            Assert.IsTrue(expectedParts.SequenceEqual(parts));
        }

        [Test]
        public void GetParts_WithQuotesAndMultipleSpace_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 \"the unique reason\"";
            var expectedParts = new[] { "admin.kickPlayer", "soldier1", "the unique reason" };
            var commandString = new CommandString(aString);
            var parts = commandString.CommandWords();
            Assert.IsTrue(expectedParts.SequenceEqual(parts));
        }
    }
}
