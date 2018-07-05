using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Room
    {
        public Room() { }

        public Room(int roomNumber, string roomName, string adjacentRoom)
        {
            RoomNumber = roomNumber;
            RoomName = roomName;
            AdjacentRoom = adjacentRoom;
        }



        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string AdjacentRoom { get; set; }



    }
}