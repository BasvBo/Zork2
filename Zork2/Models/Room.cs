using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Room
    {
        private int RoomNumber { get; set; }

        public string TextField { get; set; }

        public List<string> Options { get; set; }


        public Room(int roomNumber, string textField, List<string> options)
        {
            RoomNumber = roomNumber;
            TextField = textField;
            Options = options;
        }
    }
}