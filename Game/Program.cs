using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        public static Player currentPlayer = new Player();

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

        static void Print(string s, int speed = 10)
        {
            foreach (char c in s)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);

            }
            Console.WriteLine();
        }

        #endregion

        static void Main(string[] args)
        {
            MainMenu();
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
            Console.Clear();
            Print("Your eyes begin to slowly adjust to the darkness of the room.");
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

        //TODO: Add IntroTwo Method explaining the room
        //TODO: Introduce typing mechanic to loot the room.
    }
}
