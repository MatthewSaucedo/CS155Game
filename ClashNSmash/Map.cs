using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClashNSmash
{
    public class Map
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

        public Map(string mapText)
        {
            string[] split = mapText.Split('\n');
            width = split[0].Length-1;
            height = split.Length-1;
            Tiles = new Tile[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (split[y][x] == 'w')
                        Tiles[x, y] = new Tile('w');
                    else
                        Tiles[x, y] = new Tile(' ');
                }
            }
        }

        public Tile getTile(int x, int y)
        {
            return Tiles[x, y];
        }
        public void buildMapDefault()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    Tiles[x, y] = new Tile(' ');
            for (int y = 0; y < Height; y++)
            {
                Tiles[0, y] = new Tile('w');
                Tiles[Width - 1, y] = new Tile('w');
            }
            for (int x = 2; x < Width - 1; x++)
            {
                Tiles[x, 0] = new Tile('w');
                Tiles[x, Height - 1] = new Tile('w');
            }
        }

        public override string ToString()
        {
            string returnString = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    returnString += Tiles[x, y].Icon;
                }
                returnString += "\n";
            }
            return returnString;
        }
    }
}
