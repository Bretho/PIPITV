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

        private void Auswahl_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Dateien (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                io.csv.csvRead(openFileDialog.FileName, io.m1);
                Combi.ItemsSource = io.m1.medialist;
                aktualisieren.IsEnabled = true;
                export.IsEnabled = true;
            }         
        }

        private void Bearbeiten(object sender, RoutedEventArgs e)
        {
            Bearbeiten b = new Bearbeiten();
            media change = new media();
            b.Show();
            change = io.m1.mediaauswahl((media)Combi.SelectedValue);
            b.holder = change;
            b.name.Text = change.Name;
            b.gruppe.Text = change.Gruppe;
            b.logo.Text = change.Logo;
            b.link.Text = change.Link;
        }

        private void Combi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bearbeitung.IsEnabled = true;
        }

        private void Aktualisieren(object sender, RoutedEventArgs e)
        {
            Combi.Items.Refresh();
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog speichern = new SaveFileDialog();
            speichern.Filter = "XML-Datei (*.xml)|*.xml";
       
            if (speichern.ShowDialog() == true)
            {
                io.martin.Serialisieren(speichern.FileName, io.m1.medialist);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog einlesen = new OpenFileDialog();
            einlesen.Filter = "XML-Datei (*.xml)|*.xml";
            if (einlesen.ShowDialog() == true)
            {
                io.m1.medialist = io.martin.Deserialisieren(einlesen.FileName, io.m1.medialist);
                Combi.ItemsSource = io.m1.medialist;
                aktualisieren.IsEnabled = true;
                export.IsEnabled = true;
            }
        }
    }
}
