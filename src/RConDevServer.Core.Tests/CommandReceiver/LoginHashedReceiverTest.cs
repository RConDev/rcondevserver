using System.Collections.Generic;
using NUnit.Framework;
using RConDevServer.Protocol.Dice.Battlefield3;

namespace BF3DevServer.Core.Tests.CommandReceiver
{
    using RConDevServer.Core.Tests;
    using RConDevServer.Protocol.Dice.Battlefield3.Util;
    using RConDevServer.Protocol.Dice.Common;

    [TestFixture]
    public class LoginHashedReceiverTest : ServerInstanceTestBase
    {
        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainHashedHandlesCorrectPasswordHash()
        {
            string correctPasswordHash = PasswordHashService.GeneratePasswordHash(HexConverterService.HashToByteArray(Session.HashValue), ServerInstance.Password);
            var packet = new Packet(PacketOrigin.Client, false, 1,
                                    new List<string> {"login.hashed", correctPasswordHash});
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            Packet receivedPacket = ReceivePacket();
            Assert.AreEqual(1, receivedPacket.Words.Count);
            Assert.AreEqual("OK", receivedPacket.Words[0]);
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainHashedHandlesIncorrectPasswordHash()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string> {"login.hashed", "test123"});
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            Packet receivedPacket = ReceivePacket();
            Assert.AreEqual(1, receivedPacket.Words.Count);
            Assert.AreEqual("InvalidPasswordHash", receivedPacket.Words[0]);
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainHashedHandlesReceivingHashValue()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string> {"login.hashed"});
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            Packet receivedPacket = ReceivePacket();
            Assert.AreEqual(2, receivedPacket.Words.Count);
            Assert.AreEqual("OK", receivedPacket.Words[0]);
            Assert.AreEqual(Session.HashValue, receivedPacket.Words[1]);
        }
    }
}