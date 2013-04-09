using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    public class InvalidPlayerResponseTest
    {
        #region ResponseName

        [Test]
        public void ResponseName_InvalidPlayerName()
        {
            var response = new InvalidPlayerNameResponse();
            Assert.AreEqual("InvalidPlayerName", response.ResponseName);
        }

        #endregion

        #region ToWords()

        [Test]
        public void ToWords_InvalidPlayerName()
        {
            var response = new InvalidPlayerNameResponse();
            var words = response.ToWords();

            Assert.AreEqual(new [] {"InvalidPlayerName"}, words);
        }

        #endregion
    }
}
