using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Life.Domain;
using System.Threading;
using System.Windows.Threading;

namespace Life
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent ();

            _drawer = new UniverseDrawer (universeCanvas);
        }

        private Universe _universe;
        private readonly UniverseDrawer _drawer;
        private bool _stop = false;

        private void btnStart_Click( object sender, RoutedEventArgs e )
        {
            btnStart.IsEnabled = false;
            btnInitRandom.IsEnabled = false;
            btnGliderAndSpaceship.IsEnabled = false;
            btnStop.IsEnabled = true;

            _stop = false;

            lblIteration.Content = "Iteration 0";

            int generation = 0;

            //Canvas.SetLeft (r, 50);
            while( !_stop )
            {
                _universe = _universe.Evolve ();
                _drawer.DrawUniverse (_universe);

                _stop = _universe.Stable == true;

                lblIteration.Content = "Iteration: " + ++generation;
                Application.Current.Dispatcher.Invoke (DispatcherPriority.Background,
                                          new Action (delegate { }));
            }

            btnStart.IsEnabled = true;
            btnInitRandom.IsEnabled = true;
            btnGliderAndSpaceship.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnStop_Click( object sender, RoutedEventArgs e )
        {
            _stop = true;
        }

        const int _cellSize = 10;



        private void Window_Loaded( object sender, RoutedEventArgs e )
        {

            var universeWidth = (int)universeCanvas.ActualWidth / _cellSize;
            var universeHeight = (int)universeCanvas.ActualHeight / _cellSize;

            _universe = Universe.GenerateWithOneGlider (universeHeight, universeWidth);

            //WriteableBitmap b = new WriteableBitmap ();
            //b.backread
            _drawer.DrawUniverse (_universe);

            btnStart.IsEnabled = true;
            btnInitRandom.IsEnabled = true;
            btnGliderAndSpaceship.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnGliderAndSpaceship_Click( object sender, RoutedEventArgs e )
        {
            var universeWidth = (int)universeCanvas.ActualWidth / _cellSize;
            var universeHeight = (int)universeCanvas.ActualHeight / _cellSize;

            _universe = Universe.GenerateWithOneGlider (universeHeight, universeWidth);

            _drawer.DrawUniverse (_universe);
        }

        private void btnInitRandom_Click( object sender, RoutedEventArgs e )
        {
            var universeWidth = (int)universeCanvas.ActualWidth / _cellSize;
            var universeHeight = (int)universeCanvas.ActualHeight / _cellSize;

            _universe = Universe.Generate (universeHeight, universeWidth);

            _drawer.DrawUniverse (_universe);
        }
    }
}
