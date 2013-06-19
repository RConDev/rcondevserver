using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.BanList
{
    using Battlefield3.Data;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// base test class for all tests concerning the 
    /// CommandHandlers <see cref="RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandHandler.BanList"/>
    /// </summary>
    public class BanListCommandHandlerTestBase : CommandHandlerTestBase
    {
        protected Mock<IBanList> BanListMock;

        [SetUp]
        public void TestSetup()
        {
            this.BanListMock = new Mock<IBanList>();

            this.ServerMock.SetupGet(x => x.BanList).Returns(BanListMock.Object);
        }
    }
}
