using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;
using Zork2.Repository;

namespace Zork2.Utils
{
    public class Command
    {

        Initialisation initialisation = new Initialisation();
        PlayerRepository playerRepository = new PlayerRepository();
        RoomRepository roomRepository = new RoomRepository();



        public string CheckCommand(string input,string playerId)
        {
            // search if input is a room namen
            if (roomRepository.IsRoomName(input))
            {
                return "Room";
            }

            var currentLocation = playerRepository.GetPlayerLocation(playerId);
            if (roomRepository.IsPickupItem(input, currentLocation))
            {
                return "Item";
            }

            /*
            var invatory = (playerRepository.GetInvatory(playerId)).Split(';');
            foreach(var element in invatory)
            {
                if (input == element)
                {
                    return "invatoryItem";
                }
            }
            */
            return "This is not a command";
        }

    
        public string NextRoom(string input, string playerId)
        {
            var roomNumber = roomRepository.GetIdByName(input);
            int playerIntId = playerRepository.GetPlayerById(playerId);

            //if input is same room
            if (input == roomRepository.GetRoomName(playerRepository.GetPlayerLocation(playerId)))
            {
                return "You are already there";
            }
            //if input is final room 
            else if (input == roomRepository.GetRoomName(roomRepository.GetLastRoomId()))
            {
                playerRepository.SetPlayerLocation(playerIntId, roomNumber);
                return "you are a loser baby so why don't you kill me";
            }


            //set location player to new room and return next posible rooms
            playerRepository.SetPlayerLocation(playerIntId, roomNumber);
            return "where to next? -> "+ NextPosibleRoom(roomNumber);

        }


        //check if it is posible to step to the room from current location
        // using room name as input and player id for currend location
        public bool CanStapToRoom(string input, string id)
        {

            var adjecentRooms = roomRepository.GetAdjecentRooms(playerRepository.GetPlayerLocation(id));

            foreach (int element in adjecentRooms)
            {
                if (input == roomRepository.GetRoomName(element))
                {
                    return true;
                }
            }
            return false;
        }


        //input currend room number
        //output adjecent room names
        public string NextPosibleRoom(int roomId)
        {
            string roomNames = "";

            int[] roomIndex = roomRepository.GetAdjecentRooms(roomId);

            foreach (int element in roomIndex)
            {
                roomNames += roomRepository.GetRoomName(element) + ", ";
            }
            return roomNames;
        }

    }
}