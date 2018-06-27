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

            var player = new Player(name);

            using (var context = ApplicationDbContext.Create())
            {

                context.Players.Add(player); 
                context.SaveChanges(); 
            }
        }



        public int GetPlayerIdByName(string name)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.NamePlayer == name);
                
                return player.Id;
            }
           
        }


        public int GetPlayerLocation(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.Id == id);

                return player.CurrentRoom;
            }

        }


        public void SetPlayerLocation(int id, int room )
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(id); 
                player.CurrentRoom = room; 
                context.SaveChanges(); 
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