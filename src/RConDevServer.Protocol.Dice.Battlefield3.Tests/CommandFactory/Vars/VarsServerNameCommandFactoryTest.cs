namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandFactory.Vars
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Vars;
    using Battlefield3.CommandFactory.Vars;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VarsServerNameCommandFactoryTest
    {
        private readonly VarsServerNameCommandFactory commandFactory = 
            new VarsServerNameCommandFactory();

        [Test]
        public void FromWords_WithCorrectWords_ReturnsCommand()
        {
            var commandWords = new[] {CommandNames.VarsServerName, "My Server Name"};
            VarsServerNameCommand command = this.commandFactory.FromWords(commandWords);
            Assert.IsNotNull(command);
            Assert.IsInstanceOf<VarsServerNameCommand>(command);
            Assert.AreEqual("My Server Name", command.Value);
        }

        [Test]
        public void FromWords_WithGreaterWordCount_ThrowsException()
        {
            var commandWords = new[] {CommandNames.VarsServerName, "value", "test"};
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => this.commandFactory.FromWords(commandWords));
            Assert.AreEqual(
                "The sequence 'words' has not the expected length of 2 at maximum." +
                "\r\nParameter name: words",
                exception.Message);
        }

        [Test]
        public void FromWords_WithIncorrectCommandName_ThrowsException()
        {
            var commandWords = new[] {"myCommand", "value"};
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => this.commandFactory.FromWords(commandWords));
            Assert.AreEqual("\r\nParameter name: commandName\r\nActual value was myCommand.", 
                exception.Message);
        }

        [Test]
        public void FromWords_WithSmallerWordCount_ThrowsException()
        {
            var commandWords = new string[] {};
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => this.commandFactory.FromWords(commandWords));
            Assert.AreEqual(
                "The sequence 'words' has not the expected length of 1 at minimum." +
                "\r\nParameter name: words",
                exception.Message);
        }
    }
}