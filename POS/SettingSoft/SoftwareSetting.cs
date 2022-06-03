using POS.SettingSoft;
using System;
using System.Windows.Forms;

namespace TMS
{
    public partial class SoftwareSetting : Form
    {
        public SoftwareSetting()
        {
            InitializeComponent();
            
        }

        private void btnsaveupdate_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                POS.Properties.Settings.Default.TopTitle = txtname.Text;
                POS.Properties.Settings.Default.Save();
                POS.Properties.Settings.Default.Address = txtaddress.Text;
                POS.Properties.Settings.Default.Save();
                POS.Properties.Settings.Default.Phone = txtcontact.Text;
                POS.Properties.Settings.Default.Save();
                POS.Properties.Settings.Default.Email = txtemail.Text;
                POS.Properties.Settings.Default.Save();
                POS.Properties.Settings.Default.BackUpPath = txtpath.Text;
                POS.Properties.Settings.Default.Save();
                this.Close(); 
            }
        }
        private void SoftwareSetting_Load(object sender, EventArgs e)
        {
       
       
            txtaddress.Text = POS.Properties.Settings.Default.Address;
            txtemail.Text = POS.Properties.Settings.Default.Email;
            txtcontact.Text = POS.Properties.Settings.Default.Phone;
            txtname.Text = POS.Properties.Settings.Default.TopTitle;
            txtpath.Text = POS.Properties.Settings.Default.BackUpPath;
            txtname.Focus();
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            lblname.Text = Language.Name;
            lbladdress.Text = Language.Address1;
      
            this.Text = "د سافټویر ترتیب";

            lblcontact.Text = Language.Phone1;
            lblemail.Text = Language.Email;
            btnsaveupdate.Text = Language.save;
            btnopen.Text = Language.Open;
            lbllocation.Text = Language.location;

        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtname.Text != string.Empty)
                    txtaddress.Focus(); 
        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtaddress.Text != string.Empty)
                    txtcontact.Focus(); 
        }

        private void txtcontact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtcontact.Text != string.Empty)
                    txtemail.Focus(); 
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtemail.Text != string.Empty)
                   btnsaveupdate.Focus(); 
        }

        private bool CheckEmpty()
        {
            string m=" is required ";
            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Name"+m);
                txtname.Focus(); 
                return false;
            }
            else if (txtaddress.Text == string.Empty)
            {
                 MessageBox.Show("Address"+m);
                txtaddress.Focus(); 
                return false;
            }
            else  if (txtcontact.Text == string.Empty)
            {
                MessageBox.Show("Contact" + m);
                txtcontact.Focus();
                return false;
            }
            else  if (txtemail.Text == string.Empty)
            {
                MessageBox.Show("Email" + m);
                txtemail.Focus();
                return false;
            }
            return true;
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = dlg.SelectedPath;
                
            }
        }

        private void SoftwareSetting_Fill_Panel_PaintClient(object sender, PaintEventArgs e)
        {

        }
    }
}
