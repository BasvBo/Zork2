using Microsoft.AspNet.Identity;
using System;
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

        static Story theStory = new Story();



        static List<Room> roomList = new List<Room>();

 
        PlayerRepository playerRepository = new PlayerRepository();
        GameController gameController = new GameController();





        [Authorize]
        public ActionResult Index(string input)
        {
            //get ID of currend user
            var id = User.Identity.GetUserId();

           
            if (input != null)
            {
                theStory.MyStory += ("Input -> " + input + Environment.NewLine);
            }
            
            theStory.MyStory += gameController.GameManager(input,id)+ Environment.NewLine;



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




