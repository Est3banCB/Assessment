using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Testlet.Constants;
using static Testlet.Enums;

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

        [Test]
        public void InvalidNumberOfPretest()
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
                operational, operational, operational, operational, operational, operational,
                pretest
            };

            var expectedErrorMessage = "The number of items of type Pretest is not correct.";
            var ex = Assert.Throws<ArgumentException>(() => new Testlet(Guid.NewGuid().ToString(), lstItems));
            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }

        [Test]
        public void RandomizeWithTwoPretestsAtTheBeginning()
        {
            var operationalItem1 = new Item()
            {
                ItemId = "1",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var operationalItem2 = new Item()
            {
                ItemId = "2",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var operationalItem3 = new Item()
            {
                ItemId = "3",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var operationalItem4 = new Item()
            {
                ItemId = "4",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var operationalItem5 = new Item()
            {
                ItemId = "5",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var operationalItem6 = new Item()
            {
                ItemId = "6",
                ItemType = Enums.ItemTypeEnum.Operational
            };

            var pretestItem1 = new Item()
            {
                ItemId = "1",
                ItemType = Enums.ItemTypeEnum.Pretest
            };

            var pretestItem2 = new Item()
            {
                ItemId = "2",
                ItemType = Enums.ItemTypeEnum.Pretest
            };

            var pretestItem3 = new Item()
            {
                ItemId = "3",
                ItemType = Enums.ItemTypeEnum.Pretest
            };

            var pretestItem4 = new Item()
            {
                ItemId = "4",
                ItemType = Enums.ItemTypeEnum.Pretest
            };

            var lstItems = new List<Item>()
            {
                operationalItem1, operationalItem2, operationalItem3, operationalItem4, operationalItem5, operationalItem6,
                pretestItem1,  pretestItem2,  pretestItem3,  pretestItem4
            };
            var testlet = new Testlet(Guid.NewGuid().ToString(), lstItems);

            var resultRandomize = testlet.Randomize();

            var result = false;

            for (var i = 0; i <= TotalInitialPretestItems - 1; i++)
            {
                result = resultRandomize[i].ItemType == ItemTypeEnum.Pretest;
                if (!result) break;
            }
            if (result) result = resultRandomize.Count == TotalPretestItems + TotalOperationalItems;
            Assert.IsTrue(result);
        }
    }
}