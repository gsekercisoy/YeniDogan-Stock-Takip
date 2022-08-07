using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace YENİDOĞAN_V3
{
    class vt
    {
        public static OleDbConnection Baglan()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
            baglanti.Open();
            return baglanti;
        }
        public static DataTable dtGetir(string sql)
        {
            OleDbConnection baglanti = Baglan();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            cmd.Connection.Close();
            baglanti.Close();
            adp.Dispose();
            cmd.Dispose();
            return dt;
        }

        public static DataTable dtGetirs(string sql)
        {
            OleDbConnection baglanti = Baglan();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            DataTable st = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(st);
            cmd.Connection.Close();
            baglanti.Close();
            adp.Dispose();
            cmd.Dispose();
            return st;
        }

        public static bool sqlCalistir(string sql)
        {
            OleDbConnection baglanti = Baglan();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            baglanti.Close();
            cmd.Dispose();
            return true;
        }
        public static int kayitSayisi(string sql)
        {
            OleDbConnection baglanti = Baglan();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            return dt.Rows.Count;
            cmd.Connection.Close();
            baglanti.Close();
            adp.Dispose();
            cmd.Dispose();

        }
    }
}
