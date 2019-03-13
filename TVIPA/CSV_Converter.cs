using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PIPITV
{
    class CSV_Converter
    {
        public void csvRead(string path, mediaManager manager)
        {
            StreamReader reader = new StreamReader(path);
            int counter = 1;
            reader.ReadLine();
            media mediasv = null;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split('"');
                for (int i = 0; i < 9; i++)
                {
                    items[i] = items[i].Replace("$)C", "");
                }
                if (counter % 2 != 0)
                {
                    mediasv = new media();
                    mediasv.name = items[1];
                    mediasv.group = items[5];
                    mediasv.logo = items[7];
                }
                else
                {
                    mediasv.link = items[0];
                    manager.medialist.Add(mediasv);
                }
                counter++;
            }
        }
    }
}
