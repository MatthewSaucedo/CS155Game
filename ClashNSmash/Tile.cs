using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    public class Tile
    {
        private char icon;
        private Character occupant;
        public Tile(char type)
        {
            switch (type)
            {
                case ' ':
                    icon = ' ';
                    break;
                case 'w':
                    icon = 'w';
                    break;
                case '+':
                    icon = '+';
                    break;
                case '@':
                    icon = ' ';
                    SetOccupant(new Player());
                    break;
                case 'G':
                    icon = ' ';
                    SetOccupant(new GelCube());
                    break;
            }
        }
        public char GetIcon()
        {
            if (this.occupant == null)
            {
                return icon;
            }
            else
            {
                return occupant.Icon;
            }
        }
        public Character GetOccupant ()
        {
            return occupant;
        }
        public void SetOccupant (Character newOccupant)
        {
            this.occupant = newOccupant;
        }
    }
}
