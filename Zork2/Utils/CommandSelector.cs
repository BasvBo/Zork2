using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Utils
{
    public class CommandSelector
    {
        Command command = new Command();

        public string Select(string input, string userId)
        {

            //if input is equal change comand state player
            if (input == "location" | input == "move" | input == "pickup" | input == "use")
            {
                return "ChangeCommandType";
            }

            return "UseCommand";

        }


        public string Execute(string commandType, string input, string userId)
        {
            if(commandType == "ChangeCommandType")
            {
              return command.ChangeCommandTyp(input, userId);
            }
            if(commandType == "UseCommand")
            {
                var commandIsValid = command.ValidateCommand(input, userId);
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