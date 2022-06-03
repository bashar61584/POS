using MDS.Customer;
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

namespace POS.Item
{
    public partial class LoanMaster : Form
    {
        private LoanLayer  layer = new LoanLayer ();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";

        private LoanMain owner;     
        private LoanModel Model;
        private string saveupdate { get; set; }

        public LoanMaster(LoanMain _owner,string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (LoanMain)_owner;
            txtname.Select();
        }
        
        public LoanMaster(LoanMain _owner, string save,LoanModel model)
        { 
            InitializeComponent();
            saveupdate = save;
            owner = (LoanMain)_owner;
            Model = (LoanModel)model;
            txtname.Select();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    btnSave.Focus();
                    BtnSave_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.D:
                    btnDelete.Focus();
                    BtnDelete_Click(new object(), new EventArgs());
                    break;
                case Keys.Escape:
                    BtnClose_Click(new object(), new EventArgs());
                    break;
              

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetProperty()
        {
            txtcode.Text = Model.Lo_ID.ToString();
            chkblock.Checked = Convert.ToBoolean(Model.status);
            txtname.Text = Model.Name;
            txtaddress1.Text = Model.Address1;
            txtaddress2.Text = Model.Address2;
            txtphone1.Text = Model.phone1;
            txtphon2.Text = Model.phone2;
            txtemail.Text = Model.email;
            txtwebsite.Text = Model.website;
            txtlicence.Text = Model.licence;
            txtremark.Text = Model.remark;
            txtfax.Text = Model.fax;

      
           
      

        }
        private void ItemMaster2_Load(object sender, EventArgs e)
        {
           
            txtusername.Text= POS.Properties.Settings.Default.username;
            btnSave.Text = saveupdate;
            if(saveupdate!="Save")
            GetProperty();
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {

            lblcode.Text = Language.code;
            lblcode.Font = Language.font;
            lblname.Text = Language.Name;
            lblname.Font = Language.font;
            lbladdress1.Text = Language.Address1;
            lbladdress1.Font = Language.font;
            lbladdress2.Text = Language.Address2;
            lbladdress2.Font = Language.font;
            lblphone1.Text = Language.Phone1;
            lblphone1.Font = Language.font;
            lblphone2.Text = Language.Phone2;
            lblphone2.Font = Language.font;
            lblfax.Text = Language.Fax;
            lblfax.Font = Language.font;
            lblemail.Text = Language.Email;
            lblemail.Font = Language.font;
            lbluser.Text = Language.user;
            lbluser.Font = Language.font;
            lblstatus.Text = Language.active;
            lblstatus.Font = Language.font;
            lblwebsite.Text = Language.Website;
            lblwebsite.Font = Language.font;
            lbllicence.Text = Language.Licence;
            lbllicence.Font = Language.font;
            lblremarks.Text = Language.Remark;
            lblremarks.Font = Language.font;
            lbltitle.Text = "د پور حساب";
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;

        }
        private LoanModel SetProperty()
        {
            LoanModel model = new LoanModel();
            model.status = Convert.ToBoolean(chkblock.Checked);
            model.Name= txtname.Text;
            model.Address1=txtaddress1.Text ;
            model.Address2=txtaddress2.Text ;
            model.phone1= txtphone1.Text ;
            model.phone2=txtphon2.Text  ;
            model.email= txtemail.Text;
            model.website= txtwebsite.Text ;
            model.licence=txtlicence.Text;
            model.fax = txtfax.Text;
            model.remark=txtremark.Text ;
            model.user_id = POS.Properties.Settings.Default.userid;
            return model; 


        }
        private string CheckNullNumber(string t)
        {
            if (t == string.Empty)
                return "0";
            else
                return t; 
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
          

            if (CheckEmpty())
            {
                if (saveupdate == "Save")
                {
                    if (Confirm(message + "Save it?", "Save Record") == DialogResult.Yes)
                    {
                        if (layer.SaveUpdateFnc("", SetProperty()) != 0)
                        {
                            MessageBox.Show(Saved);
                            if (owner != null)
                                owner.LoadDataGridView("");
                            BtnClose_Click(new object(), new EventArgs());

                        }

                    }
                }
                else
                {
                    if (Confirm(message + " Update it?", "Update Record") == DialogResult.Yes)
                    {
                        if (layer.SaveUpdateFnc( txtcode.Text,SetProperty()) != 0)
                        {

                            MessageBox.Show(update);
                            if (owner != null)
                                owner.LoadDataGridView("Update");
                            BtnClose_Click(new object(), new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("Record Not Updated");
                            BtnClose_Click(new object(), new EventArgs());
                        }
                    }
                }


            }

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtcode.Text != string.Empty)
            {
                if (Confirm(message + "Delete it?", "Delete Record") == DialogResult.Yes)
                {
                    if (layer.DeleteFnc(txtcode.Text) != 0)
                    {
                        MessageBox.Show(delete);
                        owner.LoadDataGridView("");
                        BtnClose_Click(new object(), new EventArgs());
                    }

                }
            }
        }
        private bool CheckEmpty()
        {
            string m = "is requird";
            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Name " + m);
                txtname.Focus();
                return false;
            }
            else if (layer.CheckDuplication(txtname.Text) != 0)
            {
                if (saveupdate == "Save")
                {
                    MessageBox.Show("Supplier  Name Already Exist");
                    txtname.Focus();
                    return false;
                }

            }




            return true;
        }
        private DialogResult Confirm(string m, string t)
        {
            DialogResult dr = MessageBox.Show(m, t, MessageBoxButtons.YesNo);
            return dr;
        }

        private void Txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtname.Text != string.Empty)
                    txtaddress1.Focus();
        }

        private void Txtaddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtaddress2.Focus();
        }

        private void Txtaddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtphone1.Focus();

        }

        private void Txtphone1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtphon2.Focus();

        }

        private void Txtphon2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtfax.Focus();

        }

        private void Txtfax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtemail.Focus();

        }

        private void Txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtwebsite.Focus();

        }

        private void Txtwebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtlicence.Focus();

        }

        private void Txtlicence_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtremark.Focus();

        }

        private void Txtremark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            btnSave.Focus();
        }
    }
}
