using System.Collections.Generic;
using NUnit.Framework;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data
{
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
        public void FromWords_WithNoneWords_ReturnsNull()
        {
            var words = new List<string>() { "dumb", "string" };
            var subset = PlayerSubset.FromWords(words);

            Assert.IsNull(subset);
        }
    }
}
