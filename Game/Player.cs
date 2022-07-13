using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        public string Name { get; set; }
        public int Coins { get; set; } = 0;
        public int ArmorValue { get; set; } = 0;
        public int Potion { get; set; } = 5;

        //Attributes
        public int Strength { get; set; } = 5;
        public int Dexterity { get; set; } = 5;
        public int Constitution { get; set; } = 5;
        public int Arcana { get; set; } = 5;

        //Attribute Based Stats
        public int Health;
        public int Damage;

        //Actions
        public List<string> availableActions = new List<string>();

        public Player()
        {
            Name = "Jerris Caedwyn";
            Coins = 0;
            ArmorValue = 0;
            Potion = 5;

            Strength = 5;
            Dexterity = 5; 
            Constitution = 5;
            Arcana = 5;

            Health = Constitution * 2;
            Damage = Strength * 2;
        }

    }
}
