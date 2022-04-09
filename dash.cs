using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP_1
{
    public partial class dash : Form
    {
        private Button currentButton;
        private Form activeForm;


        public dash()
        {
            InitializeComponent();
            closeForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMnd, int wParam, int lParam);

        private void worker_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new worker(), sender);
        }

        private void itea_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new iteam(), sender);
        }

        private void invoice_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Invoice(), sender);
        }

        private void analysis_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new analysis(), sender);
        }

        private void barcode_Click(object sender, EventArgs e)
        {
            OpenChildForm(new barcode(), sender);
        }

        private void dash_Load(object sender, EventArgs e)
        {
            dashpage frm = new dashpage() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true ,FormBorderStyle = FormBorderStyle.None};
            this.paneldesktop.Controls.Add(frm);
            frm.Show();
        }

        private void ActivateButton(object btnsender)
        {
            if(btnsender != null)
            {
                if(currentButton != (Button)btnsender)
                {
                    DisableButton();
                    closeForm.Visible = true;
                    currentButton = (Button)btnsender;
                    currentButton.BackColor = Color.FromArgb(0, 160, 163);
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point); 
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panel2.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.paneldesktop.Controls.Add(childForm);
            this.paneldesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                OpenChildForm(new dashpage(), sender);
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            label1.Text = "Home";
            currentButton = null;
            closeForm.Visible = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
