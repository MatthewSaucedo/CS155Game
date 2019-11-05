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
        private int speed;
        private bool existence;
        private char icon;

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool Existence { get => existence; set => existence = value; }
        public char Icon { get => icon; set => icon = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Character()
        {
            this.name = "Default Character";
            this.health = 1;
            this.attack = 0;
            this.defense = 0;
            this.speed = 0;
            this.existence = true;
        }

        public Character(string n, int h, int a, int d, int s)
        {
            this.name = n;
            this.health = h;
            this.attack = a;
            this.defense = d;
            this.speed = s;
            this.existence = true;
        }

        public Character(string n, int h, int a, int d, int s, bool exist)
        {
            this.Name = n;
            this.Health = h;
            this.Attack = a;
            this.Defense = d;
            this.Speed = s;
            this.Existence = exist;
        }
        public void dealAttack(Character target)
        {
            int damageDealt = Attack - target.Defense;
            if (damageDealt > 0)
            {
                target.Health -= damageDealt;
                if (target.Health <= 0)
                {
                    //TODO: Death action
                }
            }
        }

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
                    (Defense == c.Defense) && (Speed == c.Speed));
            }
        }
        public override string ToString()
        {
            string temp = "";
            temp += "Name: " + Name + "\n";
            temp += "Health: " + Health + "\n";
            temp += "Attack: " + Attack + "\n";
            temp += "Defense: " + Defense + "\n";
            temp += "Speed: " + Speed + "\n";
            temp += "Exist: " + Existence + "\n";
            return temp;
        }
    }
}
