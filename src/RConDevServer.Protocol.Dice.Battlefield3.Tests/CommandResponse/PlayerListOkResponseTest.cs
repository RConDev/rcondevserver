using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class PlayerListOkResponseTest
    {
        #region Ctor

        [Test]
        public void Ctor_Empty_PlayerListIsNull()
        {
            var response = new PlayerListOkResponse();
            Assert.IsNull(response.PlayerList);
        }

        [Test]
        public void Ctor_Empty_IncludeGuidFalse()
        {
            var response = new PlayerListOkResponse();
            Assert.IsFalse(response.IncludeGuid);
        }

        [Test]
        public void Ctor_EmptyPlayerList_PlayerListNotNull()
        {
            var response = new PlayerListOkResponse(new PlayerList());
            Assert.IsNotNull(response.PlayerList);
        }

        [Test]
        public void Ctor_EmptyPlayerList_IncludeGuidFalse()
        {
            var response = new PlayerListOkResponse(new PlayerList());
            Assert.IsFalse(response.IncludeGuid);
        }

        [Test]
        public void Ctor_EmptyPlayerListIncludeGuidTrue_IncludeGuidTrue()
        {
            var response = new PlayerListOkResponse(new PlayerList(), true);
            Assert.IsTrue(response.IncludeGuid);
        }

        #endregion

        #region ResponseName

        [Test]
        public void ResponseName_Ok()
        {
            var response = new PlayerListOkResponse();
            Assert.AreEqual("OK", response.Response);
        }

        #endregion

        #region ToWords()

        [Test]
        public void ToWords_WithPlayerList_ReturnsWordsWithoutGuids()
        {
            var playerListMock = new Mock<IPlayerList>();
            playerListMock
                .Setup(x => x.ToWords(It.Is<bool>(c => c == false)))
                .Returns(new[] {"false", "words"})
                .Verifiable();

            var response = new PlayerListOkResponse(playerListMock.Object);
            var words = response.ToWords();

            Assert.AreEqual(new[] { "OK", "false", "words" }, words);
            playerListMock.VerifyAll();
        }

        [Test]
        public void ToWords_WithPlayerList_ReturnsWordsWithGuids()
        {
            var playerListMock = new Mock<IPlayerList>();
            playerListMock
                .Setup(x => x.ToWords(It.Is<bool>(c => true)))
                .Returns(new[] { "true", "words" })
                .Verifiable();

            var response = new PlayerListOkResponse(playerListMock.Object);
            var words = response.ToWords();

            Assert.AreEqual(new[] { "OK", "true", "words" }, words);
            playerListMock.VerifyAll();
        } 

        #endregion
    }
}
