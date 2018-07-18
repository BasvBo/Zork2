using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork2.Models;
using Zork2.Repository;
using Zork2.Utils;
using Zork2.ViewModels;

namespace Zork2.Controllers
{
    public class HomeController : Controller
    {
     
        #region lazy loaders
        PlayerRepository playerRepository;
        PlayerRepository PlayerRepository
        {
            get
            {
                if (playerRepository == null)
                {
                    playerRepository = new PlayerRepository();
                }
                return playerRepository;
            }
        }

        RoomRepository roomRepository;
        RoomRepository RoomRepository
        {
            get
            {
                if (roomRepository == null)
                {
                    roomRepository = new RoomRepository();
                }
                return roomRepository;
            }
        }

        ItemRepository itemRepository;
        ItemRepository ItemRepository
        {
            get
            {
                if(itemRepository == null)
                {
                    itemRepository = new ItemRepository();
                }
                return itemRepository;
            }
        }

        Initialisation initialisation;
        Initialisation Initialisation
        {
            get
            {
                if (initialisation == null)
                {
                    initialisation = new Initialisation();
                }
                return initialisation;
            }
        }

        CommandSelector commandSelector;
        CommandSelector CommandSelector
        {
            get
            {
                if (commandSelector == null)
                {
                    commandSelector = new CommandSelector();
                }
                return commandSelector;
            }
        }
        #endregion


        [Authorize]
        public ActionResult Index(string input)
        {
            var userId = User.Identity.GetUserId();

            if (input == null)
            {
                var firstText = NullInput(userId);
                return View(new PrintViewModel(firstText));
            }


            var printText = PrintInput(input);
           

            if (PlayerRepository.Exists(userId))
            {
                var command = CommandSelector.Select(input, userId);
                printText += CommandSelector.Execute(command, input, userId);
            }
            else
            {
                printText += CreateNewPlayer(input, userId);
            }


            printText += Environment.NewLine;
            return View(new PrintViewModel(printText));
        }


        private string NullInput(string userId)
        {
            if (PlayerRepository.Exists(userId))
            {
                return ("What would you like to do " + playerRepository.GetPlayerNameById(userId) + "?" + Environment.NewLine
                     + "get 'location', 'move', 'pickup' item or 'use' item ");
            }
            else
            {
                return "Please Type in your Name";
            }
        }

        private string PrintInput(string input)
        {
            return "Input -> " + input + Environment.NewLine;
        }

        private string CreateNewPlayer(string input,string userId)
        {
            PlayerRepository.CreatPlayer(input, userId);
            var roomList = Initialisation.GetRooms();
            RoomRepository.CreatRoom(roomList);
            var itemList = Initialisation.GetItems();
            ItemRepository.SetItems(itemList);

            return "Your name has been set " + input + ", Lets play!!"
                        + Environment.NewLine + "What would you like to do? get 'location', 'move', 'pickup' item or 'use' item" ;
        }



    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}




