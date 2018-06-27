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

             var player = new Player(name, 0, 5, 5, null);

            using (var context = ApplicationDbContext.Create())
            {

                context.Players.Add(player); // adds the player to the DbSet in memory
                context.SaveChanges(); // commits the changes to the database
            }
        }



        public int GetPlayerIdByName(string name)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.NamePlayer == name);
                
                return player.PlayerId;
            }
           
        }


        public int GetPlayerLocation(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.PlayerId == id);

                return player.CurrentRoom;
            }

        }


        public void SetPlayerLocation(int id, int room )
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(id); // retrieve the entity
                player.CurrentRoom = room; // amend properties
                context.SaveChanges(); // commit the changes
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


    }
}