﻿namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Collections.Generic;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Event.Player;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AdminSayCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminSayCommandHandler handler;
        private Mock<IBattlefield3Server> serverMock;
        private Mock<IPlayerList> playerListMock;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            handler = new AdminSayCommandHandler();
            serverMock = new Mock<IBattlefield3Server>(); 
            PacketSessionMock.SetupGet(x => x.Server).Returns(this.serverMock.Object);

            this.playerListMock = new Mock<IPlayerList>();
            this.serverMock.SetupGet(x => x.PlayerList).Returns(this.playerListMock.Object);
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

        [Test]
        public void ProcessCommand_PlayerSubsetTeamId1_OkResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: 1);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetTeamIdMinus1_InvalidTeamIdResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: -1);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetTeamId17_InvalidTeamIdResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: 17);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadId1_OkResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: 1);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadIdMinus1_InvalidSquadIdResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: -1);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidSquadIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadId33_InvalidSquadIdResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: 33);
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidSquadIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameEmptyList_PlayerNotFoundResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>());

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "unknownPlayer");
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameUnknown_PlayerNotFoundResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>{new PlayerInfo(){Name = "Known"}});

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "unknownPlayer");
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameKnown_OkResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo> { new PlayerInfo() { Name = "Known" } });

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "Known");
            var command = new AdminSayCommand("A Message", playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        #endregion
    }
}
