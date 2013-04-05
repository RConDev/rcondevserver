namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResponseNamesTest
    {
        [Test]
        public void Ok()
        {
            Assert.AreEqual("OK", ResponseNames.Ok);
        }

        [Test]
        public void PlayerNotFound()
        {
            Assert.AreEqual("PlayerNotFound", ResponseNames.PlayerNotFound);
        }
    }
}
