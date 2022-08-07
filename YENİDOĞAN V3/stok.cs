using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YENİDOĞAN_V3
{
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        string ocaksorgu;
        DataTable st;
        private void stok_Load(object sender, EventArgs e)
        {
            
            urungrd.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                urungrd.Rows.Add(dt.Rows[i]["no1"].ToString(),
                dt.Rows[i]["barkod1"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["stok"].ToString());
            }
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            //--------ürün isim-------
            fürün.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from ürün", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                fürün.Items.Add(dr[1]);
            }
            baglanti.Close();
            this.ActiveControl = fürün;
        }

        private void fürün_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ocak
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}'AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            ocak.Text = st.Rows[0]["toplam"].ToString();
            //subat
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}'AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            subat.Text = st.Rows[0]["toplam"].ToString();
            //mart
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}'AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            mart.Text = st.Rows[0]["toplam"].ToString();
            //nisan
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}'AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            nisan.Text = st.Rows[0]["toplam"].ToString();
            //mayıs
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            mayıs.Text = st.Rows[0]["toplam"].ToString();
            //hazıransorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            haziran.Text = st.Rows[0]["toplam"].ToString();
            //temmuzsorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            temmuz.Text = st.Rows[0]["toplam"].ToString();
            //agustossorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            agustos.Text = st.Rows[0]["toplam"].ToString();
            //eylulsorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            eylul.Text = st.Rows[0]["toplam"].ToString();
            //ekimsorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            ekım.Text = st.Rows[0]["toplam"].ToString();
            // kasımsorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            kasım.Text = st.Rows[0]["toplam"].ToString();
            //aralıksorgu
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            aralık.Text = st.Rows[0]["toplam"].ToString();
            //yıl
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}' AND furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            yıltxt.Text = st.Rows[0]["toplam"].ToString();
            ocaksorgu = String.Format("SELECT sum(fisicerik.[fmiktar]) as toplam FROM fisicerik WHERE furunad='{1}'", dateTimePicker1.Text, fürün.Text);
            st = vt.dtGetirs(ocaksorgu);
            genel.Text = st.Rows[0]["toplam"].ToString();
        }

        private void urungrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fürün.Text = urungrd.CurrentRow.Cells[2].Value.ToString();
            try {
                fürün_SelectedIndexChanged(sender, e);
            }
            catch { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fürün_SelectedIndexChanged(sender, e);
            }
            catch { }
        }

        private void urungrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
