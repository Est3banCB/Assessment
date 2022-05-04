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
    }
}