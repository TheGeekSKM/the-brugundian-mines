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
            name = "Basic Troll";
            description = "A hideous medium creature with wrinkled green skin and bloody claws...";

            health = 3;
            damage = 1;
            sightModifier = 1;
            armor = 0;
        }

        public Enemy(string n, string d, int h, int dM, int sM, int a)
        {
            name = n;
            description = d;
            health = h;
            damage = dM;
            sightModifier = sM;
            armor = a;
        }
    }
}
