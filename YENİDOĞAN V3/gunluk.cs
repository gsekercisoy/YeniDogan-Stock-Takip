using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YENİDOĞAN_V3
{
    public partial class gunluk : Form
    {
        public gunluk()
        {
            InitializeComponent();
        }
        DataTable st;
        string gidersorgu1, gelirsorgu1, gidersorgu2;
        decimal gelir1 = 0, sonuc1 = 0, aragider = 0, aragider2 = 0, iadesatım = 0, iadealım = 0, birincigün = 0, ikincigün = 0, ücüncügün = 0, dördüncügün = 0,
            besincigün = 0,altıncıgün = 0,yedincigün = 0;
        decimal birgelir = 0, birgider = 0,
            ikigelir = 0, ikigider = 0,
            ücgelir = 0, ücgider = 0,
            dörtgelir = 0, dörtgider = 0,
            besgelir = 0, besgider = 0,
            altıgelir = 0, altıgider = 0,
            yedigelir = 0, yedigider = 0;

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sourcePath = Application.StartupPath;
            string destinationPath = @"C:\Users\meyde\Desktop\Yeni klasör"; //@"F:\yedek";
            string sourceFileName = "gelir.mdb";
            string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
            string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
            string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

            if (!System.IO.Directory.Exists(destinationPath))
            {
                System.IO.Directory.CreateDirectory(destinationPath);
            }
            System.IO.File.Copy(sourceFile, destinationFile, true);

            //ftp

            FileInfo dosyabilgisi = new FileInfo(sourceFile);
            string ftpadres = "ftp://" + "ftpupload.net" + "/" + "htdocs" + "/" + dosyabilgisi.Name;
            FtpWebRequest ftpıstek = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpadres));

            ftpıstek.Credentials = new NetworkCredential("epiz_26389227", "G9JEtVSYcj1W7J5");
            ftpıstek.KeepAlive = false;
            ftpıstek.Method = WebRequestMethods.Ftp.UploadFile;
            ftpıstek.UseBinary = true;
            ftpıstek.ContentLength = dosyabilgisi.Length;

            int bufferuzunlugu = 2048;
            byte[] buff = new byte[10000000];
            int sayi;

            FileStream strem = dosyabilgisi.OpenRead();
            Stream str = ftpıstek.GetRequestStream();
            sayi = strem.Read(buff, 0, bufferuzunlugu);

            while (sayi != 0)
            {
                str.Write(buff, 0, sayi);
                sayi = strem.Read(buff, 0, bufferuzunlugu);
            }
            str.Close();
            strem.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string sourcePath = Application.StartupPath ;
                string destinationPath = @"C:\Users\meyde\Desktop\Yeni klasör"; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                if (!System.IO.Directory.Exists(destinationPath))
                {
                    System.IO.Directory.CreateDirectory(destinationPath);
                }
                System.IO.File.Copy(sourceFile, destinationFile, true);
            }
            catch
            {
                MessageBox.Show("Yedeklenecek dosya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            
           


        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        DataTable tablo = new DataTable();
        private void gunluk_Load(object sender, EventArgs e)
        {
           
            /* dateTimePicker1.Value = DateTime.Today;
             dateTimePicker1.Format = DateTimePickerFormat.Custom;
             dateTimePicker1.CustomFormat = "dd";
             dateTimePicker2.Value = DateTime.Today;
             dateTimePicker2.Format = DateTimePickerFormat.Custom;
             dateTimePicker2.CustomFormat = "yyyy";
             dateTimePicker3.Value = DateTime.Today;
             dateTimePicker3.Format = DateTimePickerFormat.Custom;
             dateTimePicker3.CustomFormat = "MM";*/

            gunluk1();      // hazır
            haftalık();
            gunluk1();
           aylık1();
            haftalıkchart1();
            chart1aktif1();
            



            /* dateTimePicker5.Value = DateTime.Today;
             dateTimePicker5.Format = DateTimePickerFormat.Custom;
             dateTimePicker5.CustomFormat = "dd/MM/yyyy";*/
        }
        private void gunluk1()
        {
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "MM/dd/yyyy";



            //ocak gider
            //----------------
                   gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih=#{0}#", dateTimePicker4.Text);
                   st = vt.dtGetirs(gidersorgu2);
                   try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
                   catch { iadealım = 0; }
                  //-----------------------
                  gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih=#{0}#", dateTimePicker4.Text);
                   st = vt.dtGetirs(gidersorgu2);
                   try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
                   catch { iadesatım = 0; }
                   //iade--------     
           
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih=#{0}#", dateTimePicker4.Text);
            st = vt.dtGetirs(gidersorgu1);
             gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider WHERE tarih=#{0}#", dateTimePicker4.Text);
               try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
             catch { aragider = 0; }//gider menusu


            //ocak gider
             gidersorgu1 = "";
             gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih=#{0}#", dateTimePicker4.Text);
             st = vt.dtGetirs(gidersorgu1);
             try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
             aragider2 = aragider2 - iadealım;
             sonuc1 = aragider + aragider2;//sonuc
             gunlukgider.Text = sonuc1.ToString();
             //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih=#{0}#", dateTimePicker4.Text);
           // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            gunlukgelir.Text = gelir1.ToString();
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            gunlukkar.Text = sonuc1.ToString();
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;
        }
        private void haftalık()
        {
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "MM/dd/yyyy";
           dateTimePicker3.Value = DateTime.Today;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/dd/yyyy";
            dateTimePicker3.Value = DateTime.Now.AddDays(-6);


            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text,dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }
            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            
            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            haftalıkgider.Text = sonuc1.ToString();
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            
            gelir1 = gelir1 - iadesatım;
            haftalıkgelir.Text = gelir1.ToString();
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            haftalıkkar.Text = sonuc1.ToString();
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;
        }
        private void aylık1()
        {
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "MM/dd/yyyy";
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/dd/yyyy";
            dateTimePicker3.Value = DateTime.Now.AddMonths(-1);


            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }
            
            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            aylıkgider.Text = sonuc1.ToString();
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            aylıkgelir.Text = gelir1.ToString();
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            aylıkkar.Text = sonuc1.ToString();
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;
        }
       private void haftalıkchart1()
        {
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "MM/dd/yyyy";
           // dateTimePicker3.Value = DateTime.Today;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/dd/yyyy";
            //-------------------------------------------------------------------------1//////birinci 0 bu
            birgelir = Convert.ToDecimal(gunlukgelir.Text);
            birgider = Convert.ToDecimal(gunlukgider.Text);

            //----------------------------------------------------------------------------2
            //gelir--

            dateTimePicker3.Value = DateTime.Now.AddDays(-1);
           

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            ikigider = sonuc1;
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            ikigelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            ikincigün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;

            //----------------------------------------------------------------------------3
            //gelir--
            dateTimePicker3.Value = DateTime.Now.AddDays(-2);// 2.gün

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            ücgider = sonuc1;//atama-------------------------------
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            ücgelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            ücüncügün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;

            //----------------------------------------------------------------------------4
            //gelir--
            dateTimePicker3.Value = DateTime.Now.AddDays(-3);  // 3.gün

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            dörtgider = sonuc1;//atama-------------------------------
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            dörtgelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            dördüncügün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;


            //----------------------------------------------------------------------------5
            //gelir--
            dateTimePicker3.Value = DateTime.Now.AddDays(-4);  // 4.gün

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            besgider = sonuc1;//atama-------------------------------
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            besgelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            besincigün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;
            
            
            
            //----------------------------------------------------------------------------6
            //gelir--
            dateTimePicker3.Value = DateTime.Now.AddDays(-5);  // 5.gün

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            altıgider = sonuc1;//atama-------------------------------
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            altıgelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            altıncıgün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;


            //----------------------------------------------------------------------------2
            //gelir--
            dateTimePicker3.Value = DateTime.Now.AddDays(-6);     // 6.gün

            //ocak gider
            //----------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno<'1' and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadealım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadealım = 0; }
            //-----------------------
            gidersorgu2 = String.Format("SELECT sum(iade.[itutar]) as toplam FROM iade WHERE imno NOT IN ('0') and itarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu2);
            try { iadesatım = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { iadesatım = 0; }

            //iade--------     
            gidersorgu1 = String.Format("SELECT sum(gider.[miktar]) as toplam FROM gider where tarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);

            try { aragider = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { aragider = 0; }//gider menusu


            //ocak gider
            gidersorgu1 = "";
            gidersorgu1 = String.Format("SELECT sum(alım.[atutar]) as toplam FROM alım WHERE atarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gidersorgu1);
            try { aragider2 = Convert.ToDecimal(st.Rows[0]["toplam"]); } catch { aragider2 = 0; }//alım menusu
            aragider2 = aragider2 - iadealım;
            sonuc1 = aragider + aragider2;//sonuc
            yedigider = sonuc1;//atama-------------------------------
            //gelir--


            sonuc1 = 0;                 //Select  sum(fis.[ftoplam]) as toplam FROM fis between #{0}# and #{1}# , dateTimePicker2.Text, dateTimePicker3.Text
            gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE ftarih between #{0}# and #{1}#", dateTimePicker4.Text, dateTimePicker3.Text);
            // gelirsorgu1 = String.Format("SELECT sum(fis.[ftoplam]) as toplam FROM fis WHERE day(ftarih)='{0}' and year(ftarih)='{1}'and month(ftarih)='{2}'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
            st = vt.dtGetirs(gelirsorgu1);

            try { gelir1 = Convert.ToDecimal(st.Rows[0]["toplam"]); }
            catch { gelir1 = 0; }
            gelir1 = gelir1 - iadesatım;
            yedigelir = gelir1;//atama-------------------------------
            //sonuc--
            sonuc1 = gelir1 - aragider - aragider2;
            yedincigün = sonuc1;//--------------------------------------kar atama lazım olur
            sonuc1 = 0; gelir1 = 0; aragider = 0; aragider2 = 0;




        }
       private void chart1aktif1()
        {
            string bir1 = DateTime.Now.AddDays(0).ToString().Substring(0, 10);
            string iki2 = DateTime.Now.AddDays(-1).ToString().Substring(0, 10);
            string üc3 = DateTime.Now.AddDays(-2).ToString().Substring(0, 10);
            string dör4 = DateTime.Now.AddDays(-3).ToString().Substring(0, 10);
            string bes5 = DateTime.Now.AddDays(-4).ToString().Substring(0, 10);
            string altı6 = DateTime.Now.AddDays(-5).ToString().Substring(0, 10);
            string yedi7 = DateTime.Now.AddDays(-6).ToString().Substring(0, 10);
            chart1.Series["GİDER"].Points.Clear();
            chart1.Series["GELİR"].Points.Clear();

            chart1.Series["GELİR"].Points.AddXY(yedi7, yedigelir);
            chart1.Series["GELİR"].Points.AddXY(altı6, altıgelir);
            chart1.Series["GELİR"].Points.AddXY(bes5, besgelir);
            chart1.Series["GELİR"].Points.AddXY(dör4, dörtgelir);
            chart1.Series["GELİR"].Points.AddXY(üc3, ücgelir);
            chart1.Series["GELİR"].Points.AddXY(iki2, ikigelir);
            chart1.Series["GELİR"].Points.AddXY(bir1, birgelir);



            chart1.Series["GİDER"].Points.AddXY(yedi7, yedigider);
            chart1.Series["GİDER"].Points.AddXY(altı6, altıgider);
            chart1.Series["GİDER"].Points.AddXY(bes5, besgider);
            chart1.Series["GİDER"].Points.AddXY(dör4, dörtgider);
            chart1.Series["GİDER"].Points.AddXY(üc3, ücgider);
            chart1.Series["GİDER"].Points.AddXY(iki2, ikigider);
            chart1.Series["GİDER"].Points.AddXY(bir1, birgider);

            //günlük taplo
            chart2.Series["GELİR"].Points.Clear();
            chart2.Series["GELİR"].Points.AddXY("GELİR", birgelir);
            chart2.Series["GELİR"].Points.AddXY("GİDER", birgider);

            //haftalık
            chart3.Series["GELİR"].Points.Clear();
            chart3.Series["GELİR"].Points.AddXY("GELİR", haftalıkgelir.Text);
            chart3.Series["GELİR"].Points.AddXY("GİDER", haftalıkgider.Text);

            //aylık
            chart4.Series["GELİR"].Points.Clear();
            chart4.Series["GELİR"].Points.AddXY("GELİR", aylıkgelir.Text);
            chart4.Series["GELİR"].Points.AddXY("GİDER", aylıkgider.Text);


        }
    }
}
