namespace RConDevServer.Core.Tests
{
    using Core;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
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
            this.serverInstance = new ServerInstance(DEFAULT_PORT, 2);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.serverInstance.ClientConnected += (sender, args) => this.session = (Session) args.Session;
            this.serverInstance.Start();
            this.socket.Connect(DEFAULT_HOST, DEFAULT_PORT);
            while (this.session == null)
            {
                Thread.Sleep(10);
            }
            Assert.IsNotNull(this.session);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (this.socket != null)
            {
                this.socket.Close();
            }
            this.socket = null;
            this.serverInstance.Stop();
        }

        [Test]
        public void SessionReceivesDataFromServerInstance()
        {
            byte[] bytes = null;
            this.session.DataReceived += (sender, args) => bytes = args.ByteData;
            this.session.WaitForData(this.session.Socket);
            this.socket.Send(Encoding.Default.GetBytes("Test"));
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
            this.session.DataSent += (sender, args) => bytesSent = args.ByteData;
            this.session.SendToClient(Encoding.Default.GetBytes(expectedText));
            while(bytesSent == null)
            {
                Thread.Sleep(10);
            }
            Assert.AreEqual(expectedText, Encoding.Default.GetString(bytesSent));
        }
    }

}