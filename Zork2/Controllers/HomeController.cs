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
        static Boolean firstSetup = false;

        static Story theStory = new Story();

        static List<Room> roomList = new List<Room>();

        int roomIndex;


        private static void BuildRooms()
        {
           
            roomList.Add(new Room(0, "start",new int[] { 1,2,3}));
            roomList.Add(new Room(1, "boom", new int[] { 0,2,3 }));
            roomList.Add(new Room(2, "huis", new int[] { 0,1,3 }));
            roomList.Add(new Room(3, "bos", new int[] { 0,1,2 }));

        }

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


        Dictionary<string, string> Commands = new Dictionary<string, string>();


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

            

            //init
            if (!firstSetup)
            {
                BuildRooms();
                roomIndex = 0;
                firstSetup = true;
                Player player = new Player(1,5,5,null);

               // var Kamer = roomList[0].TextField;

                theStory.MyStory += (posibleRoom(roomList[0].RoomNumber)+ Environment.NewLine);

                //theStory.MyStory += (Kamer + Environment.NewLine);
            }

            System.Diagnostics.Debug.WriteLine("Input: " + input);
            System.Diagnostics.Debug.WriteLine("Story: " + theStory.MyStory);

            
            if (input != null)
            {

                if (input == roomList[roomIndex].TextField)
                {
                    theStory.MyStory += "not posible";
                }
                else
                { 
                    foreach(Room element in roomList)
                    {
                        if (input == element.TextField)
                        {
                            roomIndex = element.RoomNumber;
                            theStory.MyStory += (posibleRoom(element.RoomNumber) + roomIndex + Environment.NewLine);
                        
                        }
                    }
                    //theStory.MyStory += GetCommandText(input);
                }
            }


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




