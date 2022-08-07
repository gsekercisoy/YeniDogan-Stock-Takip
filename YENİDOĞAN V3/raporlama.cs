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
    public partial class raporlama : Form
    {
        public raporlama()
        {
            InitializeComponent();
        }
        DataTable st;
        string gidersorgu1, gelirsorgu1, gidersorgu2;
        decimal gelir1 = 0, sonuc1 = 0, aragider = 0, aragider2 = 0, iadesatım = 0, iadealım = 0;
        bool acılır=true,SENELİK=true;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            aylık();
            aylıkchartfark();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
         /*   if (SENELİK == true)
            {
                chart2.Visible = true;
             //   chart1.Visible = false;
                aylıkchartfark();
                SENELİK = false;
            }
            else
            {
                chart2.Visible = false;
             //   chart1.Visible = true;
               // aylıkchart();
                SENELİK = true;

            }*/
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "MART";
            form.aylabel.Text = "3";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "OCAK";
            form.aylabel.Text = "1";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ŞUBAT";
            form.aylabel.Text = "2";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "NİSAN";
            form.aylabel.Text = "4";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "MAYIS";
            form.aylabel.Text = "5";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "HAZİRAN";
            form.aylabel.Text = "6";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "TEMMUZ";
            form.aylabel.Text = "7";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "AĞUSTOS";
            form.aylabel.Text = "8";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "EYLÜL";
            form.aylabel.Text = "9";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "EKİM";
            form.aylabel.Text = "10";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "KASIM";
            form.aylabel.Text = "11";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "ARALIK";
            form.aylabel.Text = "12";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = dateTimePicker1.Text;
            form.aylabel.Text = "13";
            form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            musteridetay form = new musteridetay();
            form.aydetay.Text = "GENEL";
            form.aylabel.Text = "14";
            // form.yıllabel.Text = dateTimePicker1.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM";

            musteridetay form = new musteridetay();
            form.aydetay.Text = "1. HAFTA BU AY";
            form.yıl2.Text = dateTimePicker2.Text;
            form.aylabel.Text = "16";
            form.sayfa.Text = "3";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.Show();
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM";

            musteridetay form = new musteridetay();
            form.aydetay.Text = "2. HAFTA BU AY";
            form.yıl2.Text = dateTimePicker2.Text;
            form.aylabel.Text = "17";
            form.sayfa.Text = "3";
            form.yıllabel.Text = dateTimePicker1.Text;
            form.Show();
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            


        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";

            musteridetay form = new musteridetay();
            form.aydetay.Text = "GÜNLÜK";
            form.aylabel.Text = "15";
            form.yıllabel.Text = dateTimePicker2.Text;
            //form.mkodu.Text = mkodu.Text;
            form.sayfa.Text = "3";
            form.Show();
        }

        private void ürünbox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tableLayoutPanel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raporlama_Load(object sender, EventArgs e)
        {
            // ürüngetir();
          //  dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.Value = DateTime.Today;


            gunluk1();





            // aylıkchartfark();
            //  aylıkchart();

        }

        private void hazirangider_Click(object sender, EventArgs e)
        {

        }

        private void giderbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void aylık()
        {
            

            //-----------------------------------------------------------------------------------------ocak
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;


            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}' AND firma NOT IN ('0')", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            //gider++++++++++++++++++++
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='1' AND year(tarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gidersorgu1);
            try{aragider = Convert.ToDecimal(st.Rows[0]["toplam"]);}catch{ aragider = 0;}//gider menusu
            
            //yazdır-------------------
            ocakgelir.Text = gelir1.ToString();//-----------gelir
            ocaksonuc.Text = aragider2.ToString();  //--------kar
            ocakgider.Text = aragider.ToString();//--------gider

            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama



            //-----------------------------------------------------------------------------------------şubat
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            subatgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------mart
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            martgider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------nisan
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            nisangider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama

            //-----------------------------------------------------------------------------------------mayıs
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            hazirankar.Text = aragider2.ToString();  //--------kar
            hazirangider.Text = aragider.ToString();//--------gider

            gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama


            //-----------------------------------------------------------------------------------------temmuz
            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}'", dateTimePicker1.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE year(ftarih)='{0}'", dateTimePicker1.Text);
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
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik");
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik");
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





        }
      
        private void aylıkchartfark()
        {
            chart2.Series["KAR"].Points.Clear();
       
            chart2.Series["KAR"].Points.AddXY("OCAK", ocaksonuc.Text);
            chart2.Series["KAR"].Points.AddXY("ŞUBAT", subatkar.Text);
            chart2.Series["KAR"].Points.AddXY("MART", martkar.Text);
            chart2.Series["KAR"].Points.AddXY("NİSAN", nisankar.Text);
            chart2.Series["KAR"].Points.AddXY("MAYIS", mayıskar.Text);
            chart2.Series["KAR"].Points.AddXY("HAZİRAN", hazirankar.Text);
            chart2.Series["KAR"].Points.AddXY("AĞUSTOS", agustoskar.Text);
            chart2.Series["KAR"].Points.AddXY("EYLÜL", eylülkar.Text);
            chart2.Series["KAR"].Points.AddXY("EKİM", ekimkar.Text);
            chart2.Series["KAR"].Points.AddXY("KASIM", kasımkar.Text);
            chart2.Series["KAR"].Points.AddXY("ARALIK", aralıkkar.Text);


        }
        private void gunluk1()
        {
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";




            //günlük
            //----------------

            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE firma NOT IN ('0') and ftarih=#{0}#", dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            
            //iade kar--------     

            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih=#{0}#", dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE ftarih=#{0}#", dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu

            
            //gelir--


            sonuc1 = 0;                
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE ftarih=#{0}#", dateTimePicker2.Text);  
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            //iade gelir
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE ftarih=#{0}#", dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }

            gelir1 = gelir1 - iadealım;
            aragider2 = aragider2 - iadesatım;

            

            günlükgelir.Text = gelir1.ToString();
            günlükkar.Text = aragider2.ToString();
            günlükgider.Text = aragider.ToString();
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;

            //hafta--------------------------------

            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM";

            //-----------------------------------------------------------------------------------------1.hafta


            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='1'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}'and rutk='1'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;



            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' AND firma NOT IN ('0')and rutk='1'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}'and rutk='1'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;


            //yazdır-------------------
            birgelir.Text = gelir1.ToString();//-----------gelir
            birkar.Text = aragider2.ToString();  //--------kar


            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama
            //-----------------------------------------------------------------------------------------2.hafta


            //gelir--
            sonuc1 = 0;
            gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='2'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gelirsorgu1);
            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }

            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[ftutar]) as toplam FROM iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}'and rutk='2'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            gelir1 = gelir1 - iadealım;



            //iade kar
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iadefisicerik.[netkar]) as toplam FROM iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' AND firma NOT IN ('0')and rutk='2'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //ocak kar
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(fisicerik.[netkar]) as toplam FROM fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}'and rutk='2'", dateTimePicker1.Text, dateTimePicker2.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadesatım;
            

            //yazdır-------------------
            ikigelir.Text = gelir1.ToString();//-----------gelir
            ikikar.Text = aragider2.ToString();  //--------kar
           

            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;//sağlama


        }
        /*  private void ürüngetir()
          {
              ürünbox.Items.Clear();
              baglanti.Open();
              komut = new OleDbCommand("select * from ürün", baglanti);
              adtr = new OleDbDataAdapter(komut);
              komut.CommandType = CommandType.Text;
              OleDbDataReader dr = komut.ExecuteReader();
              while (dr.Read())
              {
                  ürünbox.Items.Add(dr[1]);
              }
              baglanti.Close();
          }*/
        /*   private void aylıkürün()
           {
               //ocak
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='1' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text,ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='1' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text,ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }

               //gider ocak
               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='1' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text,ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 = aragider2;//sonuc
               ocakgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='1' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text,ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               ocakgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               ocaksonuc.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;
               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------

               //subat
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='2' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='2' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //subat gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='2' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               subatgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='2' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               subatgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               subatkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;


               //mart--------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='3' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='3' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //mart gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='3' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               martgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='3' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               martgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               martkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //nisan------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='4' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='4' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //nisan gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='4' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               nisangider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='4' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               nisangelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               nisankar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //mayıs-----------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='5' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='5' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //mayıs gider          
               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='5' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               mayısgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='5' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               mayısgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 - aragider2;
               mayıskar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //haziran--------------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='6' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='6' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //haziran gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='6' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 = aragider2;//sonuc
               hazirangider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='6' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               hazirangelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               ocaksonuc.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //temmuz---------------------------------------------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='7' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='7' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //temmuz gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='7' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               temmuzgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='7' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               temmuzgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               temmuzkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //ağustus----------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='8' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='8' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //agustos gider
               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='8' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               agustosgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='8' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               agustosgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               agustoskar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;


               //eylül----------------------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='9' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='9' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //eylül gider         
               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='9' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               eylülgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='9' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               eylülgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               eylülkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //ekim----------------------------------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='10' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='10' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='10' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               ekimgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='10' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               ekimgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               ekimkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //kasım------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='11' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='11' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //kasım gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='11' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               kasımgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='11' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               kasımgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               kasımkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;

               //aralık------------------------------------------------------------------
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='12' AND year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE month(itarih)='12' AND year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //arlık gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE month(atarih)='12' AND year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               aralıkgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE month(ftarih)='12' AND year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               aralıkgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               aralıkkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım = 0; iadealım = 0;



               //senelik gider
               //iade
               //----------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE year(itarih)='{0}'and imno<'1' and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadealım = 0; }

               //-----------------------
               gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE year(itarih)='{0}'and imno NOT IN ('0') and iurunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu2);
               try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { iadesatım = 0; }
               //senelik gider

               gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE year(atarih)='{0}'and aurun='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               aragider2 = aragider2 - iadealım;
               sonuc1 =  aragider2;//sonuc
               senelikgider.Text = sonuc1.ToString();
               //gelir--
               sonuc1 = 0;
               gelirsorgu1 = String.Format("SELECT sum(fisicerik.[ftutar]) as toplam FROM fisicerik WHERE year(ftarih)='{0}'and furunad='{1}'", dateTimePicker1.Text, ürünbox.Text);
               st = vt.dtGetirs(gelirsorgu1);
               try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { gelir1 = 0; }
               gelir1 = gelir1 - iadesatım;
               senelikgelir.Text = gelir1.ToString();
               //sonuc--
               sonuc1 = gelir1 -  aragider2;
               senelikkar.Text = sonuc1.ToString();
               sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0; iadesatım=0; iadealım = 0;


           }
           private void aylıkgider()
           {

               ocakgelir.Text = "0";
               ocaksonuc.Text = "0";
               subatgelir.Text = "0";
               subatkar.Text = "0";
               martgelir.Text = "0";
               martkar.Text = "0";
               nisangelir.Text = "0";
               nisankar.Text = "0";
               mayısgelir.Text = "0";
               mayıskar.Text = "0";
               hazirangelir.Text = "0";
               hazirankar.Text = "0";
               temmuzgelir.Text = "0";
               temmuzkar.Text = "0";
               agustosgelir.Text = "0";
               agustoskar.Text = "0";
               eylülgelir.Text = "0";
               eylülkar.Text = "0";
               ekimgelir.Text = "0";
               ekimkar.Text = "0";
               kasımgelir.Text = "0";
               kasımkar.Text = "0";
               aralıkgelir.Text = "0";
               aralıkkar.Text = "0";
               senelikgelir.Text = "0";
               senelikkar.Text = "0";

               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='1' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               ocakgider.Text = sonuc1.ToString();
               ocakgelir.Text = "0";
               ocaksonuc.Text = "0";

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='2' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               subatgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='3' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               martgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='4' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               nisangider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='5' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               mayısgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='6' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               hazirangider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='7' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               temmuzgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='8' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               agustosgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='9' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               eylülgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='10' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               ekimgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='11' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               kasımgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='12' AND year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               aralıkgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------
               gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE year(tarih)='{0}'and aciklama='{1}'", dateTimePicker1.Text, giderbox.Text);
               st = vt.dtGetirs(gidersorgu1);
               try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
               catch { aragider2 = 0; }//alım menusu
               sonuc1 = aragider2;//sonuc
               senelikgider.Text = sonuc1.ToString();

               //------------------------------------------------------------------------------------------------------------
               //------------------------------------------------------------------*/





    }


}

