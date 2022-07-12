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

        #endregion

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome To The Mines of Brugundia!");
            Console.WriteLine("Character Name:");
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
            Console.WriteLine("You awake in darkness. ");
            Console.WriteLine();
            Console.WriteLine("Your eyes remain unadjusted to the pitch black that envelopes your entire being. ");
            Console.WriteLine();
            Console.WriteLine("A cacpphony or high pitched wines rattle their way through your skull.");
            Console.WriteLine();
            Console.WriteLine("You quickly grab your head as feeling and sensitivity rush back into your fingers, ");
            Console.WriteLine("your legs, your feet, and the rest of your body. ");
            Console.WriteLine();
            Console.WriteLine("As your left hand clutches your head, your right hand moves to do the same but stops");
            Console.WriteLine("as you realize that something heavy is in your right hand.");
            Console.WriteLine();
            Console.WriteLine("You drop it out of panic and instinct. ");
            Console.WriteLine();
            Console.WriteLine("As it clatters onto the ground, the high pitched wines begin to squirm their way out of");
            Console.WriteLine("your ears. The object's echo races all around you... ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("You stand still as the echo subsides.");
            Console.WriteLine();
            Console.WriteLine("No response greets you...");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Your brain rattle under the gargantuan headache that rumbles in your head.");
            Console.WriteLine();
            Console.WriteLine("You're having a hard time remembering who you are.");
            Console.WriteLine();
            Console.WriteLine($"All you know is that your name is {currentPlayer.Name}");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            AttributesDeciding();
        }

        static void AttributesDeciding()
        {
            int totalPoints = 20;
            Console.Clear();
            Console.WriteLine("Slowly a few things about you make your way back into your memory...");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("You have 20 points to divide between 4 attributes (Str, Dex, Con, Arc)...");
            Console.WriteLine("Use them well and use them all...");
            Console.ReadKey();

            #region Strength
            Console.Clear();
            Console.WriteLine("How much Strength would you like?");
            Console.WriteLine("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Console.WriteLine("Type in a number:");
            currentPlayer.Strength = 
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2, 
                    8);
            totalPoints -= currentPlayer.Strength;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Strength} Strength!");
            Console.WriteLine($"You have {totalPoints} total points left...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Dexterity
            Console.Clear();
            Console.WriteLine("How much Dexterity would you like?");
            Console.WriteLine("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Console.WriteLine("Type in a number:");
            currentPlayer.Dexterity =
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2,
                    8);
            totalPoints -= currentPlayer.Dexterity;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Dexterity} Dexterity!");
            Console.WriteLine($"You have {totalPoints} total points left...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Constitution
            Console.Clear();
            Console.WriteLine("How much Constitution would you like?");
            Console.WriteLine("[No more than 8 and no less than 2]");
            Console.WriteLine();
            Console.WriteLine("Type in a number:");
            currentPlayer.Constitution =
                LimitInteger(
                    ParseToInteger(Console.ReadLine(), 5),
                    2,
                    8);

            totalPoints -= currentPlayer.Constitution;
            if (totalPoints < 2) 
            {
                Console.Clear();
                Console.WriteLine("You failed to allot points correctly...");
                Console.WriteLine("You must try again...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                AttributesDeciding();
            }

            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Constitution} Constitution!");
            Console.WriteLine($"You have {totalPoints} points left for Arcana...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Arcana
           
            currentPlayer.Arcana = totalPoints;
            Console.Clear();
            Console.WriteLine($"You have {currentPlayer.Arcana} Arcana!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            #endregion

            Console.Clear();
            Console.WriteLine("Your attributes are: ");
            Console.WriteLine($"Strength: {currentPlayer.Strength}");
            Console.WriteLine($"Dexterity: {currentPlayer.Dexterity}");
            Console.WriteLine($"Constitution: {currentPlayer.Constitution}");
            Console.WriteLine($"Arcana: {currentPlayer.Arcana}");
            Console.WriteLine();
            Console.WriteLine("Press [Y] to continue or Press [N] to redo your attributes.");
            string attribRedo = Console.ReadLine();

            if (attribRedo.Equals("N") || attribRedo.Equals("n")) { AttributesDeciding(); }

        }
    }
}
