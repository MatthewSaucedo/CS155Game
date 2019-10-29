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
        static BitmapImage grassBitmap = new BitmapImage(new Uri(@"\Images\Plains.png", UriKind.Relative));
        static BitmapImage wallBitmap = new BitmapImage(new Uri(@"\Images\Wall.png", UriKind.Relative));
        static BitmapImage playerBitmap = new BitmapImage(new Uri(@"\Images\tempchar.png", UriKind.Relative));
        static BitmapImage skeletonBitmap = new BitmapImage(new Uri(@"\Images\tempskeleton.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();

            level = new Level();

            gridInit();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void gridInit()
        {
            MapGrid.Width = level.XSize * 32;
            MapGrid.Height = level.YSize * 32;
            for (int column = 0; column < level.XSize; column++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < level.YSize; row++)
            {
                MapGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int column = 0; column < level.XSize; column++)
            {
                for (int row = 0; row < level.YSize; row++)
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
            foreach (Image child in MapGrid.Children)
            {
                Char tempTileChar = level.getTile(Grid.GetColumn(child), Grid.GetRow(child)).getIcon();
                if (tempTileChar == '■')
                    child.Source = wallBitmap;
                else if (tempTileChar == ' ')
                    child.Source = grassBitmap;
                else if (tempTileChar == '@')
                    child.Source = playerBitmap;
                else if (tempTileChar == 'S')
                    child.Source = skeletonBitmap;
            }
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up)
            {
                level.movePlayer(0,-1);
                refresh();
            }
            if(e.Key == Key.Down)
            {
                level.movePlayer(0,1);
                refresh();
            }
            if(e.Key == Key.Right)
            {
                level.movePlayer(1,0);
                refresh();
            }
            if(e.Key == Key.Left)
            {
                level.movePlayer(-1,0);
                refresh();
            }
        }
    }
}
