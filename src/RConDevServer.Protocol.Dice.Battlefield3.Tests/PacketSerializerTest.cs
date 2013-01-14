namespace RConDevServer.Protocol.Dice.Battlefield3.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using NUnit.Framework;

    /// <summary>
    ///This is a test class for Battlefield3PacketSerializerTest and is intended
    ///to contain all Battlefield3PacketSerializerTest Unit Tests
    ///</summary>
    [TestFixture]
    public class PacketSerializerTest
    {
        private IPacketSerializer<IPacket> serializer;

        #region Setup 

        [SetUp]
        public void TestSetup()
        {
            this.serializer = new PacketSerializer();
        }

        #endregion

        #region Deserialize Tests
        /// <summary>
        ///A test for Deserialize
        ///</summary>
        [Test]
        public void DeserializeServerOriginatedPacketTest()
        {
            var expectedPacket = new Packet(PacketOrigin.Server, false, 458, new List<string>() {"listPlayers", "all"});
            var packetBytes = Convert.FromBase64String("ygEAgCQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");
            var deserializedPackets = this.serializer.Deserialize(packetBytes).ToArray();
            Assert.AreEqual(expectedPacket, deserializedPackets[0], "Deserializing Server Packet not successful");
        }

        [Test]
        public void DeserializeServerOriginatedPacketResponseTest()
        {
            var expectedPacket = new Packet(PacketOrigin.Server, true, 458, new List<string>() { "OK", "21", "test" });
            var packetBytes = Convert.FromBase64String("ygEAwCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=");
            var deserializedPackets = this.serializer.Deserialize(packetBytes).ToArray();
            Assert.AreEqual(expectedPacket, deserializedPackets[0], "Deserializing Server Packet Response not successful");
        }

        [Test]
        public void DeserializeClientOriginatedPacketTest()
        {
            var expectedPacket = new Packet(PacketOrigin.Client, false, 458, new List<string>() { "OK", "21", "test" });
            var packetBytes = Convert.FromBase64String("ygEAACMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=");
            var deserializedPackets = this.serializer.Deserialize(packetBytes).ToArray();
            Assert.AreEqual(expectedPacket, deserializedPackets[0], "Deserializing Client Packet not successful");
        }

        [Test]
        public void DeserializeClientOriginatedResponsePacketTest()
        {
            var expectedPacket = new Packet(PacketOrigin.Client, true, 458, new List<string>() { "OK", "21", "test" });
            var packetBytes = Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=");
            var deserializedPackets = this.serializer.Deserialize(packetBytes);
            Assert.AreEqual(expectedPacket, deserializedPackets.ToArray()[0], "Deserializing Client Packet Response not successful");
        }

        [Test]
        public void DeserializeMultiplePacketsInBytes()
        {
            var expectedPacket = new Packet(PacketOrigin.Client, true, 458, new List<string>() { "OK", "21", "test" });
            var packetBytes = Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=").Concat(
                              Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=")).ToArray();
            var deserializedPackets = this.serializer.Deserialize(packetBytes).ToArray();
            Assert.AreEqual(2, deserializedPackets.Length);
            Assert.AreEqual(expectedPacket, deserializedPackets[0]);
            Assert.AreEqual(expectedPacket, deserializedPackets[1]);
        }
        #endregion

        #region Serialize Tests

        [Test]
        public void SerializeClientOriginatedPacketTest()
        {
            var packet = new Packet(PacketOrigin.Client, false, 458,
                                                new List<string>() {"listPlayers", "all"});
            var expectedBytes = Convert.FromBase64String("ygEAACQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");
            var packetBytes = this.serializer.Serialize(packet);
            Assert.IsTrue(expectedBytes.SequenceEqual(packetBytes), "<expected:{0}> <actual:{1}>", Convert.ToBase64String(expectedBytes),
                          Convert.ToBase64String(packetBytes));
        }

        [Test]
        public void SerializeClientOriginatedResponsePacketTest()
        {
            var packet = new Packet(PacketOrigin.Client, true, 458,
                                                new List<string>() { "OK", "test", "test", "sasadfsad" });
            var expectedBytes = Convert.FromBase64String("ygEAQDMAAAAEAAAAAgAAAE9LAAQAAAB0ZXN0AAQAAAB0ZXN0AAkAAABzYXNhZGZzYWQA");
            var packetBytes = this.serializer.Serialize(packet);
            Assert.IsTrue(expectedBytes.SequenceEqual(packetBytes), "<expected:{0}> <actual:{1}>", Convert.ToBase64String(expectedBytes),
                          Convert.ToBase64String(packetBytes));
        }

        [Test]
        public void SerializeServerOriginatedPacketTest()
        {
            var packet = new Packet(PacketOrigin.Server, false, 458,
                                                new List<string>() { "OK", "test", "test", "sasadfsad" });
            var expectedBytes = Convert.FromBase64String("ygEAgDMAAAAEAAAAAgAAAE9LAAQAAAB0ZXN0AAQAAAB0ZXN0AAkAAABzYXNhZGZzYWQA");
            var packetBytes = this.serializer.Serialize(packet);
            Assert.IsTrue(expectedBytes.SequenceEqual(packetBytes), "<expected:{0}> <actual:{1}>", Convert.ToBase64String(expectedBytes),
                          Convert.ToBase64String(packetBytes));
        }

        [Test]
        public void SerializeServerOriginatedResponsePacketTest()
        {
            var packet = new Packet(PacketOrigin.Server, true, 458,
                                                new List<string>() { "OK", "test", "test", "sasadfsad" });
            var expectedBytes = Convert.FromBase64String("ygEAwDMAAAAEAAAAAgAAAE9LAAQAAAB0ZXN0AAQAAAB0ZXN0AAkAAABzYXNhZGZzYWQA");
            var packetBytes = this.serializer.Serialize(packet);
            Assert.IsTrue(expectedBytes.SequenceEqual(packetBytes), "<expected:{0}> <actual:{1}>", Convert.ToBase64String(expectedBytes),
                          Convert.ToBase64String(packetBytes));
        }

        [Test]
        public void SerializeWithSequenceIdNotSet()
        {
            var packet = new Packet();
            var exception = Assert.Throws<ArgumentException>(() => this.serializer.Serialize(packet));
            Assert.AreEqual(exception.Message, "SequenceId may not be null");
        }

        #endregion
    }
}