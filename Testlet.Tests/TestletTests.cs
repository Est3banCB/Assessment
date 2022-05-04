using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Testlet.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InvalidParameterTestletId()
        {
            var newItem = new Item()
            {
                ItemId = Guid.NewGuid().ToString(),
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var lstItems = new List<Item>()
            {
                newItem
            };

            var expectedErrorMessage = "Value cannot be null. (Parameter 'Wrong parameters, nulls not allowed.')";
            var ex = Assert.Throws<ArgumentNullException>(() => new Testlet(null, lstItems));
            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }

        [Test]
        public void InvalidParameterItems()
        {
            var expectedErrorMessage = "Value cannot be null. (Parameter 'Wrong parameters, nulls not allowed.')";
            var ex = Assert.Throws<ArgumentNullException>(() => new Testlet(Guid.NewGuid().ToString(), null));
            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }

        [Test]
        public void InvalidNumberOfOperational()
        {
            var operational = new Item()
            {
                ItemId = Guid.NewGuid().ToString(),
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var pretest = new Item()
            {
                ItemId = Guid.NewGuid().ToString(),
                ItemType = Enums.ItemTypeEnum.Pretest
            };

            var lstItems = new List<Item>()
            {
                operational, pretest, pretest, pretest, pretest
            };

            var expectedErrorMessage = "The number of items of type Operational is not correct.";
            var ex = Assert.Throws<ArgumentException>(() => new Testlet(Guid.NewGuid().ToString(), lstItems));
            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }
    }
}