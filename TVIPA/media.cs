using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PIPITV
{ //[XmlRoot("media")]   <----- das muss nur wenns in der xml anders heißt.
    public class media
    {
        // Wann Attribute und wann Element? hier ist die Antwort!!!
        // Attribute wenns so aussieht oder aussehen soll:  -<media name="Das Erste HD">
        // Element wenns so aussieht oder aussehen soll: <group>Vollprogramm</group>

        private string _name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _group;
        [XmlElement("group")]
        public string Gruppe
        {
            get { return _group; }
            set { _group = value; }
        }
        private string _link;
        [XmlElement("link")]
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }
        private string _logo;
        [XmlElement("logo")]
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
    }
}
