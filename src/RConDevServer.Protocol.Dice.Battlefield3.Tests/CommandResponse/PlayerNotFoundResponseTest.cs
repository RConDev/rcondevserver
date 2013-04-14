namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlayerNotFoundResponseTest
    {
        #region ResponseName

        [Test]
        public void ResponseName_PlayerNotFound()
        {
            var response = new PlayerNotFoundResponse();
            Assert.AreEqual("PlayerNotFound", response.Response);
        }

        #endregion

        #region ToWords()

        [Test]
        public void ToWords_PlayerNotFound()
        {
            var response = new PlayerNotFoundResponse();
            Assert.AreEqual(new[] { "PlayerNotFound" }, response.ToWords());
        }

        #endregion
    }
}
