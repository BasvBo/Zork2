using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork2.Models
{
    public class Player
    {
        //pri const int init settings
        private const int startRoom = 0;
        private const int startHealth = 5;
        private const string startGameState = "initialisation";

        public int Id { get; set; }
        public String NamePlayer { get; set; }
        public int CurrentRoom { get; set; }
        public int TotalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string GameState { get; set; }
        public List<string> Items { get; set; }


        public Player() { }

        public Player(string namePlayer)
        {

            NamePlayer = namePlayer;
            CurrentRoom = startRoom;
            TotalHealth = startHealth;
            CurrentHealth = startHealth;
            GameState = startGameState;
        }

      

    }
}