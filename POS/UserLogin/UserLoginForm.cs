using POS;
using POS.BussinessModel;
using POS.SettingSoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.User_Login
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }
        UserLoginAccesslayer layer = new UserLoginAccesslayer(); 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:

                    break;
                //case Keys.Control | Keys.Alt | Keys.S:
                case Keys.Control | Keys.Alt | Keys.Shift| Keys.O:
                    ConfirmBoxForm box = new ConfirmBoxForm();
                    box.ShowDialog(); 

                    break; 
               
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    private void btnLogin_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            model = layer.RetrieveUser(txtusername.Text, txtpassword.Text);
            bool result = false;
            if (model != null)
            {
                POS.Properties.Settings.Default.userid = model.user_id;
                POS.Properties.Settings.Default.Save();
                POS.Properties.Settings.Default.username = model.user_name;
                POS.Properties.Settings.Default.Save();
                result = true;
            }

            if (result)
            {
                MainForm3 obj = new MainForm3(model);
                obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong User Name Or Password");
                txtusername.Focus(); 
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtusername.Text != string.Empty)
                    txtpassword.Focus(); 
            
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtpassword.Text != string.Empty)
                    btnLogin.Focus(); 
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            Font font= new Font(FontFamily.GenericMonospace, 9.0F, FontStyle.Bold);
            ultraLabel7.Text = Language.UserName;
            ultraLabel1.Text = Language.Password;
            ultraLabel1.Font = font;
            btnLogin.Text = Language.LogIn;
            btnExit.Text = Language.Exit;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
