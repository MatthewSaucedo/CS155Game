using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Player : Character
    {

        public Player() : base()
        {
            icon = '@';
        }

        public Player(string n, int h, int a, int d, int s) : base(n, h, a, d, s)
        {
            icon = '@';
        }

        public Player(string n, int h, int a, int d, int s, bool v) : base(n, h, a, d, s, v)
        {
            icon = '@';
        }

        //method
        public string battlecry()
        {
            string temp = "";
            temp += "HEEE-YAAAHH!!";
            return temp;
        }

        public override String ToString()
        {
            string temp = "";
            temp += base.ToString();
            return temp;

        }

    }
}