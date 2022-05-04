using System;
using System.Collections.Generic;
using static Testlet.Enums;
using static Testlet.Constants;
using System.Linq;

namespace Testlet
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            ValidateParameters(testletId, items);
            TestletId = testletId;
            Items = items;
        }

        public List<Item> Randomize()
        {
            return Items;
        }

        private static void ValidateParameters(string testletId, List<Item> items)
        {
            if (testletId == null || items == null)
            {
                throw new ArgumentNullException("Wrong parameters, nulls not allowed.");
            }
            if (!ValidateNumberOfTypeItems(items, ItemTypeEnum.Operational, TotalOperationalItems))
            {
                throw new ArgumentException("The number of items of type Operational is not correct.");
            }
            if (!ValidateNumberOfTypeItems(items, ItemTypeEnum.Pretest, TotalPretestItems))
            {
                throw new ArgumentException("The number of items of type Pretest is not correct.");
            }
        }

        private static bool ValidateNumberOfTypeItems(List<Item> items, ItemTypeEnum itemType, int total)
        {
            var result = true;
            result = items.Count(x => x.ItemType == itemType) == total;
            return result;
        }
    }
}
