using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;

namespace Zork2.Repository
{
    public class PlayerRepository
    {

        public void CreatPlayer(String name)
        {
            var player = new Player(FindMaxId(), name, 0, 5, 5, null);

            using (var context = ApplicationDbContext.Create())
            {
                context.Players.Add(player); // adds the author to the DbSet in memory
                context.SaveChanges(); // commits the changes to the database
            }
        }



        public void DeletePlayer(String name)
        {
            using (var context = new ApplicationDbContext())
            {
                var player = context.Players.Find(name);
                context.Players.Remove(player);
                context.SaveChanges();
            }
        }



        public int FindPayerIdByName(string name)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.NamePlayer == name);
                
                return player.PlayerId;
            }
           
        }




        public int FindMaxId()
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.ToList();
                
                return player.Count;
            }
        }


        public int FindPlayerLocation(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.PlayerId == id);

                return player.CurrentRoom;
            }

        }
 

    }
}