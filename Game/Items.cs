using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    enum ItemType
    {
        Potion,
        Weapon,
        Tool,
        Key
    }
    class Items
    {
        private ItemType type = ItemType.Tool;
        private string itemName = "Untitled Item";
        private string itemDescription = "A random item...";

        private int itemDamage = 0;
        private int itemArmor = 0;

        public int itemDurability = 20;
        
        public ItemType Type { get { return type; } }
        public string ItemDescription { get { return itemDescription; } }
        public string ItemName { get { return itemName; } }
        public int ItemDamage { get { return itemDamage; } }
        public int ItemArmor { get { return itemArmor; } }


    }
}
