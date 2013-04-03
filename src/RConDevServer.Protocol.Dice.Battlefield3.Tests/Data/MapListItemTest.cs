using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Data
{
    using System.Diagnostics.CodeAnalysis;
    using Battlefield3.Data;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MapListItemTest
    {
        #region ToDataString

        [Test]
        public void ToDataString_WithItem_ReturnsDataString()
        {
            var mapListItem = new MapListStoreItem
                {
                    MapCode =  "123", 
                    GameModeCode  = "456" , 
                    Rounds = "6"
                };
            Assert.AreEqual("123;456;6", mapListItem.ToDataString());
        }

        #endregion

        #region FromDataString

        [Test]
        public void FromDataString_WithDataStringItem_ReturnsItem()
        {
            var dataString = "123;456;6";
            var item = MapListStoreItem.FromDataString(dataString);
            Assert.AreEqual("123", item.MapCode);
            Assert.AreEqual("456", item.GameModeCode);
            Assert.AreEqual("6", item.Rounds);
        }

        #endregion
    }
}
