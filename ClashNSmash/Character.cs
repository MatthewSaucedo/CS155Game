using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClashNSmash
{
    public class Character
    {
        private string name;
        private int x;
        private int y;
        private int health;
        private int attack;
        private int defense;
        private bool existence;
        private char icon;

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public bool Existence { get => existence; set => existence = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public char Icon { get => icon; set => icon = value; }

        //constructor
        public Character()
        {
            this.name = "Default Character";
            this.health = 5;
            this.attack = 3;
            this.defense = 1;
            this.existence = true;
        }
        public Character(string name, int health, int attack, int defense)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.existence = true;
        }
        //method
        public int dealAttack(Character target)
        {
            int damageDealt = Attack - target.Defense;
            if (damageDealt > 0)
            {
                target.Health -= damageDealt;
                if (target.Health <= 0)
                {
                    target.Health = 0;
                    target.Existence = false;
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
            temp += "Exist: " + Existence + "\n";
            return temp;
        }
    }
}
