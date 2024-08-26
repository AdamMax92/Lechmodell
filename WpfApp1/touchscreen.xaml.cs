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
    /// 


    public partial class touchscreen : Window
    {
        const int MAXIMUM_OF_BUTTONS = 25;
        public string[] button_content_description = new string[MAXIMUM_OF_BUTTONS];
        public int button_fontsize = 12;
        public int which_button_is_pressed = 0;

        public int screenIdTouch = 0;
        public int screenIdVideo = 1;

        public touchscreen()
        {
            int buttons_counter = 0;
            InitializeComponent();
            buttons_counter = CfgRead();
            InitializeButtons(buttons_counter);

        }

        public void Button_Click_Event (object sender, EventArgs e)
        {

            System.Windows.Controls.Button button_object = (System.Windows.Controls.Button) sender;

            for (int i = 1; i <= MAXIMUM_OF_BUTTONS; i++)
            {
                if (button_object.Name == "Button_" + i)
                {
                    which_button_is_pressed = i;
                    break;
                }
            }
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

                    touchscreen_button.Content = button_content_description[count - 1];
                    touchscreen_button.Name = "Button_" + count.ToString();
                    touchscreen_button.Margin = new Thickness(30, 30, 30, 30);
                    touchscreen_button.FontSize = button_fontsize;
                    touchscreen_button.Click += new RoutedEventHandler(this.Button_Click_Event);

                    Grid.SetColumn(touchscreen_button, j);
                    Grid.SetRow(touchscreen_button, i);
                    touchscreen_grid.Children.Add(touchscreen_button);
                    count++;

                    if (count == buttons_counter + 1) return;
                }
            }
        }

        public int CfgRead()
        {
            StreamReader reader = new StreamReader("cfg.json");

            var jsonCFG = File.ReadAllText("cfg.json");
            string data = reader.ReadToEnd();

            var jsonObject = JsonNode.Parse(data).AsObject();

            var number = jsonObject["buttons"].AsValue();
            var obj_fontsize = jsonObject["fontsize"].AsValue();

            var screen_id_touch = jsonObject["screenIdTouch"].AsValue();
            var screen_id_video = jsonObject["screenIdVideo"].AsValue();

            screenIdTouch = (int)screen_id_touch;
            screenIdVideo = (int)screen_id_video;
            button_fontsize = (int)obj_fontsize;
            int cnt = (int)number;

            for (int i = 1; i <= MAXIMUM_OF_BUTTONS; i++)
            {
                String text = "Text_" + i;
                button_content_description[i - 1] = jsonObject[text].AsValue().ToString();
            }
            if (cnt > MAXIMUM_OF_BUTTONS) cnt = MAXIMUM_OF_BUTTONS;

            return cnt;
        }
    }
}
