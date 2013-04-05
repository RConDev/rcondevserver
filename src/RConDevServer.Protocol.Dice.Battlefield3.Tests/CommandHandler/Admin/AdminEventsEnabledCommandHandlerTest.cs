namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Command;
    using Battlefield3.Command.Admin;
    using Battlefield3.CommandHandler.Admin;
    using Battlefield3.CommandResponse;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminEventsEnabledCommandHandlerTest
    {
        private AdminEventsEnabledCommandHandler handler;
        private Mock<IPacketSession> packetSessionMock;

        #region Setup

        [SetUp]
        public void SetupTest()
        {
            this.handler = new AdminEventsEnabledCommandHandler();
            this.packetSessionMock = new Mock<IPacketSession>();
        }

        #endregion

        #region Command

        [Test]
        public void Command_AdminEventsEnabled()
        {
            Assert.AreEqual(CommandNames.AdminEventsEnabled, this.handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_WithValueCommand_OkResponse()
        {
            var command = new AdminEventsEnabledCommand(true);
            var response = this.handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_WithTrueValueCommand_IsEventsEnabledIsSetToTrue()
        {
            this.packetSessionMock.SetupSet(x => x.IsEventsEnabled = true).Verifiable();

            var command = new AdminEventsEnabledCommand(true);
            this.handler.ProcessCommand(command, this.packetSessionMock.Object);

            this.packetSessionMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_WithoutValueCommand_BooleanOkResponse()
        {
            this.packetSessionMock.Setup(x => x.IsEventsEnabled).Returns(true);

            var command = new AdminEventsEnabledCommand();
            var response = this.handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<BooleanOkResponse>(response);
        }

        [Test]
        public void ProcessCommand_WithoutValueCommand_BooleanOkResponseValueTrue()
        {
            this.packetSessionMock.Setup(x => x.IsEventsEnabled).Returns(true);

            var command = new AdminEventsEnabledCommand();
            var response = this.handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<BooleanOkResponse>(response);
            Assert.IsTrue(((BooleanOkResponse)response).Value);
        }

        #endregion
    }
}
