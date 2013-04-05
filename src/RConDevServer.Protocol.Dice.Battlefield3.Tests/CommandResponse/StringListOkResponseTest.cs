namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class StringListOkResponseTest
    {
        #region ToWords()

        [Test]
        public void ToWords_WithEmptyStringList_Ok()
        {
            var response = new StringListOkResponse(new string[] {});
            var words = response.ToWords();
            Assert.AreEqual(new[] {"OK"}, words);
        }

        [Test]
        public void ToWords_ItemStringList_OkItem()
        {
            var response = new StringListOkResponse(new[] { "Item"});
            var words = response.ToWords();
            Assert.AreEqual(new[] { "OK", "Item" }, words);
        }

        [Test]
        public void ToWords_ItemItemStringList_OkItemItem()
        {
            var response = new StringListOkResponse(new[] { "Item", "Item"});
            var words = response.ToWords();
            Assert.AreEqual(new[] { "OK", "Item", "Item"}, words);
        }

        #endregion
    }
}
