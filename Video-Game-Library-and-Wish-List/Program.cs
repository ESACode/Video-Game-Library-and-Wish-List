using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game_Library_and_Wish_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eric's Video Game Library and Wishlish Application! \r\n");

            var sampleList = new List<Game>
            {
                new Game("Bloodborne", "PS4", 2015),
                new Game("Ghost of Tsushima", "PS5", 2020),
                new Game("The Legend of Zelda: Breath of the Wild", "Nintendo Switch", 2017),
                new Game("Grand Theft Auto V", "PS4", 2013),
                new Game("The Last of Us", "PS3", 2013),
                new Game("The Elder Scrolls V: Skyrim", "PC", 2011),
                new Game("Mass Effect 2", "Xbox 360", 2010),
                new Game("Left 4 Dead 2", "PC", 2009),
                new Game("Mortal Kombat", "SNES", 1992),
                new Game("Halo: Combat Evolved", "Xbox", 2001),
                new Game("Star Wars: Knights of the Old Republic", "PC", 2003),
                new Game("Portal", "Xbox 360", 2007)
            };

            var sampleLibrary = new Library("Eric's Sample Library", sampleList);

            while(true)  //Start of Master Loop
            { 
                Console.WriteLine("Choose from the options below:\r\n");
                Console.WriteLine("A: See a sample Video Game Library");
                Console.WriteLine("B: Create your own Video Game Library");
                Console.WriteLine("Q: Quit the program \r\n");
                Console.WriteLine("Enter your selection (Type \"A\", \"B\", or \"C\", etc.) \r\n");
                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                
                if (userInput.KeyChar == 'Q' || userInput.KeyChar == 'q')
                {
                    Console.WriteLine();
                    break;
                }
                else if (userInput.KeyChar == 'A' || userInput.KeyChar == 'a')
                {
                    sampleLibrary.Display(sampleLibrary.GamesList);
                }
                else 
                {
                    Console.WriteLine("That was not a valid Entry.  Please try again. \r\n");
                    continue;
                } 
            }
        }
    }
}
