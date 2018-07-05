using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Item
    {

        public Item() { }

        public Item(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }


    }
}