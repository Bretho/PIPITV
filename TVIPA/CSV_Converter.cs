using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// Impotent

namespace PIPITV
{
    class CSV_Converter
    {
        // Braucht den Filepath und den Manager (nur der Klasse die befüllt wird)
        public void csvRead(string path, mediaManager manager) 
        {
            // Erstellt den StreamReader und übergibt den Path
            StreamReader reader = new StreamReader(path);
            // Trifft nur auf das Programm zu
            // Falls 2 Zeilen zusammen gehören
            int counter = 1;
            // Liest die Reihen
            reader.ReadLine();
            // Setzt alle Werte auf null (Sonst funktioniert das nicht)
            media mediasv = null;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split('"');
                // Universal lösung items.Length falls die Anzahl nicht bekannt ist
                for (int i = 0; i < 9 ; i++)
                {
                    items[i] = items[i].Replace("$)C", ""); // fix shitty CSV
                }
                // Hier wird zwischen gerader und ungerader Zeile unterschieden
                if (counter % 2 != 0)
                {
                    mediasv = new media();
                    mediasv.Name = items[1];
                    mediasv.Gruppe = items[5];
                    mediasv.Logo = items[7];
                }
                else
                {
                    mediasv.Link = items[0];
                    manager.medialist.Add(mediasv);
                }
                counter++;
            }
        }
    }
}
