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
                new Game("Bloodborne", "Action Adventure", "PS4", "2015"),
                new Game("Ghost of Tsushima", "Action Adventure", "PS5", "2020"),
                new Game("The Legend of Zelda: Breath of the Wild", "Action Adventure", "Nintendo Switch", "2017"),
                new Game("Grand Theft Auto V", "Action Adventure", "PS4", "2013"),
                new Game("The Last of Us", "Action Adventure", "PS3", "2013"),
                new Game("The Elder Scrolls V: Skyrim", "RPG", "PC", "2011"),
                new Game("Mass Effect 2", "Action Adventure", "Xbox 360", "2010"),
                new Game("Left 4 Dead 2", "Action Adventure", "PC", "2009"),
                new Game("Mortal Kombat", "Fighting", "SNES", "1992"),
                new Game("Halo: Combat Evolved", "Shooter", "Xbox", "2001"),
                new Game("Star Wars: Knights of the Old Republic", "RPG", "PC", "2003"),
                new Game("Portal", "Platformer", "Xbox 360", "2007")
            };

            var sampleLibrary = new Library("Eric's Sample Library", sampleList);

            //Store list of all user created Libraries and method to display them.
            var listOfLibraries = new List<Library>();
            void displayAllLibraries()
            { 
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"List of all user created Libraries: \r\n");
                foreach (Library library in listOfLibraries)
                {
                    int place = listOfLibraries.IndexOf(library) + 1;
                    Console.WriteLine($"{place}: {library.NameOfList}");
                }
                Console.WriteLine();
            }

            //Store list of all user created Wish Lists
            var listOfWishLists = new List<WishList>();

            //Methord to handle CRUD work with user selected Library
            void workWithLibraryMenu(Library selectedLibrary)
            {
                selectedLibrary.Display(selectedLibrary.GamesList);
                while (true)
                {
                    Console.WriteLine("Choose from the options below:\r\n");
                    Console.WriteLine("A: Add a game to the library");
                    Console.WriteLine("B: Remove a game from the library");
                    Console.WriteLine("C: Sort the list by year");
                    Console.WriteLine("D: Sort the list by name");
                    Console.WriteLine("E: Sort the list by system");
                    Console.WriteLine("R: Return to previous menu");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    ConsoleKeyInfo userInput1 = Console.ReadKey();

                    //A: Add Game to Sample Library
                    if (userInput1.KeyChar == 'A' || userInput1.KeyChar == 'a')
                    {
                        Console.WriteLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("What is the name of the game you would like to add?");
                        var title = Console.ReadLine();
                        Console.WriteLine("What system is the game on?");
                        var system = Console.ReadLine();
                        Console.WriteLine("What type of game is it? (Action Adventure, RPG, Fighting, Shooter, etc..)");
                        var category = Console.ReadLine();
                        Console.WriteLine("What year was the game released?");
                        var year = Console.ReadLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Game gameToAdd = new Game(title, category, system, year);
                        selectedLibrary.AddToList(gameToAdd);
                        selectedLibrary.Display(selectedLibrary.GamesList);
                    }
                    //B: Remove Game from Sample Library
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
                                if (int.TryParse(removeSelection, out removeSelectionAsInt) && removeSelectionAsInt <= selectedLibrary.GamesList.Count() && removeSelectionAsInt > 0)
                                {
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                    selectedLibrary.RemoveFromList(removeSelectionAsInt);
                                    selectedLibrary.Display(selectedLibrary.GamesList);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("Your selection was either not a number, or the number did not match the position of any game in the list.");
                                    Console.WriteLine("Try again.");
                                    continue;
                                }
                            }
                        }
                    }
                    //C: Sort Sample Library by Year
                    else if (userInput1.KeyChar == 'C' || userInput1.KeyChar == 'c')
                    {
                        var sortedLibrary = selectedLibrary.SortByYear("Eric's Sample Library: Sorted by Year", selectedLibrary.GamesList);
                        sortedLibrary.Display(sortedLibrary.GamesList);
                    }
                    //D: Sort Sample Library by Title
                    else if (userInput1.KeyChar == 'D' || userInput1.KeyChar == 'd')
                    {
                        var sortedLibrary = selectedLibrary.SortByTitle("Eric's Sample Library: Sorted by Title", selectedLibrary.GamesList);
                        sortedLibrary.Display(sortedLibrary.GamesList);
                    }
                    //E: Sort Sample Library by System
                    else if (userInput1.KeyChar == 'E' || userInput1.KeyChar == 'e')
                    {
                        var sortedLibrary = selectedLibrary.SortBySystem("Eric's Sample Library: Sorted by System", selectedLibrary.GamesList);
                        sortedLibrary.Display(sortedLibrary.GamesList);
                    }
                    //R: Return to Main Menu
                    else if (userInput1.KeyChar == 'R' || userInput1.KeyChar == 'r')
                    {
                        Console.WriteLine("\r\n");
                        break;
                    }
                    //When input is not valid
                    else
                    {
                        Console.WriteLine("\r\n");
                        Console.WriteLine("That was not a valid selction.  Please Try again.");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        continue;
                    }
                }
            }

            //Master loop
            while (true)  
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Main Menu");
                Console.WriteLine("(Remember to save before existing the program!)\r\n");
                Console.WriteLine("Choose from the options below:\r\n");
                Console.WriteLine("A: Work with a sample Video Game Library");
                Console.WriteLine("B: Create your own Video Game Library or Wish List");
                Console.WriteLine("C: View/Add/Remove from existing Library or Wish List");
                Console.WriteLine("D: Use Video Game recommendation service");
                Console.WriteLine("S: Save any user created Libraries and Wish Lists");
                Console.WriteLine("Q: Quit the program \r\n");
                Console.WriteLine("Enter your selection (Type \"A\", \"B\", or \"C\", etc.)");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                ConsoleKeyInfo userInput = Console.ReadKey();

                //Q: Quit the program
                if (userInput.KeyChar == 'Q' || userInput.KeyChar == 'q')
                {
                    break;
                }
                //A: Work with sample Library, data not saved
                else if (userInput.KeyChar == 'A' || userInput.KeyChar == 'a')
                {
                    workWithLibraryMenu(sampleLibrary);
                }
                //B: Create new Library or Wish List
                else if (userInput.KeyChar == 'B' || userInput.KeyChar == 'b')
                {
                    Console.WriteLine();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("What is the name of your Library or Wish List?");
                    var libraryName = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Let's add your first game to this Library or Wsh List!\r\n");
                    Console.WriteLine("What is the name of the game you would like to add?");
                    var title = Console.ReadLine();
                    Console.WriteLine("What system is the game on?");
                    var system = Console.ReadLine();
                    Console.WriteLine("What type of game is it? (Action Adventure, RPG, Fighting, Shooter, etc..)");
                    var category = Console.ReadLine();
                    Console.WriteLine("What year was the game released?");
                    var year = Console.ReadLine();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("Library/Wish List created!");
                    Game gameToAdd = new Game(title, category, system, year);
                    List<Game> newListGame = new List<Game>() { gameToAdd };
                    Library newLibrary = new Library(libraryName, newListGame);
                    listOfLibraries.Add(newLibrary);

                    displayAllLibraries();
                }
                //C: CRUD with existing Library or Wish List
                else if (userInput.KeyChar == 'C' || userInput.KeyChar == 'c')
                {
                    bool isEmpty = !listOfLibraries.Any();
                    if (isEmpty)
                    {
                        Console.WriteLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("There are no user created libraries to work with, make one!");
                    }
                    else
                    {
                        while (true)
                        {
                            displayAllLibraries();
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("Choose an existing library by it's number in the list or enter M to go back to the Main Menu");
                            var librarySelection = Console.ReadLine();
                            int librarySelectionAsInt;
                            if (int.TryParse(librarySelection, out librarySelectionAsInt) && librarySelectionAsInt <= listOfLibraries.Count() && librarySelectionAsInt > 0)
                            {
                                Library selectedLibrary = listOfLibraries.ElementAt(librarySelectionAsInt - 1);
                                workWithLibraryMenu(selectedLibrary);
                            }
                            else if (librarySelection == "M" || librarySelection == "m")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("Your selection was either not a number, or the number did not match the position of any Library/Wish List in the list.");
                                Console.WriteLine("Try again.");
                                continue;
                            }
                        }
                    }

                }
                //D: Recommendation service
                else if (userInput.KeyChar == 'D' || userInput.KeyChar == 'd')
                {
                    //Read from the Json file to create sample Wish List
                    List<WishListGame> recommendGamesList = JsonConvert.DeserializeObject<List<WishListGame>>(File.ReadAllText("RecommendGames.json"));
                    var recommendGamesLibrary = new WishList("Recommended Games List", recommendGamesList);
                    //RecommendGamesLibrary.Display(RecommendGamesLibrary.WishGamesList);
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("Choose a category that interests you:\r\n");
                        Console.WriteLine("A: Action Adventure games");
                        Console.WriteLine("B: RPG games");
                        Console.WriteLine("C: Platformer games");
                        Console.WriteLine("D: Shooting games");
                        Console.WriteLine("E: Strategy games");
                        Console.WriteLine("F: Fighting games");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n");
                        ConsoleKeyInfo userSelection = Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                        //A: Show action adventure games
                        if (userSelection.KeyChar == 'A' || userSelection.KeyChar == 'a')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "Action Adventure");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //B: Show RPG games
                        else if (userSelection.KeyChar == 'B' || userSelection.KeyChar == 'b')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "RPG");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //C: Show platforming games
                        else if (userSelection.KeyChar == 'C' || userSelection.KeyChar == 'c')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "Platformer");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //D: Show shooting games
                        else if (userSelection.KeyChar == 'D' || userSelection.KeyChar == 'd')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "Shooter");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //E: Show strategy games
                        else if (userSelection.KeyChar == 'E' || userSelection.KeyChar == 'e')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "Strategy");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //F: Show fighting games
                        else if (userSelection.KeyChar == 'F' || userSelection.KeyChar == 'f')
                        {
                            recommendGamesLibrary.Display(recommendGamesLibrary.WishGamesList, "Fighting");
                            Console.WriteLine("Press enter to go back to the main menu");
                            Console.ReadLine();
                            break;
                        }
                        //Selection not valid
                        else
                        {
                            Console.WriteLine("That was not a valid entry.  Please try again.");
                            continue;
                        }
                    }
                }
                //S: Save all user created Libraries and Wish Lists
                else if (userInput.KeyChar == 'S' || userInput.KeyChar == 's')
                {

                }
                //Non valid entry handling
                else 
                {
                    Console.WriteLine("That was not a valid Entry.  Please try again. \r\n");
                    continue;
                } 
            }

            //End of program
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Thanks for using my Library and Wishlist app, goodbye!");
        }
    }
}
