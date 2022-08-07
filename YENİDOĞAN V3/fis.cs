using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;


namespace YENİDOĞAN_V3
{
    public partial class fis : Form
    {
        public fis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        decimal sonuc, fiyat1, miktar1, stok, stoksonuc, alımfiyat22,karsonuc;
        bool işlem22 = false;

        

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
            alımfiyat.Text = "";
            karsonuctxt.Text = "";

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
                        if (snotxt.Text == "") { snotxt.Text = "5"; }
                        baglanti.Open();
                        komut = new OleDbCommand("insert into fisicerik(fsno,fmno,furunad,fmiktar,fbirim,ffiyat,ftutar,ftarih,netkar,rutk) values ('" + snotxt.Text + "','" + mkodu.Text + "','" + fürün.Text + "','" + fmiktar.Text + "','" + birimtxt.Text + "','" + fiyat.Text + "','" + tutar1.Text + "','" + dateTimePicker1.Text + "','" + karsonuctxt.Text + "','" + rutkontol.Text + "')", baglanti);
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

                    vt.sqlCalistir("update fis set ftoplam='" + bakiye + "',ftarih='" + dateTimePicker1.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set fistoplam='" + toplamkontrol.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set ftavno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                }
                else { MessageBox.Show("Bu Fiş numarası bulunmakta"); }
            }
            else
            {
                MessageBox.Show("SERİ NO GİRİNİZ");
            }
            
            
        
            




         }
        public int VarMi(string aranan)
        {
            baglanti.Close();
            int sonuc;
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
            string sorgu = "Select COUNT(fno) from fis WHERE fno='" + aranan + "'";
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
            return sonuc;

        }
        private void fis_Load(object sender, EventArgs e)
        {
            OleDbCommand stokcek3 = new OleDbCommand();
            toplamkontrol.Text = "0";
            toplam.Text = "0";
            //--------ürün isim-------
            fürün.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from ürün ORDER BY urunad ASC", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                fürün.Items.Add(dr[1]);
            }
            baglanti.Close();
            // ------filtre list ismi-----
            filtre.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from musteri where mtp='0'", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                filtre.Items.Add(dr1[1]);
            }
            baglanti.Close();
            //----tarih------------
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            //----serino--------------
            OleDbCommand cmd = new OleDbCommand("select Max(fsno) from fis", baglanti);
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
                    OleDbCommand cmd1 = new OleDbCommand("select Max(fno) from fis", baglanti);
                    baglanti.Open();
                    double tavsiye1;
                    try { tavsiye1 = Convert.ToDouble(cmd1.ExecuteScalar()); } catch { tavsiye1 = 1; }
                    baglanti.Close();
                    tavsiye1 = tavsiye1 + 1;
                    snotxt.Text = tavsiye1.ToString();
                    if( snotxt.Text == "")
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
            stokcek5.CommandText = string.Format("select mbakiye from musteri where mno='"+mkodu.Text+"'");
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
                button1.Enabled = false;
                toplam.Enabled = false;
                düzenle.Visible = true;

                try
                {
                    sno.Text = serino2.Text;
                    stokcek2.Connection = baglanti;
                    stokcek2.CommandText = string.Format("select ftahsilat from fis where fsno=" + Convert.ToDouble(sno.Text));
                    baglanti.Open();
                    string stokcek45 = (string)stokcek2.ExecuteScalar();
                    kapatxt.Text = stokcek45;
                    toplam.Text = stokcek45;
                    baglanti.Close();


                    stokcek1.Connection = baglanti;
                    stokcek1.CommandText = string.Format("select fbakiye from fis where fsno=" + Convert.ToDouble(sno.Text));
                    baglanti.Open();
                    string stokcek22 = (string)stokcek1.ExecuteScalar();
                    mblabel.Text = stokcek22;
                    baglanti.Close();

                    stokcek3.Connection = baglanti;
                    stokcek3.CommandText = string.Format("select fistoplam from fis where fsno=" + Convert.ToDouble(sno.Text));
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
       
        private void listele()
        {
            try
            {
                dataGridView1.Rows.Clear();
                DataTable dt;
                string sorgu = string.Format("select * from fisicerik where fsno='" + snotxt.Text + "'order by fsno DESC", baglanti);
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
                mizrak.CommandText = string.Format("select urunbirim from ürün where urunad='" + fürün.Text + "'");
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
                mizrak7.CommandText = string.Format("select satis from ürün where urunad='" + fürün.Text + "'");
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
                stoksonuc = stok - miktar1;
                stoksonuctxt.Text = stoksonuc.ToString();
                tutar1.Text = sonuc.ToString();

                //kar
                alımfiyat22 = Convert.ToDecimal(alımfiyat.Text);
                decimal kar22 = Convert.ToDecimal(tutar1.Text);
                karsonuc = alımfiyat22; 
                karsonuc = karsonuc * miktar1;
                karsonuc = kar22 - karsonuc;
                karsonuctxt.Text = karsonuc.ToString();
                //------
            }
            catch
            {
                tutar1.Text = "0";
                stoksonuctxt.Text = "0";
            }
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (ficerik.Text == "fserino" && tutar1.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                vt.sqlCalistir("update fisicerik set furunad='" + fürün.Text + "',fmiktar='" + fmiktar.Text + "',fbirim='" + birimtxt.Text + "',ffiyat='" + fiyat.Text + "',ftutar='" + tutar1.Text + "',ftarih='" + dateTimePicker1.Text + "' where fno=" + ficerik.Text + "");
                MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
                listele();
                sıfırla();

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
                    vt.sqlCalistir("delete from fisicerik where fno=" + Convert.ToDouble(ficerik.Text));
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
                    vt.sqlCalistir("update fis set ftoplam='" + bakiye + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set fbakiye='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set fistoplam='" + toplamkontrol.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    listele();
                    button2.Enabled = false;
                    button1.Enabled = false;






                }
                catch { MessageBox.Show("BİR HATA OLUŞTU. DİKKATLİCE KONTROL EDİP TEKRAR DENEYİNİZ VE VERİTABANINI SİLMEDİĞİNİZDEN EMİN OLUNUZ."); }

            }
            else { MessageBox.Show("Bu Fiş numarası bulunmakta"); }

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
               
                fiyat1 = Convert.ToDecimal(fiyat.Text);
                miktar1 = Convert.ToDecimal(fmiktar.Text);
                sonuc = fiyat1 * miktar1;
                tutar1.Text = sonuc.ToString();

                //kar
                alımfiyat22 = Convert.ToDecimal(alımfiyat.Text);
                decimal kar22 = Convert.ToDecimal(tutar1.Text);
                karsonuc = alımfiyat22;
                karsonuc = karsonuc * miktar1;
                karsonuc = kar22 - karsonuc;
                karsonuctxt.Text = karsonuc.ToString();
                //------


            }
            catch
            {
            }
        }

        

        private void toplam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = snotxt;
            }
        }

        private void toplam_KeyPress(object sender, KeyPressEventArgs e)
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

        private void snotxt_TextChanged(object sender, EventArgs e)
        {
            listele();
            
                OleDbCommand stokcek3 = new OleDbCommand();
            stokcek3.Connection = baglanti;
            stokcek3.CommandText = string.Format("select kilit from fis where fno='"+snotxt.Text+"'");
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

        private void snotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tutar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = toplam;
            }
        }

        private void tutar1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void snotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = fürün;
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
                    form4.denetim.Text = "fis";
                    timer1.Enabled = true;
                }

            }
        }

        private void fmiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = fiyat;
            }
        }

        private void satısgrupbox_Enter(object sender, EventArgs e)
        {

        }

        private void tutar1_TextChanged(object sender, EventArgs e)
        {
            //kar
            
            try {
                decimal kar22 = Convert.ToDecimal(tutar1.Text);
                alımfiyat22 = Convert.ToDecimal(karsonuctxt.Text);
                karsonuc = kar22 - alımfiyat22;
                karsonuctxt.Text = karsonuc.ToString();
            }
            catch { }
            
            //------
        }


        public void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void filtre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--------ürün isim-------
            fürün.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from ürün where firma='" + filtre.Text + "'ORDER BY urunad ASC", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                fürün.Items.Add(dr[1]);
            }
            baglanti.Close();
        }

        private void düzenle_Click(object sender, EventArgs e)
        {
            fürün.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
                     
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
                timer1.Enabled = false;

            }
        }

        private void fiyat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = tutar1;
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

        private void fis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button3_Click(sender,e);
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
                button1.Enabled = true;


                if (serino2.Text != "serino 2")
                {
                    button2.Enabled = false;
                    button1.Enabled = false;
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
                catch {
                    
                    double silsonuc = 0;
                    stoksil.Text = silsonuc.ToString();
                    baglanti.Close();
                }
                OleDbCommand stokcek1 = new OleDbCommand();
                stokcek1.Connection = baglanti;
                stokcek1.CommandText = string.Format("select ftutar from fisicerik where fno='" + ficerik.Text + "'");
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
                if (serino2.Text != "serino 2")
                {                                   
                    this.Close();
                }
                
                if (serino2.Text == "serino 2") //MessageBox.Show("3");
                {
                    vt.sqlCalistir("update fis set kilit='1' where fsno=" + Convert.ToDouble(sno.Text));
                    double kontroltoplam1;
                    vt.sqlCalistir("update fis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    vt.sqlCalistir("update fis set ftavno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                    double kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                    try { kontroltoplam1 = Convert.ToDouble(toplam.Text); }
                    catch { kontroltoplam1 = 0; }

                    double kalanbakiye = kontroltoplam - kontroltoplam1;
                    if (kontroltoplam != kontroltoplam1)
                    {
                        vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                        vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                        
                    }
                    if (kontroltoplam == kontroltoplam1)
                    {

                        kalanbakiye = 0;

                        vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                        vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                        

                    }

                    this.Close();
                }
            }
               





                /*  if (serino2.Text == "serino 2") //MessageBox.Show("3");
                  {

                      vt.sqlCalistir("update fis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                      vt.sqlCalistir("update fis set ftavno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                      double kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                      double kontroltoplam1 = Convert.ToDouble(toplam.Text);
                      double kalanbakiye = kontroltoplam - kontroltoplam1;



                      if (kalanbakiye < 0 && kontroltoplam < 0 && işlem22==false)
                      {
                          if (kontroltoplam != kontroltoplam1)
                          {
                              kalanbakiye = 0;
                              kontroltoplam = 0;
                              kontroltoplam1 = 0;
                              kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                              kontroltoplam1 = Convert.ToDouble(toplam.Text);
                              kalanbakiye = kontroltoplam + kontroltoplam1;

                              vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                              vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                          }
                          if (kontroltoplam == kontroltoplam1)
                          {

                              kalanbakiye = 0;

                              vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                              vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                          }

                          this.Close();
                        //  MessageBox.Show("1");
                          işlem22 = true;


                      }
                      if (kalanbakiye < 0 && kontroltoplam>0 && işlem22 == false)
                      {
                          if (kontroltoplam != kontroltoplam1)
                          {
                              kalanbakiye = 0;
                              kontroltoplam = 0;
                              kontroltoplam1 = 0;
                              kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                              kontroltoplam1 = Convert.ToDouble(toplam.Text);
                              kalanbakiye = kontroltoplam - kontroltoplam1;

                              vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                              vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                          }
                          if (kontroltoplam == kontroltoplam1)
                          {

                              kalanbakiye = 0;

                              vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                              vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                              vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                          }

                          this.Close();
                        //  MessageBox.Show("2");
                          işlem22 = true;

                      }
                      if (kalanbakiye > 0 && işlem22 == false)
                      {
                              if (kontroltoplam != kontroltoplam1)
                              {
                                  kalanbakiye = 0;
                                  kontroltoplam = 0;
                                  kontroltoplam1 = 0;
                                  kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                                  kontroltoplam1 = Convert.ToDouble(toplam.Text);
                                  kalanbakiye = kontroltoplam - kontroltoplam1;

                                  vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                                  vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                                  vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                                  vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                              }
                              if (kontroltoplam == kontroltoplam1)
                              {

                                  kalanbakiye = 0;

                                  vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                                  vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                                  vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                              }

                          this.Close();
                       //   MessageBox.Show("3");
                          işlem22 = true;
                      }*/



           
            else
            {
                MessageBox.Show("SERİ NO BOŞ OLAMAZ");
            }
           

            /*       if (snotxt.Text != "" || serino2.Text != "serino 2")  /// eskisi
               {
                   if (snotxt.Text != "")
                   {
                       vt.sqlCalistir("update fis set fno='" + snotxt.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                   }
                   double kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                   double kontroltoplam1 = Convert.ToDouble(toplam.Text);
                   double kalanbakiye = kontroltoplam - kontroltoplam1;
                   if (kalanbakiye < 0)
                   {
                       MessageBox.Show("BAKİYE NEGATİF SAYI OLAMAZ");
                   }
                   else
                   {

                       /* if (serino2.Text != "serino 2" && toplam2.Text == toplamkontrol.Text && kapatxt.Text == toplam.Text)
                        {
                            musteriportfoy form1 = new musteriportfoy();
                            form1.pictureBox1_Click(sender, e);
                            this.Close();
                            // MessageBox.Show("1");
                        }

                        if (serino2.Text != "serino 2" && toplam2.Text != toplamkontrol.Text || serino2.Text != "serino 2" && kapatxt.Text != toplam.Text)
                        {
                            kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                            kontroltoplam1 = Convert.ToDouble(toplam.Text);




                            //MessageBox.Show("2");

                            if (kontroltoplam != kontroltoplam1)
                            {

                                kalanbakiye = kontroltoplam - kontroltoplam1;

                                vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno=" + Convert.ToDouble(mkodu.Text));
                                vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fno=" + Convert.ToDouble(sno.Text));
                                vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fno=" + Convert.ToDouble(sno.Text));
                                vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                            }
                            if (kontroltoplam == kontroltoplam1)
                            {

                                kalanbakiye = kontroltoplam - kontroltoplam1;

                                vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno=" + Convert.ToDouble(mkodu.Text));
                                vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fno=" + Convert.ToDouble(sno.Text));
                                vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fno=" + Convert.ToDouble(sno.Text));

                            }
                            musteriportfoy form = new musteriportfoy();
                            form.pictureBox1_Click(sender, e);
                            this.Close();
                        }

                       if (serino2.Text == "serino 2") //MessageBox.Show("3");
                       {

                           kalanbakiye = 0;
                           kontroltoplam = 0;
                           kontroltoplam1 = 0;
                           kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                           kontroltoplam1 = Convert.ToDouble(toplam.Text);


                           if (kontroltoplam != kontroltoplam1)
                           {
                               kalanbakiye = 0;
                               kontroltoplam = 0;
                               kontroltoplam1 = 0;
                               kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                               kontroltoplam1 = Convert.ToDouble(toplam.Text);
                               kalanbakiye = kontroltoplam - kontroltoplam1;
                               MessageBox.Show("123");
                               vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno='" + mkodu.Text + "'");
                               vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                               vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                               vt.sqlCalistir("insert into bakiye(bmno,bakiye,btarih) values ('" + mkodu.Text + "','" + kalanbakiye + "','" + dateTimePicker1.Text + "')");
                           }
                           if (kontroltoplam == kontroltoplam1)
                           {
                               kalanbakiye = 0;
                               kontroltoplam = 0;
                               kontroltoplam1 = 0;
                               kontroltoplam = Convert.ToDouble(toplamkontrol.Text);
                               kontroltoplam1 = Convert.ToDouble(toplam.Text);
                               kalanbakiye = kontroltoplam - kontroltoplam1;
                               MessageBox.Show("swws");
                               vt.sqlCalistir("update musteri set mbakiye='" + kalanbakiye + "' where mno=" + Convert.ToDouble(mkodu.Text));
                               vt.sqlCalistir("update fis set fbakiye='" + mblabel.Text + "' where fsno=" + Convert.ToDouble(sno.Text));
                               vt.sqlCalistir("update fis set ftahsilat='" + toplam.Text + "' where fsno=" + Convert.ToDouble(sno.Text));

                           }
                           //-----boş ise




                           musteriportfoy form = new musteriportfoy();
                           form.pictureBox1_Click(sender, e);
                           this.Close();
                       }
                   }
               }

               else
               {
                   MessageBox.Show("SERİ NO GİRİNİZ");
               }*/




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
    }
}
