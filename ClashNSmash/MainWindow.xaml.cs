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
        Level level;
        static BitmapImage floorBitmap = new BitmapImage(new Uri(@"\Images\Floor.png", UriKind.Relative));
        static BitmapImage wallBitmap = new BitmapImage(new Uri(@"\Images\Pillar.png", UriKind.Relative));
        static BitmapImage playerBitmap = new BitmapImage(new Uri(@"\Images\Player.png", UriKind.Relative));
        static BitmapImage skeletonBitmap = new BitmapImage(new Uri(@"\Images\tempskeleton.png", UriKind.Relative));
        static BitmapImage gelatinousCubeBitmap = new BitmapImage(new Uri(@"\Images\gelatinousCube.png", UriKind.Relative));
        static BitmapImage stairsDownBitmap = new BitmapImage(new Uri(@"\Images\StairsDown.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();

            level = new Level();

            gridInit();

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void gridInit()
        {
            MapGrid.Width = level.Map.Width * 32;
            MapGrid.Height = level.Map.Height * 32;
            for (int column = 0; column < level.Map.Width; column++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < level.Map.Height; row++)
            {
                MapGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int column = 0; column < level.Map.Width; column++)
            {
                for (int row = 0; row < level.Map.Height; row++)
                {
                    Image tempImage = new Image();
                    Grid.SetRow(tempImage, row);
                    Grid.SetColumn(tempImage, column);
                    MapGrid.Children.Add(tempImage);
                }
            }
            refresh();
        }
        private void refresh()
        {
            BattleLogScrollViewer.Content += level.ExtractBattleLog();
            BattleLogScrollViewer.ScrollToEnd();

            if (!level.Player.Alive)
            {
                GameEndLabel.Content = "GAME OVER";
            }
            if (level.GameWin())
            {
                GameEndLabel.Content = "YOU WIN";
            }
            level.enemiesAct();
            PlayerInfoLabel.Content = "" + level.Player;
            EnemyInfoLabel.Content = "" + level.GetLastEnemy();
            foreach (Image child in MapGrid.Children)
            {
                Char tempTileChar = level.Map.Tiles[Grid.GetColumn(child), Grid.GetRow(child)].GetIcon();
                if (tempTileChar == 'w')
                    child.Source = wallBitmap;
                else if (tempTileChar == ' ')
                    child.Source = floorBitmap;
                else if (tempTileChar == '+')
                    child.Source = stairsDownBitmap;
                else if (tempTileChar == '@')
                    child.Source = playerBitmap;
                else if (tempTileChar == 'S')
                    child.Source = skeletonBitmap;
                else if (tempTileChar == 'G')
                    child.Source = gelatinousCubeBitmap;
            }
        }

        //listeners
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up && level.Player.Alive)
            {
                level.move(level.Player, 0,-1);
                refresh();
            }
            if(e.Key == Key.Down && level.Player.Alive)
            {
                level.move(level.Player, 0, 1);
                refresh();
            }
            if(e.Key == Key.Right && level.Player.Alive)
            {
                level.move(level.Player, 1, 0);
                refresh();
            }
            if(e.Key == Key.Left && level.Player.Alive)
            {
                level.move(level.Player, -1,0);
                refresh();
            }
        }
    }
}