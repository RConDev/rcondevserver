namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Collections.Generic;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AdminYellCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminYellCommandHandler handler;
        private Mock<IBattlefield3Server> serverMock;
        private Mock<IPlayerList> playerListMock;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            this.handler = new AdminYellCommandHandler();
            serverMock = new Mock<IBattlefield3Server>();
            PacketSessionMock.SetupGet(x => x.Server).Returns(this.serverMock.Object);

            this.playerListMock = new Mock<IPlayerList>();
            this.serverMock.SetupGet(x => x.PlayerList).Returns(this.playerListMock.Object);
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminYell()
        {
            Assert.AreEqual("admin.yell", handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_MessageToAll_OkResponse()
        {
            var command = new AdminYellCommand("a message", playerSubset: new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message255Chars_OkResponse()
        {
            var command = new AdminYellCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata", playerSubset: new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message256Chars_TooLongMessageResponse()
        {
            var command = new AdminYellCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimataa", playerSubset: new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<TooLongMessageResponse>(response);
        }

        [Test]
        public void ProcessCommand_Message257Chars_TooLongMessageResponse()
        {
            var command = new AdminYellCommand("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimataab", playerSubset: new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<TooLongMessageResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetTeamId1_OkResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: 1);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetTeamIdMinus1_InvalidTeamIdResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: -1);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetTeamId17_InvalidTeamIdResponse()
        {
            var playerSubset = new PlayerSubset(type: PlayerSubsetType.Team, teamId: 17);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadId1_OkResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: 1);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadIdMinus1_InvalidSquadIdResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: -1);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidSquadIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetSquadId33_InvalidSquadIdResponse()
        {
            var playerSubset = new PlayerSubset(PlayerSubsetType.Squad, squadId: 33);
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidSquadIdResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameEmptyList_PlayerNotFoundResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>());

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "unknownPlayer");
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameUnknown_PlayerNotFoundResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo> { new PlayerInfo() { Name = "Known" } });

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "unknownPlayer");
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
        }

        [Test]
        public void ProcessCommand_PlayerSubsetPlayerNameKnown_OkResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo> { new PlayerInfo() { Name = "Known" } });

            var playerSubset = new PlayerSubset(PlayerSubsetType.Player, playerName: "Known");
            var command = new AdminYellCommand("A Message", playerSubset: playerSubset);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);
        }

        #endregion
    }
}
