using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClashNSmash
{
    public struct coord
    {
        public int x;
        public int y;
        public coord (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Level
    {
        //variables
        private Map map;
        private List<Enemy> characters = new List<Enemy>();
        private Player player;
        private Character lastEnemy;
        private bool gameWin = false;
        private string battleLogText;
        private string[] mapText;
        private int floor = 0;

        //properties
        public Player Player { get => player; set => player = value; }
        internal Map Map { get => map; set => map = value; }
        internal Character LastEnemy { get => lastEnemy; set => lastEnemy = value; }

        //contructor
        public Level()
        {
            StreamReader file = new StreamReader("..\\..\\LevelData.txt");
            mapText = file.ReadToEnd().Split(new string[] { "\r\nBREAK\r\n" }, StringSplitOptions.None);
            //string mapText = file.ReadToEnd();
            file.Close();
            GenerateFloor(floor);
        }

        //methods
        public Character GetLastEnemy()
        {
            return lastEnemy;
        }
        public void DownStairs()
        {
            if (floor < mapText.Length - 1)
                GenerateFloor(++floor);
            else
                gameWin = true;

        }
        public bool GameWin()
        {
            return gameWin;
        }
        public void GenerateFloor(int floor)
        {
            Map = new Map(mapText[floor]);
            AddCharacters(mapText[floor]);
        }
        public void enemiesAct()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                if (characters[i].Alive)
                {
                    coord moveCoord = characters[i].patrolBlock(map);
                    move(characters[i], moveCoord.x, moveCoord.y);
                }
                else
                {
                    map.getTile(characters[i].X, characters[i].Y).SetOccupant(null);
                    characters.RemoveAt(i);
                }
            }
        }
        public string ExtractBattleLog()
        {
            string returnString = battleLogText;
            battleLogText = "";
            return returnString;
        }
        public void AddCharacters(string mapText)
        {
            characters.Clear();
            string[] split = mapText.Split('\n');
            int width = split[0].Length-1;
            int height = split.Length;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (split[y][x] != ' ' && split[y][x] != 'w')
                        AddCharacter(split[y][x], x, y);
                }
            }
        }
        public void AddCharacter (char type, int x, int y)
        {
            Character newCharacter;
            switch (type)
            {
                case '@':
                    newCharacter = new Player();
                    player = (Player)newCharacter;
                    newCharacter.X = x;
                    newCharacter.Y = y;
                    map.getTile(x,y).SetOccupant(newCharacter);
                    break;
                case 'G':
                    newCharacter = new GelCube();
                    newCharacter.X = x;
                    newCharacter.Y = y;
                    characters.Add((Enemy)newCharacter);
                    map.getTile(x,y).SetOccupant(newCharacter);
                    break;
            }
        }
        public void move (Character actor, int dx, int dy)
        {
            Tile targetTile;
            int targetX = actor.X + dx;
            int targetY = actor.Y + dy;

            if (targetX > Map.Width - 1)
                targetX -= Map.Width;
            if (targetX < 0)
                targetX += Map.Width;
            if (targetY > Map.Height - 1)
                targetY -= Map.Height;
            if (targetY < 0)
                targetY += Map.Height;
            targetTile = Map.Tiles[targetX, targetY];
            if (targetTile.GetIcon() == '+' && actor == player)
            {
                DownStairs();
            }
            else if (targetTile.GetIcon() != 'w')
            {
                targetTile = Map.Tiles[targetX, targetY];
                // Move onto empty space
                if (targetTile.GetOccupant() == null)
                {
                    targetTile.SetOccupant(actor);
                    Map.Tiles[actor.X, actor.Y].SetOccupant(null);
                    actor.X = targetX;
                    actor.Y = targetY;
                }
                // Interract with occupant of occupied space
                else
                {
                    Character target = targetTile.GetOccupant();
                    int damageDealt = actor.dealAttack(target);
                    battleLogText += actor.Name + " strikes " + target.Name + ", dealing " + damageDealt + " damage!\n";
                    if (!target.Alive)
                    {
                        targetTile.SetOccupant(null);
                        lastEnemy = null;
                        battleLogText += "The " + target.Name + " is slain...\n";
                    }
                    /* retaliation?
                    else
                    {
                        int damageTaken = target.dealAttack(actor);
                        battleLogText += target.Name + " retaliates at " + actor.Name + ", you take " + damageTaken + " damage!\n";
                        lastEnemy = target;
                        if (actor.Health <= 0)
                        {
                            Map.Tiles[actor.X, actor.Y].SetOccupant(null);
                            battleLogText += "- G A M E   O V E R -\n";
                        }
                    }
                    */
                }
            }
        }
    }
}
