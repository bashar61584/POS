using MDS.Customer;
using POS.BussinessModel;
using POS.BussinessModel.MasterModel;
using POS.BussinessModel.TransactionModel.AccountModel;
using POS.SettingSoft;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class EmployeePaymentMain : Form 
    {
        readonly EmployeePaymentLayer layer = new EmployeePaymentLayer();
        DataTable dt = new DataTable();
        private string decession = "";
        public EmployeePaymentMain()
        {
            InitializeComponent();
            this.Select();
        }
        public EmployeePaymentMain(string dec)
        {
            InitializeComponent();
            txtsearch.Select();
            this.decession = dec;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control| Keys.N:
                        BtnNew_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.O:
                    BtnOpen_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.P:
                    Btnprint_Click(new object(), new EventArgs());
                    break;
                case Keys.Alt| Keys.P:
                    BtnPreview_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.W:
                    Btnword_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.E:
                    Btnexcel_Click(new object(), new EventArgs());
                    break;
                case Keys.Control | Keys.F:
                    txtsearch.Focus(); 
                    break;
                case Keys.Escape:
                    BtnClose_Click(new object(), new EventArgs());
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            EmployeePaymentMaster item = new EmployeePaymentMaster(this,"Save");
            item.ShowDialog();
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                    EmployeePaymentMaster item = new EmployeePaymentMaster(this, "Update", SetProperty());
                item.ShowDialog();
            }
        }
        private void ItemMaster_Load(object sender, EventArgs e)
        {
         
          //ultraGrid1.DataSource= db.UserModels.ToList();

            LoadDataGridView("");
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            Btnprint.Text = Language.print;
            btnPreview.Text = Language.Preview;
            btnOpen.Text = Language.Open;
            btnNew.Text = Language.New;
            lbltitle.Text = "د کارمن د تادیې لیست";
            this.Text = "د کارمن د تادیې لیست";
        } 
        internal void LoadDataGridView(string state)
        {
            dt.Clear();
            dt = layer.LoadGridView(state);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.Columns[2].Visible = false;
            bunifuCustomDataGrid1.Columns[3].Visible = false;
            bunifuCustomDataGrid1.Columns[4].Visible = false;
            bunifuCustomDataGrid1.Columns[5].Visible = false;
            bunifuCustomDataGrid1.Columns[6].Visible = false;
            bunifuCustomDataGrid1.Columns[7].Visible = false;
            bunifuCustomDataGrid1.Columns[13].Visible = false;
            bunifuCustomDataGrid1.Columns[16].Visible = false;
            bunifuCustomDataGrid1.Columns[17].Visible = false;
            bunifuCustomDataGrid1.Columns[18].Visible = false;
            bunifuCustomDataGrid1.Columns[19].Visible = false;
            bunifuCustomDataGrid1.Columns[20].Visible = false;
            bunifuCustomDataGrid1.Columns[21].Visible = false;
        }


        private EmployeePaymentModel SetProperty()
        {
            EmployeePaymentModel model = new EmployeePaymentModel();
            EmployeeModel EmpModel = new EmployeeModel();
            DesignationModel desigmodel = new DesignationModel(); 

            model.EMP_AC_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString());
            EmpModel.Name = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            EmpModel.Address1 = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            EmpModel.phone1 = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            EmpModel.Address2 = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            EmpModel.phone2 = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            EmpModel.NICNO = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            EmpModel.email = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();
            EmpModel.BasicSalary = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[8].Value.ToString());
            desigmodel.Name = bunifuCustomDataGrid1.SelectedRows[0].Cells[9].Value.ToString();
            model.Salary = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[10].Value.ToString());
            model.Deduction = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[11].Value.ToString());
            model.Allownce = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[12].Value.ToString());
            model.AllowRemark= bunifuCustomDataGrid1.SelectedRows[0].Cells[13].Value.ToString();
            model.Date=Convert.ToDateTime( bunifuCustomDataGrid1.SelectedRows[0].Cells[14].Value.ToString());
            model.user_id = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[16].Value.ToString());
            desigmodel.DSIG_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[17].Value.ToString());
            EmpModel.EMP_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[18].Value.ToString());
            EmpModel.remark = bunifuCustomDataGrid1.SelectedRows[0].Cells[19].Value.ToString();
            model.Remarks = bunifuCustomDataGrid1.SelectedRows[0].Cells[20].Value.ToString();
            EmpModel.AddDate= Convert.ToDateTime(bunifuCustomDataGrid1.SelectedRows[0].Cells[21].Value.ToString());
            EmpModel.DesignationModels = desigmodel;
            model.EmployeeModels = EmpModel;
            return model;
        }

        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = bunifuCustomDataGrid1.Columns[0].HeaderText+ " like '%" + txtsearch.Text + "%'" +
                "or Convert([" + bunifuCustomDataGrid1.Columns[1].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                " or [" + bunifuCustomDataGrid1.Columns[2].HeaderText + "]  like '%" + txtsearch.Text + "%'" +
                " or  [" + bunifuCustomDataGrid1.Columns[3].HeaderText + "]  like '%" + txtsearch.Text + "%'" +
                " or  " + bunifuCustomDataGrid1.Columns[4].HeaderText + "  like '%" + txtsearch.Text + "%'" +
                " or [" + bunifuCustomDataGrid1.Columns[7].HeaderText + "] like '%" + txtsearch.Text + "%'";
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                    EmployeePaymentMaster item = new EmployeePaymentMaster(this, "Update", SetProperty());
                    item.LoadDataForprint("MainForm", "Preview");
                }
        }

        private void Btnprint_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                    EmployeePaymentMaster item = new EmployeePaymentMaster(this, "Update", SetProperty());
                    item.LoadDataForprint("MainForm", "Print");
                }

        }

        private void Btnword_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                    EmployeePaymentMaster item = new EmployeePaymentMaster(this, "Update", SetProperty());
                    item.LoadDataForprint("MainForm", "Word");
                }
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                    EmployeePaymentMaster item = new EmployeePaymentMaster(this, "Update", SetProperty());
                    item.LoadDataForprint("MainForm", "Excel");
                }
            
        }

        private void Txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bunifuCustomDataGrid1.Focus();
        }
        public EmployeePaymentModel EmployeePaymentmodel;

        //...........................................
        private void BunifuCustomDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (decession == "ForSearchOnly")
                if (e.KeyCode == Keys.Enter)
                    if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                    {
                        EmployeePaymentmodel = SetProperty();
                        this.Close();
                    }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
