using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.CommandResponse
{
    using Battlefield3.CommandResponse;
    using NUnit.Framework;

    [TestFixture]
    public class InvalidSquadIdResponseTest
    {
        #region TestSetup
        #endregion

        #region ResponseName

        [Test]
        public void ResponseName_InvalidSquadId()
        {
            Assert.AreEqual("InvalidSquadId", new InvalidSquadIdResponse().ResponseName);
        }

        #endregion
    }
}
