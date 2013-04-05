using System.Collections.Generic;
using NUnit.Framework;
using RConDevServer.Protocol.Dice.Battlefield3;

namespace BF3DevServer.Core.Tests.CommandReceiver
{
    using RConDevServer.Core.Tests;
    using RConDevServer.Protocol.Dice.Common;

    [TestFixture]
    public class LoginPlainTextReceiverTest : ServerInstanceTestBase
    {
        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainTextHandlesCorrectPassword()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string> { "login.plainText", "test123" });
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            var receivedPacket = ReceivePacket();
            Assert.AreEqual("OK", receivedPacket.Words[0]);
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainTextHandlesIncorrectPassword()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string> { "login.plainText", "test" });
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            var receivedPacket = ReceivePacket();
            Assert.AreEqual("InvalidPassword", receivedPacket.Words[0]);
        }

        [Test]
        [Ignore("Too many dependencies")]
        public void LoginPlainTextHandlesPasswordNotSet()
        {
            var packet = new Packet(PacketOrigin.Client, false, 1, new List<string> { "login.plainText" });
            byte[] bytes = new PacketSerializer().Serialize(packet);
            Socket.Send(bytes);
            var receivedPacket = ReceivePacket();
            Assert.AreEqual("PasswordNotSet", receivedPacket.Words[0]);
        }
    }
}