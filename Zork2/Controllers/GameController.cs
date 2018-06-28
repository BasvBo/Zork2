using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;
using Zork2.Repository;
using Zork2.Utils;

namespace Zork2.Controllers
{
    public class GameController
    {
        PlayerRepository playerRepository = new PlayerRepository();
        Initialisation initalisation = new Initialisation();
        Command command = new Command();
        static List<Room> roomList = new List<Room>();

        enum CommandType {location, move };


        public string GameManager(string input, string id)
        {
            var PlayerId = playerRepository.GetPlayerById(id);

            BuildRooms();

            if (input == null)
            {
                return ("Pleas type a valid command " + playerRepository.GetPlayerNameById(id));
            }

            //if ID is not fout Creat and Link player to accound
            if (PlayerId == 0)
            {             
                return initalisation.PlayerSetup(input, id);  
            }

            //if input is equal change comand state player
            if(input == "location"| input == "move")
            {
                //set command type of the player 
                return "set command type and return options";
            }

            if(playerRepository.GetPayerCommandState(id) != "")
            {
                return "i need to go to command controller";
            }
            else
            {
                return "What would you like to do? get 'location' or 'move'";
            }

           // var commandType1 = command.CheckCommand(input,roomList);

           // return commandType1;


        }


        private void BuildRooms()
        {
            roomList.Add(new Room(0, "start", new int[] { 1, 2, 3 }));
            roomList.Add(new Room(1, "boom", new int[] { 0, 2, 3 }));
            roomList.Add(new Room(2, "huis", new int[] { 0, 1, 3 }));
            roomList.Add(new Room(3, "bos", new int[] { 1, 2, 4 }));
            roomList.Add(new Room(4, "kat", new int[] { 3, 5 }));
            roomList.Add(new Room(5, "sloot", new int[] { 4, 6, 7 }));
            roomList.Add(new Room(6, "berg", new int[] { 5, 8 }));
            roomList.Add(new Room(7, "put", new int[] { 5, 8 }));
            roomList.Add(new Room(8, "strand", new int[] { 7, 6, 9 }));
            roomList.Add(new Room(9, "einde", new int[] { 8 }));
        }


    }
}