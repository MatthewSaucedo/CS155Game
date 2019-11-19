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
        public char Icon { get => icon; set => icon = value; }
        public Tile(char type)
        {
            switch (type)
            {
                case ' ':
                    Icon = ' ';
                    break;
                case 'w':
                    Icon = 'w';
                    break;
                case '@':
                    setOccupant(new Player());
                    break;
                case 'G':
                    setOccupant(new GelCube());
                    break;
            }
        }
        public Character getOccupant ()
        {
            return occupant;
        }
        public void setOccupant (Character newOccupant)
        {
            this.occupant = newOccupant;
            if (newOccupant == null)
                Icon = ' ';
            else
                Icon = newOccupant.Icon;
        }
    }
}
