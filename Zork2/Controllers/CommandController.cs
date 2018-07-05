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

            return "Not valid Command Change Type";
        }


        public string ValidateCommand(string input, string userId)
        {

            var currentComandState = playerRepository.GetPlayerCommandState(userId);
            string commandType = command.CheckCommand(input.ToLower());

            if(currentComandState == "move" && commandType == "Room")
            {
                return "Room";
            }

            return "false";
        }


        public string UseCommand(string commandType, string input, string userId)
        {
            if (commandType == "Room")
            {
               return MoveRoom(input.ToLower(), userId);
            }

            return "Not a valid command";
        }


        public string MoveRoom(string input, string userId)
        {
            bool canMove = command.CanStapToRoom(input, userId);

            if (canMove == true)
            {
                return command.NextRoom(input, userId);
            }

            return "Can not move to this room";
        }
    }
}