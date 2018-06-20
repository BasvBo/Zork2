using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork2.Models;

namespace Zork2.Controllers
{
    public class HomeController : Controller
    {

        static Story theStory = new Story();

        Dictionary<string, string> Commands = new Dictionary<string, string>();


        static Boolean firstSetup = false;

        static List<Room> roomList = new List<Room>();

        static Player player = new Player(0, 5, 5, null);




        /// <summary>
        /// Setup is cald once to setup the game ande build the rooms
        /// </summary>
        private void setUpGame()
        {
            if (!firstSetup)
            {
                BuildRooms();

                theStory.MyStory += (posibleRoom(roomList[0].RoomNumber) + Environment.NewLine);

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

        /// <summary>
        /// searches for next posible rooms, input = index for roomlist
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        private string posibleRoom(int room)
        {
            string roomName = "";

            int[] roomIndex = roomList[room].nextRoom;

            //Console.WriteLine(roomIndex);

            foreach (int element in roomIndex)
            {
                roomName += roomList[element].TextField + ", ";
            }

            return roomName;
        }

        /// <summary>
        /// check what kind of input the player has given, input = string input from game
        /// </summary>
        /// <param name="input"></param>
        private void checkInput(string input)
        {
            if (input != null)
            {
                bool inputIsRoom = false;

                theStory.MyStory += ("input -> " + input + Environment.NewLine);

                // search if input is a room namen
                foreach (Room element in roomList)
                {
                    if(input == element.TextField)
                    {
                        inputIsRoom = true;
                        roomInput(input);
                    }
                }

                if(inputIsRoom == false)
                {
                    theStory.MyStory += ("This is not a command" + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// If the input is a room name look to see if posible
        /// if posible show next avalible rooms
        /// </summary>
        /// <param name="input"></param>
        private void roomInput(string input)
        {
            if (input == roomList[player.currentRoom].TextField)
            {
                theStory.MyStory += ("You are already there" + Environment.NewLine);
            }
            else if(input == roomList[roomList.Count - 1].TextField)
            {
                theStory.MyStory += ("you are a loser baby so why don't you kill me" + Environment.NewLine);
            }
            else
            {
                foreach (Room element in roomList) //search for new room index and show next posible rooms
                {
                    if (input == element.TextField)
                    {
                        theStory.MyStory += ("where to next? -> " + posibleRoom(element.RoomNumber) + Environment.NewLine);
                        player.currentRoom = element.RoomNumber;

                    }
                }
            }
        }

        private void FillCommands()
        {
            Commands.Add("poke", "Stop poking me, god dammit");
            Commands.Add("dance", "You are making a fool of yourself");
            Commands.Add("test", "this is a test");
        }

        private string GetCommandText(string input)
        {
            FillCommands();
            if (Commands.ContainsKey(input))
            {
                var c = Commands[input];
                return "<" + input + ">" + "\n" + c + "\n\n";
            }
            else
            {
                return "<" + input + ">" + "\nThis is not a command, for all commands see the Help page\n\n";
            }
        }


        public ActionResult Index(string input)
        {
            setUpGame();

            checkInput(input);

            System.Diagnostics.Debug.WriteLine("Story: " + theStory.MyStory);
            System.Diagnostics.Debug.WriteLine("Input: " + input + Environment.NewLine);

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




