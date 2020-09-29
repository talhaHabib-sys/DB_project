using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DBProject
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-B6HO24B;Initial Catalog=DB_PROJECT;Integrated Security=True");
            SqlDataAdapter sa = new SqlDataAdapter("Select * From Logins where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'",c);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            if (dt.Rows.Count == 1)
            {




                if (textBox1.Text == "employee" && textBox2.Text == "0")
                {
                    
                    this.Hide();
                    Mainn a = new Mainn(textBox1.Text,textBox2.Text);
                    a.Show();
                    
                    


                }

                else if (textBox1.Text == "parking" && textBox2.Text == "1")
                {
                    this.Hide();
                    Mainn s=new Mainn(textBox1.Text,textBox2.Text);
                    s.Show();
                    


                }
                else if (textBox1.Text == "car" && textBox2.Text == "11")
                {
                    this.Hide();
                    Mainn a = new Mainn(textBox1.Text, textBox2.Text);
                    a.Show();
                    




                }
                else if (textBox1.Text == "finance" && textBox2.Text == "111")
                {
                    this.Hide();
                    Mainn w = new Mainn(textBox1.Text, textBox2.Text);
                    w.Show();
                    



                }
                else
                {
                    MessageBox.Show("invalid");
                }
            }
            else
            {


                MessageBox.Show("No such record in database");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();

            }
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
