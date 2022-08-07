using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace YENİDOĞAN_V3
{
    public partial class musteriportfoy : Form
    {
        public musteriportfoy()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        DataTable tablo = new DataTable();
        DataTable st;
        DataTable dt;
        string aralıksorgu, yıl, gidersorgu2, gelirsorgu1, gidersorgu1;
        int rutkontrol1;
        decimal gelir1 = 0, sonuc1 = 0, aragider = 0, aragider2 = 0, iadesatım = 0, iadealım = 0;
        string[] satıstut = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        string[] kartut= { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        int say;

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void mblabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            TextBox textBox = (TextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == ',' && textBox.Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf(',') > -1 && textBox.Text.Substring(textBox.Text.IndexOf(',')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)//liste
        {
            if (panel4.Visible)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)//fiş
        {
            if (panel2.Visible)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
             
                panel4.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel4.Visible)
            {
                panel4.Visible = false;
                panel3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
            }
            else
            {
                panel4.Visible = true;
                panel3.Enabled = false;
                
                panel2.Visible = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button8.Enabled = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mkodu.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                madılabel.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                madreslabel.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                mkisilabel.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                mvdlabel.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                mvnlabel.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                milabel.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                mblabel.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                ruttxt.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                panel4.Visible = false;

                dataGridView1.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from fis where fmno = '" + mkodu.Text + "' and fno NOT IN ('0') order by ftarih DESC,fsno desc", baglanti);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["fno"].ToString(),
                    dt.Rows[i]["ftahsilat"].ToString(),
                    dt.Rows[i]["ftoplam"].ToString(),
                    dt.Rows[i]["ftarih"].ToString().Substring(0, 10),
                    dt.Rows[i]["fsno"].ToString());
                }




                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
                // istatistik();
                forista();
                panel3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
            }
            catch { MessageBox.Show("Müşteri Ekleyiniz"); }



        }

        private void ara_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from musteri where mno like '%" + ara.Text + "%' or madı like '%" + ara.Text + "%' and mtp='1' order by mno");
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["mno"].ToString());
                dataGridView2.Rows.Add(
                dt.Rows[i]["mno"].ToString(),
                dt.Rows[i]["madı"].ToString(),
                dt.Rows[i]["madres"].ToString(),
                dt.Rows[i]["myetkili"].ToString(),
                dt.Rows[i]["vergid"].ToString(),
                dt.Rows[i]["vergino"].ToString(),
                dt.Rows[i]["miletisim"].ToString(),
                dt.Rows[i]["mbakiye"].ToString());
            }
            if (ara.Text == "") musterilist1();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from fis where fmno = '" + mkodu.Text + "' and fno NOT IN ('0') order by ftarih DESC,fsno desc", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                dataGridView1.Rows.Add(
                 dt.Rows[i]["fno"].ToString(),
                dt.Rows[i]["ftahsilat"].ToString(),
                dt.Rows[i]["ftoplam"].ToString(),
                dt.Rows[i]["ftarih"].ToString().Substring(0, 10),
                dt.Rows[i]["fsno"].ToString());
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            istatistik();
        }

        private void musteriportfoy_KeyDown(object sender, KeyEventArgs e)
        {
            if (panel4.Visible == false)
            {
                if (e.KeyCode == Keys.F1)
                {
                    button1_Click(sender, e);
                }
                if (e.KeyCode == Keys.F8)
                {
                    button4_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                button5_Click(sender, e);
            }
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            



            /*  bakiyeform form = new bakiyeform();
              form.mkodu.Text = mkodu.Text;
              form.madılabel.Text = madılabel.Text;
              form.Show();*/

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("MÜŞTERİ BAKİYESİNİ GÜNCELLEMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ?", "Bakiye Güncelle", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    //  string IsimGirisi = Interaction.InputBox("Bakiye Açıklama", "Bakiye Açıklama Giriniz.", "", 0, 0);
                    vt.sqlCalistir("update musteri set mbakiye='" + mblabel.Text + "' where mno=" + Convert.ToDouble(mkodu.Text));
                    baglanti.Open();
                    komut = new OleDbCommand("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + mblabel.Text + "','" + dateTimePicker2.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    // bakiye sayfası güncelle
                    dataGridView3.Rows.Clear();
                    string sorgu1 = string.Format("select * from bakiye where bmno='" + mkodu.Text + "'order by bno DESC", baglanti);
                    dt = vt.dtGetir(sorgu1);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double gider = Convert.ToDouble(dt.Rows[i]["bno"].ToString());
                        dataGridView3.Rows.Add(
                        dt.Rows[i]["bno"].ToString(),//gizli --ilerde lazım olur. (guncelle-sil)
                        dt.Rows[i]["bmno"].ToString(),
                        dt.Rows[i]["bakiye"].ToString() + " TL",
                        dt.Rows[i]["btarih"].ToString().Substring(0, 10));
                    }
                }
                catch
                { }
                MessageBox.Show("BAKİYE GÜNCELLENEMEDİ", "HATA OLUŞTU");
            }
            if (dialog == DialogResult.No)
            {
               // MessageBox.Show("SİLME İŞLEMİ BAŞARISIZ");
            }*/

            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fis form = new fis();
                form.Name = "deneme";

                if (Application.OpenForms["deneme"] == null)
                {
                    string MNO = mkodu.Text;
                    string MAD = madılabel.Text;
                    string MADRES = madreslabel.Text;
                    string MV = mvnlabel.Text;
                    string fissno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string fissno1 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    form.mkodu.Text = MNO;
                    form.madılabel.Text = MAD;
                    form.madreslabel.Text = MADRES;
                    form.mvnlabel.Text = MV;
                    form.serino2.Text = fissno1;
                    form.sno.Text = fissno1;
                    form.snotxt.Text = fissno;
                    form.Show();
                }
                else
                {
                    form.Focus();
                    notifyIcon1.ShowBalloonTip(1000, "SATIŞ FİŞİ", "Açık sayfa mevcut", ToolTipIcon.Info);// hata veridirme
                }
            }
            catch
            {
                MessageBox.Show("Satış Yapınız");
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ŞUBAT";
            form.aylabel.Text = "2";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "HAZİRAN";
            form.aylabel.Text = "6";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "OCAK";
            form.aylabel.Text = "1";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "MART";
            form.aylabel.Text = "3";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "NİSAN";
            form.aylabel.Text = "4";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "MAYIS";
            form.aylabel.Text = "5";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "TEMMUZ";
            form.aylabel.Text = "7";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "AĞUSTOS";
            form.aylabel.Text = "8";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "EYLÜL";
            form.aylabel.Text = "9";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "EKİM";
            form.aylabel.Text = "10";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "KASIM";
            form.aylabel.Text = "11";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ARALIK";
            form.aylabel.Text = "12";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = dateTimePicker1.Text ;
            form.aylabel.Text = "13";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "GENEL";
            form.aylabel.Text = "14";
            // form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "1";
            form.Show();
        }

        public void button6_Click_1(object sender, EventArgs e)
        {




            /*listele05422821509();
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            forista();

            try
            {
                OleDbCommand stokcek4 = new OleDbCommand();
                stokcek4.Connection = baglanti;
                stokcek4.CommandText = string.Format("select mbakiye from musteri where mno= '" + mkodu.Text + "'");
                baglanti.Open();
                string stokcek4512 = (string)stokcek4.ExecuteScalar();
                mblabel.Text = stokcek4512;
                baglanti.Close();
            }
            catch { }*/
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
           
            fis form = new fis();
            form.Name = "deneme";

            if (Application.OpenForms["deneme"] == null)
            {
               
                listele05422821509();
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
                forista();

                try
                {
                    OleDbCommand stokcek4 = new OleDbCommand();
                    stokcek4.Connection = baglanti;
                    stokcek4.CommandText = string.Format("select mbakiye from musteri where mno= '" + mkodu.Text + "'");
                    baglanti.Open();
                    string stokcek4512 = (string)stokcek4.ExecuteScalar();
                    mblabel.Text = stokcek4512;
                    baglanti.Close();
                }
                catch { }

                int milliseconds1 = 2000;
                Thread.Sleep(milliseconds1);
                timer1.Enabled = false;
            }

            
            

           
        }

        private void gunceltxt_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            fissil form = new fissil();
            form.sayfatxt.Text = "SATIŞ FİŞİ SİL";
            form.Show();
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            fissil form = new fissil();
            form.Name = "deneme";

            if (Application.OpenForms["deneme"] == null)
            {
                listele05422821509();
                timer2.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void musteriportfoy_Load(object sender, EventArgs e)
        {
           
            //listele05422821509();
            musterilist1();
            //----tarih------------
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
           
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";


          // int milliseconds = 1000;
          // Thread.Sleep(milliseconds);

          //  forista();
          //  istatistik();
            panel3.Enabled = false;
           





        }
        private void musterilist1()
        {
            dataGridView2.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from musteri where mtp='1'", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["mno"].ToString());
                dataGridView2.Rows.Add(
                dt.Rows[i]["mno"].ToString(),
                dt.Rows[i]["madı"].ToString(),
                dt.Rows[i]["madres"].ToString(),
                dt.Rows[i]["myetkili"].ToString(),
                dt.Rows[i]["vergid"].ToString(),
                dt.Rows[i]["vergino"].ToString(),
                dt.Rows[i]["miletisim"].ToString(),
                dt.Rows[i]["mbakiye"].ToString(),
                dt.Rows[i]["rutp"].ToString());
            }
        }
        public void listele05422821509()
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from fis where fmno = '" + mkodu.Text + "' and fno NOT IN ('0') order by ftarih DESC,fsno desc", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double gider = Convert.ToDouble(dt.Rows[i]["fsno"].ToString());
                dataGridView1.Rows.Add(
                dt.Rows[i]["fno"].ToString(),
                dt.Rows[i]["ftahsilat"].ToString(),
                dt.Rows[i]["ftoplam"].ToString(),
                dt.Rows[i]["ftarih"].ToString().Substring(0, 10),
                dt.Rows[i]["fsno"].ToString());
            }
        }
        
        public void listeleguncelle1()
        {

            /*
            OleDbCommand stokcek = new OleDbCommand();
            stokcek.Connection = baglanti;
            stokcek.CommandText = string.Format("select myetkili from musteri where madı='" + madılabel.Text + "'");
            baglanti.Open();
            string stokcek2 = (string)stokcek.ExecuteScalar();
            mkisilabel.Text = stokcek2.ToString(); ;
            baglanti.Close();
            
            OleDbCommand stokcek1 = new OleDbCommand();
            stokcek1.Connection = baglanti;
            stokcek1.CommandText = string.Format("select vergid from musteri where madı='" + madılabel.Text + "'");
            baglanti.Open();
            string stokcek3 = (string)stokcek1.ExecuteScalar();
            mvdlabel.Text = stokcek2.ToString(); ;
            baglanti.Close();
            
            OleDbCommand guncelle111 = new OleDbCommand();
            guncelle111.Connection = baglanti;
            guncelle111.CommandText = string.Format("select miletisim from musteri where madı='" + madılabel.Text + "'");
            baglanti.Open();
            string guncellecek = (string)guncelle111.ExecuteScalar();
            milabel.Text = stokcek2.ToString(); ;
            baglanti.Close();
            OleDbCommand guncelle112 = new OleDbCommand();
            guncelle112.Connection = baglanti;
            guncelle112.CommandText = string.Format("select rutp from musteri where madı='" + madılabel.Text + "'");
            baglanti.Open();
            string guncellecek2 = (string)guncelle112.ExecuteScalar();
            ruttxt.Text = stokcek2.ToString(); ;
            baglanti.Close();
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fis form = new fis();
            form.Name = "deneme";

            if (Application.OpenForms["deneme"] == null)
            {
                if(ruttxt.Text== "1. HAFTA 1.Gün"||
                    ruttxt.Text == "1. HAFTA 2.Gün" ||
                    ruttxt.Text == "1. HAFTA 3.Gün" ||
                    ruttxt.Text == "1. HAFTA 4.Gün" ||
                    ruttxt.Text == "1. HAFTA 5.Gün" ||
                    ruttxt.Text == "1. HAFTA 6.Gün" ||
                    ruttxt.Text == "1. HAFTA 7.Gün") { rutkontrol1 = 1; }
                else { rutkontrol1 = 2; }
                //diğerr sayfa
                string MNO = mkodu.Text;
                string MAD = madılabel.Text;
                string MADRES = madreslabel.Text;
                string MV = mvnlabel.Text;
                string MBKİE = mblabel.Text;
            
                form.mkodu.Text = MNO;
                form.madılabel.Text = MAD;
                form.madreslabel.Text = MADRES;
                form.mvnlabel.Text = MV;
                form.mblabel.Text = MBKİE;
                form.sno.Text = sno.Text;
                    form.rutkontol.Text = rutkontrol1.ToString();
                    form.Show();             

                double bakiye = 0;
                baglanti.Open();
                komut = new OleDbCommand("insert into fis(fno,fmno,ftoplam,ftarih,fbakiye,fistoplam,ftahsilat,rutk,kilit,madı) values ('" + bakiye + "','" + mkodu.Text + "','" + bakiye + "','" + dateTimePicker2.Text + "','" + bakiye + "','" + bakiye + "','" + bakiye + "','" + rutkontrol1 + "','0','" + madılabel.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                // this.Hide();
                timer1.Enabled = true;
                mblabel.Text = "FİŞ BEKLENİYOR...";

            }
            else
            {
                form.Focus();
                notifyIcon1.ShowBalloonTip(1000, "SATIŞ FİŞİ","Açık sayfa mevcut", ToolTipIcon.Info);// hata veridirme


            }
        }
        private void forista()
        {
            for (int i = 1; i < 12; i++)
            {

                //-----------------------------------------------------------------------------------------ocak
                //gelir--
                sonuc1 = 0;
                gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='" + i + "' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
                st = vt.dtGetirs(gelirsorgu1);
                try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
                catch { gelir1 = 0; }

                gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='" + i + "' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
                st = vt.dtGetirs(gidersorgu2);
                try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
                catch { iadealım = 0; }
                gelir1 = gelir1 - iadealım;


                //iade kar
                //----------------
                gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='" + i + "' AND year(ftarih)='{0}' AND firma NOT IN ('0') and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
                st = vt.dtGetirs(gidersorgu2);
                try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
                catch { iadesatım = 0; }

                //ocak kar
                gidersorgu1 = "";
                gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='" + i + "' AND year(ftarih)='{0}' and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
                st = vt.dtGetirs(gidersorgu1);
                try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
                aragider2 = aragider2 - iadesatım;


                //yazdır-------------------
                satıstut[i] = gelir1.ToString();   //--------gelir
                kartut[i] = aragider2.ToString();
                //--------kar
                //--------kar
            }

            ocakgelir.Text = satıstut[1];   //--------gelir
            ocakkar.Text = kartut[1];       //--------kar

            subatgelir.Text = satıstut[2];//-----------gelir
            subatkar.Text = kartut[2];   //--------kar

            martgelir.Text = satıstut[3];//-----------gelir
            martkar.Text = kartut[3];  //--------kar

            nisangelir.Text = satıstut[4];//-----------gelir
            nisankar.Text = kartut[4];  //--------kar

            mayısgelir.Text = satıstut[5];//-----------gelir
            mayıskar.Text = kartut[5];  //--------kar

            hazirangelir.Text = satıstut[6];//-----------gelir
            hazirangelir.Text = kartut[6];  //--------kar

            temmuzgelir.Text = satıstut[7];//-----------gelir
            temmuzkar.Text = kartut[7]; //--------kar


            agustosgelir.Text = satıstut[8];//-----------gelir
            agustoskar.Text = kartut[8];  //--------kar


            eylülgelir.Text = satıstut[9];//-----------gelir
            eylülkar.Text = kartut[9];  //--------kar

            ekimgelir.Text = satıstut[10];//-----------gelir
            ekimkar.Text = kartut[10]; ;  //--------kar

            kasımgelir.Text = satıstut[11];//-----------gelir
            kasımkar.Text = kartut[11]; //--------kar------------------

            //-----------------------------------------------------------------------------------------ocak
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;


            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}' AND firma NOT IN ('0') and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}' and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;

            aralıkgelir.Text = gelir1.ToString(); //-----------gelir
            aralıkkar.Text = aragider2.ToString();  //--------kar

            //-----------------------------------------------------------------------------------------yıl
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;


            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE year(ftarih)='{0}' AND firma NOT IN ('0') and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}' and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;


            //yazdır-------------------
            yılgelir.Text = gelir1.ToString();   //--------gelir
            yılkar.Text = aragider2.ToString();

            //-----------------------------------------------------------------------------------------genel
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE fmno='{0}'", mkodu.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE fmno='{0}'", mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;


            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE firma NOT IN ('0') and fmno='{0}'", mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE fmno='{0}'", mkodu.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;


            //yazdır-------------------
            genelgelir.Text = gelir1.ToString();   //--------gelir
            genelkar.Text = aragider2.ToString();


        }
        private void istatistik()
        {
            /*

            //-----------------------------------------------------------------------------------------ocak
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='1' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text,mkodu.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='1' AND year(ftarih)='{0}'and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;


            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}' AND firma NOT IN ('0') and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}' and fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
           

            //yazdır-------------------
            ocakgelir.Text = gelir1.ToString();//-----------gelir
            ocakkar.Text = aragider2.ToString();  //--------kar
           

            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama



            //-----------------------------------------------------------------------------------------şubat
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='2' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum3, as toplam FROM iadefis WHERE month(ftarih)='2' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='2' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            subatgelir.Text = gelir1.ToString();//-----------gelir
            subatkar.Text = aragider2.ToString();  //--------kar
            

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------mart
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='3' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum3, as toplam FROM iadefis WHERE month(ftarih)='3' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='3' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            martgelir.Text = gelir1.ToString();//-----------gelir
            martkar.Text = aragider2.ToString();  //--------kar
           

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------nisan
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='4' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum3, as toplam FROM iadefis WHERE month(ftarih)='4' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='4' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            nisangelir.Text = gelir1.ToString();//-----------gelir
            nisankar.Text = aragider2.ToString();  //--------kar


            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------mayıs
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='5' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum3, as toplam FROM iadefis WHERE month(ftarih)='5' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='5' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            mayısgelir.Text = gelir1.ToString();//-----------gelir
            mayıskar.Text = aragider2.ToString();  //--------kar
            mayısgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------haziran
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='6' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum3, as toplam FROM iadefis WHERE month(ftarih)='6' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='6' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            hazirangelir.Text = gelir1.ToString();//-----------gelir
            hazirangelir.Text = aragider2.ToString();  //--------kar
            hazirangider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama


            //-----------------------------------------------------------------------------------------temmuz
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='7' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='7' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='7' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            temmuzgelir.Text = gelir1.ToString();//-----------gelir
            temmuzkar.Text = aragider2.ToString();  //--------kar
            temmuzgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------ağustos
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='8' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='8' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='8' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            agustosgelir.Text = gelir1.ToString();//-----------gelir
            agustoskar.Text = aragider2.ToString();  //--------kar
            agustosgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------eylül
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='9' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='9' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='9' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            eylülgelir.Text = gelir1.ToString();//-----------gelir
            eylülkar.Text = aragider2.ToString();  //--------kar
            eylülgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------ekim
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='10' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='10' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='10' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            ekimgelir.Text = gelir1.ToString();//-----------gelir
            ekimkar.Text = aragider2.ToString();  //--------kar
            ekimgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------kasım
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='11' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='11' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='11' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            kasımgelir.Text = gelir1.ToString();//-----------gelir
            kasımkar.Text = aragider2.ToString();  //--------kar
            kasımgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------aralık
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='12' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE month(ftarih)='12' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='12' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            aralıkgelir.Text = gelir1.ToString();//-----------gelir
            aralıkkar.Text = aragider2.ToString();  //--------kar
            aralıkgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------yıl
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis WHERE year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            senelikgelir.Text = gelir1.ToString();//-----------gelir
            senelikkar.Text = aragider2.ToString();  //--------kar
            senelikgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------genel
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis");
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefis");
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;
            //iade
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE firma NOT IN ('0')");
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik");
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider");
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider = 0; }//gider menusu

            //yazdır-------------------
            senelikgelir.Text = gelir1.ToString();//-----------gelir
            senelikkar.Text = aragider2.ToString();  //--------kar
            senelikgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama




            aralıksorgu = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE month(ftarih)='12' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(aralıksorgu);
            aralık.Text = st.Rows[0]["toplam"].ToString();
            //yıl
            yıl = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            yıltxt.Text = st.Rows[0]["toplam"].ToString();
            //genel
            yıl = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fis WHERE fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            genel.Text = st.Rows[0]["toplam"].ToString();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele05422821509();
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            forista();

            try
            {
                OleDbCommand stokcek4 = new OleDbCommand();
                stokcek4.Connection = baglanti;
                stokcek4.CommandText = string.Format("select mbakiye from musteri where mno= '" + mkodu.Text + "'");
                baglanti.Open();
                string stokcek4512 = (string)stokcek4.ExecuteScalar();
                mblabel.Text = stokcek4512;
                baglanti.Close();
            }
            catch { }
        }

        public void list_Click(object sender, EventArgs e)
        {
            listele05422821509();
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            forista();
           
            try {
                OleDbCommand stokcek4 = new OleDbCommand();
                stokcek4.Connection = baglanti;
                stokcek4.CommandText = string.Format("select mbakiye from musteri where mno= '"+mkodu.Text+"'");
                baglanti.Open();
                string stokcek4512 = (string)stokcek4.ExecuteScalar();
                mblabel.Text = stokcek4512;
                baglanti.Close();
            }
            catch { }
        }


    }
}


