using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data
{
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class PlayerListTest
    {
        #region ToWords()

        [Test]
        public void ToWords_EmptyPlayerList_Ok7NameGuidTeamIdSquadIdKillsDeathsScore0()
        {
            var playerList = new PlayerList();
            var expected = new[]
                {
                    "7",
                    "name",
                    "guid",
                    "teamId",
                    "squadId",
                    "kills",
                    "deaths",
                    "score",
                    "0"
                };
            var words = playerList.ToWords();
            Assert.AreEqual(expected, words);
        }

        #endregion
    }
}
