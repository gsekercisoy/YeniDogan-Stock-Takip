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
    public partial class duzenleme : Form
    {
        public duzenleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sıfırla()
        {
            urunadtxt.Text = "";
            urunbirim.Text = "";
            urunno.Text = "";
            satis.Text = "";
            birim.Text = "";
            textBox1.Text = "";
            firmatxt.Text = "";
        }
        private void listele()
        {
            urungrd.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                urungrd.Rows.Add(dt.Rows[i]["no1"].ToString(),
                dt.Rows[i]["firma"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["urunbirim"].ToString(),
                dt.Rows[i]["satis"].ToString(),              
                dt.Rows[i]["birim"].ToString()); 

            }


        }
        public int VarMi(string aranan)
        {
            baglanti.Close();
            int sonuc;
            
            string sorgu = "Select COUNT(urunad) from ürün WHERE urunad='" + aranan + "'";
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
            return sonuc;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (VarMi(urunadtxt.Text) != 0)
            {
                MessageBox.Show("AYNI İSİMDE KAYIT YAPILAMAZ");
            }
            else
            {

                try
                {
                    if (urunadtxt.Text != "")
                    {
                        baglanti.Open();
                        komut = new OleDbCommand("insert into ürün(urunad,urunbirim,birim,satis,stok,firma) values ('" + urunadtxt.Text + "','" + urunbirim.Text + "','" + birim.Text + "','" + satis.Text + "','0','" + firmatxt.Text + "')", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        listele();
                        sıfırla();
                        guncelle.Enabled = false;
                        sil.Enabled = false;
                        ekle.Enabled = true;
                    }
                }
                catch { MessageBox.Show("ÜRÜN BİLGİLERİNİ KONTROL EDİNİZ"); }
               
                
            }
        }

        private void duzenleme_Load(object sender, EventArgs e)
        {
            listele();
            guncelle.Enabled = false;
            sil.Enabled = false;
            this.ActiveControl = urunadtxt;

            //--------firma ismi-------
            firmatxt.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from musteri where mtp='0'", baglanti); 
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                firmatxt.Items.Add(dr[1]);
            }
            baglanti.Close();
        }

        private void guncelle_Click(object sender, EventArgs e)
        {




           // try
          //  {
                vt.sqlCalistir("update ürün set urunad='" + urunadtxt.Text + "',urunbirim='" + urunbirim.Text + "',birim='" + birim.Text + "',satis='" + satis.Text + "',firma='" + firmatxt.Text + "' where no1=" + Convert.ToInt16(urunno.Text));
                MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                sıfırla();
                guncelle.Enabled = false;
                sil.Enabled = false;
                ekle.Enabled = true;



         /*   }
            catch
            {
                MessageBox.Show("Güncellemek istediğiniz ürünün üzerine tıklayınız ve Tüm alanları doğru doldurduğunuza emin olunuz");
            }*/
         }
            
        private void sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (urunno.Text != "")
                {
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("ÜRÜN SİLMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ?", "ÜRÜN SİL", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        groupBox3.Visible = true;
                        MessageBox.Show("ONAY YAZARAK SİLEBİLİRSİNİZ.");
                    }
                    if (dialog == DialogResult.No)
                    {
                       // MessageBox.Show("SİLME İŞLEMİ BAŞARISIZ");
                    }

                   
                }
                else MessageBox.Show("Silmek istediğiniz ürünün üzerine tıklayınız", "HATA");
            }
            catch
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ( textBox1.Text== "ONAY"|| textBox1.Text == "onay")// kullanıcı şifre atanacak
                {

                    if (string.IsNullOrEmpty(urunno.Text))
                    {

                        MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Kayıt Silinecek Onaylıyor musunuz?", "İşlem Onayı",


                    MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        
                        return;
                    }
                    vt.sqlCalistir("delete from ürün where urunad='"+urunadtxt.Text+"'");                
                    listele();
                    sıfırla();
                    MessageBox.Show("Kayıt Silindi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guncelle.Enabled = false;
                    sil.Enabled = false;
                    ekle.Enabled = true;
                    groupBox3.Visible = false;






                }
                else
                {
                    MessageBox.Show("GİRİŞ HATALI");
                    groupBox3.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("GİRİŞ HATALI");
                groupBox3.Visible = false;
            }
        }

        private void urungrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                urunno.Text = urungrd.CurrentRow.Cells[0].Value.ToString();
                firmatxt.Text = urungrd.CurrentRow.Cells[1].Value.ToString();
                urunadtxt.Text = urungrd.CurrentRow.Cells[2].Value.ToString();
                urunbirim.Text = urungrd.CurrentRow.Cells[3].Value.ToString();
                satis.Text = urungrd.CurrentRow.Cells[4].Value.ToString();
                birim.Text = urungrd.CurrentRow.Cells[5].Value.ToString();
                guncelle.Enabled = true;
                sil.Enabled = true;
                ekle.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ürün Ekleyiniz");
            }




        }

        private void durunbirim_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void urunbirim_TextChanged(object sender, EventArgs e)
        {

        }

        private void urunadtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = firmatxt;
            }
        }

        private void firmatxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = satis;
            }
        }

        private void birim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = urunadtxt;
            }
        }

        private void urunbirim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = birim;
            }
        }

        private void satis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = urunbirim;
            }
        }

        private void duzenleme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                guncelle_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                button6_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                button1_Click(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guncelle.Enabled = false;
            sil.Enabled = false;
            ekle.Enabled = true;
            sıfırla();
        }

        private void firmatxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void firmatxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            urungrd.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün WHERE firma='"+firmatxt.Text+"'", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                urungrd.Rows.Add(dt.Rows[i]["no1"].ToString(),
                dt.Rows[i]["firma"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["urunbirim"].ToString(),
                dt.Rows[i]["satis"].ToString(),
                dt.Rows[i]["birim"].ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urungrd.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün WHERE urunad='" + urunadtxt.Text + "'", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                urungrd.Rows.Add(dt.Rows[i]["no1"].ToString(),
                dt.Rows[i]["firma"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["urunbirim"].ToString(),
                dt.Rows[i]["satis"].ToString(),
                dt.Rows[i]["birim"].ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void firmatxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = satis;
            }
        }
    }
}
