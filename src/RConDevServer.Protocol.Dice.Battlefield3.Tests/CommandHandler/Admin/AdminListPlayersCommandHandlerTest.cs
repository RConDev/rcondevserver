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
    public class AdminListPlayersCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminListPlayersCommandHandler handler;
        private Mock<IBattlefield3Server> serverMock;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            this.serverMock = new Mock<IBattlefield3Server>();
            this.handler = new AdminListPlayersCommandHandler();
        }

        #endregion

        #region CommandName

        [Test]
        public void Command_AdminListPlayers()
        {
            Assert.AreEqual(CommandNames.AdminListPlayers, handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_Empty_PlayerListOkResponse()
        {
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(serverMock.Object);

            var command = new AdminListPlayersCommand(new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, this.PacketSessionMock.Object);
            Assert.IsInstanceOf<PlayerListOkResponse>(response);
        }

        [Test]
        public void ProcessCommand_Empty_ContainsPlayerList()
        {
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(serverMock.Object);
            var playerListMock = new Mock<IPlayerList>();
            serverMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            var command = new AdminListPlayersCommand(new PlayerSubset(PlayerSubsetType.All));
            var response =  handler.ProcessCommand(command, this.PacketSessionMock.Object);
            Assert.IsNotNull(((PlayerListOkResponse)response).PlayerList);
            Assert.AreEqual(playerListMock.Object, ((PlayerListOkResponse)response).PlayerList);
        }

        [Test]
        public void ProcessCommand_Empty_IncludeGuidTrue()
        {
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(serverMock.Object);
            var playerListMock = new Mock<IPlayerList>();
            serverMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            var command = new AdminListPlayersCommand(new PlayerSubset(PlayerSubsetType.All));
            var response = handler.ProcessCommand(command, this.PacketSessionMock.Object);
            Assert.IsTrue(((PlayerListOkResponse)response).IncludeGuid);
        }

        #endregion
    }
}
