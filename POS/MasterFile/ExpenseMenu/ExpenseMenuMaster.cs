using MDS.Customer;
using POS.BussinessModel;
using POS.BussinessModel.MasterModel;
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
    public partial class ExpenseMenuMaster : Form
    {
        private ExpenseMenuLayer layer = new ExpenseMenuLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";

        private ExpenseMenuMain owner;     
        private ExpenseMenuModel itemModel;
        private string saveupdate { get; set; }

        public ExpenseMenuMaster(ExpenseMenuMain _owner,string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (ExpenseMenuMain)_owner;
            txtname.Select();
        }
        
        public ExpenseMenuMaster(ExpenseMenuMain _owner, string save,ExpenseMenuModel model)
        { 
            InitializeComponent();
            saveupdate = save;
            owner = (ExpenseMenuMain)_owner;
            itemModel = (ExpenseMenuModel)model;

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
            
            txtname.Text = itemModel.Name;
            chkblock.Checked = Convert.ToBoolean(itemModel.status);
            txtcode.Text = itemModel.EXPMENU_ID.ToString();
      

        }
        private void ItemMaster2_Load(object sender, EventArgs e)
        {
            txtusername.Text = POS.Properties.Settings.Default.username;
            btnSave.Text = saveupdate;
            if (saveupdate != "Save")
                GetProperty();
            txtname.Select();

            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {

                lblcode.Text = Language.code;
                lblcode.Font = Language.font;
                lblname.Text = Language.Name;
                lblname.Font = Language.font;
               
                lbluser.Text = Language.user;
                lbluser.Font = Language.font;
                lblactive.Text = Language.active;
                lblactive.Font = Language.font;
                lbltitle.Text = "د لګښتونو مینو";
                btnSave.Text = Language.save;
                btnDelete.Text = Language.delete;
            
        }
        private ExpenseMenuModel SetProperty()
        {
            ExpenseMenuModel model = new ExpenseMenuModel();
         
            model.Name = txtname.Text; 
            model.status = Convert.ToBoolean(chkblock.Checked);
            model.user_id = POS.Properties.Settings.Default.userid;
            return model; 


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
                    MessageBox.Show("Item Name Already Exist");
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
                        btnSave.Focus();
        }
        private void ItemMaster2_Click(object sender, EventArgs e)
        {
            txtname.Focus();
        }

        private void Txttp_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumber(sender, e);
        }
        private void AllowNumber(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       


    
    }
}
