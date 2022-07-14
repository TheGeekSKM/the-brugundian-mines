using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy
    {
        public int health;
        public string name = "";
        public string description;
        public int damage;
        public int sightModifier;
        public int armor;
        public int level;

        public Enemy()
        {
            level = 1;
            
            name = "Basic Troll";
            description = "A hideous medium creature with wrinkled green skin and bloody claws...";

            health = level + 2;
            damage = level;
            sightModifier = 1;
            armor = level - 1;
        }
    }
}
