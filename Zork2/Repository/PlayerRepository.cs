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
                    return -1;
                }
                
                return player.Id;
            }
        }

        public bool Exists(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                return context.Players.SingleOrDefault(p => p.UserId == id) != null;
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

        public void SetInventory(string input, int id)
        {

            var item = new Item(input, 1);
          
            using (var context = ApplicationDbContext.Create())
            {
                var player = context.Players.Find(id);
                var selectItem = context.Items.SingleOrDefault(i => i.Name == input);
                
                player.ItemsList.Add(selectItem);

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

        public string GetInventory(string userId)
        {
            using(var context = ApplicationDbContext.Create())
            {
                var player = context.Players.SingleOrDefault(p => p.UserId == userId);

                var inventoryList = "";
                foreach(var element in player.ItemsList)
                {
                    inventoryList += element.Name + ",";
                }
                return inventoryList;
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