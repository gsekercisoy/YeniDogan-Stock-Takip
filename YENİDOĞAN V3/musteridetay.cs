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
    public partial class musteridetay : Form
    {
        public musteridetay()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb"); 
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable st;
        DataTable tablo = new DataTable();
        double miktar,satış,kar, imiktar, isatış, ikar;

        private void musteridetay_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void listele()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            DataTable dt;
             DataTable st;
            /* string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam," +
                " sum(fisicerik.[ftutar])as ftutartoplam, " +
                "sum(fisicerik.[netkar])as netkartoplam" +
                " from fisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad " +
                "" +
                "" +
                "UNION select furunad,sum(iadefisicerik.[fmiktar]) as fmiktartoplam1,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad", yıllabel.Text, mkodu.Text, aylabel.Text);
*/


            /*   string sorgu2asd = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam," +
                  " sum(fisicerik.[ftutar])as ftutartoplam, " +
                  "sum(fisicerik.[netkar])as netkartoplam" +
                  " from fisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad ", yıllabel.Text, mkodu.Text, aylabel.Text);
               dt = vt.dtGetir(sorgu2asd);

            select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad




                string sorgu1 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad ", yıllabel.Text, mkodu.Text, aylabel.Text);
                st = vt.dtGetirs(sorgu1);

                //label1.Text = gelir.ToString();
                // label2.Text = iade.ToString();
               for (int i = 0; i < dt.Rows.Count; i++)
               {

                       // double gider = Convert.ToDouble(dt.Rows[i]["fno"].ToString());
                       dataGridView1.Rows.Add(
                       dt.Rows[i]["furunad"].ToString(),
                       dt.Rows[i]["fmiktartoplam"].ToString(),
                       dt.Rows[i]["ftutartoplam"].ToString(),
                       dt.Rows[i]["netkartoplam"].ToString());
               }

               for (int i = 0; i < st.Rows.Count; i++)
               {

                   // double gider = Convert.ToDouble(dt.Rows[i]["fno"].ToString());
                   dataGridView2.Rows.Add(
                   st.Rows[i]["furunad"].ToString(),
                   st.Rows[i]["ifmiktartoplam"].ToString(),
                   st.Rows[i]["iftutartoplam"].ToString(),
                   st.Rows[i]["inetkartoplam"].ToString());

                 //  vt.sqlCalistir("insert into detay(furunad,fmiktar1) values ('" + st.Rows[i]["iftutartoplam"] + "',2)");

               }


               */


            int ay = Convert.ToInt16(aylabel.Text);
            if (ay < 13 && sayfa.Text == "1")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' group by furunad", yıllabel.Text, mkodu.Text, aylabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }
            
                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{2}' AND year(ftarih)='{0}' and fmno='{1}' and firma NOT IN ('0') group by furunad ", yıllabel.Text, mkodu.Text, aylabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {                 
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//tamam
            if (ay ==13 && sayfa.Text == "1")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE year(ftarih)='{0}' and fmno='{1}' group by furunad ", yıllabel.Text, mkodu.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE year(ftarih)='{0}' and fmno='{1}' and firma NOT IN ('0') group by furunad ", yıllabel.Text, mkodu.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//tmm
            if (ay == 14 && sayfa.Text == "1")//genel
            {
                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE fmno='{0}' group by furunad ", mkodu.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // double gider = Convert.ToDouble(dt.Rows[i]["fno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }
                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE fmno='{0}' and firma NOT IN ('0') group by furunad ", mkodu.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {


                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//tmm
            
            ///sayfa2------------------------------------------------------------------------------------------------------------------------------------

            if (ay < 13 && sayfa.Text == "2")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(alımfisicerik.[fmiktar])as fmiktartoplam,sum(alımfisicerik.[ftutar])as ftutartoplam, sum(alımfisicerik.[netkar])as netkartoplam from alımfisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' group by furunad ", yıllabel.Text, aylabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and firma NOT IN ('1') group by furunad ", yıllabel.Text, aylabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//alım tamam
            if (ay == 13 && sayfa.Text == "2")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(alımfisicerik.[fmiktar])as fmiktartoplam,sum(alımfisicerik.[ftutar])as ftutartoplam, sum(alımfisicerik.[netkar])as netkartoplam from alımfisicerik WHERE year(ftarih)='{0}' group by furunad ", yıllabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE year(ftarih)='{0}' and firma NOT IN ('1') group by furunad ", yıllabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//alım tamam
            if (ay == 14 && sayfa.Text == "2")//genel
            {
                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(alımfisicerik.[fmiktar])as fmiktartoplam,sum(alımfisicerik.[ftutar])as ftutartoplam, sum(alımfisicerik.[netkar])as netkartoplam from alımfisicerik group by furunad ");
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // double gider = Convert.ToDouble(dt.Rows[i]["fno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }
                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE firma NOT IN ('1') group by furunad ");
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {


                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }//alım tamam
            //sayfa3 ---------------------------------------------------------------------------------------------------------------------------------------------

            if (sayfa.Text == "3"&& ay != 16 && ay != 17) { panel3.Visible = true; }
            if (ay < 13 && sayfa.Text == "3")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}'  group by furunad ", yıllabel.Text, aylabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' group by furunad ", yıllabel.Text,  aylabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
                //gider
                string sorgu3 = string.Format("select aciklama,sum(gider.[miktar]) as toplam FROM gider WHERE month(tarih)='{1}' AND year(tarih)='{0}' group by aciklama ", yıllabel.Text, aylabel.Text);
                st = vt.dtGetirs(sorgu3);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add(
                    st.Rows[i]["aciklama"].ToString(),
                    st.Rows[i]["toplam"].ToString());
                }


                // gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih=#{0}#", dateTimePicker2.Text);
            }//tmm
            if (ay == 13 && sayfa.Text == "3")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE year(ftarih)='{0}' group by furunad ", yıllabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE year(ftarih)='{0}' and firma NOT IN ('0') group by furunad ", yıllabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
                //gider
                string sorgu3 = string.Format("select aciklama,sum(gider.[miktar])as tutar from gider WHERE year(tarih)='{0}' group by aciklama ", yıllabel.Text);
                st = vt.dtGetirs(sorgu3);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add(
                    st.Rows[i]["aciklama"].ToString(),
                    st.Rows[i]["tutar"].ToString());
                }
            }//++
            if (ay == 14 && sayfa.Text == "3")///genel
            {
                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik group by furunad ");
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // double gider = Convert.ToDouble(dt.Rows[i]["fno"].ToString());
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }
                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik where firma NOT IN ('0')/ group by furunad ");
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {


                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
                //gider
                string sorgu3 = string.Format("select aciklama,sum(gider.[miktar])as tutar from gider group by aciklama ");
                st = vt.dtGetirs(sorgu3);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add(
                    st.Rows[i]["aciklama"].ToString(),
                    st.Rows[i]["tutar"].ToString());
                }
            }//
            if (ay == 15 && sayfa.Text == "3")
            {

                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE ftarih=#{0}# group by furunad ", yıllabel.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE ftarih=#{0}# and firma NOT IN ('0') group by furunad ", yıllabel.Text);
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
                //gider
                string sorgu3 = string.Format("select aciklama,sum(gider.[miktar])as tutar from gider WHERE tarih=#{0}# group by aciklama ", yıllabel.Text);
                st = vt.dtGetirs(sorgu3);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add(
                    st.Rows[i]["aciklama"].ToString(),
                    st.Rows[i]["tutar"].ToString());
                }
            }//
            if (ay == 16 && sayfa.Text == "3")
            {
                
                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='1' group by furunad ", yıllabel.Text,yıl2.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }
                
                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='1' and firma NOT IN ('0') group by furunad", yıllabel.Text, yıl2.Text);//yıl=ay  yıl2=yıl
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }// butonunu sildim 
            if (ay == 17 && sayfa.Text == "3")
            {
               
                dataGridView1.Rows.Clear();

                string sorgu = string.Format("select furunad, sum(fisicerik.[fmiktar])as fmiktartoplam,sum(fisicerik.[ftutar])as ftutartoplam, sum(fisicerik.[netkar])as netkartoplam from fisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='2' group by furunad ", yıllabel.Text, yıl2.Text);
                dt = vt.dtGetir(sorgu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(
                    dt.Rows[i]["furunad"].ToString(),
                    dt.Rows[i]["fmiktartoplam"].ToString(),
                    dt.Rows[i]["ftutartoplam"].ToString(),
                    dt.Rows[i]["netkartoplam"].ToString());
                }

                string sorgu2 = string.Format("select furunad,sum(iadefisicerik.[fmiktar])as ifmiktartoplam,sum(iadefisicerik.[ftutar])as iftutartoplam, sum(iadefisicerik.[netkar])as inetkartoplam from iadefisicerik WHERE month(ftarih)='{1}' AND year(ftarih)='{0}' and rutk='2' and firma NOT IN ('0') group by furunad", yıllabel.Text, yıl2.Text);//yıl=ay  yıl2=yıl
                st = vt.dtGetirs(sorgu2);
                for (int i = 0; i < st.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(
                    st.Rows[i]["furunad"].ToString(),
                    st.Rows[i]["ifmiktartoplam"].ToString(),
                    st.Rows[i]["iftutartoplam"].ToString(),
                    st.Rows[i]["inetkartoplam"].ToString());
                }
            }// butonunu sildim




        }
    }
}
