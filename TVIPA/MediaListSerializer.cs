using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PIPITV
{
    public class MediaListSerializer
    {
        public void Serialisieren (string filepath, List<media> medialist)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<media>));
            StreamWriter schreiber = new StreamWriter(filepath);
            serializer.Serialize(schreiber, medialist);
            schreiber.Close();
        }

        public List<media> Deserialisieren (string filepath)
        {
            List<media> medialist = new List<media>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<media>));
            StreamReader leser = new StreamReader(filepath);
            medialist = (List<media>)serializer.Deserialize(leser);
            leser.Close();
            return medialist;
        }
    }
}
