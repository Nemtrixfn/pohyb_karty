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

namespace lol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle karta;
        Point point;
        public MainWindow()
        {
            InitializeComponent();
            karta = new Rectangle();
            karta.Width = 50;
            karta.Height = 75;
            karta.Fill = new SolidColorBrush(Colors.Blue);
            karta.MouseMove += Karta_MouseMove;
            karta.MouseDown += Karta_MouseDown;
            karta.MouseUp += Karta_MouseUp;
            platno.Children.Add(karta);
            karta.Cursor = Cursors.Hand;
            Canvas.SetLeft(karta, 100);
            Canvas.SetTop(karta, 100);

        }

        private void Karta_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var newPoint = e.GetPosition(platno);
                var diffX = newPoint.X - point.X;
                var diffY = newPoint.Y - point.Y;   
                Canvas.SetLeft(karta,Canvas.GetLeft(karta) + diffX);
                Canvas.SetTop(karta,Canvas.GetTop(karta) + diffY);
                point = e.GetPosition(platno);


            }


        }

        private void Karta_MouseUp(object sender, MouseButtonEventArgs e)
        {
            karta.Cursor = Cursors.Hand;
        }

        private void Karta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            karta.Cursor = Cursors.ScrollAll;
            e.GetPosition(platno);
            point = e.GetPosition(platno);
            

        }
    }
}
