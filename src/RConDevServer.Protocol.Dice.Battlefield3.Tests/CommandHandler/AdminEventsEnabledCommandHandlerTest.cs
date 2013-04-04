using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler
{
    using System.Diagnostics.CodeAnalysis;
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

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_WithValueCommand_OkResponse()
        {
            var command = new AdminEventsEnabledCommand(true);
            var response = handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<OkResponse>(response);
        }

        [Test]
        public void ProcessCommand_WithTrueValueCommand_IsEventsEnabledIsSetToTrue()
        {
            packetSessionMock.SetupSet(x => x.IsEventsEnabled = true).Verifiable();

            var command = new AdminEventsEnabledCommand(true);
            var response = handler.ProcessCommand(command, this.packetSessionMock.Object);

            packetSessionMock.VerifyAll();
        }

        [Test]
        public void ProcessCommand_WithoutValueCommand_BooleanOkResponse()
        {
            packetSessionMock.Setup(x => x.IsEventsEnabled).Returns(true);

            var command = new AdminEventsEnabledCommand();
            var response = handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<BooleanOkResponse>(response);
        }

        [Test]
        public void ProcessCommand_WithoutValueCommand_BooleanOkResponseValueTrue()
        {
            packetSessionMock.Setup(x => x.IsEventsEnabled).Returns(true);

            var command = new AdminEventsEnabledCommand();
            var response = handler.ProcessCommand(command, this.packetSessionMock.Object);

            Assert.IsInstanceOf<BooleanOkResponse>(response);
            Assert.IsTrue(((BooleanOkResponse)response).Value);
        }

        #endregion
    }
}
