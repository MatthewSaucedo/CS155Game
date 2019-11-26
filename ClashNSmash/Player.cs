using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Player : Character
    {
        int score;
        //constructor
        public Player() : base("Player", 100, 3, 1)
        {
            Icon = '@';
            AttackVerb = "slashes";
        }
        public Player(string n, int h, int a, int d) : base(n, h, a, d)
        {
            Icon = '@';
            AttackVerb = "slashes";
        }
        //method
        public string Battlecry()
        {
            return "HEEE-YAAAHH!!";
        }
        public void AddScore(int score)
        {
            this.score += score;
        }
        public int GetScore()
        {
            return score;
        }
        //override
        public override String ToString()
        {
            string temp = "";
            temp += base.ToString();
            temp += "\nscore: " + score;
            return temp;
        }
    }
}