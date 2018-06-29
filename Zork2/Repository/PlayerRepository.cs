using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;

namespace Zork2.Repository
{
    public class PlayerRepository
    {

        public void CreatPlayer(string name,string id)
        {

            var player = new Player(name,id);

            using (var context = ApplicationDbContext.Create())
            {

                context.Players.Add(player); 
                context.SaveChanges(); 
            }
        }



        public int GetPlayerById(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == id);
                if (player == null)
                {
                    return 0;
                }
                
                return player.Id;
            }
           
        }


        public string GetPlayerNameById(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == id);
 
                return player.NamePlayer;
            }

        }


        public int GetPlayerLocation(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.UserId == id);

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


        public string GetPlayerCommandState(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Single(p => p.UserId == id);

                return player.CommandState;
            }
        }


        public void SetPlayerCommandState(string input, int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(id);
                player.CommandState = input;
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