using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;
using Zork2.Repository;
using Zork2.Utils;

namespace Zork2.Controllers
{
    public class CommandController
    {
        PlayerRepository playerRepository = new PlayerRepository();
        RoomRepository roomRepository = new RoomRepository();
        Command command = new Command();

        
        public string ChangeCommandTyp(string input, string userId)
        {
            var playerTableId = playerRepository.GetPlayerById(userId);

            if (input == "location")
            {
                playerRepository.SetPlayerCommandState(input, playerTableId);
                var currendLocation = playerRepository.GetPlayerLocation(userId);
                
                return ("Currend Location is -> " + roomRepository.GetRoomName(currendLocation));
            }

            if (input == "move")
            {
                playerRepository.SetPlayerCommandState(input, playerTableId);
                var currendLocation = playerRepository.GetPlayerLocation(userId);
                var possibelmoves = command.NextPosibleRoom(currendLocation);

                return ("possible movements are -> " + possibelmoves);
            }

            if (input == "pickup")
            {
                playerRepository.SetPlayerCommandState(input, playerTableId);
                var currendLocation = playerRepository.GetPlayerLocation(userId);
                var possibleItems = roomRepository.GetPickupItems(currendLocation);

                return ("pickup items are -> "+ string.Join(",",possibleItems));
            }
/*
            if (input == "use item")
            {
                playerRepository.SetPlayerCommandState(input, playerTableId);
                return ("Your invatory is => " + playerRepository.GetInvatory(userId));

            }
*/
            return "Not valid Command Change Type";
        }


        public string ValidateCommand(string input, string userId)
        {

            var currentComandState = playerRepository.GetPlayerCommandState(userId);
            string commandType = command.CheckCommand(input.ToLower(),userId);

            if(currentComandState == "move" && commandType == "Room")
            {
                return "Room";
            }

            if(currentComandState == "pickup" && commandType == "Item")
            {
                return "Item";
            }

            if (currentComandState == "use item" && commandType == "invatoryItem")
            {
                return "Activate";
            }

            return "false";
        }


        public string UseCommand(string commandType, string input, string userId)
        {
            if (commandType == "Room")
            {
               return MoveRoom(input.ToLower(), userId);
            }

            if (commandType == "Item")
            {

                return PickUpTheItem(input,userId);
            }

            if(commandType == "invatory")
            {
                return ("Your invatory is => " + (playerRepository.GetInvatory(userId)).ToString());
            }

            if(commandType == "Activate")
            {
                playerRepository.SetActiveItem(userId, input);
                return ("You are using => " + input);
            }

            return "Not a valid command";
        }


        public string MoveRoom(string roomName, string userId)
        {
            bool itemIsActive = true;
            bool canMove = false;
            bool itemIsNeeded = true;

            canMove = command.CanStapToRoom(roomName, userId);
            itemIsNeeded = roomRepository.IsUnlockItemNeeded(roomName);

            if (itemIsNeeded)
            {
                var neededItem = roomRepository.GetUnlockItem(roomName);
                itemIsActive = playerRepository.IsItemActive(userId, neededItem);
            }

            if (canMove == true && itemIsActive == true)
            {
                playerRepository.SetActiveItem(userId, "");
                return command.NextRoom(roomName, userId);
            }


            if(itemIsActive == false)
                return "Item needed to continue";


            return "Can not move to this room";
        }


        public string PickUpTheItem(string input, string userId)
        {

            var playerIntId = playerRepository.GetPlayerById(userId);
            playerRepository.SetInvatory(input, playerIntId);

            return ("You have picked up a -> " + input);
        }
    }
}