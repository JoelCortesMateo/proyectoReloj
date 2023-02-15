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
            Restart.IsEnabled= false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tempo.Content = time.ToString();
            if (time <= 0)
            {
                timer.Stop();
                MessageBox.Show("¡TIEMPO!");
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Restart.IsEnabled = false;
            if(time == 0) 
            { 
                time = int.Parse(timerTextBox.Text);
                timer.Start();
                timerTextBox.Text = "0";
            }
            else if(time > 0)
            {
                timer.Start();
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Restart.IsEnabled= true;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            tempo.Content = "0";
            timer.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Cronometro crono = new Cronometro();
            crono.Show();
            Hide();
        }
    }
}
