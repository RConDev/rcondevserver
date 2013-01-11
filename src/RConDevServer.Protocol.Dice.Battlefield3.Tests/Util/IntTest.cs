namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Util
{
    using Battlefield3.Util;
    using NUnit.Framework;

    [TestFixture]
    public class IntTest
    {
        [Test]
        public void SafeParse_WithIntValue_ReturnsValue()
        {
            const string stringValue = "123";
            int? expectedValue = 123;
            var value = Int.SafeParse(stringValue);
            Assert.AreEqual(expectedValue, value);
        }

        [Test]
        public void SafeParse_WithText_ReturnsNull()
        {
            const string stringValue = "A Text";
            var value = Int.SafeParse(stringValue);
            Assert.IsNull(value);
        }

        [Test]
        public void SafeParse_WithFloat_ReturnsNull()
        {
            const string stringValue = "123,58";
            var value = Int.SafeParse(stringValue);
            Assert.IsNull(value);
        }
    }
}