namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Admin
{
    using System.Linq;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using NUnit.Framework;

    [TestFixture]
    public class EffectiveMaxPlayersCommandTest
    {
        [Test]
        public void ToWords_ReturnsCommandWords()
        {
            var expectedWords = new[] {CommandNames.AdminEffectiveMaxPlayers};
            var command = new EffectiveMaxPlayersCommand();
            Assert.AreEqual(CommandNames.AdminEffectiveMaxPlayers, command.Command);
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }
    }
}