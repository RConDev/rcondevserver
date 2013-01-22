namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System.Linq;
    using Battlefield3.Command;
    using NUnit.Framework;

    public abstract class VarsTestBase<TCommand, TValue> where TCommand : class, IVarsCommand<TValue>
    {
        public abstract string CommandName { get; }

        public abstract TCommand CreateCommandWithValue();

        public abstract TCommand CreateCommandWithoutValue();

        public abstract TValue GetValue();

        public abstract string GetStringValue();

        [Test]
        public void Ctor_WithValueNotSet_ReturnsCommand()
        {
            TCommand command = this.CreateCommandWithoutValue();
            Assert.IsNotNull(command);
            Assert.IsNull(command.Value);
            Assert.AreEqual(this.CommandName, command.Command);
        }

        [Test]
        public void Ctor_WithValueSet_ReturnsCommand()
        {
            TCommand command = this.CreateCommandWithValue();
            Assert.IsNotNull(command);
            Assert.AreEqual(this.GetValue(), command.Value);
            Assert.AreEqual(this.CommandName, command.Command);
        }

        [Test]
        public void ToWords_WithValueNotSet_ReturnsWords()
        {
            TCommand command = this.CreateCommandWithoutValue();
            var expectedWords = new[] {this.CommandName};
            Assert.IsTrue(expectedWords.SequenceEqual(command.ToWords()));
        }

        [Test]
        public void ToWords_WithValueSet_ReturnsWords()
        {
            TCommand command = this.CreateCommandWithValue();
            var expectedWords = new[] {this.CommandName, this.GetStringValue()};
            var words = command.ToWords();
            Assert.IsTrue(expectedWords.SequenceEqual(words));
        }
    }
}