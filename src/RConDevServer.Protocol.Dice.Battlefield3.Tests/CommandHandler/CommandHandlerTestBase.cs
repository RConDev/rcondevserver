namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.Admin
{
    using System.Diagnostics.CodeAnalysis;
    using Interface;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class CommandHandlerTestBase
    {
        protected Mock<IServiceLocator> ServiceLocatorMock;
        protected Mock<IPacketSession> PacketSessionMock;

        [SetUp]
        public void TestSetup()
        {
            this.ServiceLocatorMock = new Mock<IServiceLocator>();
            this.PacketSessionMock = new Mock<IPacketSession>();
        }
    }
}