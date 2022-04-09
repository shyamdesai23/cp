using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CP_1
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] id = new String[3];
            string conns = "datasource=127.0.0.1;port=3306;username = root;password= ; database=cp";
            MySqlConnection con = new MySqlConnection(conns);
            con.Open();
            string qr = "SELECT * from `user` WHERE `uname` = '" + textBox1.Text +"'";
            MySqlCommand cmd = new MySqlCommand(qr, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                id[0] = reader["uname"].ToString();
                id[1] = reader["pass"].ToString();
                id[2] = reader["utype"].ToString();
            }
            
            if (textBox1.Text == id[0] && textBox2.Text == id[1])
            {
                if(id[2] == "o")
                {
                    dash obj = new dash();
                    if (obj == null)
                    {
                        obj.Parent = this;
                    }
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    Invoice obj = new Invoice();
                    if (obj == null)
                    {
                        obj.Parent = this;
                    }
                    obj.Show();
                    this.Hide();
                }
            }
            else
            {
                label2.Text = "Invalid username or password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            if (obj == null)
            {
                obj.Parent = this;
            }
            obj.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            checkBox1.Checked = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            if (obj == null)
            {
                obj.Parent = this;
            }
            obj.Show();
            this.Hide();
        }
    }
}
