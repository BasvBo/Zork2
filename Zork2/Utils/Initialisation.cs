using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Controllers;
using Zork2.Models;
using Zork2.Repository;

namespace Zork2.Utils
{
    public class Initialisation: PlayerRepository
    {

        RoomRepository roomRepository = new RoomRepository();
        List<Room> roomList = new List<Room>();



        public string PlayerSetup(string input, string id)
        {
            if (input == null)
            {
                return "Pleas Type in your Name";
            }
            else
            {
                CreatPlayer(input, id);
                BuildRooms();
                return "set"; 
            }
            
        }


        public void BuildRooms()
        {
            roomList.Add(new Room(1,    "start",    "2;3;4"));
            roomList.Add(new Room(2,    "boom",     "1;3;4"));
            roomList.Add(new Room(3,    "huis",     "1;2;4"));
            roomList.Add(new Room(4,    "bos",      "2;3;5"));
            roomList.Add(new Room(5,    "kat",      "4;6"));
            roomList.Add(new Room(6,    "sloot",    "5;7;8"));
            roomList.Add(new Room(7,    "berg",     "6;9"));
            roomList.Add(new Room(8,    "put",      "6;9"));
            roomList.Add(new Room(9,    "strand",   "8;7;10"));
            roomList.Add(new Room(10,   "einde",    "9"));

            //if rooms already saved don't add to db
            if (roomRepository.GetLastRoomId() == 0)
            {
                foreach (var element in roomList)
                {
                    roomRepository.CreatRoom(element.RoomNumber, element.RoomName, element.AdjacentRoom);

                }
            }
        }


    }
}