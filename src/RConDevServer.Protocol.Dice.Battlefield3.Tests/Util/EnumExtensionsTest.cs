namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Battlefield3.Util;
    using NUnit.Framework;

    [TestFixture]
    public class EnumExtensionsTest
    {
        #region ToDataSource()

        [Test]
        public void ToDataSource_WithIntTypeParameter_ThrowsArgumentExcetion()
        {
            Assert.Throws<ArgumentException>(() => EnumExtensions.ToDataSource<int>());
        }

        [Test]
        public void ToDataSource_WithDummyEnum_ReturnsListWithTwoItems()
        {
            var dataSource = EnumExtensions.ToDataSource<DummyEnum>();
            Assert.IsNotNull(dataSource);
            Assert.IsInstanceOf<IList<KeyValuePair<DummyEnum, string>>>(dataSource);
            Assert.AreEqual(2, dataSource.Count);
        }

        [Test]
        public void ToDataSource_WithDummyEnum_Item1IsCorrect()
        {
            var dataSource = EnumExtensions.ToDataSource<DummyEnum>();
            Assert.AreEqual(dataSource[0].Key, DummyEnum.Item1);
        }

        [Test]
        public void ToDataSource_WithDummyEnum_Item2IsCorrect()
        {
            var dataSource = EnumExtensions.ToDataSource<DummyEnum>();
            Assert.AreEqual(dataSource[1].Key, DummyEnum.Item2);
        }

        [Test]
        public void ToDataSource_WithDummyEnum_Item1IsCorrectNamed()
        {
            var dataSource = EnumExtensions.ToDataSource<DummyEnum>();
            Assert.AreEqual(dataSource[0].Value, "Item 1");
        }

        [Test]
        public void ToDataSource_WithDummyEnum_Item2IsCorrectNamed()
        {
            var dataSource = EnumExtensions.ToDataSource<DummyEnum>();
            Assert.AreEqual(dataSource[1].Value, "Item 2");
        }

        #endregion

        #region DummyEnum

        public enum DummyEnum
        {
            [Display(Name = "Item 1")]
            Item1,

            [Display(Name = "Item 2")]
            Item2
        }

        #endregion
    }
}
