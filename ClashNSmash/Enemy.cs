
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Enemy : Character
    {
        int patrolCounter = 0;
        int patrolCounterMax = 4;
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

        public coord patrolBlock()
        {
            if (patrolCounter >= patrolCounterMax)
                patrolCounter = 0;

            coord returnCoord;

            if (patrolCounter == 0)
                returnCoord = new coord(1, 0);
            else if (patrolCounter == 1)
                returnCoord = new coord(0, -1);
            else if (patrolCounter == 2)
                returnCoord = new coord(-1, 0);
            else if (patrolCounter == 3)
                returnCoord = new coord(0, 1);
            else
                returnCoord = new coord(0,0);

            patrolCounter++;
            return returnCoord;
        }
        public override String ToString()
        {
            return base.ToString();
        }
    }
}