using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Player : Character
    {
        //constructor
        public Player() : base()
        {
            Name = "Player";
            Icon = '@';
        }
        public Player(string n, int h, int a, int d) : base(n, h, a, d)
        {
            Icon = '@';
        }
        //method
        public string battlecry()
        {
            string temp = "";
            temp += "HEEE-YAAAHH!!";
            return temp;
        }
        //override
        public override String ToString()
        {
            string temp = "";
            temp += base.ToString();
            return temp;
        }
    }
}