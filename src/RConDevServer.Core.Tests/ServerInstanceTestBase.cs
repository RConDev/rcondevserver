using System.Linq;
using System.Net.Sockets;
using System.Threading;
using NUnit.Framework;
using RConDevServer.Core;
using RConDevServer.Protocol.Dice.Battlefield3;

namespace BF3DevServer.Core.Tests
{
    public class ServerInstanceTestBase
    {
        protected ServerInstance SocketServer;

        protected Battlefield3Server ServerInstance;

        protected PacketSession Session;

        protected Socket Socket;

        [SetUp]
        public void TestSetup()
        {
            SocketServer = new ServerInstance(11000, 1);
            var protocol = new Battlefield3Protocol() {Bf3Server = {Password = "test123"}};
            SocketServer.SetProtocol(protocol);

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ServerInstance = protocol.Bf3Server;
            Session = Connect();
            Session.StartReceiving();
        }

        [TearDown]
        public void TestCleanUp()
        {
            if (Socket != null)
            {
                Socket.Close();
                Socket = null;
            }
            if (Session != null)
            {
                Session = null;
            }
            if (ServerInstance != null)
            {
                SocketServer.Stop();
                SocketServer = null;
            }
        }

        #region Protocted Methods

        protected Packet ReceivePacket()
        {
            var received = new byte[1024];
            Packet receivedPacket = null;
            var sessionBuffer = new SessionBuffer(null, Socket, received);
            Socket.BeginReceive(sessionBuffer.Buffer, 0, sessionBuffer.Buffer.Length, SocketFlags.None,
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
            ServerInstance.ClientConnected += (sender, args) => packetSession = args.PacketSession;
            SocketServer.Start();
            Socket.Connect("localhost", 11000);
            while (packetSession == null)
            {
                Thread.Sleep(10);
            }
            return packetSession;
        }

        #endregion
    }
}