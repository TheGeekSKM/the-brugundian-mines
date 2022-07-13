using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room
    {
        private Random rand = new Random();

        private string roomName = "Untitled Room";
        private string roomDescription = "A random room...";
        public string RoomDescription { get { return roomDescription; } }
        public string RoomName { get { return roomName; } }

        public List<Items> itemsInRoom = new List<Items>();

        public Room(string name, string description)
        {
            roomName = name;
            roomDescription = description;

            //Adding some rocks to a room.
            for (int i = 0; i < rand.Next(3, 6); i++)
            {
                itemsInRoom.Add(
               new Items(
                   ItemType.Tool,
                   "Rock",
                   "Just an ordinary rock...",
                   3,
                   0,
                   1)
               );
            }
        }
    }
}
