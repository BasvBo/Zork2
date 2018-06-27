using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Room
    {

        public Room(int roomNumber, string textField, int[] nextRoom)
        {
            RoomNumber = roomNumber;
            TextField = textField;
            NextRoom = nextRoom;
        }

        public int RoomNumber { get; set; }

        public string TextField { get; set; }

        public int[] NextRoom { get; set; }

      //  public List<string> Options { get; set; }
        
    }
}