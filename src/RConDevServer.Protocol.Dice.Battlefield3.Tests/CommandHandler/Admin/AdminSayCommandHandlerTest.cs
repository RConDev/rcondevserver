namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Event.Player;
    using NUnit.Framework;

    [TestFixture]
    public class AdminSayCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminSayCommandHandler handler;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            handler = new AdminSayCommandHandler();
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminSay()
        {
            Assert.AreEqual("admin.say", handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_MessageToAll_OkResponse()
        {
            var command = new AdminSayCommand("a message", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message127Chars_OkResponse()
        {
            var command = new AdminSayCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliqu", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message128Chars_TooLongMessageResponse()
        {
            var command = new AdminSayCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquy", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<TooLongMessageResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message129Chars_TooLongMessageResponse()
        {
            var command = new AdminSayCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquya", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<TooLongMessageResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message_RaisesServerEvent()
        {
            var command = new AdminSayCommand("A Message", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            
            Assert.AreEqual(1, handler.CommandEvents.Count);
        }

        [Test]
        public void ProcessCommand_Message_RaisedServerEventIsPlayerOnChat()
        {
            var command = new AdminSayCommand("A Message", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);

            var commandEvent = handler.CommandEvents[0];
            Assert.IsInstanceOf<PlayerOnChatEvent>(commandEvent);
        }

        [Test]
        public void ProcessCommand_Message_RaisedServerEventContainsMessage()
        {
            var command = new AdminSayCommand("A Message", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);

            var commandEvent = handler.CommandEvents[0] as PlayerOnChatEvent;
            Assert.AreEqual("A Message", commandEvent.Message) ;
        }

        [Test]
        public void ProcessCommand_Message_RaisedServerEventSenderIsServer()
        {
            var command = new AdminSayCommand("A Message", new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);

            var commandEvent = handler.CommandEvents[0] as PlayerOnChatEvent;
            Assert.AreEqual("Server", commandEvent.SenderName );
        }

        [Test]
        public void ProcessCommand_Message_RaisedServerEventReciepientsSet()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.All);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);

            var commandEvent = handler.CommandEvents[0] as PlayerOnChatEvent;
            Assert.AreEqual( playerSubset, commandEvent.Receivers);
        }

        #endregion
    }
}
