using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace PIPITV
{
    class mediaManager
    {
        // Erstellt dbc und List
        private DB_Connection _dbc = new DB_Connection();

        private List<media> _medialist = new List<media>();
        public List<media> medialist
        {
            get { return _medialist; }
            set { _medialist = value; }
        }

        // Methode zum überprüfen von Listen einträgen
        public media mediaauswahl(media ubergabe)
        {   
            // Erstellt neues Objekt
            media m2 = new media();
            // Prüft alle Reihen
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
            // wenn keine Übereinstimmung gefunden wurde gibt er null zurück
            return null;
        }

        // Methode zum ersetzen von Listen Einträgen
        public void mediaersatz(media ubergabe, string nameu, string logou, string linku, string groupu)
        {
            // Prüft alle Reihen
            for (int i = 0; i < medialist.Count; i++)
            {
                if (medialist[i].Name == ubergabe.Name)
                {
                    // Setz die geänderten Daten in die Liste
                    medialist[i].Name = nameu;
                    medialist[i].Logo = logou;
                    medialist[i].Link = linku;
                    medialist[i].Gruppe = groupu;
                }
            }
        }

        // Methode zur Abfrage von DB
        public void getMedia()
        {
            // Ersrtellt neue DataTable
            DataTable dt = new DataTable();
            // Schreibt Inhalt ind qry
            string qry = "SELECT * FROM tbl_Media";
            _dbc.conOpen();
            // Führt in der DB die qry aus und scheichert die Ausgabe in dt
            dt = _dbc.getData(qry);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Erstellt neues Objekt m
                media m = new media();
                // Schreibt die Daten in die List mit den richtigen DataTyp
                m.Name = dt.Rows[i]["Name"].ToString();
                m.Logo = dt.Rows[i]["Logo"].ToString();
                m.Link = dt.Rows[i]["Link"].ToString();
                m.Gruppe = dt.Rows[i]["Gruppe"].ToString();
                medialist.Add(m);
            }
            _dbc.conClose();
        }

        public void SaveMediaInDB()
        {
            for (int i = 0; i < medialist.Count; i++)
            {
                _dbc.conOpen();
                string qry = "INSERT INTO tbl_Media(name,logo,link,gruppe) Values(" + medialist[i].Name + "," + medialist[i].Logo + "," + medialist[i].Link + "," + medialist[i].Gruppe + ");";
                _dbc.modifyData(qry);
                _dbc.conClose();
            }
        }

    }
}
