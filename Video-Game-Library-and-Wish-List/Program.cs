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
            //List<WishListGame> RecommendGamesList = JsonConvert.DeserializeObject<List<WishListGame>>(File.ReadAllText("RecommendGames.json"));
            //var RecommendGamesLibrary = new WishList("Recommend Games List", RecommendGamesList);
            //RecommendGamesLibrary.Display(RecommendGamesLibrary.WishGamesList);

            //Master loop
            while (true)  
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Main Menu\r\n");
                Console.WriteLine("Choose from the options below:\r\n");
                Console.WriteLine("A: See a sample Video Game Library");
                Console.WriteLine("B: Create your own Video Game Library");
                Console.WriteLine("Q: Quit the program \r\n");
                Console.WriteLine("Enter your selection (Type \"A\", \"B\", or \"C\", etc.)");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                ConsoleKeyInfo userInput = Console.ReadKey();

                //Quit the program
                if (userInput.KeyChar == 'Q' || userInput.KeyChar == 'q')
                {
                    break;
                }
                //Show sample Library
                else if (userInput.KeyChar == 'A' || userInput.KeyChar == 'a')
                {
                    sampleLibrary.Display(sampleLibrary.GamesList);
                    while (true)
                    {
                        Console.WriteLine("Choose from the options below:\r\n");
                        Console.WriteLine("A: Add a game to the library");
                        Console.WriteLine("B: Remove a game from the library");
                        Console.WriteLine("C: Sort the list by year");
                        Console.WriteLine("D: Sort the list by name");
                        Console.WriteLine("E: Sort the list by system");
                        Console.WriteLine("R: Return to main menu");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        ConsoleKeyInfo userInput1 = Console.ReadKey();

                        //Add Game to Sample Library
                        if (userInput1.KeyChar == 'A' || userInput1.KeyChar == 'a')
                        {
                            Console.WriteLine();
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        }
                        //Remove Game from Sample Library
                        else if (userInput1.KeyChar == 'B' || userInput1.KeyChar == 'b')
                        {
                            while (true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("Enter the game you want removed's numerical position in the list.\r\n");
                                Console.WriteLine("(Type \"1\", \"2\", or \"3\", etc. and hit enter.  Enter \"B\" to go back to the previous menu");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                string removeSelection = Console.ReadLine();
                                if (removeSelection == "B" || removeSelection == "b")
                                {
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    break;
                                }
                                else
                                {
                                    int removeSelectionAsInt;
                                    if (int.TryParse(removeSelection, out removeSelectionAsInt) && removeSelectionAsInt <= sampleLibrary.GamesList.Count() && removeSelectionAsInt > 0)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                        sampleLibrary.RemoveFromList(removeSelectionAsInt);
                                        sampleLibrary.Display(sampleLibrary.GamesList);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine("Your selection was either not a number, or the number did not match the position of any game in the library.");
                                        Console.WriteLine("Try again.");
                                        continue;
                                    }
                                }
                            }
                        }
                        //Sort Sample Library by Year
                        else if (userInput1.KeyChar == 'C' || userInput1.KeyChar == 'c')
                        {
                            var sortedLibrary = sampleLibrary.SortByYear("Eric's Sample Library: Sorted by Year", sampleLibrary.GamesList);
                            sortedLibrary.Display(sortedLibrary.GamesList);
                        }
                        //Sort Sample Library by Title
                        else if (userInput1.KeyChar == 'D' || userInput1.KeyChar == 'd')
                        {
                            var sortedLibrary = sampleLibrary.SortByTitle("Eric's Sample Library: Sorted by Title", sampleLibrary.GamesList);
                            sortedLibrary.Display(sortedLibrary.GamesList);
                        }
                        //Sort Sample Library by System
                        else if (userInput1.KeyChar == 'E' || userInput1.KeyChar == 'e')
                        {
                            var sortedLibrary = sampleLibrary.SortBySystem("Eric's Sample Library: Sorted by System", sampleLibrary.GamesList);
                            sortedLibrary.Display(sortedLibrary.GamesList);
                        }
                        //Go back to Main Menu
                        else if (userInput1.KeyChar == 'R' || userInput1.KeyChar == 'r')
                        {
                            Console.WriteLine("\r\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\r\n");
                            Console.WriteLine("That was not a valid selction.  Please Try again.");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            continue;
                        }
                    }
                }
                //Create new Library
                else if (userInput.KeyChar == 'B' || userInput.KeyChar == 'b')
                {
                    Console.WriteLine("\r\n");
                    Console.WriteLine("What is the name of your library?");
                    var libraryName = Console.ReadLine();
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
