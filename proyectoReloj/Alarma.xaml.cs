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
    /// Lógica de interacción para Alarma.xaml
    /// </summary>
    public partial class Alarma : Window
    {
        private DispatcherTimer timer;
        public Alarma()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Muestra un mensaje de alerta al usuario
            MessageBox.Show("¡Alarma activada!", "Alarma", MessageBoxButton.OK, MessageBoxImage.Warning);

            // Detiene el temporizador
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
        }

        private void btnActivar_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene la hora y el minuto seleccionados por el usuario
            int hora = int.Parse(cmbHora.SelectedValue.ToString());
            int minuto = int.Parse(cmbMinuto.SelectedValue.ToString());

            // Crea un DateTime con la hora y el minuto seleccionados
            DateTime horaAlarma = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);

            // Crea un DispatcherTimer para activar la alarma
            timer = new DispatcherTimer();
            timer.Interval = horaAlarma - DateTime.Now;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Habilita el botón de detener la alarma y deshabilita el botón de activar la alarma
            btnDetener.IsEnabled = true;
            btnActivar.IsEnabled = false;
        }

        private void btnDetener_Click(object sender, RoutedEventArgs e)
        {
            // Detiene el temporizador
            timer.Stop();

            // Deshabilita el botón de detener la alarma y habilita el botón de activar la alarma
            btnDetener.IsEnabled = false;
            btnActivar.IsEnabled = true;

        }
    }
}
