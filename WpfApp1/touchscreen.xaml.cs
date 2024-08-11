using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für touchscreen.xaml
    /// </summary>
    public partial class touchscreen : Window
    {
        public touchscreen()
        {
            InitializeComponent();
            CreateButtons();

            Button bt1 = new Button();

            bt1.Height = 200;
            bt1.Width = 100;
            bt1.Name = "Button_1";
            bt1.Visibility = Visibility.Visible;
        }
        public void CreateButtons()
        {

        }
    }
}
