using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Player
    {
        

        public int currentRoom { get; set; }
        public int totalHealth { get; set; }
        public int currentHealth { get; set; }
        public List<string> Item { get; set; }

        public Player(int currentRoom, int totalHealth, int currentHealth, List<string> item)
        {
            this.currentRoom = currentRoom;
            this.totalHealth = totalHealth;
            this.currentHealth = currentHealth;
            Item = item;
        }

    }
}