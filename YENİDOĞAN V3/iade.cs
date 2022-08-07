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
    public partial class iade : Form
    {
        public iade()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbCommand komut1;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        decimal fiyat1, miktar1, sonuc, stok, stoksonuc;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

                stok = Convert.ToDecimal(stoktxt.Text);
                miktar1 = Convert.ToDecimal(txtMiktar.Text);
                decimal gunculstk = Convert.ToDecimal(stokguncel.Text);
                decimal guncelsonuc = stok - gunculstk;
                stoksonuc = guncelsonuc + miktar1;



                stoksonuctxt.Text = stoksonuc.ToString();
            }
            catch
            {
            }
            if (satimiade.Checked == true)
            {
                if (txtMiktar.Text == "" && musteritxt.Text == "" && dtTarih.Text == "" && atoplam.Text == "" && fürün.Text == "" && txtNo.Text == "" && mnotxt.Text == "")
                {
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vt.sqlCalistir("update iade set imno='" + mnotxt.Text + "', iurunad='" + fürün.Text + "',imiktar='" + txtMiktar.Text + "', ibirim='" + birimtxt.Text + "', ifiyat='" + fiyat.Text + "',itutar='" + atoplam.Text + "',itarih='" + dtTarih.Text + "'  where ino=" + Convert.ToDouble(txtNo.Text) + "");
                vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
                MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                btnGider.Enabled = true;
                musteritxt.Enabled = true;
            }
            if (alımiade.Checked == true)
            {
                if (txtMiktar.Text == "" && atoplam.Text == "" && fürün.Text == "" && txtNo.Text == "" )
                {
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vt.sqlCalistir("update alım set imno='" + mnotxt.Text + "',iurunad='" + musteritxt.Text + "',imiktar='" + txtMiktar.Text + "',atutar='" + atoplam.Text + "',itarih='" + dtTarih.Text + "', ibirim='" + birimtxt.Text + "', ifiyat='" + fiyat.Text + "', where ino=" + txtNo.Text + "");
                vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
                MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                btnGider.Enabled = true;
                musteritxt.Enabled = false;

            }
            
            sıfırla();
            Goster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text))
            {

                MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Kayıt Silinecek Onaylıyor musunuz?", "İşlem Onayı",

            MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }
            // vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
            OleDbCommand stokcek = new OleDbCommand();
            try
            {
                 stokcek.Connection = baglanti;
                stokcek.CommandText = string.Format("select stok from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                string stokcek2 = (string)stokcek.ExecuteScalar();
                stoktxt.Text = stokcek2.ToString(); ;
                baglanti.Close();

            
                stok = Convert.ToDecimal(stoktxt.Text);
                miktar1 = Convert.ToDecimal(txtMiktar.Text);
                stoksonuc = stok - miktar1;
                stoksonuctxt.Text = stoksonuc.ToString();
                vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
                vt.sqlCalistir("delete from iade where ino=" + Convert.ToInt32(txtNo.Text));
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                btnGider.Enabled = true;              
                sıfırla();
                if (satimiade.Checked == true)
                {
                    musteritxt.Enabled = true;
                }
                if (satimiade.Checked == false)
                {
                    musteritxt.Enabled = false;
                }
            }
            catch
            {
                vt.sqlCalistir("delete from iade where ino=" + Convert.ToInt32(txtNo.Text));
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                btnGider.Enabled = true;
                sıfırla();
                if (satimiade.Checked == true)
                {
                    musteritxt.Enabled = true;
                }
                if (satimiade.Checked == false)
                {
                    musteritxt.Enabled = false;
                }
            }
            
            Goster();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //hesap makinesi
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void numara1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMiktar.Text = txtMiktar.Text + ((Button)sender).Text;
            }
            catch { }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            try
            {
                int sil = txtMiktar.Text.Length;
                txtMiktar.Text = txtMiktar.Text.Substring(0, sil - 1);
            }
            catch
            {
                //MessageBox.Show("Silinecek Değer Yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dgGider.Rows.Clear();
            DataTable dt;


            dt = vt.dtGetir("select* from iade where iurunad like '%" + txtAra.Text + "%' or imno like '%" + txtAra.Text + "%' or ino like '%" + txtAra.Text + "%' or imiktar like '%" + txtAra.Text + "%' or itarih like '%" + txtAra.Text + "%' or itutar like '%" + txtAra.Text + "%' order by itarih desc,ino desc");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["ino"].ToString());
                dgGider.Rows.Add(
                dt.Rows[i]["ino"].ToString(),
                dt.Rows[i]["imno"].ToString(),
                dt.Rows[i]["iurunad"].ToString(),
                dt.Rows[i]["imiktar"].ToString(),
                dt.Rows[i]["ibirim"].ToString(),
                dt.Rows[i]["ifiyat"].ToString(),
                dt.Rows[i]["itutar"].ToString(),
                dt.Rows[i]["itarih"].ToString().Substring(0, 10));
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Gostertarih();
        }
        public void Gostertarih()
        {
            dgGider.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("Select * from iade where itarih=#{0}# order by itarih desc, ino desc", dateTimePicker1.Text);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["ino"].ToString());
                dgGider.Rows.Add(
                 dt.Rows[i]["ino"].ToString(),
                dt.Rows[i]["imno"].ToString(),
                dt.Rows[i]["iurunad"].ToString(),
                dt.Rows[i]["imiktar"].ToString(),
                dt.Rows[i]["ibirim"].ToString(),
                dt.Rows[i]["ifiyat"].ToString(),
                dt.Rows[i]["itutar"].ToString(),
                dt.Rows[i]["itarih"].ToString().Substring(0, 10));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //tarih fark
            if (panel2.Visible)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgGider.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("Select * from iade where itarih between #{0}# and #{1}# order by itarih desc, ino desc", dateTimePicker2.Text, dateTimePicker3.Text);
            //string sorgu = string.Format("Select * from gider where tarih BETWEEN '"+dateTimePicker2.Text+"'and'"+dateTimePicker3.Text+"'");// order by tarih desc, giderId
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["ino"].ToString());
                dgGider.Rows.Add(
                 dt.Rows[i]["ino"].ToString(),
                dt.Rows[i]["imno"].ToString(),
                dt.Rows[i]["iurunad"].ToString(),
                dt.Rows[i]["imiktar"].ToString(),
                dt.Rows[i]["ibirim"].ToString(),
                dt.Rows[i]["ifiyat"].ToString(),
                dt.Rows[i]["itutar"].ToString(),
                dt.Rows[i]["itarih"].ToString().Substring(0, 10));
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fürün_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMiktar.Text = "";
           // musteritxt.Text = "";
            fiyat.Text = "";
            atoplam.Text = "";
            stoktxt.Text = "";
            stoksonuctxt.Text = "";
            OleDbCommand mizrak = new OleDbCommand();
            if (satimiade.Checked == true)
            {
                mizrak.Connection = baglanti;
                mizrak.CommandText = string.Format("select urunbirim from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    decimal ffiyat = (decimal)mizrak.ExecuteScalar();
                    fiyat.Text = ffiyat.ToString(); ;
                    baglanti.Close();
                }
                catch
                {
                    fiyat.Text = "0";
                    baglanti.Close();
                }
                
            }
            if (alımiade.Checked == true)
            {
                mizrak.Connection = baglanti;
                mizrak.CommandText = string.Format("select satis from ürün where urunad='" + fürün.Text + "'");
                baglanti.Open();
                try
                {
                    decimal ffiyat = (decimal)mizrak.ExecuteScalar();
                    fiyat.Text = ffiyat.ToString(); ;
                    baglanti.Close();
                }
                catch
                {
                    fiyat.Text = "0";
                    baglanti.Close();
                }
                
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
                baglanti.Close();
            }
            catch
            {
                stoktxt.Text = "0";
                baglanti.Close();
            }
            
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (satimiade.Checked == true)
                {
                    stok = Convert.ToDecimal(stoktxt.Text);
                    fiyat1 = Convert.ToDecimal(fiyat.Text);
                    miktar1 = Convert.ToDecimal(txtMiktar.Text);
                    sonuc = fiyat1 * miktar1;
                    stoksonuc = stok + miktar1;
                    stoksonuctxt.Text = stoksonuc.ToString();
                    atoplam.Text = sonuc.ToString();
                }
                if (alımiade.Checked == true)
                {
                    stok = Convert.ToDecimal(stoktxt.Text);
                    fiyat1 = Convert.ToDecimal(fiyat.Text);
                    miktar1 = Convert.ToDecimal(txtMiktar.Text);
                    sonuc = fiyat1 * miktar1;
                    stoksonuc = stok - miktar1;
                    stoksonuctxt.Text = stoksonuc.ToString();
                    atoplam.Text = sonuc.ToString();
                }
            }
            catch
            {
                atoplam.Text = "0";
                stoksonuctxt.Text = "0";
            }
        }

        private void musteritxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand mizrak = new OleDbCommand();
            mizrak.Connection = baglanti;
            mizrak.CommandText = string.Format("select mno from musteri where madı='" + musteritxt.Text + "'");
            baglanti.Open();
            string mnotxt1 = (string)mizrak.ExecuteScalar();
            mnotxt.Text = mnotxt1.ToString();
            baglanti.Close();

        }

        private void alımiade_CheckedChanged(object sender, EventArgs e)
        {
            musteritxt.Text = "";
            musteritxt.Enabled = false;
            label2.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnGider.Enabled = true;
            mnotxt.Text = "0";
            sıfırla();
        }

        private void dgGider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dgGider.CurrentRow.Cells[0].Value.ToString();          
            mnotxt.Text = dgGider.CurrentRow.Cells[1].Value.ToString();
            fürün.Text = dgGider.CurrentRow.Cells[2].Value.ToString();
            txtMiktar.Text = dgGider.CurrentRow.Cells[3].Value.ToString();
          //  birimtxt.Text = dgGider.CurrentRow.Cells[4].Value.ToString();
            fiyat.Text = dgGider.CurrentRow.Cells[5].Value.ToString();
            atoplam.Text = dgGider.CurrentRow.Cells[6].Value.ToString();
            dtTarih.Text = dgGider.CurrentRow.Cells[7].Value.ToString();
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnGider.Enabled = false;
            musteritxt.Enabled = false;

            OleDbCommand stokcek11 = new OleDbCommand();
            stokcek11.Connection = baglanti;
            stokcek11.CommandText = string.Format("select imiktar from iade where ino=" + txtNo.Text + "");
            baglanti.Open();
            try
            {
                string stokcek3 = (string)stokcek11.ExecuteScalar();
                stokguncel.Text = stokcek3;
                baglanti.Close();
            }
            catch
            {

                stokguncel.Text = "0";
                baglanti.Close();
            }



        }

        private void satimiade_CheckedChanged(object sender, EventArgs e)
        {
            musteritxt.Text = "";
            musteritxt.Enabled = true;
            label2.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnGider.Enabled = true;

            sıfırla();
            
        }

        private void dgGider_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnGuncelle_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnGider_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                btnSil_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                satimiade.Checked = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                alımiade.Checked = true;
            }
        }

        private void musteritxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = fürün;
            }
        }

        private void fürün_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = txtMiktar;
            }
        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = fiyat;
            }
        }

        private void atoplam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = dtTarih;
            }
        }

        private void dtTarih_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = musteritxt;
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void fiyat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = atoplam;
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            if (satimiade.Checked == true)
            {
                musteritxt.Enabled = true;
            }
            if (alımiade.Checked == true)
            {
                mnotxt.Text = "0";
                musteritxt.Enabled = false;
            }

            if (txtMiktar.Text == "" || dtTarih.Text == "")
            {
               
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                
            }
            vt.sqlCalistir("insert into iade (imno,iurunad,imiktar,ibirim,ifiyat,itutar,itarih) values ('" + mnotxt.Text + "','" + fürün.Text + "','" + txtMiktar.Text + "','" + birimtxt.Text + "','" + fiyat.Text + "','" + atoplam.Text + "','" + dtTarih.Text + "')");
            vt.sqlCalistir("update ürün set stok='" + stoksonuctxt.Text + "' where urunad='" + fürün.Text + "'");
            MessageBox.Show("iade alındı", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sıfırla();
            Goster();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
           


        }

        private void iade_Load(object sender, EventArgs e)
        {
            dtTarih.Value = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Custom;
            dtTarih.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Now.AddMonths(-1);
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            Goster();
            this.ActiveControl = musteritxt;
        }
        public void Goster()
        {
            dgGider.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("Select * from iade order by itarih desc,ino desc");
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["ino"].ToString());
                dgGider.Rows.Add(
                dt.Rows[i]["ino"].ToString(),
                dt.Rows[i]["imno"].ToString(),
                dt.Rows[i]["iurunad"].ToString(),
                dt.Rows[i]["imiktar"].ToString(),
                dt.Rows[i]["ibirim"].ToString(),
                dt.Rows[i]["ifiyat"].ToString(),
                dt.Rows[i]["itutar"].ToString(),
                dt.Rows[i]["itarih"].ToString().Substring(0, 10));
            }
            //--------ürün isim-------
            baglanti.Close();
            fürün.Items.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from ürün", baglanti);
            adtr = new OleDbDataAdapter(komut);
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                fürün.Items.Add(dr[1]);
            }
            baglanti.Close();
            //------müsteri-----------------
            musteritxt.Items.Clear();
            baglanti.Open();
            komut1 = new OleDbCommand("select * from musteri", baglanti);
            adtr = new OleDbDataAdapter(komut1);
            komut1.CommandType = CommandType.Text;
            OleDbDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                musteritxt.Items.Add(dr1[1]);
            }
            baglanti.Close();
        }
        public void sıfırla()
        {
            txtMiktar.Clear();
            txtNo.Clear();
            fürün.Text="";
            txtAra.Clear();
            atoplam.Clear();
            musteritxt.Text = "";
            stoktxt.Text = "";
            txtMiktar.Text = "";
            txtAra.Text = "";
            mnotxt.Text = "";
            ffiyat1.Text = "";
            fiyat.Text = "";
            stoksonuctxt.Text = "";

        }
        
    }
}
