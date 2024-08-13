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

            for (int i = 0; i < 5; i++)
            {
                System.Windows.Controls.Button newBtn = new Button();

                newBtn.Content = i.ToString();
                newBtn.Name = "Button" + i.ToString();

                touchscreen_grid.SetValue(Grid.RowProperty, i);
                touchscreen_grid.SetValue(Grid.ColumnProperty, i);
                touchscreen_grid.Children.Add(newBtn);
            }
        }
    }
}
