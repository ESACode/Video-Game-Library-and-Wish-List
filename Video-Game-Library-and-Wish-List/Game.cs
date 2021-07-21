using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game_Library_and_Wish_List
{
    class Game
    {
        public string Title;
        public string System;
        public string Category;
        public int Year;
        public Game(string title, string category, string system, int year)
        {
            Title = title;
            Category = category;
            System = system;
            Year = year;
        }

    }
}
