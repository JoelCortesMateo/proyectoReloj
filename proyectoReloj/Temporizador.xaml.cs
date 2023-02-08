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
    /// Lógica de interacción para Temporizador.xaml
    /// </summary>
    public partial class Temporizador : Window
    {
        private DispatcherTimer timer;
        private int time;
        public Temporizador()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            timerLabel.Content = time.ToString();
            if (time == 0)
            {
                timer.Stop();
                MessageBox.Show("¡TIEMPO!");
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            time = int.Parse(timeTextBox.Text);
            timer.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            timerLabel.Content = "0";
            timer.Stop();
        }
    }
}
