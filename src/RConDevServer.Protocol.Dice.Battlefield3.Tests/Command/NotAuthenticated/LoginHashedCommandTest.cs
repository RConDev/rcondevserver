using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.NotAuthenticated
{
    using Battlefield3.Command;
    using Battlefield3.Command.NotAuthenticated;
    using NUnit.Framework;

    [TestFixture]
    public class LoginHashedCommandTest
    {
        [Test]
        public void Ctor_WithoutPasswordHash_PasswordHashNotSet()
        {
            var command = new LoginHashedCommand();
            Assert.IsNotNull(command);
            Assert.IsNull(command.PasswordHash);
        }

        [Test]
        public void Ctor_WitPasswordHash_PasswordIsSet()
        {
            var expectedHash = "MyHash";
            var command = new LoginHashedCommand(expectedHash);
            Assert.IsNotNull(command);
            Assert.IsNotNull(command.PasswordHash);
            Assert.AreEqual(expectedHash, command.PasswordHash);
        }

        [Test]
        public void ToWords_WithPasswordHashSet_ReturnsWords()
        {
            var hash = "MyHash";
            var expectedWords = new[] {CommandNames.LoginHashed, hash};
            var command = new LoginHashedCommand(hash);
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }

        [Test]
        public void ToWords_WithPasswordHashNotSet_ReturnsWords()
        {
            var expectedWords = new[] { CommandNames.LoginHashed };
            var command = new LoginHashedCommand();
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }
    }
}
