using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    class Snake : Enemy
    {
        //constructor
        public Snake() : base("Snake", 10, 10, 0)
        {
            Icon = 'S';
            AttackVerb = "bites";
            DeathText = "The " + Name + " falls limp";
        }
        //override
        public override coord patrolBlock(Map map)
        {
            for (int x = 0; x < map.Width; x++)
            {
                if (map.getTile(x, Y).GetOccupant() != null && map.getTile(x, Y).GetOccupant().Icon == '@')
                {
                    if (X < x)
                        return new coord(1, 0);
                    else
                        return new coord(- 1 , 0);
                }
            }
            for (int y = 0; y < map.Height; y++)
            {
                if (map.getTile(X, y).GetOccupant() != null && map.getTile(X, y).GetOccupant().Icon == '@')
                {
                    if (Y < y)
                        return new coord(0, 1);
                    else
                        return new coord(0, -1);
                }
            }
            return new coord(0, 0);
        }
    }
}
