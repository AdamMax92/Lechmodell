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
    /// Interaktionslogik für videoplayer.xaml
    /// </summary>
    public partial class videoplayer : Window
    {
        public videoplayer()
        {
            InitializeComponent();

            Console.WriteLine("Mediaplayer-Class called");

            contentPlayer.LoadedBehavior = MediaState.Manual;
            contentPlayer.Play();

        }
    }
}
