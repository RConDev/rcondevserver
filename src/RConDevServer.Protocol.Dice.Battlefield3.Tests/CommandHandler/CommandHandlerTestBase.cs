namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler
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
        protected Mock<IBattlefield3Server> ServerMock;
            
        [SetUp]
        public void TestSetup()
        {
            this.ServiceLocatorMock = new Mock<IServiceLocator>();
            this.PacketSessionMock = new Mock<IPacketSession>();
            this.ServerMock = new Mock<IBattlefield3Server>();

            // Setup the behaviour
            PacketSessionMock.SetupGet(x => x.Server).Returns(ServerMock.Object);
        }
    }
}