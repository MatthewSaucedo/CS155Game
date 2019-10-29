using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClashNSmash
{
    public class Character
    {
        protected string name;
        protected coord pos;
        protected int health;
        protected int attack;
        protected int defense;
        protected int speed;
        protected bool existence;
        protected char icon;

        public Character()
        {
            this.name = "Skeleton";
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
            this.name = n;
            this.health = h;
            this.attack = a;
            this.defense = d;
            this.speed = s;
            this.existence = exist;
        }

        //getters
        public String getName()
        {
            return this.name;
        }

        public int getHealth()
        {
            return this.health;
        }

        public int getAttack()
        {
            return this.attack;
        }

        public int getDefense()
        {
            return this.defense;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public bool getExistence()
        {
            return this.existence;
        }

        public char getIcon()
        {
            return icon;
        }

        public coord getPos()
        {
            return pos;
        }


        //setters
        public void setName(string n)
        {
            this.name = n;
        }
        public void setHealth(int h)
        {
            this.health = h;
        }

        public void setAttack(int a)
        {
            this.attack = a;
        }

        public void setDefense(int d)
        {
            this.defense = d;
        }

        public void setSpeed(int s)
        {
            this.speed = s;
        }

        public void setExistence(bool exist)
        {
            this.existence = exist;
        }

        public void setIcon(char i)
        {
            this.icon = i;
        }

        public void setPos(coord pos)
        {
            this.pos = pos;
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
                return ((getName() == c.getName()) && (getHealth() == c.getHealth()) && (getAttack() == c.getAttack()) &&
                    (getDefense() == c.getDefense()) && (getSpeed() == c.getSpeed()));
            }
        }

        public override string ToString()
        {
            string temp = "";
            temp += "Name: " + getName() + "\n";
            temp += "Health: " + getHealth() + "\n";
            temp += "Attack: " + getAttack() + "\n";
            temp += "Defense: " + getDefense() + "\n";
            temp += "Speed: " + getSpeed() + "\n";
            temp += "Exist: " + getExistence() + "\n";
            return temp;
        }






    }
}
