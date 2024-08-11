using System;
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

            Screen first = Screen.AllScreens[0];
            Screen third = Screen.AllScreens[2];
            System.Drawing.Rectangle thirdScreen = third.WorkingArea;
            System.Drawing.Rectangle firstScreen = first.WorkingArea;

            touchscreen touchS = new touchscreen();
            videoplayer videoS = new videoplayer();

            touchS.WindowStartupLocation = WindowStartupLocation.Manual;
            videoS.WindowStartupLocation = WindowStartupLocation.Manual;

            touchS.Left = thirdScreen.Left;
            videoS.Left = firstScreen.Left;

            touchS.Show();
            videoS.Show();

 
            touchS.WindowStyle = WindowStyle.None;
            touchS.WindowState = WindowState.Maximized;

            videoS.WindowStyle = WindowStyle.None;
            videoS.WindowState = WindowState.Maximized;
        }
    }
}
    /*
    private void setFormLocation(Form form, Screen screen)
    {
        // first method
        Rectangle bounds = screen.Bounds;
        form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

        // second method
        //Point location = screen.Bounds.Location;
        //Size size = screen.Bounds.Size;

        //form.Left = location.X;
        //form.Top = location.Y;
        //form.Width = size.Width;
        //form.Height = size.Height;
    }
    */