﻿using System;
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
        private const string initialItems = "";


        public Player() { }

        public Player(string namePlayer, string string2)
        {
            UserId = string2;
            NamePlayer = namePlayer;
            CurrentRoom = startRoom;
            TotalHealth = startHealth;
            CurrentHealth = startHealth;
            CommandState = initialCommandType;
            Items = initialItems;
        }



        public int Id { get; set; }
        public string UserId { get; set; }
        public string NamePlayer { get; set; }
        public int CurrentRoom { get; set; }
        public int TotalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string CommandState { get; set; }
        public string Items { get; set; }



      

    }
}