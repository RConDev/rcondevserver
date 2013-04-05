namespace RConDevServer.Core.Tests
{
    using System.Linq;
    using System.Net.Sockets;
    using System.Threading;
    using NUnit.Framework;
    using Core;
    using Protocol.Dice.Battlefield3;
    using System.Diagnostics.CodeAnalysis;
    using Protocol.Dice.Common;

    [ExcludeFromCodeCoverage]
    public class ServerInstanceTestBase
    {
        protected ServerInstance SocketServer;

        protected Battlefield3Server ServerInstance;

        protected PacketSession Session;

        protected Socket Socket;

        [SetUp]
        public void TestSetup()
        {
            this.SocketServer = new ServerInstance(11000, 1);
            var protocol = new Battlefield3Protocol() {Bf3Server = {Password = "test123"}};
            this.SocketServer.SetProtocol(protocol);

            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.ServerInstance = protocol.Bf3Server;
            this.Session = this.Connect();
            this.Session.StartReceiving();
        }

        [TearDown]
        public void TestCleanUp()
        {
            if (this.Socket != null)
            {
                this.Socket.Close();
                this.Socket = null;
            }
            if (this.Session != null)
            {
                this.Session = null;
            }
            if (this.ServerInstance != null)
            {
                this.SocketServer.Stop();
                this.SocketServer = null;
            }
        }

        #region Protocted Methods

        protected Packet ReceivePacket()
        {
            var received = new byte[1024];
            Packet receivedPacket = null;
            var sessionBuffer = new SessionBuffer(null, this.Socket, received);
            this.Socket.BeginReceive(sessionBuffer.Buffer, 0, sessionBuffer.Buffer.Length, SocketFlags.None,
                                (asyncResult) =>
                                    {
                                        var buffer =
                                            asyncResult.
                                                AsyncState as
                                            SessionBuffer;
                                        if (buffer == null) return;
                                        int bytesReceived = buffer.Socket.EndReceive(asyncResult);

                                        receivedPacket = new PacketSerializer().Deserialize(
                                            buffer.Buffer.Take(bytesReceived).
                                                ToArray()).FirstOrDefault();
                                    }, sessionBuffer);

            while (receivedPacket == null)
            {
                Thread.Sleep(10);
            }
            return receivedPacket;
        }

        protected PacketSession Connect()
        {
            PacketSession packetSession = null;
            this.ServerInstance.ClientConnected += (sender, args) => packetSession = args.PacketSession;
            this.SocketServer.Start();
            this.Socket.Connect("localhost", 11000);
            while (packetSession == null)
            {
                Thread.Sleep(10);
            }
            return packetSession;
        }

        #endregion
    }
}