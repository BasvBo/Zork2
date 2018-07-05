using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork2.Models;

namespace Zork2.Repository
{
    public class RoomRepository
    {

        public void CreatRoom(int id, string roomName, string adjacentRoom)
        {

            var room = new Room(id, roomName, adjacentRoom);

            using (var context = ApplicationDbContext.Create())
            {

                context.Rooms.Add(room);
                context.SaveChanges();
            }
        }


        public int[] GetAdjecentRooms(int roomId)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var room = context.Rooms.SingleOrDefault(r => r.Id == roomId);
                if (room == null)
                {
                    return null;
                }

                return Array.ConvertAll(room.AdjacentRoom.Split(';'), int.Parse);

            }
        }

        public int GetLastRoomId()
        {
            using(var context = ApplicationDbContext.Create())
            {
                var room = context.Rooms.Count<Room>();

                return room;
            }
        }


        public string GetRoomName(int roomId)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var room = context.Rooms.SingleOrDefault(r => r.Id == roomId);

                return room.RoomName;
            }
          
        }


        public int GetIdByName(string roomName)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var room = context.Rooms.SingleOrDefault(r => r.RoomName == roomName);
 
                return room.RoomNumber;
            }

        }


        public bool IsRoomName(string roomName)
        {
            using(var context = ApplicationDbContext.Create())
            {
                var room = context.Rooms.SingleOrDefault(r => r.RoomName == roomName);
                if(room == null)
                {
                    return false;
                }
            }

            return true;
        }


    }
}