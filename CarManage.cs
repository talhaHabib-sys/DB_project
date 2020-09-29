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
    public partial class DASHBOARD3 : Form
    {
        public DASHBOARD3()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");
        public int studentID;
        public int i = 0;
        private  void ret_ID()
        {
            c.Open();           
            
            
                string qurey = "Select max(EMP_ID) from employee ";
                SqlDataAdapter sa = new SqlDataAdapter(qurey, c);
                DataTable d = new DataTable();
                sa.Fill(d);
                textBox4.Text = d.Rows[0][0].ToString();
               
                c.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {

                SqlCommand a = new SqlCommand("INSERT INTO CarManage VALUES (@CARNUMBER,@CARCOLOR,@CARMODEL,@EMP_ID)", c);
                a.CommandType = CommandType.Text;

                a.Parameters.AddWithValue("@CARNUMBER", textBox1.Text);
                a.Parameters.AddWithValue("@CARCOLOR", textBox2.Text);
                a.Parameters.AddWithValue("@CARMODEL", textBox3.Text);
                a.Parameters.AddWithValue("@EMP_ID", textBox4.Text);


                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                i++;
                MessageBox.Show("successfully inserted");
            }
            else
            {
                MessageBox.Show("Only one person Car At a time");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT Employee.NAME,Employee.ADDRESS,Employee.TELEPHONE,Employee.GENDER,CarManage.[CAR NUMBER],CarManage.[CAR COLOR],CarManage.[CAR MODEL] from Employee inner join CarManage ON Employee.EMP_ID=CarManage.EMP_ID";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                SqlCommand a = new SqlCommand("UPDATE CarManage SET [CAR NUMBER]=@CAR_NUMBER,[CAR COLOR]=@CARCOLOR,[CAR MODEL]=@CARMODEL WHERE EMP_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@CAR_NUMBER", textBox1.Text);
                a.Parameters.AddWithValue("@CARCOLOR", textBox2.Text);
                a.Parameters.AddWithValue("@CARMODEL", textBox3.Text);
                a.Parameters.AddWithValue("@ID", textBox4.Text);
                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully updated");
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

                SqlCommand a = new SqlCommand("DELETE FROM  CarManage WHERE EMP_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@ID", textBox4.Text);
                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully delete");


            
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsDigit(c))
            {
                e.Handled = true;
                MessageBox.Show("Enter string");
            }
        }

        private void DASHBOARD3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void DASHBOARD3_Load(object sender, EventArgs e)
        {
            ret_ID();
        }
    }
}
