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
    public partial class musteriekle : Form
    {
        public musteriekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        int say22=0;
        private void musteriekle_Load(object sender, EventArgs e)
        {
            listele();
            this.ActiveControl = mnotxt;
            OleDbCommand cmd = new OleDbCommand("select Max(tavsiyeno) from musteri", baglanti);
            baglanti.Open();
            double kayitSayisi;
            try { kayitSayisi = Convert.ToDouble(cmd.ExecuteScalar()); kayitSayisi = kayitSayisi + 1; } catch { kayitSayisi = 1; }
            baglanti.Close();
            mnotxt.Text = kayitSayisi.ToString();
            button15.Enabled = false;
            button16.Enabled = false;
            this.ActiveControl = mnotxt;


        }
        private void sıfırla()
        {
            mnotxt.Text = "";
            musteritxt.Text = "";
            adrestxt.Text = "";
            kişi.Text = "";
            vergid.Text = "";
            vergino.Text = "";
            iletisim.Text = "";
            bakiye.Text = "";
            rut.Text = "";

        }
        private void listele()
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from musteri order by tavsiyeno desc", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["mno"].ToString());
                dataGridView1.Rows.Add(
                dt.Rows[i]["mno"].ToString(),
                dt.Rows[i]["madı"].ToString(),
                dt.Rows[i]["madres"].ToString(),
                dt.Rows[i]["myetkili"].ToString(),
                dt.Rows[i]["vergid"].ToString(),
                dt.Rows[i]["vergino"].ToString(),
                dt.Rows[i]["miletisim"].ToString(),
                dt.Rows[i]["mbakiye"].ToString(),
                dt.Rows[i]["rutp"].ToString(),
                dt.Rows[i]["mtp"].ToString());
        }
        }
        public int VarMi(string aranan)
        {
            int sonuc;
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
            string sorgu = "Select COUNT(madı) from musteri WHERE madı='" + aranan + "'";
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
            return sonuc;

        }
        public int VarMino(string aranan)
        {
            baglanti.Close();
            int sonuc;      
            string sorgu = "Select COUNT(mno) from musteri WHERE mno='" + aranan + "'";
            komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
            return sonuc;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (mnotxt.Text != "")
            {


                if (bakiye.Text == "")
                {
                    bakiye.Text = "0";
                }

                if (VarMino(mnotxt.Text) != 0)
                {
                    MessageBox.Show("AYNI MÜŞTERİ KODUNDA KAYIT YAPILAMAZ");
                }
                else
                {


                    if (VarMi(musteritxt.Text) != 0)
                    {
                        MessageBox.Show("AYNI İSİMDE KAYIT YAPILAMAZ");
                    }
                    else
                    {


                        if (musteritxt.Text != "" && mnotxt.Text != "")
                        {

                            OleDbCommand cmd = new OleDbCommand("select Max(rno) from rut where rhafta='" + rut.Text + "'", baglanti);
                            baglanti.Open();
                            double kayitSayisi;
                            try { kayitSayisi = Convert.ToDouble(cmd.ExecuteScalar()); } catch { kayitSayisi = 1; }
                            baglanti.Close();
                            kayitSayisi = kayitSayisi + 1;
                            baglanti.Open();
                            if (mustericek.Checked == true && rut.Text != "")//müsteri ekle
                            {
                                string qq = "1";
                                vt.sqlCalistir("insert into musteri(mno,madı,madres,myetkili,vergid,vergino,miletisim,mbakiye,rutp,tavsiyeno,mtp) values ('" + mnotxt.Text + "','" + musteritxt.Text + "','" + adrestxt.Text + "','" + kişi.Text + "','" + vergid.Text + "','" + vergino.Text + "','" + iletisim.Text + "','" + bakiye.Text + "','" + rut.Text + "','" + mnotxt.Text + "','" + qq + "')");//müşteri
                                vt.sqlCalistir("insert into rut(rno,rmadı,rhafta) values ('" + kayitSayisi + "','" + musteritxt.Text + "','" + rut.Text + "')");
                            }

                            if (firmacek.Checked == true) // firma ekle
                            {
                                string qq0 = "0";
                                vt.sqlCalistir("insert into musteri(mno,madı,madres,myetkili,vergid,vergino,miletisim,mbakiye,tavsiyeno,mtp) values ('" + mnotxt.Text + "','" + musteritxt.Text + "','" + adrestxt.Text + "','" + kişi.Text + "','" + vergid.Text + "','" + vergino.Text + "','" + iletisim.Text + "','" + bakiye.Text + "','" + mnotxt.Text + "','" + qq0 + "')");//firma
                            }


                            listele();
                            sıfırla();
                                                    
                            OleDbCommand cmd122 = new OleDbCommand("select Max(tavsiyeno) from musteri", baglanti);
                            baglanti.Close();
                            baglanti.Open();
                            double kayitSayisi2;
                            try { kayitSayisi2 = Convert.ToDouble(cmd122.ExecuteScalar()); kayitSayisi2 = kayitSayisi2 + 1; } catch { kayitSayisi2 = 1; }
                            baglanti.Close();
                            mnotxt.Text = kayitSayisi2.ToString();


                           
                           
                        }
                        else
                        {

                        }


                    }
                }
            }
            else { MessageBox.Show("Müşteri Numarasını Giriniz"); }
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = true;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mnotxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                musteritxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                adrestxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                kişi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                vergid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                vergino.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                iletisim.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                bakiye.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                rut.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                //rutkontrol.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                rutkontrol.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString(); // müsteri tipi

                if(rutkontrol.Text == "1") { mustericek.Checked = true; }
                if (rutkontrol.Text == "0") { firmacek.Checked = true; }
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = false;

            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        double kayitSayisi;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (mnotxt.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (mustericek.Checked == true && rut.Text != "")//müsteri ekle
                {
                    vt.sqlCalistir("update musteri set madı='" + musteritxt.Text + "', madres='" + adrestxt.Text + "',myetkili='" + kişi.Text + "',vergid='" + vergid.Text + "',vergino='" + vergino.Text + "',miletisim='" + iletisim.Text + "',rutp='" + rut.Text + "',mtp='1' where mno='" + mnotxt.Text + "'");
                    //if (rut.Text != rutkontrol.Text) //gereksiz kontrol
                    //{
                        OleDbCommand cmd = new OleDbCommand("select Max(rno) from rut where rhafta='" + rut.Text + "'", baglanti);
                        baglanti.Open();
                        try { kayitSayisi = Convert.ToDouble(cmd.ExecuteScalar()); } catch { kayitSayisi = 0; }
                        baglanti.Close();
                        kayitSayisi = kayitSayisi + 1;
                    vt.sqlCalistir("delete from rut where rmadı='" + musteritxt.Text + "'");
                    vt.sqlCalistir("insert into rut(rno,rmadı,rhafta) values ('" + kayitSayisi + "','" + musteritxt.Text + "','" + rut.Text + "')");//tekrar ekleme

                   // }
                }
                if (mustericek.Checked == true && rut.Text == "") { MessageBox.Show("Rut alanını doldurunuz"); }

                if (firmacek.Checked == true) // firma ekle
                {
                    vt.sqlCalistir("update musteri set madı='" + musteritxt.Text + "', madres='" + adrestxt.Text + "',myetkili='" + kişi.Text + "',vergid='" + vergid.Text + "',vergino='" + vergino.Text + "',miletisim='" + iletisim.Text + "',mtp='0' where mno='" + mnotxt.Text + "'");
                    try
                    {
                        vt.sqlCalistir("delete from rut where rmadı='" + musteritxt.Text + "'");
                    }
                    catch {}
                       

                    
                }

               // vt.sqlCalistir("update musteri set madı='" + musteri.Text + "', madres='" + adrestxt.Text + "',myetkili='" + kişi.Text + "',vergid='" + vergid.Text + "',vergino='" + vergino.Text + "',miletisim='" + iletisim.Text + "',rutp='" + rut.Text + "' where mno='" + mnotxt.Text + "'");
                MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                sıfırla();

            }
            try
            {
                OleDbCommand cmd1 = new OleDbCommand("select Max(tavsiyeno) from musteri", baglanti);
                baglanti.Open();
                double kayitSayisi2;
                try { kayitSayisi2 = Convert.ToDouble(cmd1.ExecuteScalar()); kayitSayisi2 = kayitSayisi2 + 1; } catch { kayitSayisi2 = 1; }
                baglanti.Close();
                mnotxt.Text = kayitSayisi2.ToString();


            }
            catch { }
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = true;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select* from musteri where mno like '%" + ara.Text + "%' or madı like '%" + ara.Text + "%' or madres like '%" + ara.Text + "%' or myetkili like '%" + ara.Text + "%' or vergid like '%" + ara.Text + "%' or rutp like '%" + ara.Text + "%'  order by tavsiyeno desc");
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["mno"].ToString());
                dataGridView1.Rows.Add(
               dt.Rows[i]["mno"].ToString(),
                dt.Rows[i]["madı"].ToString(),
                dt.Rows[i]["madres"].ToString(),
                dt.Rows[i]["myetkili"].ToString(),
                dt.Rows[i]["vergid"].ToString(),
                dt.Rows[i]["vergino"].ToString(),
                dt.Rows[i]["miletisim"].ToString(),
                dt.Rows[i]["mbakiye"].ToString(),
                dt.Rows[i]["rutp"].ToString(),
                dt.Rows[i]["mtp"].ToString());
            }
            if (ara.Text == "") listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mnotxt.Text))
            {

                MessageBox.Show("Lütfen Silinecek Kaydı Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Kayıt Silinecek Onaylıyor musunuz?", "İşlem Onayı",

            MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }
            vt.sqlCalistir("delete from musteri where mno='"+mnotxt.Text+"'");
            vt.sqlCalistir("delete from rut where rmadı='" + musteritxt.Text + "'");
            Convert.ToInt32(mnotxt.Text);
            listele();
            sıfırla();
            MessageBox.Show("Kayıt Silindi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                OleDbCommand cmd1 = new OleDbCommand("select Max(tavsiyeno) from musteri", baglanti);
                baglanti.Open();
                double kayitSayisi2;
                try { kayitSayisi2 = Convert.ToDouble(cmd1.ExecuteScalar()); kayitSayisi2 = kayitSayisi2 + 1; } catch { kayitSayisi2 = 1; }
                baglanti.Close();
                mnotxt.Text = kayitSayisi2.ToString();


            }
            catch { }
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = true;

        }

        private void bakiye_KeyPress(object sender, KeyPressEventArgs e)
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

        private void musteriekle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button2_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                button1_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                button3_Click(sender, e);
            }
        }

        private void mnotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = musteritxt;
            }
        }

        private void musteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = adrestxt;
            }
        }

        private void adrestxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = kişi;
            }
        }

        private void kişi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = vergid;
            }
        }

        private void vergid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = vergino;
            }
        }

        private void vergino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = iletisim;
            }
        }

        private void iletisim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = bakiye;
            }
        }

        private void bakiye_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.ActiveControl = rut;
            }
        }

        private void mnotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void firmacek_CheckedChanged(object sender, EventArgs e)
        {
            rut.Enabled = false;
            label63.Text = "FİRMA KODU";
            label69.Text = "FİRMA ADI";
        }

        private void mustericek_CheckedChanged(object sender, EventArgs e)
        {
            rut.Enabled = true;
            label63.Text = "MÜŞTERİ KODU";
            label69.Text = "MÜŞTERİ ADI";
        }

        private void bakiye_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void bakiye_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = rut;
            }
        }

        private void mnotxt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mnotxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = musteritxt;
            }
        }

        private void musteritxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = adrestxt;
            }
        }

        private void adrestxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = kişi;
            }
        }

        private void kişi_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = vergid;
            }
        }

        private void vergid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = vergino;
            }
        }

        private void vergino_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = iletisim;
            }
        }

        private void iletisim_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = bakiye;
            }
        }

        private void rut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = mnotxt;
            }
        }
    }
}
