using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIPA
{
    class IOController
    {
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



    }
}
