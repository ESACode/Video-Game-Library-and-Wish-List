using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game_Library_and_Wish_List
{
    class WishListGame : Game
    {
        public int MetacriticScore;
        public WishListGame(string title, string category, string system, int year, int metacriticScore) : base(title, category, system, year)
        {
            MetacriticScore = metacriticScore;
        }
    }
}
