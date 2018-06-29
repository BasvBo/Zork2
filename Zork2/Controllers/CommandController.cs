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
        Command command = new Command();

        public string ChangeCommandTyp(string input, string userId, List<Room>roomlist)
        {
            var playerTableId = playerRepository.GetPlayerById(userId);

            if (input == "location")
            {
                //set command typ to location
                playerRepository.SetPlayerCommandState(input, playerTableId);
                //send back current location
                var currendLocation = playerRepository.GetPlayerLocation(userId);
                
                return ("Currend Location is -> " + roomlist[currendLocation].TextField);
            }

            if (input == "move")
            {
                //set command type to move
                playerRepository.SetPlayerCommandState(input, playerTableId);
                //send back posible move's
                var currendLocation = playerRepository.GetPlayerLocation(userId);

                var possibelmoves = command.NextPosibleRoom(currendLocation, roomlist);

                return ("possible movements are -> " + possibelmoves);
            }

            return "Not valid Command Change Type";
        }


        public string ValidateCommand(string input, string userId, List<Room> roomlist)
        {

            var currentComandState = playerRepository.GetPlayerCommandState(userId);

            string commandType = command.CheckCommand(input,roomlist);

            if(currentComandState == "move" && commandType == "Room")
            {
                bool canMove = command.CanStapToRoom(input, userId, roomlist);

                if(canMove == true)
                {
                   return command.NextRoom(input, userId, roomlist);  
                }

                return "Can not move to this room";
            }

            return "Not a valid room";
        }
    }
}