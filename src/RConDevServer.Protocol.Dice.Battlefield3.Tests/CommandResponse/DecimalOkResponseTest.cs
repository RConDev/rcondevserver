namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DecimalOkResponseTest
    {
        #region Constructor

        [Test]
        public void Ctor_1_Value1()
        {
            var response = new DecimalOkResponse(1);
            Assert.AreEqual(1, response.Value);
        }

        [Test]
        public void Ctor_1_NameOk()
        {
            var response = new DecimalOkResponse(1);
            Assert.AreEqual("OK", response.ResponseName);
        }

        #endregion

        #region ToWords()

        [Test]
        public void ToWords_1_Ok1()
        {
            var response = new DecimalOkResponse(1);
            var words = response.ToWords();

            Assert.AreEqual(new []{"OK", "1"}, words);
        }

        #endregion
    }
}
