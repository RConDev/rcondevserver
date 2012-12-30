using RConDevServer.Core;
using RConDevServer.Protocol.Interface;

namespace BF3DevServer.Core.Tests
{
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class SessionTest
    {
        public const int DEFAULT_PORT = 11000;
        public const string DEFAULT_HOST = "127.0.0.1";

        private ServerInstance serverInstance;
        
        private Socket socket;

        private Session session;

        [TestFixtureSetUp]
        public void TestSetup()
        {
            serverInstance = new ServerInstance(DEFAULT_PORT, 2);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverInstance.ClientConnected += (sender, args) => session = (Session) args.Session;
            serverInstance.Start();
            socket.Connect(DEFAULT_HOST, DEFAULT_PORT);
            while (session == null)
            {
                Thread.Sleep(10);
            }
            Assert.IsNotNull(session);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (socket != null)
            {
                socket.Close();
            }
            socket = null;
            serverInstance.Stop();
        }

        [Test]
        public void SessionReceivesDataFromServerInstance()
        {
            byte[] bytes = null;
            session.DataReceived += (sender, args) => bytes = args.ByteData;
            session.WaitForData(session.Socket);
            socket.Send(Encoding.Default.GetBytes("Test"));
            while(bytes == null)
            {
                Thread.Sleep(10);
            }
            Assert.IsNotNull(bytes);
            Assert.AreEqual("Test", Encoding.Default.GetString(bytes));
        }
    
        [Test]
        public void SessionCanSendDataToClient()
        {
            var expectedText = "TestText";
            byte[] bytesSent = null;
            session.DataSent += (sender, args) => bytesSent = args.ByteData;
            session.SendToClient(Encoding.Default.GetBytes(expectedText));
            while(bytesSent == null)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(expectedText, Encoding.Default.GetString(bytesSent));
        }
    }

}