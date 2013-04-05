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
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdminHelpCommandHandlerTest
    {
        private AdminHelpCommandHandler handler;

        private Mock<IPacketSession> packetSessionMock;

        [SetUp]
        public void SetupTest()
        {
            handler = new AdminHelpCommandHandler();
            packetSessionMock = new Mock<IPacketSession>();
        }

        #region Command

        [Test]
        public void Command_AdminHelp()
        {
            Assert.AreEqual(CommandNames.AdminHelp, handler.Command);
        }

        #endregion

        #region ProcessCommand()

        [Test]
        public void ProcessCommand_WithCommand_StringListOkResponse()
        {
            var command = new AdminHelpCommand();
            var response = this.handler.ProcessCommand(command, packetSessionMock.Object);

            Assert.IsInstanceOf<StringListOkResponse>(response);
        }

        [Test]
        public void ProcessCommand_WithCommand_OkCommandList()
        {
            var command = new AdminHelpCommand();
            var expected = new List<string> { ResponseNames.Ok };
            expected.AddRange(CommandNames.GetAll());

            var response = this.handler.ProcessCommand(command, packetSessionMock.Object);
            
            Assert.AreEqual(expected, response.ToWords());
        }

        #endregion
    }
}
