using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Room
    {
<<<<<<< HEAD
        private int RoomNumber { get; set; }
=======
        public Room(int roomNumber, string textField, int[] nextRoom)
        {
            RoomNumber = roomNumber;
            TextField = textField;
            this.nextRoom = nextRoom;
        }

        public int RoomNumber { get; set; }
>>>>>>> master

        public string TextField { get; set; }

        public int[] nextRoom { get; set; }

        public List<string> Options { get; set; }
        




        // maak functie voor add List to Room
    }
}