using POS.Item;
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

namespace POS
{
    public partial class MainForm : Form
    {
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width==200)
            {
                MenuVertical.Width = 78;
            }
            else
            {
                MenuVertical.Width = 200;
            }
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
                OpenChildForm(new ItemMain());
            else
           if (activeForm.Text == "Item")
            {

            }
            else
            {
                activeForm.Close();
                activeForm = null;
                OpenChildForm(new ItemMain());

            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(childForm);
            this.panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnmaximum_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void Btnminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            if(activeForm==null)
                OpenChildForm(new SupplierMain());
            else
            if(activeForm.Text=="Supplier")
            {

            }else
            {
                activeForm.Close();
                activeForm = null;
                OpenChildForm(new SupplierMain());

            }




        }
    }
}
