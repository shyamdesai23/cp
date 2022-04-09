using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Web;
using System.IO;

namespace CP_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            login obj = new login();
            if (obj == null)
            {
                obj.Parent = this;
            }
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
