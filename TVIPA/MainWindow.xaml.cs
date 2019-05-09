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
using Microsoft.Win32; // Importent
using System.Data; // Importent
using System.IO;  // Importent

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
                Save_in_db.IsEnabled = true;
            }         
        }

        private void Bearbeiten(object sender, RoutedEventArgs e)
        {
            Bearbeiten b = new Bearbeiten();                            // Erstellt das Fenster Bearbeiten  
            media change = new media();                                 // Erstellt ein nues Objekt vom Typ Media
            b.Show();                                                   // Zeigt das Fenster b (Bearbeiten) an 
            change = io.m1.mediaauswahl((media)Combi.SelectedValue);    // Man übergibt die Ausgewählte Reihe 
                                                                        // (Castet sie) und macht zu einen Typ Media
            b.holder = change;                                          // Setzt den Holder in b rein
            b.name.Text = change.Name;                                  // das setzt den Text in b rein    
            b.gruppe.Text = change.Gruppe;                              // usw..
            b.logo.Text = change.Logo;
            b.link.Text = change.Link;
        }

        private void Combi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bearbeitung.IsEnabled = true;  // Aktiviert den Button (DataGrid)
        }

        private void Aktualisieren(object sender, RoutedEventArgs e)
        {
            Combi.Items.Refresh();  // Aktualisiert die Quelle 
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog speichern = new SaveFileDialog();
            speichern.Filter = "XML-Datei (*.xml)|*.xml";
            if (speichern.ShowDialog() == true)
            {
                io.mls.Serialisieren(speichern.FileName, io.m1.medialist);
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog einlesen = new OpenFileDialog();     // Erstellt eine neuen FileDialog
            einlesen.Filter = "XML-Datei (*.xml)|*.xml";
            if (einlesen.ShowDialog() == true)                  // Führt funktion aus wenn die Datei Erfolgreich ausgewählt wurde
            {
                io.m1.medialist = io.mls.Deserialisieren(einlesen.FileName); // Übergibt den Datein Pfad in die Funktion Deserialisieren
                Combi.ItemsSource = io.m1.medialist;                         // Füllt die Sachen in den DataGrid
                aktualisieren.IsEnabled = true;         // Aktiviert den Button 
                export.IsEnabled = true;                // Aktiviert den Button 
                Save_in_db.IsEnabled = true;
            }
        }

        private void DBImport_Click(object sender, RoutedEventArgs e)
        {
            io.m1.getMedia();
            Combi.ItemsSource = io.m1.medialist;
            aktualisieren.IsEnabled = true;
            export.IsEnabled = true;
            Save_in_db.IsEnabled = true;
        }

        private void DBSave_Click(object sender, RoutedEventArgs e)
        {
            io.m1.SaveMediaInDB();
        }
    }
}
