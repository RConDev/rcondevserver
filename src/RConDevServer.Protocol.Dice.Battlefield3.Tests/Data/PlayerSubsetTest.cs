using System.Collections.Generic;
using NUnit.Framework;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlayerSubsetTest
    {
        [Test]
        public void FromWordsAll()
        {
            var words = new List<string>() {"all"};
            var subset = PlayerSubset.FromWords(words);

            Assert.AreEqual(PlayerSubsetType.All ,subset.Type);
            Assert.IsNull(subset.TeamId);
            Assert.IsNull(subset.SquadId);
            Assert.IsNull(subset.PlayerName);
        }

        [Test]
        public void FromWordsTeam()
        {
            var words = new List<string>() { "team", "1" };
            var subset = PlayerSubset.FromWords(words);

            Assert.AreEqual(PlayerSubsetType.Team, subset.Type);
            Assert.AreEqual(1, subset.TeamId);
            Assert.IsNull(subset.SquadId);
            Assert.IsNull(subset.PlayerName);
        }

        [Test]
        public void FromWordsSquad()
        {
            var words = new List<string>() { "squad", "1", "1" };
            var subset = PlayerSubset.FromWords(words);

            Assert.AreEqual(PlayerSubsetType.Squad, subset.Type);
            Assert.AreEqual(1, subset.TeamId);
            Assert.AreEqual(1, subset.SquadId);
            Assert.AreEqual(null, subset.PlayerName);
        }

        [Test]
        public void FromWordsPlayer()
        {
            var words = new List<string>() { "player", "TestPlayer" };
            var subset = PlayerSubset.FromWords(words);

            Assert.AreEqual(PlayerSubsetType.Player, subset.Type);
            Assert.IsNull(subset.TeamId);
            Assert.IsNull(subset.SquadId);
            Assert.AreEqual("TestPlayer", subset.PlayerName);
        }

        [Test]
        public void FromWords_WithNoneWords_ThrowsArgumentException()
        {
            var words = new List<string>() { "dumb", "string" };
            Assert.Throws<ArgumentException>(() => PlayerSubset.FromWords(words));
        }

        [Test]
        public void FromWords_WithNoneWords_ArgumentExceptionMessage()
        {
            var words = new List<string>() { "dumb", "string" };
            var exception = Assert.Throws<ArgumentException>(() => PlayerSubset.FromWords(words));
            Assert.AreEqual("The sequence '[dumb] [string]' does not represent a PlayerSubset instance.", exception.Message);
        }
    }
}
