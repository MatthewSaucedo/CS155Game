using System;
using System.Collections.Generic;
using System.Text;

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
        private Map map;
        private List<Enemy> characters = new List<Enemy>();
        private Player player;
        private Character lastEnemy;
        private string battleLogText;

        public Player Player { get => player; set => player = value; }
        internal Map Map { get => map; set => map = value; }

        public Level()
        {
            Map = new Map();
            player = new Player();
            player.X = 2;
            player.Y = 2;
            Map.Tiles[2, 2].setOccupant(player);
            Enemy newEnemy = new Enemy();
            characters.Add(newEnemy);
            Map.Tiles[4, 2].setOccupant(newEnemy);
            newEnemy.X = 4;
            newEnemy.Y = 2;
            newEnemy = new Enemy();
            characters.Add(newEnemy);
            Map.Tiles[4, 4].setOccupant(newEnemy);
            newEnemy.X = 4;
            newEnemy.Y = 4;
        }
        public Character GetLastEnemy()
        {
            return lastEnemy;
        }
        public void enemiesAct()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                coord moveCoord = characters[i].patrolBlock();
                move(characters[i], moveCoord.x, moveCoord.y);
            }
        }

        public string ExtractBattleLog()
        {
            string returnString = battleLogText;
            battleLogText = "";
            return returnString;
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

            if (Map.Tiles[targetX, targetY].Icon != '■')
            {
                targetTile = Map.Tiles[targetX, targetY];
                // Move onto empty space
                if (targetTile.getOccupant() == null)
                {
                    targetTile.setOccupant(actor);
                    Map.Tiles[actor.X, actor.Y].setOccupant(null);
                    actor.X = targetX;
                    actor.Y = targetY;
                }
                // Interract with occupant of occupied space
                else
                {
                    Character target = targetTile.getOccupant();
                    int damageDealt = actor.dealAttack(target);
                    battleLogText += actor.Name + " strikes " + target.Name + ", dealing " + damageDealt + " damage!\n";
                    if (target.Existence == false)
                    {
                        targetTile.setOccupant(null);
                        lastEnemy = null;
                        battleLogText += "The " + target.Name + " is slain...\n";
                    }
                    else
                    {
                        int damageTaken = target.dealAttack(actor);
                        battleLogText += target.Name + " retaliates at " + actor.Name + ", you take " + damageTaken + " damage!\n";
                        lastEnemy = target;
                        if (actor.Health <= 0)
                        {
                            Map.Tiles[actor.X, actor.Y].setOccupant(null);
                            battleLogText += "- G A M E   O V E R -\n";
                        }
                    }
                }
            }
        }
    }
}
