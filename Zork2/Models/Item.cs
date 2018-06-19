using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Item
    {


        private string Name { get; set; }
        private bool Used { get; set; }
        private int Number { get; set; }

        public Item(string name, bool used, int number)
        {
            Name = name;
            Used = used;
            Number = number;
        }
    }
}