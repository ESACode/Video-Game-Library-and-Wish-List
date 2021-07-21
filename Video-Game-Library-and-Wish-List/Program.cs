using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Video_Game_Library_and_Wish_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eric's Video Game Library and Wishlish Application! \r\n");

            //Read from this list to create sample library
            var sampleList = new List<Game>
            {
                new Game("Bloodborne", "Action Adventure", "PS4", 2015),
                new Game("Ghost of Tsushima", "Action Adventure", "PS5", 2020),
                new Game("The Legend of Zelda: Breath of the Wild", "Action Adventure", "Nintendo Switch", 2017),
                new Game("Grand Theft Auto V", "Action Adventure", "PS4", 2013),
                new Game("The Last of Us", "Action Adventure", "PS3", 2013),
                new Game("The Elder Scrolls V: Skyrim", "RPG", "PC", 2011),
                new Game("Mass Effect 2", "Action Adventure", "Xbox 360", 2010),
                new Game("Left 4 Dead 2", "Action Adventure", "PC", 2009),
                new Game("Mortal Kombat", "Fighting", "SNES", 1992),
                new Game("Halo: Combat Evolved", "Shooter", "Xbox", 2001),
                new Game("Star Wars: Knights of the Old Republic", "RPG", "PC", 2003),
                new Game("Portal", "Platformer", "Xbox 360", 2007)
            };

            var sampleLibrary = new Library("Eric's Sample Library", sampleList);

            //Read from the Json file
            //var fileName = "RecommendGames.json";
            List<WishListGame> RecommendGamesList = JsonConvert.DeserializeObject<List<WishListGame>>(File.ReadAllText("RecommendGames.json"));
            var RecommendGamesLibrary = new WishList("Recommend Games List", RecommendGamesList);
            RecommendGamesLibrary.Display(RecommendGamesLibrary.WishGamesList);

            //Master loop
            while (true)  
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
