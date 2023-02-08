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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace proyectoReloj
{
    /// <summary>
    /// Lógica de interacción para Cronometro.xaml
    /// </summary>
    public partial class Cronometro : Window
    {
        private DispatcherTimer timer;
        private TimeSpan elapsedTime;

        public Cronometro()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            reset.IsEnabled= false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            reset.IsEnabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(timer.Interval);
            TimeTextBlock.Text = elapsedTime.ToString("g");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(); 
            main.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           Temporizador tempo = new Temporizador();
            tempo.Show();
            Hide();
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            elapsedTime = TimeSpan.Zero;
            TimeTextBlock.Text = elapsedTime.ToString("G");
            reset.IsEnabled = false;
        }
    }
}
