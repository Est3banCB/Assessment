using System;
using System.Collections.Generic;

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
            if (testletId == null)
            {
                throw new ArgumentNullException("Wrong parameters, nulls not allowed.");
            }
        }
    }
}
