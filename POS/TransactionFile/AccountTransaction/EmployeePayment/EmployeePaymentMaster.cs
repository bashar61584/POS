using MDS.Customer;
using POS.BussinessModel;
using POS.BussinessModel.MasterModel;
using POS.BussinessModel.TransactionModel.AccountModel;
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
    public partial class EmployeePaymentMaster : Form
    {
        private EmployeePaymentLayer layer = new EmployeePaymentLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";

        private EmployeePaymentMain owner;     
        private EmployeePaymentModel Model;
        private string saveupdate { get; set; }

        public EmployeePaymentMaster(EmployeePaymentMain _owner,string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (EmployeePaymentMain)_owner;
            txtdesignationName.Select();
            txtdate.Value = DateTime.Now;
        }
        
        public EmployeePaymentMaster(EmployeePaymentMain _owner, string save, EmployeePaymentModel model)
        { 
            InitializeComponent();
            saveupdate = save;
            owner = (EmployeePaymentMain)_owner;
            Model = (EmployeePaymentModel)model;
            txtdesignationName.Select();

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
                case Keys.Control | Keys.Space:
                    TxtdesignationName_EditorButtonClick(new object(), null);
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
            txtcode.Text = Model.EMP_AC_ID.ToString();
            txtaddress1.Text = Model.EmployeeModels.Address1;
            txtaddress2.Text = Model.EmployeeModels.Address2;
            txtphone1.Text = Model.EmployeeModels.phone1;
            txtphon2.Text = Model.EmployeeModels.phone2;
            txtemail.Text = Model.EmployeeModels.email;
            txtsalary.Text = Model.EmployeeModels.BasicSalary.ToString();
            txtnic.Text = Model.EmployeeModels.NICNO;
            txtremark.Text = Model.EmployeeModels.remark;
            txtdesignationName.Text = Model.EmployeeModels.Name;
            txtdesignationid.Text = Model.EmployeeModels.EMP_ID.ToString();
            txtdate.Value = Model.Date.Value;
            txtdesignation.Text = Model.EmployeeModels.DesignationModels.Name;
            txtpay.Text = Model.Salary.ToString();
            txtdeduction.Text = Model.Deduction.ToString();
            txtdecuctionremark.Text = Model.Remarks.ToString();
            txtallowance.Text = Model.Allownce.ToString();
            txtallowanceremark.Text = Model.AllowRemark;



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
            lbladdress1.Text = Language.Address1;
            lbladdress1.Font = Language.font;
            lbladdress2.Text = Language.Address2;
            lbladdress2.Font = Language.font;
            lblphone1.Text = Language.Phone1;
            lblphone1.Font = Language.font;
            lblphone2.Text = Language.Phone2;
            lblphone2.Font = Language.font;
            lblnic.Text = Language.NICNO;
            lblemail.Text = Language.Email;
            lblemail.Font = Language.font;
            lbluser.Text = Language.user;
            lbluser.Font = Language.font;
            lblstatus.Text = Language.active;
            lblstatus.Font = Language.font;
            lblbasicsalary.Text = Language.Website;
            lblbasicsalary.Font = Language.font;
            lbldate.Text = Language.Date;
            lbldate.Font = Language.font;
            lbldesignation.Text = "کارمن";
            lbldesignation.Font = Language.font;
            lblremarks.Text = Language.Remark;
            lblremarks.Font = Language.font;
            lblbasicsalary.Text = Language.Salary;
            lblbasicsalary.Font = Language.font;
            lbltitle.Text = "د کارمن د تادیې ";
            lblpay.Text = Language.Salarypay; 
            lblpay.Font = Language.font;
            lbldeduction.Text = Language.Deduction;
            lbldeduction.Font= Language.font;
            lbldeductionremark.Text = Language.Remark;
            lbldeductionremark.Font = Language.font; 
            lbldesig.Text = Language.Designation;
            lbldesig.Font = Language.font;
            lblallowance.Text = Language.Allowances;
            lblallowance.Font = Language.font;
            lblallowremarks.Text = Language.Remark;
            lblallowremarks.Font = Language.font;
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;

        }
        private EmployeePaymentModel SetProperty()
        {
            EmployeePaymentModel model = new EmployeePaymentModel();
            model.Salary = txtpay.Text == string.Empty ? 0 : Convert.ToDecimal(txtpay.Text);
            model.Time =DateTime.Now.TimeOfDay;
            model.Date = txtdate.Value;
            model.Deduction = txtdeduction.Text == string.Empty ? 0 : Convert.ToDecimal(txtdeduction.Text);
            model.Allownce = txtallowance.Text == string.Empty ? 0 : Convert.ToDecimal(txtallowance.Text);
            model.EMP_ID= Convert.ToInt32(txtdesignationid.Text);
            model.Remarks = txtdecuctionremark.Text;
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
            decimal salary = 0;
            if (txtpay.Text != string.Empty)
                salary = Convert.ToDecimal(txtpay.Text);
            string m = "is requird";
            if (txtdesignationName.Text == string.Empty)
            {
                MessageBox.Show("Employee  " + m);
                txtdesignationName.Focus();
                return false;
            }
            else if(salary<=0)
            {
                MessageBox.Show("Salay Pay is  " + m);
                txtpay.Focus();
                return false;
            }
            //else if (layer.CheckDuplication(txtdesignationName.Text) != 0)
            //{
            //    if (saveupdate == "Save")
            //    {
            //        MessageBox.Show("Employee  Name Already Exist");
            //        txtdesignationName.Focus();
            //        return false;
            //    }

            //}




            return true;
        }
        private DialogResult Confirm(string m, string t)
        {
            DialogResult dr = MessageBox.Show(m, t, MessageBoxButtons.YesNo);
            return dr;
        }

      

        private void Txtaddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtpay.Focus();
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
            txtnic.Focus();

        }

        private void Txtfax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtemail.Focus();

        }

        private void Txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            txtsalary.Focus();

        }

        private void Txtwebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtdesignationName.Focus();

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

      

        private void TxtdesignationName_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (txtdesignationid.Focused || txtdesignationName.Focused)
                loadSearchFormSupplier();
        }
        private void loadSearchFormSupplier()
        {
            EmployeeMain obj = new EmployeeMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.Employeemodel!= null)
            {
                txtdesignationid.Text = obj.Employeemodel.EMP_ID.ToString();
                txtdesignationName.Text = obj.Employeemodel.Name.ToString();
                txtaddress1.Text = obj.Employeemodel.Address1.ToString();
                txtaddress2.Text = obj.Employeemodel.Address2.ToString();
                txtphone1.Text = obj.Employeemodel.phone1.ToString();
                txtphon2.Text = obj.Employeemodel.phone2.ToString();
                txtnic.Text = obj.Employeemodel.NICNO.ToString();
                txtemail.Text = obj.Employeemodel.email.ToString();
                txtsalary.Text = obj.Employeemodel.BasicSalary.ToString();
                txtremark.Text = obj.Employeemodel.remark.ToString();
                txtdesignation.Text = obj.Employeemodel.DesignationModels.Name; 


            }
        }

        private void AllowNumberInteger(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

     

        private void Txtsalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);
        }

        private void TxtdesignationName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtdesignationName.Text != string.Empty)
                if (e.KeyCode == Keys.Enter)
                    txtremark.Focus();
        }

        private void Txtpay_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtpay.Text != string.Empty)
                if (e.KeyCode == Keys.Enter)
                    txtdeduction.Focus(); 
        }

        private void Txtdeduction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtdecuctionremark.Focus();
        }

        private void Txtdecuctionremark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }

        private void Txtpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);
        }

        private void Txtdeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);
        }
        internal void LoadDataForprint(string fromform, string p)
        {
            if (fromform == "MainForm")
            {
                txtusername.Text = POS.Properties.Settings.Default.username;
                btnSave.Text = saveupdate;
                if (saveupdate != "Save")
                {
                    GetProperty();
                }
            }
            DataSet1 ds = new DataSet1();
            
                DataRow row = ds.Tables["tbl_EmployeePay"].NewRow();
            row["MainCode"] = txtcode.Text; 
            row["Code"] =txtdesignationid.Text;
            row["Name"] = txtdesignationName.Text;
            row["Phone"] = txtphone1.Text;
            row["Address"] =txtaddress1.Text;
            row["Designation"] =txtdesignation.Text;
            row["JoinDate"] =Model.EmployeeModels.AddDate.Value.ToShortDateString();
            row["PayDate"] =txtdate.Value.ToShortDateString();
            row["BasicSalary"] =txtsalary.Text;
            row["Deduction"] = txtdeduction.Text;
            row["PayedSalary"] = txtpay.Text;
            row["Allowance"] = txtallowance.Text;
            row["allowRemark"] = txtallowanceremark.Text;
            row["deductionRemark"] = txtdecuctionremark.Text;
            ds.Tables["tbl_EmployeePay"].Rows.Add(row);
           


            switch (p)
            {

                case "Preview":
                    EmployeePaymentReportForm obj = new EmployeePaymentReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    EmployeePaymentOtherReport obj2 = new EmployeePaymentOtherReport(p, ds);
                    break;
                case "Word":
                    EmployeePaymentOtherReport obj3 = new EmployeePaymentOtherReport(p, ds);
                    break;
                case "Excel":
                    EmployeePaymentOtherReport obj4 = new EmployeePaymentOtherReport(p, ds);
                    break;

            }


        }
    }
}
