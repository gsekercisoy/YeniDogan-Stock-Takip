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
    public partial class rutform : Form
    {
        public rutform()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        DataTable tablo = new DataTable();

        double rnosayı;
        double üst1;
        double üsttekialtabul,altbul;
        double üsttekialta;
        private void rutform_Load(object sender, EventArgs e)
        {
            listele();
            
        }
        private void listele2()
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from rut where rhafta='2. HAFTA 1.Gün' order by rno");
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                dataGridView1.Rows.Add(
                dt.Rows[i]["no1"].ToString(),
                dt.Rows[i]["rno"].ToString(),
                dt.Rows[i]["rmadı"].ToString());
            }
            dataGridView2.Rows.Clear();
            DataTable dt44;

            string sorgu44 = string.Format("select * from rut where rhafta='2. HAFTA 2.Gün' order by rno");
            dt44 = vt.dtGetir(sorgu44);
            for (int i = 0; i < dt44.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt44.Rows[i]["no1"].ToString());
                dataGridView2.Rows.Add(
                dt44.Rows[i]["no1"].ToString(),
                dt44.Rows[i]["rno"].ToString(),
                dt44.Rows[i]["rmadı"].ToString());
            }
            dataGridView3.Rows.Clear();
            DataTable dt1;

            string sorgu1 = string.Format("select * from rut where rhafta='2. HAFTA 3.Gün' order by rno");
            dt1 = vt.dtGetir(sorgu1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt1.Rows[i]["no1"].ToString());
                dataGridView3.Rows.Add(
                dt1.Rows[i]["no1"].ToString(),
                dt1.Rows[i]["rno"].ToString(),
                dt1.Rows[i]["rmadı"].ToString());
            }
            dataGridView4.Rows.Clear();
            DataTable dt11;

            string sorgu11 = string.Format("select * from rut where rhafta='2. HAFTA 4.Gün' order by rno");
            dt11 = vt.dtGetir(sorgu11);
            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt11.Rows[i]["no1"].ToString());
                dataGridView4.Rows.Add(
                dt11.Rows[i]["no1"].ToString(),
                dt11.Rows[i]["rno"].ToString(),
                dt11.Rows[i]["rmadı"].ToString());
            }
            dataGridView5.Rows.Clear();
            DataTable dt2;

            string sorgu12 = string.Format("select * from rut where rhafta='2. HAFTA 5.Gün' order by rno");
            dt2 = vt.dtGetir(sorgu12);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt2.Rows[i]["no1"].ToString());
                dataGridView5.Rows.Add(
                dt2.Rows[i]["no1"].ToString(),
                dt2.Rows[i]["rno"].ToString(),
                dt2.Rows[i]["rmadı"].ToString());
            }
            dataGridView6.Rows.Clear();
            DataTable dt13;

            string sorgu13 = string.Format("select * from rut where rhafta='2. HAFTA 6.Gün' order by rno");
            dt13 = vt.dtGetir(sorgu13);
            for (int i = 0; i < dt13.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt13.Rows[i]["no1"].ToString());
                dataGridView6.Rows.Add(
                dt13.Rows[i]["no1"].ToString(),
                dt13.Rows[i]["rno"].ToString(),
                dt13.Rows[i]["rmadı"].ToString());
            }
            dataGridView7.Rows.Clear();
            DataTable dt14;

            string sorgu14 = string.Format("select * from rut where rhafta='2. HAFTA 7.Gün' order by rno");
            dt14 = vt.dtGetir(sorgu14);
            for (int i = 0; i < dt14.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt14.Rows[i]["no1"].ToString());
                dataGridView7.Rows.Add(
                dt14.Rows[i]["no1"].ToString(),
                dt14.Rows[i]["rno"].ToString(),
                dt14.Rows[i]["rmadı"].ToString());
            }
        }
        private void listele()
        {
            dataGridView1.Rows.Clear();
            DataTable dt44;

            string sorgu44 = string.Format("select * from rut where rhafta='1. HAFTA 1.Gün' order by rno");
            dt44 = vt.dtGetir(sorgu44);
            for (int i = 0; i < dt44.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt44.Rows[i]["no1"].ToString());
                dataGridView1.Rows.Add(
                dt44.Rows[i]["no1"].ToString(),
                dt44.Rows[i]["rno"].ToString(),
                dt44.Rows[i]["rmadı"].ToString());
            }
            dataGridView2.Rows.Clear();
           

            sorgu44 = string.Format("select * from rut where rhafta='1. HAFTA 2.Gün' order by rno");
            dt44 = vt.dtGetir(sorgu44);
            for (int i = 0; i < dt44.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt44.Rows[i]["no1"].ToString());
                dataGridView2.Rows.Add(
                dt44.Rows[i]["no1"].ToString(),
                dt44.Rows[i]["rno"].ToString(),
                dt44.Rows[i]["rmadı"].ToString());
            }
            dataGridView3.Rows.Clear();
            DataTable dt1;

            string sorgu1 = string.Format("select * from rut where rhafta='1. HAFTA 3.Gün' order by rno");
            dt1 = vt.dtGetir(sorgu1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt1.Rows[i]["no1"].ToString());
                dataGridView3.Rows.Add(
                dt1.Rows[i]["no1"].ToString(),
                dt1.Rows[i]["rno"].ToString(),
                dt1.Rows[i]["rmadı"].ToString());
            }
            dataGridView4.Rows.Clear();
            DataTable dt11;

            string sorgu11 = string.Format("select * from rut where rhafta='1. HAFTA 4.Gün' order by rno");
            dt11 = vt.dtGetir(sorgu11);
            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt11.Rows[i]["no1"].ToString());
                dataGridView4.Rows.Add(
                dt11.Rows[i]["no1"].ToString(),
                dt11.Rows[i]["rno"].ToString(),
                dt11.Rows[i]["rmadı"].ToString());
            }
            dataGridView5.Rows.Clear();
            DataTable dt2;

            string sorgu12 = string.Format("select * from rut where rhafta='1. HAFTA 5.Gün' order by rno");
            dt2 = vt.dtGetir(sorgu12);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt2.Rows[i]["no1"].ToString());
                dataGridView5.Rows.Add(
                dt2.Rows[i]["no1"].ToString(),
                dt2.Rows[i]["rno"].ToString(),
                dt2.Rows[i]["rmadı"].ToString());
            }
            dataGridView6.Rows.Clear();
            DataTable dt13;

            string sorgu13 = string.Format("select * from rut where rhafta='1. HAFTA 6.Gün' order by rno");
            dt13 = vt.dtGetir(sorgu13);
            for (int i = 0; i < dt13.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt13.Rows[i]["no1"].ToString());
                dataGridView6.Rows.Add(
                dt13.Rows[i]["no1"].ToString(),
                dt13.Rows[i]["rno"].ToString(),
                dt13.Rows[i]["rmadı"].ToString());
            }
            dataGridView7.Rows.Clear();
            DataTable dt14;

            string sorgu14 = string.Format("select * from rut where rhafta='1. HAFTA 7.Gün' order by rno");
            dt14 = vt.dtGetir(sorgu14);
            for (int i = 0; i < dt14.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt14.Rows[i]["no1"].ToString());
                dataGridView7.Rows.Add(
                dt14.Rows[i]["no1"].ToString(),
                dt14.Rows[i]["rno"].ToString(),
                dt14.Rows[i]["rmadı"].ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            notxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            rno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            rnosayı = Convert.ToDouble(rno.Text);
            üsttekialtabul = rnosayı - 1;//üstekini bul
            altbul = rnosayı + 1;//alttakini bulma



            OleDbCommand mizrak = new OleDbCommand();//üst
            mizrak.Connection = baglanti;
            mizrak.CommandText = string.Format("select no1 from rut where rhafta='1. HAFTA' and rno='" + üsttekialtabul + "'");
            baglanti.Open();
            int ffiyat = Convert.ToUInt16(mizrak.ExecuteScalar());
            altrno.Text = ffiyat.ToString();
            baglanti.Close();

            OleDbCommand mizrak1 = new OleDbCommand();//alt
            mizrak1.Connection = baglanti;
            mizrak1.CommandText = string.Format("select no1 from rut where rhafta='1. HAFTA' and rno='" + altbul + "'");
            baglanti.Open();
            int ffiyat1 = Convert.ToUInt16(mizrak1.ExecuteScalar());
            altcek2.Text = ffiyat1.ToString();
            baglanti.Close();



           
            say.Text = "1";


        }

        private void ust_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("select Max(rno) from rut where rhafta='1. HAFTA'", baglanti);
            baglanti.Open();
            string max = (string)cmd.ExecuteScalar();
            baglanti.Close();
            OleDbCommand cmd1 = new OleDbCommand("select min(rno) from rut where rhafta='1. HAFTA'", baglanti);
            baglanti.Open();
            string min = (string)cmd1.ExecuteScalar();
            baglanti.Close();
            OleDbCommand cmd2 = new OleDbCommand("select Max(rno) from rut where rhafta='2. HAFTA'", baglanti);
            baglanti.Open();
            string max2 = (string)cmd2.ExecuteScalar();
            baglanti.Close();

            OleDbCommand cmd3 = new OleDbCommand("select min(rno) from rut where rhafta='2. HAFTA'", baglanti);
            baglanti.Open();
            string mi2 = (string)cmd3.ExecuteScalar();
            baglanti.Close();

            if (say.Text == "1" && altrno.Text != "0" && altrno.Text != "1" && altcek2.Text != max || altrno.Text != min)
            {
                rnosayı = Convert.ToDouble(rno.Text);
                üsttekialta = rnosayı;//üstteki alta                      
                üst1 = rnosayı - 1;//alttaki üste
              

                vt.sqlCalistir("update rut set rno='" + üsttekialta + "' where no1=" + altrno.Text + "");

                vt.sqlCalistir("update rut set rno='" + üst1 + "' where no1=" + notxt.Text + "");
                listele();
                listele2();
                
            }
            if (say.Text == "2" && altrno.Text != "0" && altrno.Text != "1" && altcek2.Text != max || altrno.Text != min)
            {

                rnosayı = Convert.ToDouble(rno.Text);               
                üsttekialta = rnosayı;//üstteki alta                      
                üst1 = rnosayı - 1;//alttaki üste

               

                vt.sqlCalistir("update rut set rno='" + üsttekialta + "' where no1=" + altrno.Text + "");

                vt.sqlCalistir("update rut set rno='" + üst1 + "' where no1=" + notxt.Text + "");
                listele();
                listele2();
                
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void alt_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("select Max(rno) from rut where rhafta='1. HAFTA'", baglanti);
            baglanti.Open();
            string max = (string)cmd.ExecuteScalar();
            baglanti.Close();
            OleDbCommand cmd1 = new OleDbCommand("select min(rno) from rut where rhafta='1. HAFTA'", baglanti);
            baglanti.Open();
            string min = (string)cmd1.ExecuteScalar();
            baglanti.Close();
            OleDbCommand cmd2 = new OleDbCommand("select Max(rno) from rut where rhafta='2. HAFTA'", baglanti);
            baglanti.Open();
            string max2 = (string)cmd2.ExecuteScalar();
            baglanti.Close();

            OleDbCommand cmd3 = new OleDbCommand("select min(rno) from rut where rhafta='2. HAFTA'", baglanti);
            baglanti.Open();
            string mi2 = (string)cmd3.ExecuteScalar();
            baglanti.Close();

            if (say.Text == "1" && altrno.Text != "0" && altrno.Text != "1" && altcek2.Text != max || altrno.Text != min)
            {
                rnosayı = Convert.ToDouble(rno.Text);
                üsttekialta = rnosayı;//üstteki alta                      
                üst1 = rnosayı + 1;//alttaki üste
          

                vt.sqlCalistir("update rut set rno='" + üsttekialta + "' where no1=" + altcek2.Text + "");

                vt.sqlCalistir("update rut set rno='" + üst1 + "' where no1=" + notxt.Text + "");
                listele();
                listele2();
               
            }
            if (say.Text == "2" && altrno.Text != "0" && altrno.Text != "1" && altcek2.Text != max || altrno.Text != min)
            {

                rnosayı = Convert.ToDouble(rno.Text);
                üsttekialta = rnosayı;//üstteki alta                      
                üst1 = rnosayı + 1;//alttaki üste

              

                vt.sqlCalistir("update rut set rno='" + üsttekialta + "' where no1=" + altcek2.Text + "");

                vt.sqlCalistir("update rut set rno='" + üst1 + "' where no1=" + notxt.Text + "");
                listele();
                listele2();
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele2();
        }

        private void rutform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                button2_Click(sender, e);
            }
            
            if (e.KeyCode == Keys.F5)
            {
                button1_Click(sender, e);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
            notxt.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            rno.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            rnosayı = Convert.ToDouble(rno.Text);
            üsttekialtabul = rnosayı - 1;//üstekini bul
            altbul = rnosayı + 1;//alttakini bulma



            OleDbCommand mizrak = new OleDbCommand();//üst
            mizrak.Connection = baglanti;
            mizrak.CommandText = string.Format("select no1 from rut where rhafta='1. HAFTA' and rno='" + üsttekialtabul + "'");
            baglanti.Open();
            int ffiyat = Convert.ToUInt16(mizrak.ExecuteScalar());
            altrno.Text = ffiyat.ToString();
            baglanti.Close();

            OleDbCommand mizrak1 = new OleDbCommand();//alt
            mizrak1.Connection = baglanti;
            mizrak1.CommandText = string.Format("select no1 from rut where rhafta='1. HAFTA' and rno='" + altbul + "'");
            baglanti.Open();
            int ffiyat1 = Convert.ToUInt16(mizrak1.ExecuteScalar());
            altcek2.Text = ffiyat1.ToString();
            baglanti.Close();
            
            say.Text = "2";
        }
    }
}
