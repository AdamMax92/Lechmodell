﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Screen first_screen = Screen.AllScreens[0];
            Screen second_screen = Screen.AllScreens[1];

            System.Drawing.Rectangle thirdScreen = second_screen.WorkingArea;
            System.Drawing.Rectangle firstScreen = first_screen.WorkingArea;

            touchscreen touchS = new touchscreen();
            videoplayer videoS = new videoplayer();

            touchS.WindowStartupLocation = WindowStartupLocation.Manual;
            videoS.WindowStartupLocation = WindowStartupLocation.Manual;

            touchS.Left = thirdScreen.Left;
            videoS.Left = firstScreen.Left;
                        
            touchS.Show();
            videoS.Show();

            /*
                touchS.WindowStyle = WindowStyle.None;
                touchS.WindowState = WindowState.Maximized;

                videoS.WindowStyle = WindowStyle.None;
                videoS.WindowState = WindowState.Maximized;
            */

            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Windows.Controls.Button MyControl1 = new System.Windows.Controls.Button();
                    MyControl1.Content = count.ToString();
                    MyControl1.Name = "Button" + count.ToString();

                    Grid.SetColumn(MyControl1, j);
                    Grid.SetRow(MyControl1, i);
                    main_window_grid.Children.Add(MyControl1);

                    count++;
                }
            }
        }
    }
}