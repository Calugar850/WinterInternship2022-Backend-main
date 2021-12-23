using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        DateTime date_of_write;
        List<Item> items;

        public Letter(DateTime date_of_write, List<Item> items)
        {
            Date_of_write = date_of_write;
            Items = items;
        }

        public DateTime Date_of_write { get; set; }

        public List<Item> Items { get; set; }

    }
}
