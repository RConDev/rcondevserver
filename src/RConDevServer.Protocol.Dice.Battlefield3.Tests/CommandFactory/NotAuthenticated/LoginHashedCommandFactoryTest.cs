namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.NotAuthenticated
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.NotAuthenticated;
    using Battlefield3.CommandFactory.NotAuthenticated;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LoginHashedCommandFactoryTest
    {
        [Test]
        public void FromWords_WithoutPasswordHash_ReturnsCommand()
        {
            var factory = new LoginHashedCommandFactory();
            var command = factory.FromWords(new[] {CommandNames.LoginHashed});
            Assert.IsNotNull(command);
            Assert.IsInstanceOf<LoginHashedCommand>(command);
            Assert.IsNull(command.PasswordHash);
        }
    }
}