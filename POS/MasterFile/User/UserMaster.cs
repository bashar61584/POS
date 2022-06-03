using Bunifu.Framework.UI;
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
    public partial class UserMaster : Form
    {
        private UserLayer layer = new UserLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";

        private UserMain owner;     
        private UserModel Model;
        private string saveupdate { get; set; }

        public UserMaster(UserMain _owner,string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (UserMain)_owner;
            txtname.Select();
        }
        
        public UserMaster(UserMain _owner, string save,UserModel model)
        { 
            InitializeComponent();
            saveupdate = save;
            owner = (UserMain)_owner;
            Model = (UserModel)model;
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
            UserModel tempmodel = new UserModel();
            txtcode.Text = Model.user_id.ToString();
            chkblock.Checked = Convert.ToBoolean(Model.status);
            txtname.Text = Model.user_name;
            txtpassword.Text = Model.user_password;

            tempmodel = layer.loadTempConstraints(Model.user_id);

            chkproductfile.Checked = Convert.ToBoolean(tempmodel.productFile);
            chkProduct.Checked = Convert.ToBoolean(tempmodel.prductstatus);
            chkproductmaster.Checked = Convert.ToBoolean(tempmodel.productmaster);
            chkproductlist.Checked = Convert.ToBoolean(tempmodel.productlist);
            chkpurchase.Checked = Convert.ToBoolean(tempmodel.purchasestock);
            chkpurchaseMaster.Checked = Convert.ToBoolean(tempmodel.purchasemaster);
            chkpurchaselist.Checked = Convert.ToBoolean(tempmodel.purchaselist);
            chkpurchaseretun.Checked = Convert.ToBoolean(tempmodel.purchasereturn);
            chkpurchasereturnmaster.Checked = Convert.ToBoolean(tempmodel.purchasereturnmaster);
            chkpurchaseretunlist.Checked = Convert.ToBoolean(tempmodel.purchasereturnlist);
            chkproductaccount.Checked = Convert.ToBoolean(tempmodel.prodaccount);
            chkprodaccmaster.Checked = Convert.ToBoolean(tempmodel.prodaccmaster);
            chkprodacclist.Checked = Convert.ToBoolean(tempmodel.prodacclist);
            chkprodreport.Checked = Convert.ToBoolean(tempmodel.prodreport);
            chkcutomerfile.Checked = Convert.ToBoolean(tempmodel.customerFile);
            chkcustomer.Checked = Convert.ToBoolean(tempmodel.customerstatus);
            chkcustomerlist.Checked = Convert.ToBoolean(tempmodel.customerlist);
            chkcustomermaster.Checked = Convert.ToBoolean(tempmodel.customermaster);
            chksaleinvoice.Checked = Convert.ToBoolean(tempmodel.saleinvoice);
            chksaleinvoicelist.Checked = Convert.ToBoolean(tempmodel.saleinvoicelist);
            chksaleinvoicemaster.Checked = Convert.ToBoolean(tempmodel.saleinvoicemaster);
            chksalereturn.Checked = Convert.ToBoolean(tempmodel.salereturn);
            chksalereturnlist.Checked = Convert.ToBoolean(tempmodel.salereturnlist);
            chksalereturnmaster.Checked = Convert.ToBoolean(tempmodel.salereturnmaster);
            chkcustaccount.Checked = Convert.ToBoolean(tempmodel.custaccount);
            chkcustaccmaster.Checked = Convert.ToBoolean(tempmodel.custaccmaster);
            chkcustacclist.Checked = Convert.ToBoolean(tempmodel.custacclist);
            chkcustomerreport.Checked = Convert.ToBoolean(tempmodel.customerreport);
            chkbranhfile.Checked = Convert.ToBoolean(tempmodel.branche);
            chkbranch.Checked = Convert.ToBoolean(tempmodel.branchstatus);
            chkbranchmaster.Checked = Convert.ToBoolean(tempmodel.branchmaster);
            chkbranchlist.Checked = Convert.ToBoolean(tempmodel.branchlist);
            chktransferin.Checked = Convert.ToBoolean(tempmodel.transferin);
            chktransferinmaster.Checked = Convert.ToBoolean(tempmodel.transferinmaster);
            chktransferinlist.Checked = Convert.ToBoolean(tempmodel.transferinlist);
            chktransferout.Checked = Convert.ToBoolean(tempmodel.transferout);
            chktransferoutmaster.Checked = Convert.ToBoolean(tempmodel.transferoutmaster);
            chktransferoutlist.Checked = Convert.ToBoolean(tempmodel.transferoutlist);
            chkbranchaccount.Checked = Convert.ToBoolean(tempmodel.branchaccount);
            chkbranchaccmaster.Checked = Convert.ToBoolean(tempmodel.branchaccmaster);
            chkbranchacclist.Checked = Convert.ToBoolean(tempmodel.branchacclist);
            chkbranchreport.Checked = Convert.ToBoolean(tempmodel.loanreport);
            chksupplierfile.Checked = Convert.ToBoolean(tempmodel.supplier);
            chksupplierstatus.Checked = Convert.ToBoolean(tempmodel.supplierstatus);
            chksuppliermaster.Checked = Convert.ToBoolean(tempmodel.suppliermaster);
            chksupplierlist.Checked = Convert.ToBoolean(tempmodel.supplierlist);
            chkexpensefile.Checked = Convert.ToBoolean(tempmodel.Expense);
            chkemployeefile.Checked = Convert.ToBoolean(tempmodel.Employee);
            chkreportfile.Checked = Convert.ToBoolean(tempmodel.Report);
            chksettingfile.Checked = Convert.ToBoolean(tempmodel.Setting);






        }
        private void ItemMaster2_Load(object sender, EventArgs e)
        {
           
        
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
            lblpassword.Text = Language.Password;
            lblpassword.Font = Language.font;
           
            lblstatus.Text = Language.active;
            lblstatus.Font = Language.font;
         
            lbltitle.Text = "کاروونکی";
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;

        }
        private bool  ConvertCheckBox(BunifuCheckbox chk)
        {
            return Convert.ToBoolean(chk.Checked);
        }
        private UserModel SetProperty()
        {
            UserModel model = new UserModel();
            model.status = ConvertCheckBox(chkblock);
            model.user_name= txtname.Text;
            model.user_password=txtpassword.Text ; 
            model.productFile = ConvertCheckBox(chkproductfile);
            model.prductstatus = ConvertCheckBox(chkProduct);
            model.productmaster = ConvertCheckBox(chkproductmaster);
            model.productlist= ConvertCheckBox(chkproductlist);
            model.purchasestock = ConvertCheckBox(chkpurchase);
            model.purchasemaster= ConvertCheckBox(chkpurchaseMaster);
            model.purchaselist = ConvertCheckBox(chkpurchaselist);
            model.purchasereturn = ConvertCheckBox(chkpurchaseretun);
            model.purchasereturnmaster = ConvertCheckBox(chkpurchasereturnmaster);
            model.purchasereturnlist = ConvertCheckBox(chkpurchaseretunlist);
            model.prodaccount = ConvertCheckBox(chkproductaccount);
            model.prodaccmaster = ConvertCheckBox(chkproductmaster);
            model.prodacclist = ConvertCheckBox(chkproductlist);
            model.prodreport = ConvertCheckBox(chkprodreport);
            model.customerFile = ConvertCheckBox(chkcutomerfile);
            model.customerstatus = ConvertCheckBox(chkcustomer); 
            model.customerlist=ConvertCheckBox(chkcustomerlist);
            model.customermaster = ConvertCheckBox(chkcustomermaster);
            model.saleinvoice = ConvertCheckBox(chksaleinvoice);
            model.saleinvoicelist = ConvertCheckBox(chksaleinvoicelist);
            model.saleinvoicemaster = ConvertCheckBox(chksaleinvoicemaster);
            model.salereturn = ConvertCheckBox(chksalereturn);
            model.salereturnlist = ConvertCheckBox(chksalereturnlist);
            model.salereturnmaster = ConvertCheckBox(chksalereturnmaster);
            model.custaccount = ConvertCheckBox(chkcustaccount);
            model.custaccmaster = ConvertCheckBox(chkcustomermaster);
            model.custacclist = ConvertCheckBox(chkcustomerlist);
            model.customerreport = ConvertCheckBox(chkcustomerreport);
            model.branche = ConvertCheckBox(chkbranhfile);
            model.branchstatus = ConvertCheckBox(chkbranch);
            model.branchmaster = ConvertCheckBox(chkbranchmaster);
            model.branchlist = ConvertCheckBox(chkbranchlist);
            model.transferin = ConvertCheckBox(chktransferin);
            model.transferinmaster = ConvertCheckBox(chktransferinmaster);
            model.transferinlist = ConvertCheckBox(chktransferinlist);
            model.transferout = ConvertCheckBox(chktransferout);
            model.transferoutmaster = ConvertCheckBox(chktransferoutmaster);
            model.transferoutlist = ConvertCheckBox(chktransferoutlist);
            model.branchaccount = ConvertCheckBox(chkbranchaccount);
            model.branchaccmaster = ConvertCheckBox(chkbranchaccmaster);
            model.branchacclist = ConvertCheckBox(chkbranchacclist);
            model.loanreport = ConvertCheckBox(chkbranchreport);
            model.supplier = ConvertCheckBox(chksupplierfile);
            model.supplierstatus = ConvertCheckBox(chksupplierstatus);
            model.suppliermaster = ConvertCheckBox(chksuppliermaster);
            model.supplierlist = ConvertCheckBox(chksupplierlist);
            model.Expense = ConvertCheckBox(chkexpensefile);
            model.Employee = ConvertCheckBox(chkemployeefile);
            model.Report = ConvertCheckBox(chkreportfile);
            model.Setting = ConvertCheckBox(chksettingfile);
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
                            if(owner!=null)
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
                    MessageBox.Show("User Name Already Exist");
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
                    txtpassword.Focus();
        }

        private void Txtaddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }


    }
}
