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
    public partial class DASHBORD : Form
    {
        
        public DASHBORD()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");
        public int studentID;
        public int i = 0;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (i == 0)
            {

                SqlCommand a = new SqlCommand("INSERT INTO Employee VALUES (@NAME,@ADDRESS,@TELEPHONE,@GENDER)", c);
                a.CommandType = CommandType.Text;

                a.Parameters.AddWithValue("@NAME", textBox2.Text);
                a.Parameters.AddWithValue("@ADDRESS", textBox3.Text);
                a.Parameters.AddWithValue("@TELEPHONE", textBox4.Text);
                a.Parameters.AddWithValue("@GENDER", comboBox1.Text);

                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                i++;
                MessageBox.Show("successfully inserted");
            }
            else
            {
                MessageBox.Show("you can only insert 1 person information at a time");
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT * from Employee";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(studentID > 0)
            {

                SqlCommand a = new SqlCommand("UPDATE Employee SET NAME=@NAME,ADDRESS=@ADDRESS,TELEPHONE=@TELEPHONE,GENDER=@GENDER WHERE EMP_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@NAME", textBox2.Text);
                a.Parameters.AddWithValue("@ADDRESS", textBox3.Text);
                a.Parameters.AddWithValue("@TELEPHONE", textBox4.Text);
                a.Parameters.AddWithValue("@GENDER", comboBox1.Text);
                a.Parameters.AddWithValue("@ID", this.studentID);
                
                
                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully updated");
               

            }
            else
            {
                MessageBox.Show("Please Select an student to update ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (studentID > 0)
            {

                SqlCommand a = new SqlCommand("DELETE FROM  Employee WHERE EMP_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@ID", this.studentID);
                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully delete");


            }

            else
            {
                MessageBox.Show("Please Select an student to delete ");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(!char.IsDigit(c)&&c!=8)
            {
                e.Handled=true;
                MessageBox.Show("Enter integer value");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Enter integer value");
            }
        }

        private void DASHBORD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            Form1 a = new Form1();
            a.Show();
        }
    }
}
