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

namespace YENİDOĞAN_V3
{
    public partial class alım : Form
    {
        public alım()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        DataTable tablo = new DataTable();
        DataTable st;
        DataTable dt;
        string ocaksorgu, subatsorgu, martsorgu, nisansorgu,
            mayıssorgu, hazıransorgu, temmuzsorgu, agustossorgu,
            eylulsorgu, ekimsorgu, kasımsorgu, aralıksorgu, yıl;

        private void timer1_Tick(object sender, EventArgs e)
        {
            alımfis form = new alımfis();
            form.Name = "deneme";

            if (Application.OpenForms["deneme"] == null)
            {
                mblabel.Text = "HESAPLANIYOR...";
                listele05422821509();
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
                istatistik();

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

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            
            musteridetay form = new musteridetay();
            form.aydetay.Text = "OCAK";
            form.aylabel.Text = "1";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
            form.Show();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ŞUBAT";
            form.aylabel.Text = "2";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
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
            form.sayfa.Text = "2";
            form.Show();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            //ŞUBAT DETAY
            musteridetay form = new musteridetay();
            form.aydetay.Text = "KASIM";
            form.aylabel.Text = "11";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
            form.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ARALIK";
            form.aylabel.Text = "12";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
            form.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = dateTimePicker1.Text;
            form.aylabel.Text = "13";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
            form.Show();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "GENEL";
            form.aylabel.Text = "14";
            // form.yıllabel.Text = dateTimePicker1.Text;
            form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "2";
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fissil form = new fissil();
            form.sayfatxt.Text = "ALIM FİŞİ SİL";
            form.Show();
            timer2.Enabled = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            istatistik();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                alımfis form = new alımfis();
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

        private void button1_Click(object sender, EventArgs e)
        {
            alımfis form = new alımfis();
            form.Name = "deneme";

            if (Application.OpenForms["deneme"] == null)
            {
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
                form.Show();

                double bakiye = 0;
                baglanti.Open();
                komut = new OleDbCommand("insert into alımfis(fno,fmno,ftoplam,ftarih,fbakiye,fistoplam,ftahsilat,madı) values ('" + bakiye + "','" + mkodu.Text + "','" + bakiye + "','" + dateTimePicker2.Text + "','" + bakiye + "','" + bakiye + "','" + bakiye + "','" + madılabel.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                // this.Hide();
                timer1.Enabled = true;
                mblabel.Text = "HESAPLANIYOR..";

            }
            else
            {
                form.Focus();
                notifyIcon1.ShowBalloonTip(1000, "SATIŞ FİŞİ", "Açık sayfa mevcut", ToolTipIcon.Info);// hata veridirme


            }
        }

        private void alım_KeyDown(object sender, KeyEventArgs e)
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
                if (e.KeyCode == Keys.F7)
                {
                    button5_Click(sender, e);
                }
            }
            
           
            
        }

        private void ara_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select* from musteri where mno like '%" + ara.Text + "%' or madı like '%" + ara.Text + "%' and mtp='0'  order by mno");
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
        private void musterilist1()
        {
            dataGridView2.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from musteri where mtp='0'", baglanti);
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
        }
        public void listele05422821509()
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from alımfis where fmno = '" + mkodu.Text + "' and fno NOT IN ('0') order by ftarih DESC,fsno desc", baglanti);
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
                // ruttxt.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                panel4.Visible = false;

                dataGridView1.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from alımfis where fmno = '" + mkodu.Text + "' and fno NOT IN ('0') order by ftarih DESC,fsno desc", baglanti);
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




                //   int milliseconds = 1000;
                //   Thread.Sleep(milliseconds);
                istatistik();
                panel3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
            }
            catch { MessageBox.Show("Müşteri Ekleyiniz"); }
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
                button8.Enabled = false;
                panel2.Visible = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void alım_Load(object sender, EventArgs e)
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


