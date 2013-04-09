using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminMovePlayerCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminMovePlayerCommandHandler handler;
        private Mock<IBattlefield3Server> serverMock;
        private Mock<IPlayerList> playerListMock;

        #region Setup()

        [SetUp]
        public void TestSetup()
        {
            handler = new AdminMovePlayerCommandHandler();

            this.serverMock = new Mock<IBattlefield3Server>();
            PacketSessionMock.SetupGet(x => x.Server).Returns(this.serverMock.Object);

            this.playerListMock = new Mock<IPlayerList>();
            this.serverMock.SetupGet(x => x.PlayerList).Returns(this.playerListMock.Object);
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminMovePlayer()
        {
            Assert.AreEqual(CommandNames.AdminMovePlayer, handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_WithEmptyPlayerList_InvalidPlayerNameResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>());

            var command = new AdminMovePlayerCommand("Nobody", 1, 1, false);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidPlayerNameResponse>(response);

            playerListMock.VerifyAll();
            serverMock.VerifyAll();
            PacketSessionMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_WithExistingPlayerList_OkResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>
                {
                    new PlayerInfo {Name = "Nobody"}
                });

            var command = new AdminMovePlayerCommand("Nobody", 1, 1, false);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<OkResponse>(response);

            playerListMock.VerifyAll();
            serverMock.VerifyAll();
            PacketSessionMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_WithExistingPlayerListTeamId3_InvalidTeamIdResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>
                {
                    new PlayerInfo {Name = "Nobody"}
                });

            var command = new AdminMovePlayerCommand("Nobody", 3, 1, false);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);

            playerListMock.VerifyAll();
            serverMock.VerifyAll();
            PacketSessionMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_WithExistingPlayerListTeamIdMinus1_InvalidTeamIdResponse()
        {
            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>
                {
                    new PlayerInfo {Name = "Nobody"}
                });

            var command = new AdminMovePlayerCommand("Nobody", -1, 1, false);
            var response = handler.ProcessCommand(command, PacketSessionMock.Object);
            Assert.IsInstanceOf<InvalidTeamIdResponse>(response);

            playerListMock.VerifyAll();
            serverMock.VerifyAll();
            PacketSessionMock.VerifyAll();
        }

        #endregion
    }
}
