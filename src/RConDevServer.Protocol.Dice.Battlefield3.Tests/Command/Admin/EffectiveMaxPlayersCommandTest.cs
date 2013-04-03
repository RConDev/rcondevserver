namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EffectiveMaxPlayersCommandTest
    {
        [Test]
        public void ToWords_ReturnsCommandWords()
        {
            var expectedWords = new[] {CommandNames.AdminEffectiveMaxPlayers};
            var command = new AdminEffectiveMaxPlayersCommand();
            Assert.AreEqual(CommandNames.AdminEffectiveMaxPlayers, command.Command);
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}