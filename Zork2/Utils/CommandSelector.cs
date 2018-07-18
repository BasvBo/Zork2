using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Utils
{
    public class CommandSelector
    {
        Command command;
        Command Command
        {
            get
            {
                if (command == null)
                {
                    command = new Command();
                }
                return command;
            }
        }

        public string Select(string input, string userId)
        {

            //if input is equal change comand state player
            if (input == "location" | input == "move" | input == "pickup" | input == "use")
            {
                return "ChangeCommandType";
            }
            if (input == "help")
            {
                return "help";
            }

            return "UseCommand";

        }


        public string Execute(string commandType, string input, string userId)
        {
            if (input == "help")
            {
                return 
            }
            if (commandType == "ChangeCommandType")
            {
              return Command.ChangeCommandTyp(input, userId);
            }
            if(commandType == "UseCommand")
            {
                var commandIsValid = Command.ValidateCommand(input, userId);
                if (commandIsValid == "false")
                {
                    return "this is not a valid command";
                }
                return command.UseCommand(commandIsValid, input, userId);
            }
            return "flase";
        }

    }
}