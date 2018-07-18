using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;
using Zork2.Repository;
using Zork2.Resources;

namespace Zork2.Utils
{
    public class Command
    {

        PlayerRepository playerRepository = new PlayerRepository();
        RoomRepository roomRepository = new RoomRepository();

        public string CheckCommand(string input,string playerId)
        {
            // search if input is a room namen
            if (roomRepository.IsRoomName(input))
            {
                return "Room";
            }

            var inventory = (playerRepository.GetInventory(playerId)).Split(',');
            foreach (var element in inventory)
            {
                if (input == element)
                {
                    return "inventoryItem";
                }
            }

            var currentLocation = playerRepository.GetPlayerLocation(playerId);
            if (roomRepository.IsPickupItem(input, currentLocation))
            {
                return "Item";
            }
            

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
            else if (input == roomRepository.GetRoomName(roomRepository.GetSizeOfRoomDb()))
            {
                playerRepository.SetPlayerLocation(playerIntId, roomNumber);
                return "you are a loser baby so why don't you kill me";
            }


            //set location player to new room and return next posible rooms
            playerRepository.SetPlayerLocation(playerIntId, roomNumber);
            var roomDiscription = RoomStories.ResourceManager.GetString("Room" + roomNumber) + Environment.NewLine;
            return roomDiscription + "where to next? -> " + NextPosibleRoom(roomNumber);

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


        public string ChangeCommandTyp(string input, string userId)
        {
            var playerTableId = playerRepository.GetPlayerById(userId);
            var currendLocation = playerRepository.GetPlayerLocation(userId);

            switch (input)
            {
                case "location":
                    playerRepository.SetPlayerCommandState(input, playerTableId);
                    return ("Currend Location is -> " + roomRepository.GetRoomName(currendLocation));

                case "move":
                    playerRepository.SetPlayerCommandState(input, playerTableId);
                    var possibelmoves = NextPosibleRoom(currendLocation);

                    return ("possible movements are -> " + possibelmoves);

                case "pickup":
                    playerRepository.SetPlayerCommandState(input, playerTableId);
                    var possibleItems = roomRepository.GetPickupItems(currendLocation);
                    if (possibleItems[0] == "")
                        return ("There are no items to pick up");
                    return ("pickup items are -> " + string.Join(",", possibleItems));

                case "use":
                    playerRepository.SetPlayerCommandState(input, playerTableId);
                    return ("Your inventory is => " + playerRepository.GetInventory(userId));

                default:
                    return "Not valid Command Change Type";
            }
        }

        public string ValidateCommand(string input, string userId)
        {

            var currentComandState = playerRepository.GetPlayerCommandState(userId);
            string commandType = CheckCommand(input.ToLower(), userId);

            if (currentComandState == "move" && commandType == "Room")
            {
                return "Room";
            }

            if (currentComandState == "pickup" && commandType == "Item")
            {
                return "Item";
            }

            if (currentComandState == "use" && commandType == "inventoryItem")
            {
                return "Activate";
            }

            return "false";
        }


        public string UseCommand(string commandType, string input, string userId)
        {
            switch (commandType)
            {
                case "Room":
                    return MoveRoom(input.ToLower(), userId);

                case "Item":
                    return PickUpTheItem(input, userId);

                case "Activate":
                    playerRepository.SetActiveItem(userId, input);
                    return ("You are using => " + input);

                default:
                    return "Not a valid command";
            }

        }


        public string MoveRoom(string roomName, string userId)
        {
            bool itemIsActive = true;
            bool canMove = false;
            bool itemIsNeeded = true;

            canMove = CanStapToRoom(roomName, userId);
            itemIsNeeded = roomRepository.IsUnlockItemNeeded(roomName);

            if (itemIsNeeded)
            {
                var neededItem = roomRepository.GetUnlockItem(roomName);
                itemIsActive = playerRepository.IsItemActive(userId, neededItem);
            }

            if (canMove == true && itemIsActive == true)
            {
                playerRepository.SetActiveItem(userId, "");
                return NextRoom(roomName, userId);
            }


            if (itemIsActive == false)
                return "Item needed to continue";


            return "Can not move to this room";
        }


        public string PickUpTheItem(string input, string userId)
        {

            var playerIntId = playerRepository.GetPlayerById(userId);
            playerRepository.SetInventory(input, playerIntId);

            return ("You have picked up a -> " + input);
        }

    }
}