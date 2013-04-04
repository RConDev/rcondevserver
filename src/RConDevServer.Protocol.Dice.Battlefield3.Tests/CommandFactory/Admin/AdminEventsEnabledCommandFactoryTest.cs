using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandFactory.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminEventsEnabledCommandFactoryTest
    {
        private AdminEventsEnabledCommandFactory factory;

        #region Setup

        [SetUp]
        public void SetupTest()
        {
            this.factory = new AdminEventsEnabledCommandFactory();
        }

        #endregion

        #region FromWords()

        [Test]
        public void FromWords_WithTrueValue_CommandWithTrueValue()
        {
            var words = new[] {CommandNames.AdminEventsEnabled, "true"};

            var command = factory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.IsInstanceOf<AdminEventsEnabledCommand>(command);
            Assert.IsTrue(command.IsEnabled.HasValue);
            Assert.IsTrue(command.IsEnabled.Value);
        }

        [Test]
        public void FromWords_WithFalseValue_CommandWithFalseValue()
        {
            var words = new[] { CommandNames.AdminEventsEnabled, "false" };

            var command = factory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.IsInstanceOf<AdminEventsEnabledCommand>(command);
            Assert.IsTrue(command.IsEnabled.HasValue);
            Assert.IsFalse(command.IsEnabled.Value);
        }

        [Test]
        public void FromWords_WithoutValue_CommandWithoutValue()
        {
            var words = new[] { CommandNames.AdminEventsEnabled};

            var command = factory.FromWords(words);

            Assert.IsNotNull(command);
            Assert.IsInstanceOf<AdminEventsEnabledCommand>(command);
            Assert.IsFalse(command.IsEnabled.HasValue);
            Assert.IsNull(command.IsEnabled);
        }

        [Test]
        public void FromWords_WithInvalidValue_ThrowsArgumentException()
        {
            var words = new[] { CommandNames.AdminEventsEnabled, "123" };

            Assert.Throws<ArgumentException>(() => factory.FromWords(words));
        }

        [Test]
        public void FromWords_WithInvalidArgumentCount_ThrowsArgumentException()
        {
            var words = new[] { CommandNames.AdminEventsEnabled, "true", "123" };

            Assert.Throws<ArgumentException>(() => factory.FromWords(words));
        }

        #endregion
    }
}
