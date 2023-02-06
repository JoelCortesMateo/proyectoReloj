﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace proyectoReloj
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            fecha.Text = DateTime.Now.ToString("d");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void alarma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void temporizador_Click(object sender, RoutedEventArgs e)
        {
            Temporizador tempo = new Temporizador();
            tempo.Show();
            Hide();
        }

        private void cronometro_Click(object sender, RoutedEventArgs e)
        {
            Cronometro crono = new Cronometro();
            crono.Show();
            Hide();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }

    }

}
