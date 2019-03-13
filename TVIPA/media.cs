using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIPA
{
    class media
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _group;

        public string group
        {
            get { return _group; }
            set { _group = value; }
        }
        private string _link;

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }
        private string _logo;

        public string logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
    }
}
