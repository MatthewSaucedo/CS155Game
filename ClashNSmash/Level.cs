﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClashNSmash
{
    public struct coord
    {
        public int x;
        public int y;

        public coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Level
    {
        List<Character> characters = new List<Character>();
        Character player;
        public Tile[,] map;
        private int xSize, ySize;
        public int XSize { get { return xSize; } }
        public int YSize { get { return ySize; } }

        public Level()
        {
            xSize=10; ySize=10;
            // 219 █
            // 254 ■
            // 153 Ö
            map = new Tile[xSize,ySize];
            player = new Player();

            buildDefault();
        }
        public Level(int x,int y)
        {
            xSize = x; ySize = y;
            map = new Tile[xSize, ySize];
            player = new Player();

            buildDefault();
        }
        public Tile getTile(int x, int y)
        {
            return map[x, y];
        }
        public void movePlayer (int dx, int dy)
        {
            if (player.getPos().x + dx < xSize && player.getPos().x + dx >= 0 &&
                player.getPos().y + dy < ySize && player.getPos().y + dy >= 0 &&
                map[player.getPos().x + dx, player.getPos().y + dy].getIcon() == ' ')
            {
                map[player.getPos().x + dx, player.getPos().y + dy].setOccupant(player);
                map[player.getPos().x, player.getPos().y].setOccupant(null);
                player.setPos(new coord(player.getPos().x + dx, player.getPos().y + dy));
            }
        }

        public void buildDefault()
        {
            for (int x = 0; x < xSize; x++)
                for (int y = 0; y < ySize; y++)
                    map[x,y] = new Tile("Floor");
            for (int y = 0; y < ySize; y++)
            {
                map[0,y] = new Tile("wall");
                map[xSize-1,y] = new Tile("wall");
            }
            for (int x = 2; x < xSize-1; x++)
            {
                map[x,0] = new Tile("wall");
                map[x,ySize-1] = new Tile("wall");
            }
            map[2,2].setOccupant(player);
            map[4, 2].setOccupant(new Enemy());
            player.setPos(new coord(2,2));
        }

        public override string ToString()
        {
            string returnString = "";
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    returnString += map[x,y].getIcon() + " ";
                }
                returnString += "\n";
            }
            return returnString;
        }
    }
}