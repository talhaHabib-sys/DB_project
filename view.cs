using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBProject
{
    public partial class view : Form
    {
        public view()
        {
            InitializeComponent();
        }
        public static string passArea;
        public static string passAv;
        public static int passF;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");

        private void view_Load(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT [Parking Area],Floor,TYPE,STATUS from Pview";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT  [Parking Area],Floor,TYPE,STATUS from Pview Where status LIKE '%" + textBox1.Text.ToString() + "%'";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT  [Parking Area],Floor,TYPE,STATUS from Pview Where [Parking Area] LIKE '%" + textBox2.Text.ToString() + "%'";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT  [Parking Area],Floor,TYPE,STATUS from Pview Where Floor LIKE '%" + textBox3.Text.ToString() + "%'";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            passArea = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            passAv = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            passF =Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[1].Value);
            
           
           
        }

        private void view_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
