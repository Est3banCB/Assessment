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
            var random = new Random();

            var pretest = Items.Where(x => x.ItemType == ItemTypeEnum.Pretest)
                                      .Select(x => new Item
                                      {
                                          ItemId = x.ItemId,
                                          ItemType = x.ItemType,
                                      }).ToList();

            var leftover = Items.Where(x => x.ItemType == ItemTypeEnum.Operational)
                                       .Select(x => new Item
                                       {
                                           ItemId = x.ItemId,
                                           ItemType = x.ItemType,
                                       }).ToList();

            var @return = new List<Item>();

            int index;

            for (var i = 1; i <= TotalInitialPretestItems; i++)
            {
                index = random.Next(pretest.Count() - 1);
                @return.Add(pretest[index]);
                pretest.RemoveAt(index);
            }

            leftover.AddRange(pretest);

            while (leftover.Count() - 1 >= 0)
            {
                index = random.Next(leftover.Count() - 1);
                @return.Add(leftover[index]);
                leftover.RemoveAt(index);
            }

            return @return;
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
