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

        public int HidingDifficulty = 10;

        public string RoomDescription { get { return roomDescription; } }
        public string RoomName { get { return roomName; } }

        public List<Items> itemsInRoom = new List<Items>();

        public Room(string name, string description)
        {
            #region Hallway

            int r = rand.Next(3);
            string descAddendum = "";

            if (r == 0) { descAddendum = " A hallway lies in front of you..."; }
            else if (r == 1) { descAddendum = " A hallway lies to the left of you..."; }
            else if (r == 2) { descAddendum = " A hallway lies to the right of you..."; }

            #endregion

            roomName = name;
            roomDescription = description + descAddendum;

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
