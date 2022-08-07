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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();

        private void musteri_Load(object sender, EventArgs e)
        {

        }
        private void listele()
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from musteri", baglanti);
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
                dt.Rows[i]["rutp"].ToString());
            }
        }

        private void ara_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select* from musteri where mno like '%" + ara.Text + "%' or madı like '%" + ara.Text + "%'  order by mno");
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
                dt.Rows[i]["mbakiye"].ToString());
            }
            if (ara.Text == "") listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            musteriportfoy form = new musteriportfoy();
            form.mkodu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form.madılabel.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form.madreslabel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            form.mkisilabel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            form.mvdlabel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            form.mvnlabel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            form.milabel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            form.mblabel.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            form.ruttxt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            form.Show();





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void mkodubtn_Click(object sender, EventArgs e)
        {

        }

        private void ocak_Click(object sender, EventArgs e)
        {

        }

        private void kasım_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
           /* double kalanbakiye;
            double kontroltoplam = double.Parse(textBox1.Text);
            double kontroltoplam1 = double.Parse(textBox2.Text);
            kalanbakiye = kontroltoplam - kontroltoplam1; textBox3.Text = kalanbakiye.ToString();*/



        }
    }
}
