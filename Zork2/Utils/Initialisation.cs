using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Controllers;
using Zork2.Models;
using Zork2.Repository;

namespace Zork2.Utils
{
    public class Initialisation: PlayerRepository
    {

       

        public string PlayerSetup(string input, string id)
        {
            if (input == null)
            {
                return "Pleas Type in your Name";
            }
            else
            {
                CreatPlayer(input, id);

                return "set"; 
            }
            
        }


    }
}