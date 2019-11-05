
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
            Name = "Gelatinous Cube";
            Icon = Name[0];
        }

        public Enemy(string n, int h, int a, int d, int s) : base(n, h, a, d, s)
        {
            Icon = Name[0];
        }

        public Enemy(string n, int h, int a, int d, int s, bool v) : base(n, h, a, d, s, v)
        {
            Icon = Name[0];
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
            return base.ToString();
        }
    }
}