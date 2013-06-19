namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.BanList
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command.BanList;
    using Battlefield3.CommandHandler.BanList;
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BanListClearCommandHandlerTest : BanListCommandHandlerTestBase
    {
        private BanListClearCommandHandler commandHandler;

        #region TestSetup

        [SetUp]
        public void TestSetup()
        {
            this.commandHandler = new BanListClearCommandHandler();
        }

        #endregion

        #region CommandName

        [Test]
        public void Command_BanListClear()
        {
            Assert.AreEqual("banList.clear", commandHandler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_WithCommand_ResponseOk()
        {
            var command = new BanListClearCommand();
            var response = commandHandler.ProcessCommand(command, this.PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        #endregion
    }
}
