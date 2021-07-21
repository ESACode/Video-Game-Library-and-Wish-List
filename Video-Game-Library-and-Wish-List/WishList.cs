using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game_Library_and_Wish_List
{
    class WishList
    {
        public List<WishListGame> WishGamesList;
        public string NameOfList;
        public WishList(string name, List<WishListGame> wishListGames)
        {
            NameOfList = name;
            WishGamesList = wishListGames;
        }
        public void Display(List<WishListGame> WishGamesList)
        {
            Console.WriteLine($"{this.NameOfList} \r\n");
            foreach (WishListGame game in WishGamesList)
            {
                Console.WriteLine($"Title: {game.Title}  Category: {game.Category}  System: {game.System}  Year: {game.Year} Metacritic Score: {game.MetacriticScore}");
            }
            Console.WriteLine();
        }
    }
}
