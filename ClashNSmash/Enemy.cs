
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Enemy : Character
    {

        public Enemy() : base()
        {
            icon = name[0];
        }

        public Enemy(string n, int h, int a, int d, int s) : base(n, h, a, d, s)
        {
            icon = name[0];
        }

        public Enemy(string n, int h, int a, int d, int s, bool v) : base(n, h, a, d, s, v)
        {
            icon = name[0];
        }

        // method
        public string battlecry()
        {
            string temp = "";
            temp += "ROOOAR";
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