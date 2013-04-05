namespace RConDevServer.Core.Tests
{
    using Moq;
    using Core;
    using Protocol.Dice.Battlefield3;
    using Protocol.Dice.Battlefield3.DataStore;
    using Protocol.Interface;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using NUnit.Framework;
    using RConDevServer.Protocol.Dice.Common;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PacketSessionTest
    {
        private Mock<IServiceLocator> serviceLocatorMock;
        private Mock<IDataContext> dataContextMock;
        private IPacketSerializer<IPacket> packetSerializer;

        [SetUp]
        public void Setup()
        {
            this.serviceLocatorMock = new Mock<IServiceLocator>();
            this.dataContextMock = new Mock<IDataContext>();
            this.serviceLocatorMock.Setup(x => x.GetService<IDataContext>()).Returns(this.dataContextMock.Object);
            this.packetSerializer = new PacketSerializer();
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void PacketSessionInvokesPacketReceivedOnSessionDataReceived()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string>() { "login.plainText", "myPassword" });
            var session = new Session();
            var packetSession = new PacketSession(session, new Battlefield3Server(this.serviceLocatorMock.Object));

            Packet packetReceived = null;
            packetSession.PacketReceived += (sender, args) =>
                                                {
                                                    packetReceived = args.PacketData;
                                                };

            session.InvokeDataReceived(this.packetSerializer.Serialize(packet));
            while(packetReceived == null)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(packet, packetReceived);
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void PacketSessionInvokesPacketSentOnSessionDataSent()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string>() { "login.plainText", "myPassword" });
            var session = new Session();
            var packetSession = new PacketSession(session, new Battlefield3Server(this.serviceLocatorMock.Object));

            Packet packetSent = null;
            packetSession.PacketSent += (sender, args) =>
                                            {
                                                packetSent = args.PacketData;
                                            };

            session.InvokeDataSent(this.packetSerializer.Serialize(packet));
            while (packetSent == null)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(packet, packetSent);
        }
    
        [Test]
        public void PacketSessionDisposesWrappedSession()
        {

        }

        [Test]
        public void PacketSessionPacketSequenceGrowing()
        {
            var packetSequence = new PacketSequence();
            var id = packetSequence.CurrentSequenceId;
            Assert.Greater(packetSequence.NextSequenceId, id);
        }
    }
}