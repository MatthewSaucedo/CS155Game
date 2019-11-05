using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashNSmash
{
    class Map
    {
        private Tile[,] tiles;
        private int width, height;

        internal Tile[,] Tiles { get => tiles; set => tiles = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public Map()
        {
            Width = 10; Height = 10;
            // 219 █
            // 254 ■
            // 153 Ö
            Tiles = new Tile[Width, Height];

            buildMapDefault();
        }

        public Map(int x, int y)
        {
            Width = x; Height = y;
            Tiles = new Tile[Width, Height];

            buildMapDefault();
        }

        public Tile getTile(int x, int y)
        {
            return Tiles[x, y];
        }

        public void buildMapDefault()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    Tiles[x, y] = new Tile("Floor");
            for (int y = 0; y < Height; y++)
            {
                Tiles[0, y] = new Tile("wall");
                Tiles[Width - 1, y] = new Tile("wall");
            }
            for (int x = 2; x < Width - 1; x++)
            {
                Tiles[x, 0] = new Tile("wall");
                Tiles[x, Height - 1] = new Tile("wall");
            }
        }

        public override string ToString()
        {
            string returnString = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    returnString += Tiles[x, y].Icon + " ";
                }
                returnString += "\n";
            }
            return returnString;
        }
    }
}
