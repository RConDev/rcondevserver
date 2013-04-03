namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Util
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Util;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BoolTest
    {
        [Test]
        public void SafeParse_WithTrue_ReturnsTrue()
        {
            var stringValue = "true";
            var value = Bool.SafeParse(stringValue);
            Assert.IsTrue(value.HasValue);
            Assert.IsTrue(value.Value);
        }

        [Test]
        public void SafeParse_WithFalse_ReturnsTrue()
        {
            var stringValue = "false";
            var value = Bool.SafeParse(stringValue);
            Assert.IsTrue(value.HasValue);
            Assert.IsFalse(value.Value);
        }
    }
}