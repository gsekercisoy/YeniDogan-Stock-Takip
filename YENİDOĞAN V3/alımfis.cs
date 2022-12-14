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
    public partial class alımfis : Form
    {
        public alımfis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        decimal sonuc, fiyat1, miktar1, stok, stoksonuc, alımfiyat22, karsonuc;
        private object notifyIcon1;

        private void alımfis_Load(object sender, EventArgs e)
        {
            OleDbCommand stokcek3 = new OleDbCommand();
            toplamkontrol.Text = "0";
            toplam.Text = "0";
            //--------ürün isim-------
            fürün.Items.Clear();
            baglanti.Close();
            baglanti.Open();
            komut = new OleDbCommand("select * from ürün where firma='"+madılabel.Text+ "'ORDER BY urunad ASC", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                fürün.Items.Add(dr[1]);
            }
            baglanti.Close();
            //----tarih------------
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            //----serino--------------
            OleDbCommand cmd = new OleDbCommand("select Max(fsno) from alımfis", baglanti);
            baglanti.Open();
            double kayitSayisi;
            try { kayitSayisi = Convert.ToDouble(cmd.ExecuteScalar()); } catch { kayitSayisi = 1; }
            baglanti.Close();
            kayitSayisi = kayitSayisi + 1;
            if (serino2.Text == "serino 2")
            {
                sno.Text = kayitSayisi.ToString();
            }
            try
            {
                if (serino2.Text == "serino 2")
                {
                    OleDbCommand cmd1 = new OleDbCommand("select Max(fno) from alımfis", baglanti);
                    baglanti.Open();
                    double tavsiye1 = Convert.ToDouble(cmd1.ExecuteScalar());
                    baglanti.Close();
                    tavsiye1 = tavsiye1 + 1;
                    snotxt.Text = tavsiye1.ToString();
                    if (snotxt.Text == "")
                    { snotxt.Text = "1"; }

                    stokcek3.Connection = baglanti;
                    stokcek3.CommandText = string.Format("select kilit from fis where fno='" + snotxt.Text + "'");
                    baglanti.Close();
                    baglanti.Open();
                    try
                    {
                        string stokcek4511 = (string)stokcek3.ExecuteScalar();
                        kilit.Text = stokcek4511;
                        baglanti.Close();
                    }
                    catch { kilit.Text = "0"; }
                }
            }
            catch { }

            OleDbCommand stokcek1 = new OleDbCommand();
            OleDbCommand stokcek2 = new OleDbCommand();
            
            OleDbCommand stokcek4 = new OleDbCommand();
            OleDbCommand stokcek5 = new OleDbCommand();
            stokcek5.Connection = baglanti;
            stokcek5.CommandText = string.Format("select mbakiye from musteri where mno='" + mkodu.Text + "'");
            baglanti.Close();
            baglanti.Open();
            string stokcek45121 = (string)stokcek5.ExecuteScalar();
            toplamkontrol.Text = stokcek45121;
            double bakiye = 0;
            for (int w = 0; w < dataGridView1.RowCount; w++)
            {
                bakiye += Convert.ToDouble(dataGridView1.Rows[w].Cells[5].Value);
            }
            double eskibakiye1 = Convert.ToDouble(mblabel.Text);
            double toplam11 = bakiye + eskibakiye1;
            toplamkontrol.Text = toplam11.ToString();

            baglanti.Close();
            if (serino2.Text != "serino 2")
            {
                snotxt.Enabled = false;
                furun.Enabled = false;
                button2.Enabled = false;
                toplam.Enabled = false;

                try
                {
                    sno.Text = serino2.Text;
                    stokcek2.Connection = baglanti;
                    stokcek2.CommandText = string.Format("select ftahsilat from alımfis where fsno=" + Convert.ToDouble(sno.Text));
                    baglanti.Open();
                    string stokcek45 = (string)stokcek2.ExecuteScalar();
                    kapatxt.Text = stokcek45;
                    toplam.Text = stokcek45;
                    baglanti.Close();


                    stokcek1.Connection = baglanti;
                    stokcek1.CommandText = string.Format("select fbakiye from alımfis where fsno=" + Convert.ToDouble(sno.Text));
                    baglanti.Open();
                    string stokcek22 = (string)stokcek1.ExecuteScalar();
                    mblabel.Text = stokcek22;
                    baglanti.Close();

                    stokcek3.Connection = baglanti;
                    stokcek3.CommandText = string.Format("select fistoplam from alımfis where fsno=" + Convert.ToDouble(sno.Text));
                    baglanti.Open();
                    string stokcek451 = (string)stokcek3.ExecuteScalar();
                    toplam2.Text = stokcek451;
                    toplamkontrol.Text = stokcek451;
                    baglanti.Close();

                    stokcek4.Connection = baglanti;
                    stokcek4.CommandText = string.Format("select mbakiye from musteri where mno=" + Convert.ToDouble(mkodu.Text));
                    baglanti.Open();
                    string stokcek4512 = (string)stokcek4.ExecuteScalar();
                    guncelb.Text = stokcek4512;
                    baglanti.Close();
                }
                catch { }

            }
            listele();
            this.ActiveControl = snotxt;
        }

        private void fmiktar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (kilit.Text != "1")
            {
                try
                {
                    if (string.IsNullOrEmpty(ficerik.Text))
                    {

                        MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Kayıt Silinecek Onaylıyor musunuz?", "İşlem Onayı",

                    MessageBoxButtons.YesNo) == DialogResult.No)
                    {

                        return;
                    }

                    try
                    {
                        vt.sqlCalistir("update ürün set stok='" + stoksil.Text + "' where urunad='" + fürün1.Text + "'");
                    }
                    catch { }
                    vt.sqlCalistir("delete from alımfisicerik where fno=" + Convert.ToDouble(ficerik.Text));
                    listele();
                    double bakiye = 0;
                    try
                    {
                        for (int w = 0; w < dataGridView1.RowCount; w++)
                        {
                            bakiye += Convert.ToDouble(dataGridView1.Rows[w].Cells[5].Value);
                        }
                        double eskibakiye1 = Convert.ToDouble(mblabel.Text);
                        double toplam11 = bakiye + eskibakiye1;
                        toplamkontrol.Text = toplam11.ToString();
                        ttoplam.Text = bakiye.ToString();

                    }
                    catch { bakiye = 0; }
                    vt.sqlCalistir("update alımfis set ftoplam='" + bakiye + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update alımfis set fbakiye='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update alımfis set fistoplam='" + toplamkontrol.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    listele();
                    button2.Enabled = false;






                }
                catch { MessageBox.Show("BİR HATA OLUŞTU. DİKKATLİCE KONTROL EDİP TEKRAR DENEYİNİZ VE VERİTABANINI SİLMEDİĞİNİZDEN EMİN OLUNUZ."); }
            }
            else { MessageBox.Show("Bu Fiş numarası bulunmakta"); }
        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stok = Convert.ToDecimal(stoktxt.Text);
                fiyat1 = Convert.ToDecimal(fiyat.Text);
                miktar1 = Convert.ToDecimal(fmiktar.Text);
                sonuc = fiyat1 * miktar1;
                tutar1.Text = sonuc.ToString();
            }
            catch
            {
            }
        }

        private void tutar1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toplam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = fürün;
            }
        }

        private void fiyat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void fiyat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = tutar1;
            }
        }

        private void fürün_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Application.OpenForms["ürünara"] == null)
                {
                    ürünara form4 = new ürünara();
                    form4.Show();  // form2 göster diyoruz
                    string ara = fürün.Text;
                    form4.textBox1.Text = ara;
                    form4.denetim.Text = "alımfis";
                    timer1.Enabled = true;
                }
                
            }
                
        }

        private void fmiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = fiyat;
            }
        }

        private void tutar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = toplam;
            }
        }

        private void snotxt_TextChanged(object sender, EventArgs e)
        {
            listele();

            OleDbCommand stokcek3 = new OleDbCommand();
            stokcek3.Connection = baglanti;
            stokcek3.CommandText = string.Format("select kilit from alımfis where fno='" + snotxt.Text + "'");
            baglanti.Close();
            baglanti.Open();
            try
            {
                string stokcek4511 = (string)stokcek3.ExecuteScalar();
                kilit.Text = stokcek4511;
                baglanti.Close();
            }
            catch { kilit.Text = "0"; }
        }

        private void alımfis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button3_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                furun_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                furun_Click(sender, e);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                /*fürün.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                fmiktar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                birimtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                fiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tutar1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();*/
                fürün1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                silmiktar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ficerik.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                button2.Enabled = true;


                if (serino2.Text != "serino 2")
                {
                    button2.Enabled = false;
                }




                OleDbCommand stokcek = new OleDbCommand();
                stokcek.Connection = baglanti;
                stokcek.CommandText = string.Format("select stok from ürün where urunad='" + fürün1.Text + "'");
                baglanti.Open();
                try
                {
                    string stokcek2 = (string)stokcek.ExecuteScalar();
                    double silinecek = Convert.ToDouble(silmiktar.Text);
                    double olan = Convert.ToDouble(stokcek2);
                    double silsonuc = olan + silinecek;
                    stoksil.Text = silsonuc.ToString();
                    baglanti.Close();
                }
                catch
                {

                    double silsonuc = 0;
                    stoksil.Text = silsonuc.ToString();
                    baglanti.Close();
                }
                OleDbCommand stokcek1 = new OleDbCommand();
                stokcek1.Connection = baglanti;
                stokcek1.CommandText = string.Format("select ftutar from alımfisicerik where fno='" + ficerik.Text + "'");
                baglanti.Open();
                try
                {
                    string stokcek3 = (string)stokcek1.ExecuteScalar();
                    iceriktutar.Text = stokcek3.ToString();
                    baglanti.Close();
                }
                catch
                {
                    iceriktutar.Text = "0";
                    baglanti.Close();
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musteriportfoy form = new musteriportfoy();
            if (snotxt.Text != "")
            {
                if (serino2.Text != "serino 2" )
                {
                   

                    this.Close();
                }
                if (serino2.Text == "serino 2") //MessageBox.Show("3");
                {
                    vt.sqlCalistir("update alımfis set kilit='1' where fsno=" + Convert.ToDouble(sno.Text));
                    double kontroltoplam1;
                    vt.sqlCalistir("update alımfis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update alımfis set ftavno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    double kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                    try { kontroltoplam1 = Convert.ToDouble(toplam.Text); }
                    catch { kontroltoplam1 = 0; }
                    double kalanbakiye = kontroltoplam - kontroltoplam1;
                    if (kontroltoplam != kontroltoplam1)
                    {
                        vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                        vt.sqlCalistir("update alımfis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        
                    }
                    if (kontroltoplam == kontroltoplam1)
                    {

                        kalanbakiye = 0;

                        vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                        vt.sqlCalistir("update alımfis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        

                    }


                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("SERİ NO BOŞ OLAMAZ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
                
            double kalanbakiye;
                    
            double kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
            double kontroltoplam1 = Convert.ToDouble(toplam.Text);
            if (kontroltoplam < 0)
            {  kalanbakiye = kontroltoplam1 - kontroltoplam; }
            if (kontroltoplam < 0)
            { kalanbakiye = kontroltoplam1 + kontroltoplam; }






        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                /*fürün.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                fmiktar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                birimtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                fiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tutar1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();*/
                fürün1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                silmiktar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ficerik.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                button2.Enabled = true;


                if (serino2.Text != "serino 2")
                {
                    button2.Enabled = false;
                }




                OleDbCommand stokcek = new OleDbCommand();
                stokcek.Connection = baglanti;
                stokcek.CommandText = string.Format("select stok from ürün where urunad='" + fürün1.Text + "'");
                baglanti.Open();
                try
                {
                    string stokcek2 = (string)stokcek.ExecuteScalar();
                    double silinecek = Convert.ToDouble(silmiktar.Text);
                    double olan = Convert.ToDouble(stokcek2);
                    double silsonuc = olan - silinecek;
                    stoksil.Text = silsonuc.ToString();
                    baglanti.Close();
                }
                catch
                {

                    double silsonuc = 0;
                    stoksil.Text = silsonuc.ToString();
                    baglanti.Close();
                }
                OleDbCommand stokcek1 = new OleDbCommand();
                stokcek1.Connection = baglanti;
                stokcek1.CommandText = string.Format("select ftutar from iadefisicerik where fno='" + ficerik.Text + "'");
                baglanti.Open();
                try
                {
                    string stokcek3 = (string)stokcek1.ExecuteScalar();
                    iceriktutar.Text = stokcek3.ToString();
                    baglanti.Close();
                }
                catch
                {
                    iceriktutar.Text = "0";
                    baglanti.Close();
                }
            }
            catch { }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void snotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = fürün;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (Application.OpenForms["ürünara"] == null)
            {
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
                OleDbCommand stokcek5 = new OleDbCommand();
                stokcek5.Connection = baglanti;
                stokcek5.CommandText = string.Format("select ara1 from araurun where no1=1");
                baglanti.Close();
                baglanti.Open();
                string stokcek45121 = (string)stokcek5.ExecuteScalar();
                fürün.Text = stokcek45121;
                timer1.Enabled=false;

            }
        }

        private void sıfırla()
        {
            fürün.Text = "";
            fmiktar.Text = "";
            birimtxt.Text = "";
            fiyat.Text = "";
            tutar1.Text = "";
            stoktxt.Text = "";
            stoksonuctxt.Text = "";
            stok1.Text = "";

        }

        private void furun_Click(object sender, EventArgs e)
        {
            if (snotxt.Text != "")
            {
                
                    if (kilit.Text != "1")
                    {
                        // try
                        //{
                        if (tutar1.Text != "")
                        {
                            baglanti.Open();
                            komut = new OleDbCommand("insert into alımfisicerik(fsno,fmno,furunad,fmiktar,fbirim,ffiyat,ftutar,ftarih) values ('" + snotxt.Text + "','" + mkodu.Text + "','" + fürün.Text + "','" + fmiktar.Text + "','" + birimtxt.Text + "','" + fiyat.Text + "','" + tutar1.Text + "','" + dateTimePicker1.Text + "')", baglanti);
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");

                            sıfırla();
                            listele();
                        }
                        else { MessageBox.Show("ÜRÜN VE MİKTAR GİRİNİZ"); }

                        /*  }
                          catch
                          {

                          }*/


                        double bakiye = 0;
                        try
                        {
                            for (int w = 0; w < dataGridView1.RowCount; w++)
                            {
                                bakiye += Convert.ToDouble(dataGridView1.Rows[w].Cells[5].Value);
                            }


                            double eskibakiye1 = Convert.ToDouble(mblabel.Text);
                            double toplam11 = bakiye + eskibakiye1;
                            toplamkontrol.Text = toplam11.ToString();
                            //toplam.Text = toplam11.ToString();
                        }
                        catch { bakiye = 0; }

                        vt.sqlCalistir("update alımfis set ftoplam='" + bakiye + "',ftarih='" + dateTimePicker1.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set fistoplam='" + toplamkontrol.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update alımfis set ftavno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                    }
                    else { MessageBox.Show("Bu Fiş numarası bulunmakta"); }
                
            }
            else
            {
                MessageBox.Show("FİŞ NO GİRİNİZ");
            }
        }
        public int VarMi(string aranan)
        {
            baglanti.Close();
            int sonuc;
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
            string sorgu = "Select COUNT(fno) from alımfis WHERE fno='" + aranan + "'";
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
            return sonuc;

        }
        private void listele()
        {
            try
            {
                dataGridView1.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from alımfisicerik where fsno='" + snotxt.Text + "'order by fsno DESC", baglanti);
                dt = vt.dtGetir(sorgu);
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
                    try
                    {
                        double bakiye = 0;
                        for (int w = 0; w < dataGridView1.RowCount; w++)
                        {
                            bakiye += Convert.ToDouble(dataGridView1.Rows[w].Cells[5].Value);
                        }
                        ttoplam.Text = bakiye.ToString();
                    }
                    catch { }
                }
            }
            catch { }

        }

        private void fürün_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fmiktar.Text = "";
                birimtxt.Text = "";
                fiyat.Text = "";
                tutar1.Text = "";
                stoktxt.Text = "";
                stok1.Text = "";
                stoksonuctxt.Text = "";
                karsonuctxt.Text = "";
                baglanti.Close();
                OleDbCommand mizrak = new OleDbCommand();
                mizrak.Connection = baglanti;
                mizrak.CommandText = string.Format("select satis from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    decimal ffiyat = (decimal)mizrak.ExecuteScalar();
                    fiyat.Text = ffiyat.ToString();
                    baglanti.Close();
                }
                catch
                {
                    fiyat.Text = "0";
                    baglanti.Close();
                }

                OleDbCommand mizrak7 = new OleDbCommand();
                mizrak7.Connection = baglanti;
                mizrak7.CommandText = string.Format("select urunbirim from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    decimal ffiyat44 = (decimal)mizrak7.ExecuteScalar();
                    alımfiyat.Text = ffiyat44.ToString();
                    baglanti.Close();
                }
                catch
                {
                    alımfiyat.Text = "0";
                    baglanti.Close();
                }

                OleDbCommand br = new OleDbCommand();
                br.Connection = baglanti;
                br.CommandText = string.Format("select birim from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    string br2 = (string)br.ExecuteScalar();
                    birimtxt.Text = br2.ToString();
                    baglanti.Close();
                }
                catch
                {
                    baglanti.Close();
                }

                OleDbCommand stokcek = new OleDbCommand();
                stokcek.Connection = baglanti;
                stokcek.CommandText = string.Format("select stok from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    string stokcek2 = (string)stokcek.ExecuteScalar();
                    stoktxt.Text = stokcek2.ToString();
                    stok1.Text = stokcek2.ToString();
                    baglanti.Close();
                }
                catch
                {
                    stoktxt.Text = "0";
                    stok1.Text = "0";
                    baglanti.Close();
                }

            }
            catch { }
        }

        private void fmiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {

                stok = Convert.ToDecimal(stoktxt.Text);
                fiyat1 = Convert.ToDecimal(fiyat.Text);
                miktar1 = Convert.ToDecimal(fmiktar.Text);
                sonuc = fiyat1 * miktar1;
                stoksonuc = stok + miktar1;
                stoksonuctxt.Text = stoksonuc.ToString();
                tutar1.Text = sonuc.ToString();
            }
            catch
            {
               
            }
        }
    }
}
