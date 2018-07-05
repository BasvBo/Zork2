using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Item
    {

        public Item() { }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        


    }
}