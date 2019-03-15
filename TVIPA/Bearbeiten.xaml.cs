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

namespace PIPITV
{
    /// <summary>
    /// Interaktionslogik für Bearbeiten.xaml
    /// </summary>
    public partial class Bearbeiten : Window
    {
        IOController io = IOController.instance;
        public media holder = null;

        public Bearbeiten()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            io.m1.mediaersatz(holder, name.Text, logo.Text,link.Text,gruppe.Text);
        }
    }
}
