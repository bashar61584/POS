using MDS.Customer;
using POS.BussinessModel;
using POS.SettingSoft;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class LoanMain : Form 
    {
        readonly LoanLayer layer = new LoanLayer ();
        DataTable dt = new DataTable();
        private string decession = "";
        public LoanMain()
        {
            InitializeComponent();
            txtsearch.Select();
            
        }
        public LoanMain(string dec)
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
                case Keys.Escape:
                    BtnClose_Click(new object(), new EventArgs());
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

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.loanlist)
            {
                LoanMaster item = new LoanMaster(this, "Save");
                item.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry you don't have permession");
            }
           
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.loanlist)
            {
                if (bunifuCustomDataGrid1.RowCount != 1)
                    if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                    {
                        LoanMaster item = new LoanMaster(this, "Update", SetProperty());
                        item.ShowDialog();
                    }
            }
            else
            {
                MessageBox.Show("Sorry you don't have permession");
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
            lbltitle.Text = "د پور لیست";
            this.Text = "د پور لیست";
        }
        internal void LoadDataGridView(string state)
        {
            dt.Clear();
            dt = layer.LoadGridView(state);
           bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.Columns[5].Visible = false;
            bunifuCustomDataGrid1.Columns[9].Visible = false;
            bunifuCustomDataGrid1.Columns[8].Visible = false;
            bunifuCustomDataGrid1.Columns[6].Visible = false;
            bunifuCustomDataGrid1.Columns[10].Visible = false;
            bunifuCustomDataGrid1.Columns["user_id"].Visible = false;
        }


        private LoanModel SetProperty()
        {
            LoanModel model = new LoanModel();


            model.Lo_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString());
            model.Name = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            model.phone1 = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            model.phone2 = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            model.Address1 = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            model.Address2 = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            model.fax = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            model.email = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();
            model.website = bunifuCustomDataGrid1.SelectedRows[0].Cells[8].Value.ToString();
            model.licence = bunifuCustomDataGrid1.SelectedRows[0].Cells[9].Value.ToString();
            model.remark = bunifuCustomDataGrid1.SelectedRows[0].Cells[10].Value.ToString();
            model.status = Convert.ToBoolean(bunifuCustomDataGrid1.SelectedRows[0].Cells[11].Value.ToString());

            model.user_id = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells["user_id"].Value.ToString());

            return model;
        }
        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = bunifuCustomDataGrid1.Columns[0].HeaderText + " like '%" + txtsearch.Text + "%'" +
                           "or Convert([" + bunifuCustomDataGrid1.Columns[1].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                           " or [" + bunifuCustomDataGrid1.Columns[2].HeaderText + "]  like '%" + txtsearch.Text + "%'" +
                           " or  [" + bunifuCustomDataGrid1.Columns[3].HeaderText + "]  like '%" + txtsearch.Text + "%'" +
                           " or  " + bunifuCustomDataGrid1.Columns[4].HeaderText + "  like '%" + txtsearch.Text + "%'" +
                           " or [" + bunifuCustomDataGrid1.Columns[7].HeaderText + "] like '%" + txtsearch.Text + "%'";
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                layer.RetrieveReport("Preview");
        }

        private void Btnprint_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                layer.RetrieveReport("Print");

        }

        private void Btnword_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                layer.RetrieveReport("Word");
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                layer.RetrieveReport("Excel");
        }

        private void Txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                    bunifuCustomDataGrid1.Focus();
        }
        //This retrieve for the Purchase Master Form also see the datagrid key down
        public LoanModel loanmodel;

        //...........................................
        private void BunifuCustomDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if(decession== "ForSearchOnly")
            if (e.KeyCode == Keys.Enter)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                        loanmodel = SetProperty();
                    this.Close();
                }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
