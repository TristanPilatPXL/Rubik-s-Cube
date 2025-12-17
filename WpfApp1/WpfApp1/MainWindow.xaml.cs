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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Brush[] _cubeColors =
            { Brushes.Blue, Brushes.Green, Brushes.Yellow, Brushes.Red, Brushes.White, Brushes.Orange };

        private int _colorIndex = 0;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var labels = rubriksGrid.Children.OfType<Label>().ToList();

            
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Background = _cubeColors[(_colorIndex + i) % _cubeColors.Length];
            }

            _colorIndex = (_colorIndex + 1) % _cubeColors.Length;
        }
    }
}