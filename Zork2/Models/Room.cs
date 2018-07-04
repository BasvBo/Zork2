using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Room
    {
        public Room() { }

        public Room(int roomNumber, string roomName, string adjacentRoom, string pickUpItems, string unlockItem)
        {
            RoomNumber = roomNumber;
            RoomName = roomName;
            AdjacentRoom = adjacentRoom;
            PickUpItems = pickUpItems;
            UnlockItem = unlockItem;
        }



        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string AdjacentRoom { get; set; }
        public string PickUpItems { get; set; }
        public string UnlockItem { get; set; }



    }
}