﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIPITV
{
    class mediaManager
    {
        private List<media> _medialist = new List<media>();

        public List<media> medialist
        {
            get { return _medialist; }
            set { _medialist = value; }
        }

        public media mediaauswahl(media ubergabe)
        {
            media m2 = new media();
            for (int i = 0; i < medialist.Count; i++)
            {
                if (medialist[i].name == ubergabe.name)
                {
                    m2.name = medialist[i].name;
                    m2.logo = medialist[i].logo;
                    m2.link = medialist[i].link;
                    m2.group = medialist[i].group;
                    return m2;
                }
            }
            return null;
        }

        public void mediaersatz(media ubergabe, string nameu, string logou, string linku, string groupu)
        {
            for (int i = 0; i < medialist.Count; i++)
            {
                if (medialist[i].name == ubergabe.name)
                {
                    medialist[i].name = nameu;
                    medialist[i].logo = logou;
                    medialist[i].link = linku;
                    medialist[i].group = groupu;
                }
            }
        }

    }
}
