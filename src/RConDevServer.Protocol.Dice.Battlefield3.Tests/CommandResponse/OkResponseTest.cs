using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OkResponseTest
    {
        #region Constructor

        [Test]
        public void Ctor_Empty_Ok()
        {
            var response = new OkResponse();
            Assert.AreEqual("OK", response.ResponseName);
        }

        #endregion

        #region ToWords()

        [Test]
        public void ToWords_Empty_Ok()
        {
            var response = new OkResponse();
            var words = response.ToWords();

            Assert.IsTrue(new [] {"OK"}.SequenceEqual(words));
        }

        #endregion
    }
}
