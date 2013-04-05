namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Battlefield3.Data;
    using Interface;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminKickPlayerCommandHandlerTest
    {
        private readonly Mock<IServiceLocator> serviceLocatorMock = new Mock<IServiceLocator>();
        private AdminKickPlayerCommandHandler handler;
        private Mock<IPacketSession> packetSessionMock;

        #region Setup

        [SetUp]
        public void TestSetup()
        {
            handler = new AdminKickPlayerCommandHandler(this.serviceLocatorMock.Object);
            packetSessionMock = new Mock<IPacketSession>();
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminKickPlayer()
        {
            Assert.AreEqual(CommandNames.AdminKickPlayer, this.handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_EmptyPlayerList_ResponsePlayerNotFound()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            packetSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);
            
            var playerListMock = new Mock<IPlayerList>();
            battlefield3ServerMock.SetupGet(x => x.PlayerList).Returns(playerListMock.Object);

            playerListMock.SetupGet(x => x.Players).Returns(new List<PlayerInfo>());

            var command = new AdminKickPlayerCommand("A Player", "a reason");
            var response = handler.ProcessCommand(command, packetSessionMock.Object);

            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
            packetSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_NotExistingPlayerName_ResponsePlayerNotFound()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            packetSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);

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

            var command = new AdminKickPlayerCommand("A Player", "a reason");
            var response = handler.ProcessCommand(command, packetSessionMock.Object);

            Assert.IsInstanceOf<PlayerNotFoundResponse>(response);
            packetSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_ExistingPlayerName_ResponseOk()
        {
            var battlefield3ServerMock = new Mock<IBattlefield3Server>();
            packetSessionMock.SetupGet(x => x.Server).Returns(battlefield3ServerMock.Object);

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

            var command = new AdminKickPlayerCommand("TestPlayer", "a reason");
            var response = handler.ProcessCommand(command, packetSessionMock.Object);

            Assert.IsInstanceOf<OkResponse>(response);
            packetSessionMock.VerifyAll();
            battlefield3ServerMock.VerifyAll();
            playerListMock.VerifyAll();
        }

        #endregion
    }
}
