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

namespace YENİDOĞAN_V3
{
    public partial class GÜNLÜK : Form
    {
        public GÜNLÜK()
        {
            InitializeComponent();

        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        DataTable tablo = new DataTable();
        public void Goster()
        {
            dgGider.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("Select * from gelir_ciro where tarih=#{0}# order by tarih desc, giderId", dateTimePicker1.Text);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["giderId"].ToString());
                dgGider.Rows.Add(dt.Rows[i]["aciklama"].ToString(), dt.Rows[i]["miktar"].ToString(),
                dt.Rows[i]["tarih"].ToString().Substring(0, 10), dt.Rows[i]["giderId"].ToString());
            }
            double bakiye = 0;
            for (int i = 0; i < dgGider.RowCount; i++)
            {
                bakiye += Convert.ToDouble(dgGider.Rows[i].Cells[1].Value);
            }
            lblGider.Text = bakiye.ToString() + "TL";



        }
        private void GÜNLÜK_Load(object sender, EventArgs e)
        {
            
        }

        private void dgGider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dgGider.CurrentRow.Cells[3].Value.ToString();
            txtMiktar.Text = dgGider.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dgGider.CurrentRow.Cells[0].Value.ToString();
            dtTarih.Text = dgGider.CurrentRow.Cells[2].Value.ToString();
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnGider.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tümünü göster
            dgGider.Rows.Clear();
            DataTable dt;

            dt = vt.dtGetir("select* from gelir_ciro order by tarih desc, giderId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["giderId"].ToString());
                dgGider.Rows.Add(dt.Rows[i]["aciklama"].ToString(), dt.Rows[i]["miktar"].ToString(),
                dt.Rows[i]["tarih"].ToString().Substring(0, 10), dt.Rows[i]["giderId"].ToString());
            }
            double bakiye = 0;
            for (int i = 0; i < dgGider.RowCount; i++)
            {
                bakiye += Convert.ToDouble(dgGider.Rows[i].Cells[1].Value);
            }
            lblGider.Text = bakiye.ToString() + " TL";
        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            if (txtMiktar.Text == "" || txtAciklama.Text == "" || dtTarih.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vt.sqlCalistir("insert into gelir_ciro (aciklama,miktar,tarih) values ('" + txtAciklama.Text + "','" + txtMiktar.Text + "','" + dtTarih.Text + "')");
            MessageBox.Show("Gelir Eklendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMiktar.Clear();
            Goster();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtMiktar.Text == "" || txtAciklama.Text == "" || dtTarih.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vt.sqlCalistir("update gelir_ciro set aciklama='" + txtAciklama.Text + "',miktar='" + txtMiktar.Text + "',tarih='" + dtTarih.Text + "' where giderId=" + txtNo.Text + "");
            MessageBox.Show("Kayıt Güncellendi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMiktar.Clear();
            Goster();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnGider.Enabled = true;
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
            vt.sqlCalistir("delete from gelir_ciro where giderId=" + Convert.ToInt32(txtNo.Text));
            Convert.ToInt32(txtNo.Text);
            MessageBox.Show("Kayıt Silindi", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMiktar.Clear();
            Goster();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnGider.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //tarih fark
            if (tableLayoutPanel5.Visible)
            {
                tableLayoutPanel5.Visible = false;
            }
            else
            {
                tableLayoutPanel5.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Goster();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dgGider.Rows.Clear();
            DataTable dt;


            dt = vt.dtGetir("select* from gelir_ciro where aciklama like '%" + txtAra.Text + "%' or miktar like '%" + txtAra.Text + "%' or tarih like '%" + txtAra.Text + "%' or giderId like '%" + txtAra.Text + "%' order by tarih desc");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["giderId"].ToString());
                dgGider.Rows.Add(dt.Rows[i]["aciklama"].ToString(), dt.Rows[i]["miktar"].ToString(),
                dt.Rows[i]["tarih"].ToString().Substring(0, 10), dt.Rows[i]["giderId"].ToString());
            }
            double bakiye = 0;
            for (int i = 0; i < dgGider.RowCount; i++)
            {
                bakiye += Convert.ToDouble(dgGider.Rows[i].Cells[1].Value);
            }
            lblGider.Text = bakiye.ToString() + " TL";
            if (txtAra.Text == "") Goster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgGider.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("Select * from gelir_ciro where tarih between #{0}# and #{1}# order by tarih desc, giderId", dateTimePicker2.Text, dateTimePicker3.Text);
            //string sorgu = string.Format("Select * from gider where tarih BETWEEN '"+dateTimePicker2.Text+"'and'"+dateTimePicker3.Text+"'");// order by tarih desc, giderId
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["giderId"].ToString());
                dgGider.Rows.Add(dt.Rows[i]["aciklama"].ToString(), dt.Rows[i]["miktar"].ToString(),
                dt.Rows[i]["tarih"].ToString().Substring(0, 10), dt.Rows[i]["giderId"].ToString());
            }
            double bakiye = 0;
            for (int i = 0; i < dgGider.RowCount; i++)
            {
                bakiye += Convert.ToDouble(dgGider.Rows[i].Cells[1].Value);
            }
            lblGider.Text = bakiye.ToString() + " TL";
            tableLayoutPanel5.Visible = false;
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void txtAciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = txtMiktar;
            }
            if (e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = txtMiktar;
            }
        }

        private void GÜNLÜK_Load_1(object sender, EventArgs e)
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
            Goster();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            this.ActiveControl = txtMiktar;
        }
    }
}
