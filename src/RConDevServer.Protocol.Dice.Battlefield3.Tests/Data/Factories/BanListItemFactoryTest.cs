using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data.Factories
{
    using Battlefield3.Data;
    using Battlefield3.Data.Factories;
    using NUnit.Framework;

    [TestFixture]
    public class BanListItemFactoryTest
    {
        #region Create()

        [Test]
        public void Create_PlayerNameNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                BanListItemFactory.Create(IdType.Name, null, new Timeout(TimeoutType.Permanent)));
        }

        [Test]
        public void Create_TimeoutNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                BanListItemFactory.Create(IdType.Name, "PlayerName", null));
        }

        #endregion
    }
}
