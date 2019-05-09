using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; // Important
using System.IO; // Important

namespace PIPITV
{
    public class MediaListSerializer
    {
        public void Serialisieren (string filepath, List<media> medialist)
        {
            // Erstellt einen neuen serializer vom Typ List
            XmlSerializer serializer = new XmlSerializer(typeof(List<media>));
            // Erstellt einen neuen StreamWriter und öffnet den Pfad
            StreamWriter schreiber = new StreamWriter(filepath);
            // mit dem "schreiber" schreibt er in die Datei aus "medialist"
            serializer.Serialize(schreiber, medialist);
            schreiber.Close();
        }

        public List<media> Deserialisieren (string filepath)
        {
            List<media> medialist = new List<media>();  // Erstellt neue MediaList
            // Erstellt einen neuen serializer vom Typ List
            XmlSerializer serializer = new XmlSerializer(typeof(List<media>));  
            StreamReader leser = new StreamReader(filepath);     // Erstellt einen neuen StreamReader
            medialist = (List<media>)serializer.Deserialize(leser);  // (Casted) Wandelt 
            leser.Close();  // Schließt die Datei
            return medialist;   // Gibt den Inhalt der medialist zurück
        }
    }
}
