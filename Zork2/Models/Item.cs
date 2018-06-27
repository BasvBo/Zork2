using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Item
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Used { get; set; }
        public int Number { get; set; }

        public Item(string name, bool used, int number)
        {
            Name = name;
            Used = used;
            Number = number;
        }
    }
}