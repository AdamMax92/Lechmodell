using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        touchscreen touchScreen = new touchscreen();
        videoplayer videoScreen = new videoplayer();

        public MainWindow()
        {
            this.Visibility = Visibility.Hidden;
            InitializeComponent();
            Init_Screens();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);   //sekunden timer für videoplayer
            dispatcherTimer.Start();

        }

        public void Init_Screens()
        {
            Screen first_screen = Screen.AllScreens[touchScreen.screenIdTouch];
            Screen second_screen = Screen.AllScreens[touchScreen.screenIdVideo];

            System.Drawing.Rectangle firstScreen = first_screen.WorkingArea;
            System.Drawing.Rectangle secondScreen = second_screen.WorkingArea;

            videoScreen.Left = firstScreen.Left;
            touchScreen.Left = secondScreen.Left;

            touchScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            videoScreen.WindowStartupLocation = WindowStartupLocation.Manual;

            touchScreen.Show();
            videoScreen.Show();

            touchScreen.WindowStyle = WindowStyle.None;
            touchScreen.WindowState = WindowState.Maximized;

            videoScreen.WindowStyle = WindowStyle.None;
            videoScreen.WindowState = WindowState.Maximized;

        }
        public void Play_Files_Loop(int video_index)
        {
            if (touchScreen.which_button_is_pressed != 0)
            {
                string path = "video_" + video_index +".mp4";

                videoScreen.contentPlayer.Source = new Uri(path, UriKind.RelativeOrAbsolute);
                videoScreen.contentPlayer.ScrubbingEnabled = true;

                videoScreen.contentPlayer.Play();
                touchScreen.which_button_is_pressed = 0;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Play_Files_Loop(touchScreen.which_button_is_pressed);
        }
    }
}