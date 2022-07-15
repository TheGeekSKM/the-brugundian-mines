using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Tools;

namespace Game
{
    enum CombatState
    {
        PlayerNormal,
        PlayerTurnStart,
        PlayerTurn,
        PlayerTurnEnd,
        EnemyTurnStart,
        EnemyTurn,
        EnemyTurnEnd,
    }

    class Program
    {
        public static CombatState combatState = CombatState.PlayerNormal;
        public static Random rand = new Random();
        public static Player currentPlayer = new Player();

        public static List<Room> rooms = new List<Room>();
        public static List<Enemy> enemies = new List<Enemy>();

        public static Room beginningRoom;
        public static Room currentRoom = beginningRoom;
        public static Enemy currentEnemy = null;

        public static bool gameLoopStarted = false;


        public static int NumOfRooms = 10;

        #region Helpful Methods

        static int ParseToInteger(string num, int defaultIntegerValue)
        {
            int resultNum = 0;

            if (num == "" || num == null) { return defaultIntegerValue; }

            bool isPasreable = Int32.TryParse(num, out resultNum);

            if (isPasreable) { return resultNum; }
            else { return defaultIntegerValue; }
        }

        static int LimitInteger(int value, int lowerLimit, int higherLimit)
        {
            if (value < lowerLimit) { return lowerLimit; }
            else if (value > higherLimit) { return higherLimit; }
            else { return value; }
        }

