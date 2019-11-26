using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    class GelCube : Enemy
    {
        //variables
        int patrolCounterMax = 4;
        int patrolCounter = 1;
        //constructor
        public GelCube() : base("Gelatinous Cube", 10, 10, 0)
        {
            Icon = 'G';
            AttackVerb = "squelches";
            DeathText = "The " + Name + " fizzles away";
        }
        //override
        public override coord patrolBlock(Map map)
        {
            if (patrolCounter > patrolCounterMax)
                patrolCounter = 1;

            coord returnCoord;

            if (patrolCounter == 1)
            {
                patrolCounter = 2;
                returnCoord = new coord(1, 0);
            }
            else if (patrolCounter == 2)
            {
                patrolCounter = 3;
                returnCoord = new coord(0, -1);
            }
            else if (patrolCounter == 3)
            {
                patrolCounter = 4;
                returnCoord = new coord(-1, 0);
            }
            else if (patrolCounter == 4)
            {
                patrolCounter = 1;
                returnCoord = new coord(0, 1);
            }
            else
            {
                returnCoord = new coord(0, 0);
            }
            return returnCoord;
        }
    }
}
