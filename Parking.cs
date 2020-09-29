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
    public partial class Parking : Form
    {
        public int pID;
        public int i = 0;
        public Parking()
        {
            InitializeComponent();
            
        }
        
        
        private void ret_ID()
        {
            c.Open();


            string qurey = "Select max(Car_ID) from CarManage ";
            SqlDataAdapter sa = new SqlDataAdapter(qurey, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            textBox1.Text = d.Rows[0][0].ToString();
     
            c.Close();

        }

        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");
        public int studentID;
        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                SqlCommand a = new SqlCommand("INSERT INTO ParkMang VALUES (@STATUS,@DATE,@AREA,@Car_ID,@FLOOR)", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@STATUS", comboBox1.Text);
                a.Parameters.AddWithValue("@DATE", dateTimePicker1.Text);
                a.Parameters.AddWithValue("@AREA", textBox3.Text);
                a.Parameters.AddWithValue("@Car_ID", textBox1.Text);
                a.Parameters.AddWithValue("@FLOOR", textBox2.Text);

                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                i++;
                MessageBox.Show("successfully inserted");
            }
            else
            {
                MessageBox.Show("Only one person car parking will be allocated");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.Open();
            string qury = "SELECT  Employee.NAME,Employee.ADDRESS,Employee.TELEPHONE,Employee.GENDER,CarManage.[CAR NUMBER],CarManage.[CAR COLOR],CarManage.[CAR MODEL],ParkMang.STATUS,ParkMang.DATE,ParkMang.Area,ParkMang.FLOOR from Employee inner join CarManage ON Employee.EMP_ID=CarManage.EMP_ID inner join ParkMang on CarManage.Car_ID=ParkMang.Car_ID";
            SqlDataAdapter sa = new SqlDataAdapter(qury, c);
            DataTable d = new DataTable();
            sa.Fill(d);
            dataGridView1.DataSource = d;
            c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

                SqlCommand a = new SqlCommand("UPDATE ParkMang SET STATUS=@STATUS,DATE=@DATE,Area=@Area WHERE Car_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@STATUS", comboBox1.Text);
                a.Parameters.AddWithValue("@AREA", textBox3.Text);
                a.Parameters.AddWithValue("@DATE", dateTimePicker1.Text);
                a.Parameters.AddWithValue("@FLOOR",textBox2.Text );
                a.Parameters.AddWithValue("@ID", textBox1.Text);

                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully inserted");


           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

                SqlCommand a = new SqlCommand("DELETE FROM  ParkMang WHERE Car_ID=@ID", c);
                a.CommandType = CommandType.Text;
                a.Parameters.AddWithValue("@ID", textBox1.Text);
                c.Open();
                a.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("successfully delete");


            
            
            
                
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((!char.IsDigit(c) && c != 8) || (char.IsDigit(c)))
            {
                e.Handled = true;
                MessageBox.Show("chose from the list");

            }




            comboBox1.DroppedDown = true;
            
            
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((!char.IsDigit(c) && c != 8)||(char.IsDigit(c)))
            {
                e.Handled = true;
                MessageBox.Show("chose from the list");
              
            }
            

           

            
           
            
        }

        private void Parking_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void Parking_Load(object sender, EventArgs e)
        {
            ret_ID();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            view v = new view();
            v.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = view.passArea;
            comboBox1.Text = view.passAv;
            textBox2.Text = view.passF.ToString();
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Select Values from ParkingView");
            }
           
               
            
        }
    }
}
