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
    public partial class fissil : Form
    {
        public fissil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        
        private void fissil_Load(object sender, EventArgs e)
        {
            this.ActiveControl = snotxt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listele();
        }
        private void sıfırla()
        {
            fsnotxt.Text = "";
            fnotxt.Text = "";
            icerikfsno.Text = "";
            icerik.Text = "";
            
        }
         private void listele()
        {     //form.sayfatxt.Text = "SATIŞ FİŞİ SİL";
              //form.sayfatxt.Text = "İADE FİŞİ SİL";
            if (sayfatxt.Text == "SATIŞ FİŞİ SİL")
            {
                dataGridView2.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from fis where fno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["madı"].ToString(),
                    dt.Rows[i]["ftoplam"].ToString(),
                    dt.Rows[i]["ftahsilat"].ToString(),
                    dt.Rows[i]["ftarih"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());
                }

                dataGridView1.Rows.Clear();
                string sorgu1 = string.Format("select * from fisicerik where fsno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktar"].ToString(),
                    dt.Rows[i]["fbirim"].ToString(),
                    dt.Rows[i]["ffiyat"].ToString(),
                    dt.Rows[i]["ftutar"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());

                }
            }
            if (sayfatxt.Text == "ALIM FİŞİ SİL")
            {
                dataGridView2.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from alımfis where fno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["madı"].ToString(),
                    dt.Rows[i]["ftoplam"].ToString(),
                    dt.Rows[i]["ftahsilat"].ToString(),
                    dt.Rows[i]["ftarih"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());
                }

                dataGridView1.Rows.Clear();
                string sorgu1 = string.Format("select * from alımfisicerik where fsno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktar"].ToString(),
                    dt.Rows[i]["fbirim"].ToString(),
                    dt.Rows[i]["ffiyat"].ToString(),
                    dt.Rows[i]["ftutar"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());

                }
            }
            if (sayfatxt.Text == "İADE FİŞİ SİL")
            {
                dataGridView2.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from iadefis where fno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["madı"].ToString(),
                    dt.Rows[i]["ftoplam"].ToString(),
                    dt.Rows[i]["ftahsilat"].ToString(),
                    dt.Rows[i]["ftarih"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());
                }

                dataGridView1.Rows.Clear();
                string sorgu1 = string.Format("select * from iadefisicerik where fsno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["fsno"].ToString(),
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktar"].ToString(),
                    dt.Rows[i]["fbirim"].ToString(),
                    dt.Rows[i]["ffiyat"].ToString(),
                    dt.Rows[i]["ftutar"].ToString(),
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["fmno"].ToString());

                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fsnotxt.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            fnotxt.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            //mkodu.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            button1.Enabled = true;
            button3.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fiş sil
            if (sayfatxt.Text == "SATIŞ FİŞİ SİL")
            {
                if (fnotxt.Text != "" && fsnotxt.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from fisicerik where fsno='" + fnotxt.Text + "'");//içerik
                        vt.sqlCalistir("delete from fis where fsno=" + Convert.ToDouble(fsnotxt.Text));//fiş
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz fişi seçiniz"); }
            }
            if (sayfatxt.Text == "ALIM FİŞİ SİL")
            {
                if (fnotxt.Text != "" && fsnotxt.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from alımfisicerik where fsno='" + fnotxt.Text + "'");//içerik
                        vt.sqlCalistir("delete from alımfis where fsno=" + Convert.ToDouble(fsnotxt.Text));//fiş
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz fişi seçiniz"); }
            }
            if (sayfatxt.Text == "İADE FİŞİ SİL")
            {
                if (fnotxt.Text != "" && fsnotxt.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from iadefisicerik where fsno='" + fnotxt.Text + "'");//içerik
                        vt.sqlCalistir("delete from iadefis where fsno=" + Convert.ToDouble(fsnotxt.Text));//fiş
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz fişi seçiniz"); }
            }
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            icerikfsno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//genel
            icerik.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//fis
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tek sil
            if (sayfatxt.Text == "SATIŞ FİŞİ SİL")
            {
                if (icerikfsno.Text != "" && icerik.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from fisicerik where fno=" + Convert.ToDouble(icerik.Text));//içerik
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz içeriği seçiniz"); }
            }
            if (sayfatxt.Text == "ALIM FİŞİ SİL")
            {
                if (icerikfsno.Text != "" && icerik.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from alımfisicerik where fno=" + Convert.ToDouble(icerik.Text));//içerik
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz içeriği seçiniz"); }
            }
            if (sayfatxt.Text == "İADE FİŞİ SİL")
            {
                if (icerikfsno.Text != "" && icerik.Text != "")
                {
                    try
                    {
                        vt.sqlCalistir("delete from iadefisicerik where fno=" + Convert.ToDouble(icerik.Text));//içerik
                        listele();
                        sıfırla();
                    }
                    catch { }
                }
                else { MessageBox.Show("Silmek istediğiniz içeriği seçiniz"); }
            }
            
            button2.Enabled = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sayfatxt.Text == "SATIŞ FİŞİ SİL")
            {
                vt.sqlCalistir("delete from fisicerik where fsno='" + fnotxt.Text + "'");//içerik
                listele();
                sıfırla();
            }
            if (sayfatxt.Text == "ALIM FİŞİ SİL")
            {
                vt.sqlCalistir("delete from alımfisicerik where fsno='" + fnotxt.Text + "'");//içerik
                listele();
                sıfırla();
            }
            if (sayfatxt.Text == "İADE FİŞİ SİL")
            {
                vt.sqlCalistir("delete from iadefisicerik where fsno='" + fnotxt.Text + "'");//içerik
                listele();
                sıfırla();
            }
            button3.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


           // vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int a = 0;
            try
            { vt.sqlCalistir("delete from fis where fno='" + a + "'"); }
            catch { }//fiş}
            try
            { vt.sqlCalistir("delete from alımfis where fno='" + a + "'"); }
            catch { }//fiş}
            try
            { vt.sqlCalistir("delete from iadefis where fno='" + a + "'"); }
            catch { }//fiş}



            listele();
            sıfırla();
           
        }
    }
}
