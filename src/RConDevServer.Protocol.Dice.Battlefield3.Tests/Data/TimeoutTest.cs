namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data
{
    using System;
    using System.Linq;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class TimeoutTest
    {
        [Test]
        public void FromWords_WithPermanentBan_ReturnsPermTimeout()
        {
            var words = new[] {"perm"};
            var timeout = Timeout.FromWords(words);
            Assert.AreEqual(TimeoutType.Permanent, timeout.Type);
            Assert.IsNull(timeout.Value);
        }

        [Test]
        public void FromWords_WithRoundsBan_ReturnsRoundTimeout()
        {
            var words = new[] { "rounds", "4" };
            var timeout = Timeout.FromWords(words);
            Assert.AreEqual(TimeoutType.Rounds, timeout.Type);
            Assert.AreEqual(4, timeout.Value);
        }

        [Test]
        public void FromWords_WithRoundsBanInvalidNumber_ThrowsException()
        {
            var words = new[] { "rounds", "ww" };
            Assert.Throws<ArgumentNullException>(() => 
                Timeout.FromWords(words));
        }

        [Test]
        public void FromWords_WithSecondsBan_ReturnsSecondTimeout()
        {
            var words = new[] { "seconds", "180"};
            var timeout = Timeout.FromWords(words);
            Assert.AreEqual(TimeoutType.Seconds, timeout.Type);
            Assert.AreEqual(180, timeout.Value);
        }
    
        [Test]
        public void ToWords_WithPermanentBan_ReturnsWords()
        {
            var timeout = new Timeout(TimeoutType.Permanent);
            var expectedWords = new[] {"perm"};
            Assert.IsTrue(expectedWords.SequenceEqual(timeout.ToWords()));
        }

        [Test]
        public void ToWords_WithRoundsBan_ReturnsWords()
        {
            var timeout = new Timeout(TimeoutType.Rounds, 3);
            var expectedWords = new[] {"rounds", "3"};
            Assert.IsTrue(expectedWords.SequenceEqual(timeout.ToWords()));
        }

        [Test]
        public void ToWords_WithSecondsBan_ReturnsWords()
        {
            var timeout = new Timeout(TimeoutType.Seconds, 3);
            var expectedWords = new[] { "seconds", "3" };
            Assert.IsTrue(expectedWords.SequenceEqual(timeout.ToWords()));
        }
    }
}