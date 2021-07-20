using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game_Library_and_Wish_List
{
    class WishList : Library
    {
        public WishList(string name, List<Game> games) : base(name, games)
        {

        }
    }
}