            //  int milliseconds = 1000;
            //  Thread.Sleep(milliseconds);
            //  istatistik();
            panel3.Enabled = false;
        }
        private void istatistik()
        {
            ocaksorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(ocaksorgu);
            ocakgelir.Text = st.Rows[0]["toplam"].ToString();
            //subat
            subatsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(subatsorgu);
            subatgelir.Text = st.Rows[0]["toplam"].ToString();
            //mart
            martsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(martsorgu);
            martgelir.Text = st.Rows[0]["toplam"].ToString();
            //nisan
            nisansorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(nisansorgu);
            nisangelir.Text = st.Rows[0]["toplam"].ToString();
            //mayıs
            mayıssorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(mayıssorgu);
            mayısgelir.Text = st.Rows[0]["toplam"].ToString();
            //hazıransorgu
            hazıransorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(hazıransorgu);
            hazirangelir.Text = st.Rows[0]["toplam"].ToString();
            //temmuzsorgu
            temmuzsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(temmuzsorgu);
            temmuzgelir.Text = st.Rows[0]["toplam"].ToString();
            //agustossorgu
            agustossorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(agustossorgu);
            agustosgelir.Text = st.Rows[0]["toplam"].ToString();
            //eylulsorgu
            eylulsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(eylulsorgu);
            eylülgelir.Text = st.Rows[0]["toplam"].ToString();
            //ekimsorgu
            ekimsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(ekimsorgu);
            ekimgelir.Text = st.Rows[0]["toplam"].ToString();
            // kasımsorgu
            kasımsorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(kasımsorgu);
            kasımgelir.Text = st.Rows[0]["toplam"].ToString();
            //aralıksorgu
            aralıksorgu = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(aralıksorgu);
            aralıkgelir.Text = st.Rows[0]["toplam"].ToString();
            //yıl
            yıl = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            yılgelir.Text = st.Rows[0]["toplam"].ToString();
            //genel
            yıl = String.Format("SELECT sum(alımfisicerik.[ftutar]) as toplam FROM alımfisicerik WHERE fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            genelgelir.Text = st.Rows[0]["toplam"].ToString();
            /*
            //ocak
            ocaksorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='1' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(ocaksorgu);
            ocak.Text = st.Rows[0]["toplam"].ToString();
            //subat
            subatsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='2' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(subatsorgu);
            subat.Text = st.Rows[0]["toplam"].ToString();
            //mart
            martsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='3' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(martsorgu);
            mart.Text = st.Rows[0]["toplam"].ToString();
            //nisan
            nisansorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='4' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(nisansorgu);
            nisan.Text = st.Rows[0]["toplam"].ToString();
            //mayıs
            mayıssorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='5' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(mayıssorgu);
            mayıs.Text = st.Rows[0]["toplam"].ToString();
            //hazıransorgu
            hazıransorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='6' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(hazıransorgu);
            haziran.Text = st.Rows[0]["toplam"].ToString();
            //temmuzsorgu
            temmuzsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='7' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(temmuzsorgu);
            temmuz.Text = st.Rows[0]["toplam"].ToString();
            //agustossorgu
            agustossorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='8' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(agustossorgu);
            agustos.Text = st.Rows[0]["toplam"].ToString();
            //eylulsorgu
            eylulsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='9' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(eylulsorgu);
            eylul.Text = st.Rows[0]["toplam"].ToString();
            //ekimsorgu
            ekimsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='10' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(ekimsorgu);
            ekım.Text = st.Rows[0]["toplam"].ToString();
            // kasımsorgu
            kasımsorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='11' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(kasımsorgu);
            kasım.Text = st.Rows[0]["toplam"].ToString();
            //aralıksorgu
            aralıksorgu = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE month(ftarih)='12' AND year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(aralıksorgu);
            aralık.Text = st.Rows[0]["toplam"].ToString();
            //yıl
            yıl = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE year(ftarih)='{0}' AND fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            yıltxt.Text = st.Rows[0]["toplam"].ToString();
            //genel
            yıl = String.Format("SELECT sum(alımfis.[ftahsilat]) as toplam FROM alımfis WHERE fmno='{1}'", dateTimePicker1.Text, mkodu.Text);
            st = vt.dtGetirs(yıl);
            genel.Text = st.Rows[0]["toplam"].ToString();*/
        }
    }
}
