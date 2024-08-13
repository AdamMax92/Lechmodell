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
using System.Windows.Forms;
using System.Configuration;
using System.Text.Json;
using System.Xml.Linq;
using System.IO;
using System.Text.Json.Nodes;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für touchscreen.xaml
    /// </summary>
    public partial class touchscreen : Window
    {
        public touchscreen()
        {
            int buttons_counter = 0;
            InitializeComponent();
            buttons_counter = CfgRead();
            InitializeButtons(buttons_counter);

        }
        public void InitializeButtons(int buttons_counter)
        {
            int count = 1;
            // i = columns
            // j = rows
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    System.Windows.Controls.Button touchscreen_button = new System.Windows.Controls.Button();
                    touchscreen_button.Content = count.ToString();
                    touchscreen_button.Name = "Button" + count.ToString();
                    touchscreen_button.Margin = new Thickness(30, 30, 30, 30);

                    Grid.SetColumn(touchscreen_button, j);
                    Grid.SetRow(touchscreen_button, i);
                    touchscreen_grid.Children.Add(touchscreen_button);
                    count++;

                    if (count == buttons_counter) break;
                }
            }
        }

        public int CfgRead()
        {
            StreamReader reader = new StreamReader("cfg.json");

            var jsonCFG = File.ReadAllText("cfg.json");
            string data = reader.ReadToEnd();

            var jsonObject = JsonNode.Parse(data).AsObject();

            var number = jsonObject["fruit"].AsValue();
            int cnt = (int)number;

            if (cnt > 25) cnt = 25;

            return cnt;
            
        }
    }
}
