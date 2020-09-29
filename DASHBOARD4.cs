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
    public partial class DASHBOARD4 : Form
    {
        public DASHBOARD4()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");
        public int i = 0;
        private void ret_ID()
        {
            c.Open();


            string qurey = "Select max(Park_ID) from ParkMang ";
            SqlDataAdapter sa = new SqlDataAdapter(qurey, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            textBox4.Text = d.Rows[0][0].ToString();

            c.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount =Convert.ToInt32(textBox3.Text);
            float tax = 0.15f;
            float result = amount + (amount * tax);
            textBox1.Text =result.ToString();


            if (i == 0)
            {

                SqlCommand a = new SqlCommand("INSERT INTO Finance VALUES (@Total,@PARK_ID,@TAX,@Amount)", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@Total", textBox1.Text);
                a.Parameters.AddWithValue("@PARK_ID", textBox4.Text);
                a.Parameters.AddWithValue("@TAX", textBox2.Text);
                a.Parameters.AddWithValue("@Amount", textBox3.Text);


                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                i++;
                MessageBox.Show("successfully inserted");

            }
            else
            {
                MessageBox.Show("Only one person finance will be recorded at a time");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT Employee.NAME,Employee.ADDRESS,Employee.TELEPHONE,Employee.GENDER,CarManage.[CAR NUMBER],CarManage.[CAR COLOR],CarManage.[CAR MODEL],parkMang.Area,parkMang.STATUS,parkMang.DATE,finance.ReceiptNo,finance.Amount,finance.Total from Employee inner join carManage ON Employee.EMP_ID=CarManage.EMP_ID inner join ParkMang ON CarManage.Car_ID=ParkMang.Car_ID inner join finance ON ParkMang.PARK_ID=Finance.PARK_ID";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                SqlCommand a = new SqlCommand("UPDATE Finance SET Amount=@Amount WHERE Park_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@Amount", textBox3.Text);
                a.Parameters.AddWithValue("@ID", textBox4.Text);
            
                
          

                

                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully updated");
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Enter integer value");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void DASHBOARD4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void DASHBOARD4_Load(object sender, EventArgs e)
        {
            ret_ID();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand a = new SqlCommand("DELETE FROM  Finance WHERE Park_ID=@ID", c);
            a.CommandType = CommandType.Text;
            a.Parameters.AddWithValue("@ID", textBox4.Text);
            c.Open();
            a.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("successfully delete");
        }
    }
}
