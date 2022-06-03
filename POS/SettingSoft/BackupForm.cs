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
using MDS;
using POS.SettingSoft;

namespace TMS.SettingBR
{
    public partial class BackupForm : Form
    {
   

        SqlConnection con;

        public BackupForm()
        {
            InitializeComponent();
            con = new SqlConnection(Connection.connection);
        }
       
        private void btnopen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = dlg.SelectedPath;
                btnbackup.Enabled = true;
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            string database = con.Database.ToString();
            try
            {


                if (txtpath.Text == string.Empty)
                {
                    MessageBox.Show("Please enter backup file location");
                }
                else
                {
                    txtpath.Text = txtpath.Text + "\\BackUp" + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss tt");
                    System.IO.Directory.CreateDirectory(txtpath.Text);


                    //string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtpath.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss tt") + ".bak'";
                    string cmd = "BACKUP DATABASE  [" + database + "] TO DISK = '" + txtpath.Text + "\\" + "Database" +
                        "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss tt") +
                        ".bak' WITH COMPRESSION, ENCRYPTION( ALGORITHM = AES_256,SERVER CERTIFICATE = Encrypt ),  STATS = 10";

                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        command.ExecuteNonQuery();
                    }


                    string cmd2 = "USE MASTER backup certificate Encrypt to file = '" + txtpath.Text +
                    "\\certificate" + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss tt") + ".cert' with private key(file= '"
                    + txtpath.Text + "\\certificate" + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss tt") + ".key', encryption by password='rhkg38yw4w44rhjg')";
                    using (SqlCommand command2 = new SqlCommand(cmd2, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        command2.ExecuteNonQuery();
                        con.Close();

                    }

                }
                MessageBox.Show("Database backup done successefully");
                this.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            btnbackup.Enabled = false;
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            lbllocation.Text = Language.location;
            btnbackup.Text = Language.Backup; 
            this.Text = "بیک اپ";
            btnopen.Text = Language.Open;

        }
    }
}
