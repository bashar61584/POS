using POS.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class MainForm2 : Form
    {
        private Form activeForm;

        public MainForm2()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width== 210)
            {
                MenuVertical.Width = 0;
            }
            else
            {
                MenuVertical.Width = 210;
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

        private void MainForm2_Load(object sender, EventArgs e)
        {
            Infragistics.Win.AppStyling.StyleManager.Load(FindPath()+ "Theme 01.isl");
        }

        public string FindPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (path.Contains("\\bin\\Release") || path.Contains("\\bin\\Debug"))
            {
                path = path.Replace("\\bin\\Debug", "\\Resources\\Themes");


            }
            ////---------------------Path for build exe file---------------
            //path = path + "Resources\\Themes\\";
            //////MessageBox.Show(path);
            ////------------------------------------
            return path;
        }
       

        private void UltraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key)
            {
                case "Item":
                    ItemMain item = new ItemMain();
                    item.ShowDialog();
                    break;
                case "Customer":
                    CustomerMain item2 = new CustomerMain();
                    item2.ShowDialog();
                    break;
                case "Supplier":
                    LoanMain item3 = new LoanMain();
                    item3.ShowDialog();
                    break;
                case "Loan":
                    LoanMain item4 = new LoanMain();
                    item4.ShowDialog();
                    break;
                case "Purchase Stock":
                    PurchaseMain item5 = new PurchaseMain();
                    item5.ShowDialog();
                    break;
                case "Purchase Stock Return":
                    PurchaseReturnMain item6 = new PurchaseReturnMain();
                    item6.ShowDialog();
                    break;
                case "Sale Invoice":
                    SaleMain item7 = new SaleMain();
                    item7.ShowDialog();
                    break;
                case "Sale Invoice Return":
                    SaleReturnMain item8 = new SaleReturnMain();
                    item8.ShowDialog();
                    break;
                case "Transfer In":
                    TransferInMain item9 = new TransferInMain();
                    item9.ShowDialog();
                    break;
                case "Transfer Out":
                    TransferOutMain item10 = new TransferOutMain();
                    item10.ShowDialog();
                    break;
            }
        }
    }
}
