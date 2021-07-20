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
        public int Year;
        public Game(string title, string system, int year)
        {
            Title = title;
            System = system;
            Year = year;
        }

    }
}
