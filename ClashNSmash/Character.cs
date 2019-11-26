using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClashNSmash
{
    public abstract class Character
    {

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool Alive { get; set; }
        public string AttackVerb { get; set; }
        public string DeathText { get; set; }
        public char Icon { get; set; }

        //constructor
        public Character(string name, int health, int attack, int defense)
        {
            this.Name = name;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
            this.Alive = true;
        }
        //method
        //This character attacks another
        public int dealAttack(Character target)
        {
            int damageDealt = Attack - target.Defense;
            if (damageDealt > 0)
            {
                target.Health -= damageDealt;
                if (target.Health <= 0)
                {
                    target.Health = 0;
                    target.Alive = false;
                }
            }
            else
                return 0;
            return damageDealt;
        }
        //override
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Character c = (Character)obj;
                return ((Name == c.Name) && (Health == c.Health) && (Attack == c.Attack) &&
                    (Defense == c.Defense));
            }
        }
        public override string ToString()
        {
            string temp = "";
            temp += "Name: " + Name + "\n";
            temp += "Health: " + Health + "\n";
            temp += "Attack: " + Attack + "\n";
            temp += "Defense: " + Defense + "\n";
            temp += "Alive: " + Alive + "\n";
            return temp;
        }
    }
}
