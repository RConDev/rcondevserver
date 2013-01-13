using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Moq;
using NUnit.Framework;
using RConDevServer.Protocol.Dice.Battlefield3;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Punkbuster;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server;
using RConDevServer.Protocol.Interface;
using RConDevServer.Util;

namespace RConDevServer.Core.Tests
{
    using Protocol.Dice.Battlefield3.Data;
    using Protocol.Dice.Battlefield3.EventSender;

    //[TestFixture]
    public class EventSenderTest
    {
        private Mock<IServiceLocator> serviceLocatorMock;
        private IList<ICanSendEvents> eventSenders;
        private Battlefield3Server server;
        private Session session;

        [TestFixtureSetUp]
        public void LoadEventSenders()
        {
            this.serviceLocatorMock = new Mock<IServiceLocator>();
            this.serviceLocatorMock.Setup(x => x.GetService<IServiceLocator>()).Returns(this.serviceLocatorMock.Object);
            this.server = new Battlefield3Server(serviceLocatorMock.Object);
            this.eventSenders = Utilities.LoadClassesFromDirectory<ICanSendEvents>(AppDomain.CurrentDomain.BaseDirectory);
        }

        private IEnumerable<string> GenerateParameters(ICanSendEvents canSendEvents)
        {
            var parameters = new List<string>();
            Type type = canSendEvents.GetType();

            if (type == typeof (PlayerOnAuthenticatedEventSender))
            {
                parameters.Add("Player1");
            }
            else if (type == typeof (PlayerOnChatEventSender))
            {
                parameters.Add("Player1");
                parameters.Add("Test");
                parameters.Add("all");
            }
            else if (type == typeof (PlayerOnJoinEventSender))
            {
                parameters.Add("Player1");
                parameters.Add(new Guid().ToString());
            }
            else if (type == typeof (PlayerOnKillEventSender))
            {
                parameters.Add("Player1");
                parameters.Add("Player2");
                parameters.Add("Gun");
                parameters.Add("False");
            }
            else if (type == typeof (PlayerOnLeaveEventSender))
            {
                parameters.Add("Player1");
                parameters.Add(new Guid().ToString());
                parameters.Add("1");
                parameters.Add("2");
                parameters.Add("3");
                parameters.Add("4");
                parameters.Add("5");
            }
            else if (type == typeof (PlayerOnSpawnEventSender))
            {
                parameters.Add("Player1");
                parameters.Add("1");
            }
            else if (type == typeof (PlayerOnSquadChangeEventSender))
            {
                parameters.Add("Player1");
                parameters.Add("1");
                parameters.Add("2");
            }
            else if (type == typeof (PlayerOnTeamChangeEventSender))
            {
                parameters.Add("Player1");
                parameters.Add("1");
                parameters.Add("2");
            }
            else if (type == typeof (PunkbusterOnMessageEventSender))
            {
                parameters.Add("Test");
            }
            else if (type == typeof (ServerOnLevelLoadedEventSender))
            {
                parameters.Add("MP_001");
                parameters.Add("ConquestLarge0");
                parameters.Add("1");
                parameters.Add("2");
            }
            else if (type == typeof (ServerOnRoundOverEventSender))
            {
                parameters.Add("1");
            }

            return parameters;
        }

        [Test]
        public void ServerEventRaised()
        {
            int counter = 0;
            int eventSenderCounter = 0;

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 8888));
            socket.Connect(new IPEndPoint(IPAddress.Loopback, 8888));

            this.session = new Session(socket);
            this.session.DataSent += (s, e) => { counter++; };
            this.server.OnClientConnected(this, new ClientEventArgs(this.session));

            foreach (ICanSendEvents canSendEvents in this.eventSenders)
            {
                IEnumerable<string> parameters = this.GenerateParameters(canSendEvents);
                if (canSendEvents.SetParameters(parameters) == false)
                    continue;

                eventSenderCounter++;
                canSendEvents.Send(this.server);
            }

            Assert.AreEqual(eventSenderCounter, counter);
            Assert.AreEqual(this.eventSenders.Count, counter);
        }

        [Test]
        public void SetParameters()
        {
            foreach (ICanSendEvents canSendEvents in this.eventSenders)
            {
                IEnumerable<string> parameters = this.GenerateParameters(canSendEvents);
                Assert.IsTrue(canSendEvents.SetParameters(parameters));
            }
        }

        [Test]
        public void SetParametersFail()
        {
            foreach (ICanSendEvents canSendEvents in this.eventSenders)
            {
                var parameters = new List<string>();
                Assert.IsFalse(canSendEvents.SetParameters(parameters));
            }
        }

        [Test]
        public void PlayerSendMessageToTeam()
        {
            var playerOnChatEventSender = new PlayerOnChatEventSender();
            var parameters = new[] { "Player1", "Test", "team","1" };
            playerOnChatEventSender.SetParameters(parameters);

            Assert.AreEqual(playerOnChatEventSender.PlayerSubset.Type, PlayerSubsetType.Team);
        }

        [Test]
        public void PlayerSendMessageToPlayer()
        {
            var playerOnChatEventSender = new PlayerOnChatEventSender();
            var parameters = new[] { "Player1", "Test", "player", "Player2" };
            playerOnChatEventSender.SetParameters(parameters);

            Assert.AreEqual(playerOnChatEventSender.PlayerSubset.Type, PlayerSubsetType.Player);
        }

        [Test]
        public void PlayerSendMessageToAll()
        {
            var playerOnChatEventSender = new PlayerOnChatEventSender();
            var parameters = new[] { "Player1", "Test", "all" };
            playerOnChatEventSender.SetParameters(parameters);

            Assert.AreEqual(playerOnChatEventSender.PlayerSubset.Type, PlayerSubsetType.All);
        }

        [Test]
        public void PlayerSendMessageToSquad()
        {
            var playerOnChatEventSender = new PlayerOnChatEventSender();
            var parameters = new[] {"Player1", "Test", "squad", "1", "2"};
            playerOnChatEventSender.SetParameters(parameters);

            Assert.AreEqual(playerOnChatEventSender.PlayerSubset.Type, PlayerSubsetType.Squad);
        }
    }
}