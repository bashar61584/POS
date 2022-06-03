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
    public partial class ConfirmBoxForm : Form
    {
        public ConfirmBoxForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtpassword.Text=="4rhjg")
            {
                POS.Properties.Settings.Default.Server = txtusername.Text;
                POS.Properties.Settings.Default.Save();
               
            }
            this.Close();
        }
        
    }
}
