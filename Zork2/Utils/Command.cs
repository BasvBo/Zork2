using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;

namespace Zork2.Utils
{
    public class Command
    {



        public string CheckCommand(string input, List<Room> roomList)
        {
            if (input != null)
            {
                // search if input is a room namen
                foreach (Room element in roomList)
                {
                    if (input == element.TextField)
                    {
                        return "Room";
                    }
                }
            }
            return "This is not a command";
        }




        public string NextRoom(string input, List<Room> roomList, Player player)
        { 
            if (input == roomList[player.currentRoom].TextField)
            {
                return "You are already there";
            }
            else if (input == roomList[roomList.Count - 1].TextField)
            {
                return "you are a loser baby so why don't you kill me";
            }
            else if (CanStapToRoom(input, roomList,player))
            {
                foreach (Room element in roomList) //search for new room index and show next posible rooms
                {
                    if (input == element.TextField)
                    {
                        player.currentRoom = element.RoomNumber;
                        return "where to next? -> "+ NextPosibleRoom(element.RoomNumber, roomList);
                    }
                    
                }
            }
            else
            {
                return "this move is not legal";
            }
            return "";
        }



        private bool CanStapToRoom(string input, List<Room> roomList, Player player)
        {
            foreach (int element in roomList[player.currentRoom].nextRoom)
            {
                if (input == roomList[element].TextField)
                {
                    return true;
                }
            }
            return false;
        }




        public string NextPosibleRoom(int room, List<Room> roomList)
        {
            string roomName = "";

            int[] roomIndex = roomList[room].nextRoom;

            foreach (int element in roomIndex)
            {
                roomName += roomList[element].TextField + ", ";
            }
            return roomName;
        }
    }
}