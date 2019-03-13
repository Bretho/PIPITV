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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Data;
using System.IO;

namespace PIPITV
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IOController io = IOController.instance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Dateien (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                io.csv.csvRead(openFileDialog.FileName, io.m1);
                Combi.ItemsSource = io.m1.medialist;
                aktualisieren.IsEnabled = true;
            }
        }

        private void Bearbeiten(object sender, RoutedEventArgs e)
        {
            Bearbeiten b = new Bearbeiten();
            media change = new media();
            b.Show();
            change = io.m1.mediaauswahl((media)Combi.SelectedValue);
            b.holder = change;
            b.name.Text = change.name;
            b.gruppe.Text = change.group;
            b.logo.Text = change.logo;
            b.link.Text = change.link;
            this.Close();
        }

        private void Combi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bearbeitung.IsEnabled = true;
        }

        private void Aktualisieren(object sender, RoutedEventArgs e)
        {
            Combi.ItemsSource = io.m1.medialist;
        }
    }
}
