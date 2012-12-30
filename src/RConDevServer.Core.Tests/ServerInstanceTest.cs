using RConDevServer.Core;

namespace BF3DevServer.Core.Tests
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ServerInstanceTest
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            serverInstance = new ServerInstance(DEFAULT_PORT, 2);
            socket = new TcpClient(AddressFamily.InterNetwork);
        }

        [TearDown]
        public void TearDown()
        {
            if (socket != null)
            {
                socket.Close();
            }
            socket = null;
            serverInstance.Stop();
        }

        #endregion

        public const int DEFAULT_PORT = 11000;
        public const string DEFAUL_HOST = "localhost";

        private ServerInstance serverInstance;
        private TcpClient socket;

        private static bool CanConnect(TcpClient socket)
        {
            try
            {
                socket.Connect("localhost", DEFAULT_PORT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return socket.Connected;
        }

        #region Client Connection Tests
        
        [Test]
        public void ServerInstanceMustBeStartedToConnect()
        {
            bool isConnected = CanConnect(socket);
            Assert.IsFalse(isConnected);

            serverInstance.Start();
            isConnected = CanConnect(socket);
            Assert.IsTrue(isConnected, "Connection failed after starting server");
        }

        [Test]
        public void ServerInstanceRaisesClientConnected()
        {
            bool isConnected = false;
            serverInstance.ClientConnected += (sender, eveArgs) => { isConnected = true; };
            serverInstance.Start();

            Assert.IsTrue(CanConnect(socket), "Connection to server socket failed");
            while(!isConnected)
            {
                Thread.Sleep(10);
            }
        }
        
        [Test]
        public void ServerInstanceCreatesSessionForClient()
        {
            bool isConnected = false;
            serverInstance.ClientConnected += (sender, args) => isConnected = true;
            serverInstance.Start();


            Assert.IsTrue(CanConnect(socket), "Connection to server socket failed");
            while(!isConnected)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(1, serverInstance.Sessions.Count); 
        }

        [Test]
        public void ServerInstanceRemovesClosedSession()
        {
            bool isConnected = false;
            Session clientIrConSession = null;
            serverInstance.ClientConnected += (sender, args) =>
                                                  {
                                                      isConnected = true;
                                                      clientIrConSession = (Session)args.Session;
                                                  };
            serverInstance.Start();
            socket.Connect(DEFAUL_HOST, DEFAULT_PORT);
            while(!isConnected)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(1, serverInstance.Sessions.Count);
            Assert.IsNotNull(clientIrConSession);

            bool isClosed = false;
            clientIrConSession.WaitForData(clientIrConSession.Socket);
            clientIrConSession.Closed += (sender, args) => isClosed = true;
            clientIrConSession.Dispose();

            while(!isClosed)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(0, serverInstance.Sessions.Count);
        } 

        [Test]
        public void ServerInstanceRaisesStoppedOnStop()
        {
            bool isStopped = false;
            serverInstance.Stopped += (sender, args) => isStopped = true;
            serverInstance.Start();
            serverInstance.Stop();
            while (!isStopped)
            {
                Thread.Sleep(10);
            }
            Assert.IsTrue(isStopped);
        }

        #endregion

        #region Client Communication Tests

        [Test]
        public void ServerInstanceCanSendToAllConnectedClients()
        {
            var syncRoot = new object();
            var syncRoot2 = new object();

            var sessions = new List<Session>();
            var bytesSent = new List<byte[]>();
            serverInstance.ClientConnected += (sender, args) =>
                                                  {
                                                      lock (syncRoot)
                                                      {
                                                          args.Session.DataSent += (sender2, args2) =>
                                                                                           {
                                                                                               lock(syncRoot2)
                                                                                               {
                                                                                                   bytesSent.Add(args2.ByteData);
                                                                                               }
                                                                                           };
                                                          sessions.Add((Session)args.Session);
                                                      }
                                                  };
            serverInstance.Start();
            
            var anotherSocket = new TcpClient(AddressFamily.InterNetwork);
            anotherSocket.Connect(DEFAUL_HOST, DEFAULT_PORT);
            Assert.IsTrue(anotherSocket.Connected, "AnotherSocket not connected");
            socket.Connect(DEFAUL_HOST, DEFAULT_PORT);
            Assert.IsTrue(anotherSocket.Connected, "Socket not connected");
            while(sessions.Count < 2)
            {
                Thread.Sleep(10);
            }
            var expectedText = "TestText";
            var bytes = Encoding.Default.GetBytes(expectedText);
            serverInstance.SendToClients(bytes);

            var socketBytes = ReceiveBytes(socket);
            var anotherSocketBytes = ReceiveBytes(anotherSocket);

            while (bytesSent.Count < 2)
            {
                Thread.Sleep(10);
            }

            Assert.AreEqual(expectedText, Encoding.Default.GetString(socketBytes));
            Assert.AreEqual(expectedText, Encoding.Default.GetString(anotherSocketBytes));

            anotherSocket.Close();
        }

        private byte[] ReceiveBytes(TcpClient socket)
        {
            var buffer = new byte[1024];
            var bytesRead = socket.Client.Receive(buffer, SocketFlags.None);
            var returnBytes = new byte[bytesRead];
            Array.Copy(buffer, 0, returnBytes,0,bytesRead);
            return returnBytes;
        }

        #endregion
    }
}