using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using POS.SettingSoft;

namespace TMS.SettingBR
{
    public partial class RestoreForm : Form
    {
   

        SqlConnection con;
        SqlCommand cmd;
        string query = "";
        SqlDataReader myReader;
        public RestoreForm()
        {
            InitializeComponent();
            con = new SqlConnection(MDS.Connection.connection);
        }
       
        private void btnopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER DATABASE BACK FILES|*.bak";
            dlg.Title = "DATABASE RESTORE";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = dlg.FileName;
                btnrestore.Enabled = true;
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string sqlStmt2 = string.Format("ALTER DATABASE[" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "]FROM DISK='" + txtpath.Text + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE[" + database + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                MessageBox.Show("Database are successfully restored");
                con.Close();
                Application.Exit(); 
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            btnrestore.Enabled = false;
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            lbllocation.Text = Language.location;
            btnrestore.Text = Language.Restore;
            this.Text = "بیک اپ";
            btnopen.Text = Language.Open;

        }
    }
}
