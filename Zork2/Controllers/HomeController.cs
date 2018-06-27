﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork2.Models;
using Zork2.Repository;
using Zork2.Utils;

namespace Zork2.Controllers
{
    public class HomeController : Controller
    {
        static Command command = new Command();

        static Story theStory = new Story();

       // Dictionary<string, string> Commands = new Dictionary<string, string>();

        private static Boolean firstSetup = false;

        static List<Room> roomList = new List<Room>();

        //static Player player = new Player(0, 5, 5, null);
        PlayerRepository playerRepository = new PlayerRepository(); 




        /// <summary>
        /// Setup is cald once to setup the game ande build the rooms
        /// </summary>
        public void SetUpGame()
        {
            if (!firstSetup)
            {
                System.Diagnostics.Debug.WriteLine("setup");
                BuildRooms();

                playerRepository.CreatPlayer("bassie");

                theStory.MyStory += (command.NextPosibleRoom(0, roomList) + Environment.NewLine);
                

                firstSetup = true;
            }
        }

        /// <summary>
        /// Buids rooms befor games start
        /// input = (int room number ,String nameroom, int[] next posible rooms)
        /// </summary>
        private static void BuildRooms()
        {
            roomList.Add(new Room(0, "start",new int[] { 1,2,3}));
            roomList.Add(new Room(1, "boom", new int[] { 0,2,3 }));
            roomList.Add(new Room(2, "huis", new int[] { 0,1,3 }));
            roomList.Add(new Room(3, "bos", new int[] { 1,2,4 }));
            roomList.Add(new Room(4, "kat", new int[] { 3, 5 }));
            roomList.Add(new Room(5, "sloot", new int[] { 4, 6, 7 }));
            roomList.Add(new Room(6, "berg", new int[] { 5, 8 }));
            roomList.Add(new Room(7, "put", new int[] { 5, 8 }));
            roomList.Add(new Room(8, "strand", new int[] { 7, 6, 9 }));
            roomList.Add(new Room(9, "einde", new int[] { 8 }));
        }


        public ActionResult Index(string input)
        {
            string commandType;
            string possibleRooms;

            SetUpGame();

                //show input
                theStory.MyStory += ("Input -> " + input + Environment.NewLine);

                //decipher input
                commandType = command.CheckCommand(input, roomList);
                theStory.MyStory += ("Command Type -> " + commandType + Environment.NewLine);

                //go to room and show next posible rooms
                if (commandType == "Room")
                {
                    possibleRooms = command.NextRoom(input.ToLower(), roomList, playerRepository);
                    theStory.MyStory += (possibleRooms + Environment.NewLine);
                }

                //show input and output on system log
                System.Diagnostics.Debug.WriteLine("Story: " + theStory.MyStory);
                System.Diagnostics.Debug.WriteLine("Input: " + input + Environment.NewLine);
            


            theStory.MyStory += ( Environment.NewLine);
            return View(theStory);
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




