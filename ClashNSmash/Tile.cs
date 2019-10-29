using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    class Tile
    {
        private char icon;
        private Character occupant;

        public Tile(string type)
        {
            if (type.ToLower() == "floor")
            {
                icon = ' ';
            }
            else if (type.ToLower() == "wall")
            {
                icon = '■';
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
                icon = ' ';
            else
                icon = newOccupant.getIcon();
        }
            
        public char getIcon()
        {
            return icon;
        }
    }
}
