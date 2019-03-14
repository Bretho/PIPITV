using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PIPITV
{
    class MediaListSerializer
    {
        public void Serialisieren (string filepath, List<media> medialist)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<media>));
            StreamWriter schreiber = new StreamWriter(filepath);
            serializer.Serialize(schreiber, medialist);
        }
    }
}
