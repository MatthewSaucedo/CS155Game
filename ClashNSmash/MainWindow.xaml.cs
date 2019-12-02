/// CS 155 Group Project
/// File Name: GoodTime.cs
/// @author: Monika and Matt
/// Date: December 2nd 2019
///
/// Problem Statement: (what you want the code to do)
///     Create a 2D dungeon crawler like Rogue and Wizardry
///
/// Overall Plan (step-by-step, how you want the code to make it happen):
///     Create a 2D array of objects representing a tile in the dungeon
///     Display the array to the user
///     Create a class representing entities such as Player and Enemy
///     Allow these entities to be pointed to by a tile to show where they are on the map
///     Allow Characters to move to a different tile on the board
///     Allow user to input commands to move their Player
///     Allow Characters to damage eachother by moving into eachother
///     Allow the program to create a map from a string
///     Allow the program to take in a text file and use the text in it to create the map
///     Allow the program to take in multiple map representations from a file, storing them in an array
///     Allow the program to generate a new map after it's initial generation
///     Give the Enemies methods to determine how they will move on their turn
///     Create a game over screen for when player health reaches 0
///     Only allow enemies to move after the player has moved
///     Create a game win scenario for when the player reaches the win tile
///     Show the user the players stats as well as the stats of the last attacked enemy
///     Show the user a log of what has happened in the game as far as attacks, deaths, floor progression etc
///     Allow the user to reset the game using the r key
///     
///     
///
/// Classes needed and Purpose (Input, Processing, Output)
/// MainWindow.xaml.cs - Driver and handles visuals and player input
/// Game.cs - Represents the full game, handles moving of characters and generation of floors
/// Map.cs - Represents a full floor of the games tiles
/// Tile.cs - Each instance represents one square of the game map
/// Character.cs - Class to represent entities in the game world
/// Player.cs - Specific character
/// Enemy.cs - Adds Patrol method to decide enemy movement
/// GelCube.cs - Specific enemy
/// Snake.cs - Specific enemy
/// Dragon.cs - Specific enemy
/// 
/// Import necessary C# or user-defined packages

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClashNSmash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        static BitmapImage floorBitmap = new BitmapImage(new Uri(@"\Images\Floor.png", UriKind.Relative));
        static BitmapImage wallBitmap = new BitmapImage(new Uri(@"\Images\Pillar.png", UriKind.Relative));
        static BitmapImage playerBitmap = new BitmapImage(new Uri(@"\Images\Player.png", UriKind.Relative));
        static BitmapImage gelatinousCubeBitmap = new BitmapImage(new Uri(@"\Images\gelatinousCube.png", UriKind.Relative));
        static BitmapImage snakeBitmap = new BitmapImage(new Uri(@"\Images\Snake.png", UriKind.Relative));
        static BitmapImage dragonBitmap = new BitmapImage(new Uri(@"\Images\Dragon.png", UriKind.Relative));
        static BitmapImage crownBitmap = new BitmapImage(new Uri(@"\Images\Crown.png", UriKind.Relative));
        static BitmapImage stairsDownBitmap = new BitmapImage(new Uri(@"\Images\StairsDown.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();

            Restart();

            GridInit();

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        //add image elements to the gui to represent the grid
        private void GridInit()
        {
            MapGrid.Width = game.Map.Width * 32;
            MapGrid.Height = game.Map.Height * 32;
            for (int column = 0; column < game.Map.Width; column++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < game.Map.Height; row++)
            {
                MapGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int column = 0; column < game.Map.Width; column++)
            {
                for (int row = 0; row < game.Map.Height; row++)
                {
                    Image tempImage = new Image();
                    Grid.SetRow(tempImage, row);
                    Grid.SetColumn(tempImage, column);
                    MapGrid.Children.Add(tempImage);
                }
            }
            RefreshImages();
        }
        private void Refresh()
        {
            //game win check
            if (game.GetGameWin()) GameEndLabel.Content = "WINNER\nSCORE " + game.Player.Score;

            //enemies take their turn
            game.EnemiesAct();
            if (!game.Player.Alive) GameEndLabel.Content = " LOSER\nSCORE " + game.Player.Score;

            //update battle log
            BattleLogScrollViewer.Content += game.ExtractBattleLog();
            BattleLogScrollViewer.ScrollToEnd();

            //update character status boxes
            PlayerInfoLabel.Content = "" + game.Player;
            EnemyInfoLabel.Content = "" + game.GetLastEnemy();

            //update images
            RefreshImages();
        }

        //update images
        public void RefreshImages()
        {
            foreach (Image child in MapGrid.Children)
            {
                Char tempTileChar = game.Map.Tiles[Grid.GetColumn(child), Grid.GetRow(child)].GetIcon();
                if (tempTileChar == 'w')
                    child.Source = wallBitmap;
                else if (tempTileChar == ' ')
                    child.Source = floorBitmap;
                else if (tempTileChar == '+')
                    child.Source = stairsDownBitmap;
                else if (tempTileChar == 'C')
                    child.Source = crownBitmap;
                else if (tempTileChar == '@')
                    child.Source = playerBitmap;
                else if (tempTileChar == 'S')
                    child.Source = snakeBitmap;
                else if (tempTileChar == 'G')
                    child.Source = gelatinousCubeBitmap;
                else if (tempTileChar == 'D')
                    child.Source = dragonBitmap;
            }
        }

        //Create new instance of Game and refresh visuals
        public void Restart()
        {
            GameEndLabel.Content = "";
            game = new Game("..\\..\\GameData.txt");
            PlayerInfoLabel.Content = "" + game.Player;
            RefreshImages();
        }

        //listeners
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up && game.Player.Alive)
            {
                game.Move(game.Player, 0,-1);
                Refresh();
            }
            if(e.Key == Key.Down && game.Player.Alive)
            {
                game.Move(game.Player, 0, 1);
                Refresh();
            }
            if(e.Key == Key.Right && game.Player.Alive)
            {
                game.Move(game.Player, 1, 0);
                Refresh();
            }
            if (e.Key == Key.Left && game.Player.Alive)
            {
                game.Move(game.Player, -1, 0);
                Refresh();
            }
            if (e.Key == Key.Space && game.Player.Alive)
            {
                Refresh();
            }
            if (e.Key == Key.R && game.Player.Alive)
            {
                Restart();
            }
        }
    }
}