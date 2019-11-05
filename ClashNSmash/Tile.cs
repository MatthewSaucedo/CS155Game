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

        public char Icon { get => icon; set => icon = value; }

        public Tile(string type)
        {
            if (type.ToLower() == "floor")
            {
                Icon = ' ';
            }
            else if (type.ToLower() == "wall")
            {
                Icon = '■';
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
