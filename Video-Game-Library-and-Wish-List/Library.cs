using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"{this.NameOfList} \r\n");
            foreach(Game game in GamesList)
            {
                Console.WriteLine($"Title: {game.Title}  System: {game.System}  Year: {game.Year}");
            }
            Console.WriteLine();
        }
    }
}
