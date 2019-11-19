
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public abstract class Enemy : Character
    {
        //method
        public Enemy(string name, int health, int attack, int defense) : base(name, health, attack, defense)
        {
        }
        // method
        public string battlecry()
        {
            string temp = "";
            temp += "ROOOAR";
            return temp;
        }
        public virtual coord patrolBlock(Map map)
        {
            return new coord(0, 0);
        }
        //override
        public override String ToString()
        {
            return base.ToString();
        }
    }
}