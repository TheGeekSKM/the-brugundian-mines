using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room
    {
        private string roomName = "Untitled Room";
        public string RoomName => roomName;

        private string roomDescription = "A random room...";
        public string RoomDescription => roomDescription;

        public List<object> itemsInRoom = new List<object>();
    }
}
