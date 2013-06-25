namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.BanList
{
    using Battlefield3.Command.BanList;
    using Battlefield3.CommandHandler.BanList;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    public class BanListAddCommandHandlerTest : BanListCommandHandlerTestBase
    {
        private BanListAddCommandHandler commandHandler;

        [SetUp]
        public void TestSetup()
        {
            this.commandHandler = new BanListAddCommandHandler();
        }

        #region Command

        [Test]
        public void Command_BanListAdd()
        {
            Assert.AreEqual("banList.add", commandHandler.Command);
        }

        #endregion

        #region ProcessCommand
        
        [Test]
        public void ProcessCommand_BanListAddCommand_ReturnsOkResponse()
        {
            var command = new BanListAddCommand(IdType.Name, "PlayerName", new Timeout(TimeoutType.Permanent));
            var response = commandHandler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        #endregion
    }
}
