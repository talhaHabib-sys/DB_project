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
    public partial class Mainn : Form
    {
        public Mainn()
        {
            InitializeComponent();
        }
        public Mainn(string n,string p)
        {
            InitializeComponent();
            if(n=="employee"&&p=="0")
            {
                button2.Enabled = false;
                button3.Enabled = false;

                button4.Enabled = false;
              
                
            }
            else if (n == "car" && p == "11")
            {
                button1.Enabled = false;
                button3.Enabled = false;

                button4.Enabled = false;
            }
            else if (n == "parking" && p == "1")
            {
                button2.Enabled = false;
                button1.Enabled = false;

                button4.Enabled = false;

            }
            else if (n == "finance" && p == "111")
            {
                button2.Enabled = false;
                button3.Enabled = false;

                button1.Enabled = false;
            }


        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            DASHBORD s = new DASHBORD() { Dock = DockStyle.Fill, TopLevel = false };
            this.panel1.Controls.Add(s);
            
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            DASHBOARD3 s1=new DASHBOARD3() { Dock = DockStyle.Fill, TopLevel = false };
            this.panel1.Controls.Add(s1);

            s1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            Parking p=new Parking() { Dock = DockStyle.Fill, TopLevel = false };
            this.panel1.Controls.Add(p);

            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            DASHBOARD4 d = new DASHBOARD4() { Dock = DockStyle.Fill, TopLevel = false };
            this.panel1.Controls.Add(d);
            d.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void Mainn_Load(object sender, EventArgs e)
        {

        }

        private void Mainn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }
    }
}
