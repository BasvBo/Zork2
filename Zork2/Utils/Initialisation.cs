﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Controllers;
using Zork2.Models;
using Zork2.Repository;

namespace Zork2.Utils
{
    public class Initialisation: PlayerRepository
    {

        RoomRepository roomRepository = new RoomRepository();
        ItemRepository itemRepository = new ItemRepository();
        List<Room> roomList = new List<Room>();
        List<Item> itemList = new List<Item>();



        public string PlayerSetup(string input, string id)
        {
            if (input == null)
            {
                return "Please Type in your Name";
            }
            else
            {
                CreatPlayer(input, id);
                BuildRooms();
                SetItems(id);
                return "set"; 
            }
            
        }


        public void BuildRooms()
        {
            roomList.Add(new Room(1,    "start",    "2;3",      "",     ""));
            roomList.Add(new Room(2,    "boom",     "1;3",      "key",  ""));
            roomList.Add(new Room(3,    "huis",     "1;2;4",    "",     "key"));
            roomList.Add(new Room(4,    "bos",      "3;5",      "board",""));
            roomList.Add(new Room(5,    "kat",      "4;6",      "",     ""));
            roomList.Add(new Room(6,    "sloot",    "5;7;8",    "",     ""));
            roomList.Add(new Room(7,    "berg",     "6;9",      "",     ""));
            roomList.Add(new Room(8,    "put",      "6",        "boat", "board"));
            roomList.Add(new Room(9,    "strand",   "8;7;10",   "",     ""));
            roomList.Add(new Room(10,   "einde",    "9",        "",     "boat"));

            //if rooms already saved don't add to db
            if (roomRepository.GetSizeOfRoomDb() == 0)
            {
                foreach (var element in roomList)
                {
                    roomRepository.CreatRoom(element.RoomNumber, element.RoomName, element.AdjacentRoom, element.PickUpItems, element.UnlockItem);

                }
            }
        }

        public void SetItems(string userId)
        {
            itemList.Add(new Item("key", 0));
            itemList.Add(new Item("board", 0));
            itemList.Add(new Item("boat", 0));

            if (itemRepository.GetSizeOfItemDb() == 0)
            {
                foreach (var element in itemList)
                {
                    itemRepository.SetItems(element.Name, element.Value);
                }

            }
        }


    }
}