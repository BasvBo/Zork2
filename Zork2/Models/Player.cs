using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Player
    {
        //pri const int init settings
        private const int startRoom = 1;
        private const int startHealth = 5;
        private const string initialCommandType = "";
        private const string initialUsingItem = "";
        //private const string initialInvatory = "";


        public Player() { }

        public Player(string namePlayer, string string2)
        {
            UserId = string2;
            NamePlayer = namePlayer;
            CurrentRoom = startRoom;
            TotalHealth = startHealth;
            CurrentHealth = startHealth;
            CommandState = initialCommandType;
            UsingItem = initialUsingItem;
            ItemsIn = new List<Item>();
           // Invatory = initialInvatory;
        }



        public int Id { get; set; }
        public string UserId { get; set; }
        public string NamePlayer { get; set; }
        public int CurrentRoom { get; set; }
        public int TotalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string CommandState { get; set; }
        public string UsingItem { get; set; }
        //public string Invatory { get; set; }
        public virtual Item Invatory { get; set; }
        public ICollection<Item> ItemsIn { get; set; }


    }
}