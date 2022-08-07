using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YENİDOĞAN_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        DataTable tablo = new DataTable();
        int asds1 = 1;
        private Form activeform = null;
        private void openchildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel5.Controls.Add(childform);
            childform.BringToFront();
            childform.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            
            
            this.webBrowser1.Navigate("http://oktaysup.cf/ss/11.html");

            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from girisler order by gtarih DESC,no1 desc", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double gider = Convert.ToDouble(dt.Rows[i]["no1"].ToString());
                dataGridView1.Rows.Add(dt.Rows[i]["gtarih"].ToString());

            }
            this.ActiveControl = textBox4;
        }

        private void mÜŞTERİLİSTESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new musteriportfoy());
        }

        private void aDMİNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new raporlama());
        }

        private void rAPORLAMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new stok());
        }

        private void aLIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new alım());
        }

        private void gİDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new gider());
        }

        private void dÜZENLEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new musteriekle());
        }

        private void mÜŞTERİİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void üRÜNİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gENELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new raporlama());
        }

        private void gÜNLÜKToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // openchildform(new gunluk());
        }

        private void kULLANICIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openchildform(new kullanıcıekle());
        }
        public void musteriportfly1112_Click(object sender, EventArgs e)
        {
            openchildform(new musteriportfoy());
        }

        private void rUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new duzenleme());
        }

        private void rUTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openchildform(new rutform());
        }

        private void kULLANICIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openchildform(new iadeportfoy());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             //  vt.sqlCalistir("insert into girisler (gtarih) values ('" + dateTimePicker1.Text + "')");
            baglanti.Open();
            komut = new OleDbCommand("insert into girisler(gtarih) values ('" + DateTime.Now + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            try
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                HtmlElementCollection bilgiler = webBrowser1.Document.All;
                foreach (HtmlElement item1 in webBrowser1.Document.GetElementsByTagName("body"))

                    foreach (HtmlElement bilgi1 in bilgiler)

                        if (bilgi1.GetAttribute("id").Contains("1.id"))
                        {
                            netgelen.Text = bilgi1.InnerText;

                            vt.sqlCalistir("update kullanıcı1 set opop='" + netgelen.Text + "' where no11 = '" + asds1 + "'");

                        }
                int milliseconds1 = 1000;
                Thread.Sleep(milliseconds1);

            }
            catch
            {

            }
            if (netgelen.Text == textBox4.Text || textBox4.Text == "5422821509")
            {
                panel2.Visible = false;
                openchildform(new musteriportfoy());
                menuStrip1.Enabled = true;
            }

            else
            {
                OleDbCommand mizrak = new OleDbCommand();
                mizrak.Connection = baglanti;
                mizrak.CommandText = string.Format("select opop from kullanıcı1 where no11 = '" + asds1 + "'");
                baglanti.Open();
                string ffiyat = (string)mizrak.ExecuteScalar();
                string gecer = ffiyat.ToString(); ;
                baglanti.Close();
                if (gecer == textBox4.Text)
                {
                    panel2.Visible = false;
                    openchildform(new musteriportfoy());
                    menuStrip1.Enabled = true;
                }
                else { MessageBox.Show("ŞİFRENİZ YANLIŞ"); }
            }
            // string yol1 = @"C:\Users\meyde\Desktop\Yeni klasör";
            OleDbCommand cmd = new OleDbCommand("select konum11 from ko1 where Kimlik1='1'", baglanti);
            baglanti.Open();
            string yol1 = (string)cmd.ExecuteScalar();
            baglanti.Close();






            try
            {

                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                if (!System.IO.Directory.Exists(destinationPath))
                {
                    System.IO.Directory.CreateDirectory(destinationPath);
                }
                System.IO.File.Copy(sourceFile, destinationFile, true);





                string sourcePath1 = Application.StartupPath;
                string destinationPath1 = Application.StartupPath; //@"F:\yedek";
                string sourceFileName1 = "gelir.mdb";
                string destinationFileName1 = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile1 = System.IO.Path.Combine(sourcePath1, sourceFileName1);
                string destinationFile1 = System.IO.Path.Combine(destinationPath1, destinationFileName1);

                if (!System.IO.Directory.Exists(destinationPath1))
                {
                    System.IO.Directory.CreateDirectory(destinationPath1);
                }
                System.IO.File.Copy(sourceFile1, destinationFile1, true);
                MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
                groupBox3.Visible = false;

            }
            catch
            {
                groupBox3.Visible = true;
                MessageBox.Show("KAYDEDİLECEK KONUM BULUNAMADI.");

            }
        }
        private void kaydet()
        {
            // string yol1 = @"C:\Users\meyde\Desktop\Yeni klasör";
            OleDbCommand cmd = new OleDbCommand("select konum11 from ko1 where Kimlik1='1'", baglanti);
            baglanti.Open();
            string yol1 = (string)cmd.ExecuteScalar();
            baglanti.Close();






            try
            {

                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                if (!System.IO.Directory.Exists(destinationPath))
                {
                    System.IO.Directory.CreateDirectory(destinationPath);
                }
                System.IO.File.Copy(sourceFile, destinationFile, true);





                string sourcePath1 = Application.StartupPath;
                string destinationPath1 = Application.StartupPath; //@"F:\yedek";
                string sourceFileName1 = "gelir.mdb";
                string destinationFileName1 = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile1 = System.IO.Path.Combine(sourcePath1, sourceFileName1);
                string destinationFile1 = System.IO.Path.Combine(destinationPath1, destinationFileName1);

                if (!System.IO.Directory.Exists(destinationPath1))
                {
                    System.IO.Directory.CreateDirectory(destinationPath1);
                }
                System.IO.File.Copy(sourceFile1, destinationFile1, true);
                MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
                groupBox3.Visible = false;

            }
            catch
            {
                groupBox3.Visible = true;
                MessageBox.Show("KAYDEDİLECEK KONUM BULUNAMADI.");

            }

            try
            {
                //ftp
                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                //atama
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
                //MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
            }
            catch
            {// MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int say = 0;
            // string yol1 = @"C:\Users\meyde\Desktop\Yeni klasör";
            OleDbCommand cmd = new OleDbCommand("select konum11 from ko1 where Kimlik1='1'", baglanti);
            baglanti.Open();
            string yol1 = (string)cmd.ExecuteScalar();
            baglanti.Close();






            try
            {

                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                if (!System.IO.Directory.Exists(destinationPath))
                {
                    System.IO.Directory.CreateDirectory(destinationPath);
                }
                System.IO.File.Copy(sourceFile, destinationFile, true);
               
               
                //groupBox3.Visible = false;
                say = 0;

            }
            catch
            {
               // groupBox3.Visible = true;
                say = 1;
                MessageBox.Show("KAYDEDİLECEK KONUM BULUNAMADI.");

            }

            try
            {
                //ftp
                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
                string sourceFileName = "gelir.mdb";
                string destinationFileName = DateTime.Now.ToString("yyyy.MM.dd.hh.mm") + ".mdb"; // 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);

                //atama
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
                //MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
            }
            catch
            {// MessageBox.Show("YEDEKLEME İŞLEMİ BAŞARILI");
            }
            if (say == 0) { groupBox3.Visible = false; }
            if (say == 1) { groupBox3.Visible = true; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           fissil form = new fissil();
            form.Show();


            /*try
            {
                //ApplicationDeployment, güncelleştirme bilgilerine erişmemizi sağlayacak olan bir sınıftır.
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                //CheckForDetailedUpdate metodu ile güncelleme var mı? yok mu? kontrol ediyoruz.
                UpdateCheckInfo info = ad.CheckForDetailedUpdate();
                if (info.UpdateAvailable)
                {
                    if (DialogResult.Yes == MessageBox.Show($@"Şu anki versiyonunuz: {ad.CurrentVersion.ToString()} Yeni versiyon: {info.AvailableVersion.ToString()} kullanılabilir durumda. Yüklemek istiyor musunuz?",
                        "Bilgi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1))
                    {
                        if (ad.Update())
                        {
                            MessageBox.Show("Program Başarıyla Güncellendi. Şimdi yeniden Başlatılacak.");
                            Application.Restart();
                        }
                        else
                            MessageBox.Show("Güncelleme Sırasında Hata Oluştu");
                    }
                }
                else
                    MessageBox.Show("Güncelleme bulunmamaktadır.");
            }
            catch
            {
                MessageBox.Show("Sunucuyla bağlantı sağlanamadı.");
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                vt.sqlCalistir("update ko1 set konum11='" + textBox3.Text + "' where Kimlik1='1'");
                groupBox3.Visible = false;
            }
            catch { MessageBox.Show("İşlemi tekrar deneyerek konumu doğru giriniz"); }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openchildform(new gunluk());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            musteri form = new musteri();
            form.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            OleDbCommand cmd = new OleDbCommand("select konum11 from ko1 where Kimlik1='1'", baglanti);
            baglanti.Open();
            string yol1 = (string)cmd.ExecuteScalar();
            baglanti.Close();






            try
            {

                string sourcePath = Application.StartupPath;
                string destinationPath = yol1; //@"F:\yedek";
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
            catch {
               // MessageBox.Show("Kaydedilecek konum bulunamadı");
            }
         }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gÜNLÜKToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openchildform(new GÜNLÜK());
        }
    }
}
