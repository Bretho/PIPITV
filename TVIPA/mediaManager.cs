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
                if (medialist[i].Name == ubergabe.Name)
                {
                    m2.Name = medialist[i].Name;
                    m2.Logo = medialist[i].Logo;
                    m2.Link = medialist[i].Link;
                    m2.Gruppe = medialist[i].Gruppe;
                    return m2;
                }
            }
            return null;
        }

        public void mediaersatz(media ubergabe, string nameu, string logou, string linku, string groupu)
        {
            for (int i = 0; i < medialist.Count; i++)
            {
                if (medialist[i].Name == ubergabe.Name)
                {
                    medialist[i].Name = nameu;
                    medialist[i].Logo = logou;
                    medialist[i].Link = linku;
                    medialist[i].Gruppe = groupu;
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
                m.Name = dt.Rows[i]["Name"].ToString();
                m.Logo = dt.Rows[i]["Logo"].ToString();
                m.Link = dt.Rows[i]["Link"].ToString();
                m.Gruppe = dt.Rows[i]["Gruppe"].ToString();
                medialist.Add(m);

            }
            _dbc.conClose();
        }

    }
}
