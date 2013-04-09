namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Collections.Generic;
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
    public class AdminKillPlayerCommandHandlerTest : CommandHandlerTestBase
    {
        private AdminKillPlayerCommandHandler handler;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            handler = new AdminKillPlayerCommandHandler();
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminKillPlayer()
        {
            Assert.AreEqual(CommandNames.AdminKillPlayer, this.handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_EmptyPlayerList_ResponsePlayerNotFound()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);
            
            var playerListMock = new Mock<IPlayerList>();
            battlefield3ServerMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>());

            var command = new AdminKillPlayerCommand("A Player");
            var response = handler.ProcessCommand(command, this.PacketSessionMock.Object);

            Assert.IsInstanceOf<InvalidPlayerNameResponse>(response);
            this.PacketSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_ExistingPlayerName_ResponseOk()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);

            var playerListMock = new Mock<IPlayerList>();
            battlefield3ServerMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            playerListMock.SetupGet(x => x.Players)
                          .Returns(new List<PlayerInfo>
                              {
                                  new PlayerInfo
                                      {
                                          Name = "TestPlayer"
                                      }
                              });

            var command = new AdminKillPlayerCommand("TestPlayer");
            var response = handler.ProcessCommand(command, this.PacketSessionMock.Object);

            Assert.IsInstanceOf<OkResponse>(response);
            this.PacketSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_NotExistingPlayerName_ResponsePlayerNotFound()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            this.PacketSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);

            var playerListMock = new Mock<IPlayerList>();
            battlefield3ServerMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            playerListMock.SetupGet(x => x.Players)
                          .Returns(new List<PlayerInfo>
                              {
                                  new PlayerInfo
                                      {
                                          Name = "TestPlayer"
                                      }
                              });

            var command = new AdminKillPlayerCommand("A Player");
            var response = handler.ProcessCommand(command, this.PacketSessionMock.Object);

            Assert.IsInstanceOf<InvalidPlayerNameResponse>(response);
            this.PacketSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        #endregion
    }
}
