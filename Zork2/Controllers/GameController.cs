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

        


        public string GameManager(string input, string id)
        {


            //only runs on start up & player exists
            if (input == null && playerRepository.GetPlayerById(id) != 0)
            {
                return ("What would you like to do " + playerRepository.GetPlayerNameById(id) + "?" + Environment.NewLine 
                    + "get 'location', 'move', 'pickup' item, 'use' item or see 'inventory");
            }


            //if ID is not found Creat and Link player to accound
            if (playerRepository.GetPlayerById(id) == 0)
            {   
                var iets = initalisation.PlayerSetup(input, id);
                if (iets == "set")
                {
                    return "Your name has been set " + input + ", Lets play!!"
                        + Environment.NewLine + "What would you like to do? get 'location', 'move', 'pickup' item, 'use' item or see 'inventory";
                }
                return iets;
                
            }


            //if input is equal change comand state player
            if (input == "location"| input == "move"| input == "pickup"| input == "use")
            {
                return commandController.ChangeCommandTyp(input, id);  
            }

            if(input == "inventory")
            {
                return commandController.UseCommand("Inventory", input, id);
            }


            //if command state is set check input is ok
            if(playerRepository.GetPlayerCommandState(id) != "")
            {
                //if command typ is set check if input is valid command
                var commandType = commandController.ValidateCommand(input, id);

                if (commandType == "false")
                {
                    return "this is not a valid command";
                }

                return commandController.UseCommand(commandType, input, id);

            }

            return "FALSE";
            
        }

    }
}