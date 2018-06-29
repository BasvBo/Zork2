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
        CommandController commandController = new CommandController();
        PlayerRepository playerRepository = new PlayerRepository();
        Initialisation initalisation = new Initialisation();
        Command command = new Command();
        static List<Room> roomList = new List<Room>();

        enum CommandType {location, move };


        public string GameManager(string input, string id)
        {


            //only runs on start up & player exists
            if (input == null && playerRepository.GetPlayerById(id) != 0)
            {
                BuildRooms();
                return ("Pleas type a valid command " + playerRepository.GetPlayerNameById(id) 
                    + Environment.NewLine + "What would you like to do? get 'location' info or 'move'");
            }


            //if ID is not found Creat and Link player to accound
            if (playerRepository.GetPlayerById(id) == 0)
            {   
                var iets = initalisation.PlayerSetup(input, id);
                if (iets == "set")
                {
                    BuildRooms();
                    return "Your name has been set " + input + ", Lets play!!"
                        + Environment.NewLine + "What would you like to do? get 'location' info or 'move'";
                }
                return iets;
                
            }


            //if input is equal change comand state player
            if (input == "location"| input == "move")
            {
                return commandController.ChangeCommandTyp(input, id,roomList);  
            }


            //if command state is set check input is ok
            if(playerRepository.GetPlayerCommandState(id) != "")
            {
                //if command typ is set check if input is valid command
                return commandController.ValidateCommand(input, id, roomList);
                
            }

            return "What would you like to do? get 'location' info or 'move'";
            
        }


        public void BuildRooms()
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