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

        

        private static void BuildRooms()
        {
           
            roomList.Add(new Room(1, "Start",new int[] { 2, 3 }));
            roomList.Add(new Room(2, "boom", new int[] { 1, 3 }));
            roomList.Add(new Room(3, "huis", new int[] { 1, 2 }));


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

            if (!firstSetup)
            {
                BuildRooms();
                firstSetup = true;
            }
            

            System.Diagnostics.Debug.WriteLine("Input: " + input);
            System.Diagnostics.Debug.WriteLine("Story: " + theStory.MyStory);

            //var Kamer = roomList[1].RoomNumber+ roomList[1].TextField;

            //theStory.MyStory += (Kamer + Environment.NewLine);
            if (input != null)
            {
                theStory.MyStory += GetCommandText(input);

            }

            if (input == "")
            {
                theStory.MyStory += (input + Environment.NewLine);
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




