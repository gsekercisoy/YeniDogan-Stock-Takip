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
    public partial class ürünara : Form
    {
        public ürünara()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "/gelir.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        //public void lis()
        //{
        //    alımfis form4 = new alımfis();
        //    string ara = denetim.Text;
        //    form4.denemet.Text = ara;
           
        //}
        private void ürünara_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün where urunad like '%" + textBox1.Text + "%'", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                dataGridView1.Rows.Add(dt.Rows[i]["no1"].ToString(),
                //dt.Rows[i]["firma"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["stok"].ToString(),
                dt.Rows[i]["satis"].ToString());

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt;
            string sorgu = string.Format("select * from ürün WHERE urunad like '%" + textBox1.Text + "%'", baglanti);
            dt = vt.dtGetir(sorgu);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int gider = Convert.ToInt32(dt.Rows[i]["no1"].ToString());
                dataGridView1.Rows.Add(dt.Rows[i]["no1"].ToString(),
                //dt.Rows[i]["firma"].ToString(),
                dt.Rows[i]["urunad"].ToString(),
                dt.Rows[i]["stok"].ToString(),
                dt.Rows[i]["satis"].ToString());

            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            denetim.Text  = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            vt.sqlCalistir("update araurun set ara1='" + denetim.Text + "' where no1=1");
            this.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
