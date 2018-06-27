using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Player
    {

        public int Id { get; set; }
        public String NamePlayer { get; set; }
        public int CurrentRoom { get; set; }
        public int TotalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public List<string> Item { get; set; }


        public Player() { }

        public Player(string namePlayer, int currentRoom, int totalHealth, int currentHealth, List<string> item)
        {

            NamePlayer = namePlayer;
            CurrentRoom = currentRoom;
            TotalHealth = totalHealth;
            CurrentHealth = currentHealth;
            Item = item;
        }

    }
}