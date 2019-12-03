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
    class Game
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
        public Game(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            mapText = file.ReadToEnd().Split(new string[] { "\r\nBREAK\r\n" }, StringSplitOptions.None);
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
            LastEnemy = null;
            if (floor < mapText.Length - 1)
            {
                GenerateFloor(++floor);
                battleLogText += "Now entering floor " + (floor + 1) + '\n';
            }
            else
                gameWin = true;
        }
        public void GenerateFloor(int floor)
        {
            Map = new Map(mapText[floor]);
            AddCharacters(mapText[floor]);
        }
        public bool GetGameWin()
        {
            return gameWin;
        }
        public void EnemiesAct()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                if (characters[i].Alive)
                {
                    coord moveCoord = characters[i].Patrol(map);
                    Move(characters[i], moveCoord.x, moveCoord.y);
                }
                else
                {
                    map.getTile(characters[i].X, characters[i].Y).SetOccupant(null);
                    characters.RemoveAt(i);
                    i--;
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
                    if (split[y][x] != ' ' && split[y][x] != 'w' && split[y][x] != '+')
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
                    if (player == null)
                        player = new Player();
                    player.X = x;
                    player.Y = y;
                    map.getTile(x,y).SetOccupant(player);
                    break;
                case 'G':
                    newCharacter = new GelCube();
                    newCharacter.X = x;
                    newCharacter.Y = y;
                    characters.Add((Enemy)newCharacter);
                    map.getTile(x, y).SetOccupant(newCharacter);
                    break;
                case 'S':
                    newCharacter = new Snake();
                    newCharacter.X = x;
                    newCharacter.Y = y;
                    characters.Add((Enemy)newCharacter);
                    map.getTile(x, y).SetOccupant(newCharacter);
                    break;
                case 'D':
                    newCharacter = new Dragon();
                    newCharacter.X = x;
                    newCharacter.Y = y;
                    characters.Add((Enemy)newCharacter);
                    map.getTile(x, y).SetOccupant(newCharacter);
                    break;
            }
        }
        public void Move (Character actor, int dx, int dy)
        {
            //If no movement, leave method
            if (dy == 0 && dx == 0)
            {
                return;
            }

            //Wrapping position from one edge of map to the other
            int targetX = actor.X+dx;
            int targetY = actor.Y+dy;
            if (targetX > Map.Width - 1)
                targetX -= Map.Width;
            else if (targetX < 0)
                targetX += Map.Width;
            if (targetY > Map.Height - 1)
                targetY -= Map.Height;
            else if (targetY < 0)
                targetY += Map.Height;


            Tile targetTile = Map.Tiles[targetX, targetY];
            if (targetTile.GetIcon() == '+' && actor == player)
            {
                DownStairs();
            }
            else if (targetTile.GetIcon() == 'C' && actor == player)
            {
                gameWin = true;
            }
            else if (targetTile.GetIcon() != 'w')
            {
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
                    if (actor is Enemy && target is Enemy) //Don't let enemies hit each other
                        return;
                    if (actor is Player)
                        lastEnemy = target;
                    int damageDealt = actor.dealAttack(target);
                    battleLogText += actor.Name + " " + actor.AttackVerb +" " + target.Name + ", dealing " + damageDealt + " damage!\n";
                    if (!target.Alive)
                    {
                        targetTile.SetOccupant(null);
                        lastEnemy = null;
                        battleLogText += target.DeathText + '\n';
                        actor.Score += target.Score;
                    }
                }
            }
        }
    }
}