        static void Print(string s, int speed = 30)
        {
            for (int c = 0; c < s.Length; c++)
            {
                Console.Write(s[c]);
                System.Threading.Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        Console.Write(s.Substring(c + 1));
                        
                        break;
                    }


                }

            }
            speed = 30;
            Console.WriteLine();
        }

        #endregion


        static void Main(string[] args)
        {
            LoadGame();
            MainMenu();
            BeginningRoom();
        }

        static void LoadGame()
        {
            beginningRoom = new Room("Beginning Room","A dark room with a hallway to the front of you and broken rocks all over.");
            currentRoom = beginningRoom;
            rooms.Add(beginningRoom);
            enemies.Add(beginningRoom.enemiesInRoom[0]);

            for (int i = 0; i < NumOfRooms; i++)
            {
                Room tempRoom = new Room(
                        $"Dungeon Room #{i + 1}",
                        "A cold dark room that's barely visible.");
                rooms.Add(tempRoom);
                
                
            }
        }

        #region Story/Dialogue Methods
        static void MainMenu()
        {
            Print("Welcome To The Mines of Brugundia!");
            Print("Character Name:");
            currentPlayer.Name = Console.ReadLine();

            if (currentPlayer.Name.Equals("") || currentPlayer.Name == null)
            {
                currentPlayer.Name = "Jerris Caedwyn";
            }

            Intro();

        }

        static void Intro()
        {
            Console.Clear();
            Print("You awake in darkness. ");
            Console.WriteLine();
            Print("Your eyes remain unadjusted to the pitch black that envelopes your entire being. ");
            Console.WriteLine();
            Print("A cacpphony or high pitched wines rattle their way through your skull.");
            Console.WriteLine();
            Print("You quickly grab your head as feeling and sensitivity rush back into your fingers, ");
            Print("your legs, your feet, and the rest of your body. ");
            Console.WriteLine();
            Print("As your left hand clutches your head, your right hand moves to do the same but stops");
            Print("as you realize that something heavy is in your right hand.");
            Console.WriteLine();
            Print("You drop it out of panic and instinct. ");

            beginningRoom.itemsInRoom.Add(
                new Items(
                    ItemType.Tool,
                    "Worn Pickaxe",
                    "A beaten and worn pickaxe with flesh and sinew attached to it.",
                    5,
                    0,
                    5));

            Console.WriteLine();
            Print("As it clatters onto the ground, the high pitched wines begin to squirm their way out of");
            Print("your ears. The object's echo races all around you... ");
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Print("You stand still as the echo subsides.");
            Console.WriteLine();
            Print("No response greets you...");
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Print("Your brain rattle under the gargantuan headache that rumbles in your head.");
            Console.WriteLine();
            Print("You're having a hard time remembering who you are.");
            Console.WriteLine();
            Console.WriteLine($"All you know is that your name is {currentPlayer.Name}");
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadLine();

            AttributesDeciding();
        }

        static void BeginningRoom()
        {
            #region Beginning Room Setup
            currentRoom = beginningRoom;
            currentPlayer.availableActions.Add("Hide");
            currentPlayer.availableActions.Add("Pick Up Item");
            currentPlayer.availableActions.Add("Check Inventory");
            currentPlayer.availableActions.Add("Run");
            #endregion

            Console.Clear();
            Print("Your eyes begin to slowly adjust to the darkness of the room.");
            Console.WriteLine();
            Print("You see all rocks and stones all around you.");
            Console.WriteLine();
            Print("Near the jagged rocks that dot the floor, lies the pickaxe you dropped.");
            Console.WriteLine();
            Print("It rests in a still manner, unmoving. Your eyes follow the curved metal as it");
            Print("rounds off on one end, but the other end leads to an indescribable mesh.");
            Console.WriteLine();
            Print("A head.", 50);
            Console.WriteLine();
            Print("You gasp as the head begins to show itself clearly to you, your eyes somehow");
            Print("recognizing the form and the features.");
            Console.WriteLine();
            Print("The 8 piercing eyes, the humanoid nose torn by a single venomous portruding tusk,");
            Print("the mouth that has been impaled on the pickaxe and the scraps of hair that remain on");
            Print("the backside of the head.");
            Console.WriteLine();
            Print("You inch closer to the head to get a better look.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Print("The head is vaguely humanoid, aside from the various eyes and tusks.");
            Console.WriteLine();
            Print("You slowly begin to recognize the face...");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Print("Suddenly...");
            Console.WriteLine();
            Print("the head...", 70);
            Console.WriteLine();
            Print("SCREAMS", 100);
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);

            Console.Clear();
            Print("The scream rips through the silent air and races through the seemingly empty hallway");
            Print("that seems to lie before you...");
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);
            
            Print("A moment passes before another scream-just as shrill and just as angry as the head-");
            Print("responds from the hallway.");
            Console.WriteLine();
            Print("You begin to hear scraping noises coming from the hallway as something is coming...");
            Console.WriteLine();
            Print("and it is coming quickly...", 70);
            Console.WriteLine();
            Console.ReadLine();

            combatState = CombatState.PlayerTurnStart;
            PlayerTurnStart();
        }
        #endregion

        #region Gameplay Methods
        static void AttributesDeciding()
        {
            int totalPoints = 20;
            Console.Clear();
            Print("Slowly a few things about you make your way back into your memory...");
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();
            Print("You have 20 points to divide between 4 attributes (Str, Dex, Con, Arc)...");
            Print("Use them well and use them all...");
            Console.ReadKey();

            #region Strength
            Console.Clear();
            Print("How much Strength would you like?");
            Print("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Print("Type in a number:");
            currentPlayer.Strength = 
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2, 
                    8);
            totalPoints -= currentPlayer.Strength;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Strength} Strength!");
            Console.WriteLine($"You have {totalPoints} total points left...");
            Print("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Dexterity
            Console.Clear();
            Print("How much Dexterity would you like?");
            Print("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Print("Type in a number:");
            currentPlayer.Dexterity =
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2,
                    8);
            totalPoints -= currentPlayer.Dexterity;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Dexterity} Dexterity!");
            Console.WriteLine($"You have {totalPoints} total points left...");
            Print("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Constitution
            Console.Clear();
            Print("How much Constitution would you like?");
            Print("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Print("Type in a number:");
            currentPlayer.Constitution =
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2,
                    8);

            totalPoints -= currentPlayer.Constitution;
            if (totalPoints < 2) 
            {
                Console.Clear();
                Print("You failed to allot points correctly...");
                Print("You must try again...");
                Print("Press any key to continue...");
                Console.ReadKey();
                AttributesDeciding();
            }

            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Constitution} Constitution!");
            Console.WriteLine($"You have {totalPoints} points left for Arcana...");
            Print("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Arcana
           
            currentPlayer.Arcana = totalPoints;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Arcana} Arcana!");
            Print("Press any key to continue...");
            Console.ReadKey();
            #endregion

            Console.Clear();
            Print("Your attributes are: ");
            Console.WriteLine($"Strength: {currentPlayer.Strength}");
            Console.WriteLine($"Dexterity: {currentPlayer.Dexterity}");
            Console.WriteLine($"Constitution: {currentPlayer.Constitution}");
            Console.WriteLine($"Arcana: {currentPlayer.Arcana}");
            Console.WriteLine();
            Print("Press [Y] to continue or Press [N] to redo your attributes.");
            string attribRedo = Console.ReadLine();

            if (attribRedo.Equals("N") || attribRedo.Equals("n")) { AttributesDeciding(); }

        }

        #endregion
       
        
        #region Combat States

        static void PlayerTurnStart()
        {
            if (currentPlayer.Health <= 0)
            {
                EndGame();
            }

            combatState = CombatState.PlayerTurnStart;
            PlayerTurn();
        }
        static void PlayerTurn()
        {
            combatState = CombatState.PlayerTurn;
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine($"The Room You're In: {currentRoom.RoomName}");
            Console.WriteLine(currentRoom.RoomDescription);
            Console.WriteLine("");
            Console.WriteLine($"Your Health: {currentPlayer.Health}");
            Console.WriteLine($"Your Armor: {currentPlayer.ArmorValue}");
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine("The Options You Have:");
            for (int i = 0; i < currentPlayer.availableActions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. \"{currentPlayer.availableActions[i]}\"");
            }
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.Write("Type the number of the option you choose: ");
            int response = ParseToInteger(Console.ReadLine(), 1);
            switch (response)
            {
                case 1:
                    Hide();
                    break;

                case 2:
                    PickUpItem();
                    break;

                case 4:
                    CheckInventory();
                    break;

                case 5:
                    Run();
                    break;

                default:
                    Console.WriteLine("Unknown Number...");
                    System.Threading.Thread.Sleep(1000);
                    PlayerTurn();
                    break;
            }
            combatState = CombatState.PlayerTurnEnd;
            PlayerTurnEnd();


        }
        static void PlayerTurnEnd()
        {
            combatState = CombatState.EnemyTurnStart;
            EnemyTurnStart();
        }

        static void EnemyTurnStart()
        {

            //Checks to see if the enemy is still alive...
            if (currentEnemy == null || currentEnemy.health <= 0)
            {
                ReturnToNormal();
            }
            else
            {
                //Checks to see if the enemy can see the player...
                int enemySight = (rand.Next(8) + 1) + currentEnemy.sightModifier;
                if (enemySight <= currentPlayer.Dexterity)
                {
                    combatState = CombatState.EnemyTurnEnd;
                    EnemyTurnEnd();
                }
                else
                {
                    combatState = CombatState.EnemyTurn;
                    EnemyTurn();
                }
            }

           



        }
        static void EnemyTurn()
        {
            currentPlayer.Health -= currentEnemy.damage;

            combatState = CombatState.EnemyTurnEnd;
            EnemyTurnEnd();
        }
        static void EnemyTurnEnd()
        {


            combatState = CombatState.PlayerTurnStart;
            PlayerTurnStart();
        }

        static void ReturnToNormal()
        {
            combatState = CombatState.PlayerNormal;

        }
        #endregion


        #region Commands
        static void Hide()
        {
            int decidingNum = rand.Next(currentRoom.HidingDifficulty) + 1;
            if (decidingNum <= currentPlayer.Dexterity)
            {
                currentPlayer.currentState = PlayerState.Hidden;

                Console.Clear();
                Print("You are successfully hidden.");
                Print("You will continue hiding until the next turn.");
                Print("");
                Print("While you are hidden, you cannot be seen by enemies...");
                Print("");
                Print("Your turn is over.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Print("You scramble for cover, but the room presents no space for you to hide.");
                Print("");
                Print("You will remain visible to any enemies in the area...");
                Print("");
                Print("Your turn is over.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }

        static void PickUpItem()
        {
            Console.Clear();
            Print("You look around the room for any items to pick up");
            Print("");
            Print("You find the following items on the floor");
            Print("");
            Console.WriteLine("=======================================================");

            for (int i = 0; i < currentRoom.itemsInRoom.Count; i++)
            {
                Print($"{i + 1}. {currentRoom.itemsInRoom[i].ItemName}");
                Print($"   \"{currentRoom.itemsInRoom[i].itemDescription}\"");
                Print("");
            }

            Console.WriteLine("=======================================================");
            Print("");
            Print("");
            Console.Write("Type in the number of the item you want to pick up: ");
            int response = ParseToInteger(Console.ReadLine(), 0);

            if (response < 1 || response > currentRoom.itemsInRoom.Count)
            {
                Console.Clear();
                Print("Invalid Response. Please type in a valid number...");
                System.Threading.Thread.Sleep(2000);
                PickUpItem();
            }
            else 
            {
                Items pickedItem = currentRoom.itemsInRoom[response - 1];
                Console.Clear();
                Print($"You picked up {pickedItem.ItemName}!");
                currentRoom.itemsInRoom.Remove(pickedItem);
                currentPlayer.inventory.Add(pickedItem);
                System.Threading.Thread.Sleep(2000);

            }
        }

        static void CheckInventory()
        {
            
        }

        static void Run()
        {
            
        }
        #endregion


        static void EndGame()
        {
            Console.Clear();
            Print("You died...");
            Print("");

            Print("Press any key to exit...");
            Console.ReadLine();
        }


        //TODO: Add IntroTwo Method explaining the room
        //TODO: Introduce typing mechanic to loot the room.
    }
}
