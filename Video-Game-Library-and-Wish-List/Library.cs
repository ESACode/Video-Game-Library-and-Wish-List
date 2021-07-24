using System;
using System.Collections.Generic;
using System.Linq;

namespace Video_Game_Library_and_Wish_List
{
    class Library
    {
        public List<Game> GamesList;
        public string NameOfList;
        public Library(string name, List<Game> games)
        {
            NameOfList = name;
            GamesList = games;
        }
        public void Display(List<Game> GamesList)
        {
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{this.NameOfList} \r\n");
            foreach(Game game in GamesList)
            {
                int place = GamesList.IndexOf(game) + 1;
                Console.WriteLine($"{place}: Title: {game.Title} | Category: {game.Category} | System: {game.System} | Year: {game.Year}");
            }
            Console.WriteLine();
        }

        public void AddToList(Game game)
        {
            GamesList.Add(game);
        }

        public void RemoveFromList(int index)
        {
            GamesList.RemoveAt(index - 1);
        }

        public Library SortByYear(string name, List<Game> list)
        {
            List<Game> sortedList = list.OrderBy(item => item.Year).ToList();
            Library sortedLibrary = new Library(name, sortedList);
            return sortedLibrary;
        }

        public Library SortByTitle(string name, List<Game> list)
        {
            List<Game> sortedList = list.OrderBy(item => item.Title).ToList();
            Library sortedLibrary = new Library(name, sortedList);
            return sortedLibrary;
        }

        public Library SortBySystem(string name, List<Game> list)
        {
            List<Game> sortedList = list.OrderBy(item => item.System).ToList();
            Library sortedLibrary = new Library(name, sortedList);
            return sortedLibrary;
        }
    }
}
