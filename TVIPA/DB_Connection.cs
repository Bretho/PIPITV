using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PIPITV
{
    class DB_Connection
    {
        string connectionstring = "Data Source=172.17.0.188;" +
                                  "Initial Catalog=gtl;" +
                                  "User Id=aitFF;" +
                                  "Password=ole4ever;";

        SqlConnection con = new SqlConnection(); //verbindet
        SqlDataAdapter da = new SqlDataAdapter(); // überträgt Daten

        public void conOpen()
        {
            try
            {
                con.ConnectionString = connectionstring;
                con.Open();
                Console.WriteLine(" Connection established");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Console.WriteLine(error);
            }
        }

        public void conClose()
        {
            con.Close();
        }

        public DataTable getData(string query)
        {
            //query enthält die jeweiligen Select abfrage
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;

            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }

        public void modifyData(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
    }
}