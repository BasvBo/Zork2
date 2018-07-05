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


        public void SetPlayerLocation(int playerId, int room )
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(playerId); 
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

        public void SetInvatory(string input, int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(id);

                var item = context.Items.SingleOrDefault(i => i.Name == input);
                item.Value++;
               // player.Invatory += input + ",";
                context.SaveChanges();
            }
        }

        public bool IsItemActive(string userId, string neededItem)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == userId);
                if(player.UsingItem == neededItem)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetActiveItem(string userId, string item)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p=> p.UserId == userId);
                player.UsingItem = item ;
                context.SaveChanges();
            }
        }

        public Item GetInvatory(string userId)
        {
            using(var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == userId);
                return player.Invatory;
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
        //-------------------------------------------------------------------------------------------------------------------//

        public void SetItems(string userId, string itemName, int value)
        {
            var item = new Item(itemName, value);

            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == userId);
                player.Invatory = item;
                //context.Items.Add(item);
                context.SaveChanges();
            }
        }


    }
}