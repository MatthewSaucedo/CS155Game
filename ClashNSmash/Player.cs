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
        public Player() : base("Player", 50, 3, 1)
        {
            Icon = '@';
            AttackVerb = "slashes";
            DeathText = "You have been slain";
        }
        public Player(string n, int h, int a, int d) : base(n, h, a, d)
        {
            Icon = '@';
            AttackVerb = "slashes";
            DeathText = "You have been slain";
        }
    }
}