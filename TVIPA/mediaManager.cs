using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PIPITV
{
    class mediaManager
    {
        private DB_Connection _dbc = new DB_Connection();
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

        public void getMedia()
        {
            DataTable dt = new DataTable();
            string qry = "SELECT * FROM tbl_Movement";
            _dbc.conOpen();
            dt = _dbc.getData(qry);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                media m = new media();
                m.name = dt.Rows[i]["Name"].ToString();
                m.logo = dt.Rows[i]["Logo"].ToString();
                m.link = dt.Rows[i]["Link"].ToString();
                m.group = dt.Rows[i]["Gruppe"].ToString();
                medialist.Add(m);

            }
            _dbc.conClose();
        }

    }
}
