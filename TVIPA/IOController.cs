using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIPITV
{
    class IOController
    {
        // Erstellt eine neue Instance
        private static IOController _instance;
        public static IOController instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IOController();
                return _instance;
            }
        }

        //  Erstellt Manager (propfull)
        private mediaManager _m1 = new mediaManager();
        public mediaManager m1
        {
            get { return _m1; }
            set { _m1 = value; }
        }

        private CSV_Converter _csv = new CSV_Converter();
        public CSV_Converter csv
        {
            get { return _csv; }
            set { _csv = value; }
        }

        private MediaListSerializer _mls = new MediaListSerializer();
        public MediaListSerializer mls
        {
            get { return _mls; }
            set { _mls = value; }
        }

    }
}
