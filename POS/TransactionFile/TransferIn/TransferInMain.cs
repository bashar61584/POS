using MDS.Customer;
using POS.BussinessModel;
using POS.SettingSoft;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class TransferInMain : Form 
    {
        readonly TransferInLayer layer = new TransferInLayer();
        DataTable dt = new DataTable();
        AccountTempModel account;
        public TransferInMain()
        {
            InitializeComponent();
            txtsearch.Select();
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

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TransferInMaster item = new TransferInMaster(this, "Save");
            item.ShowDialog();
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                TransferInMaster item = new TransferInMaster(this, "Update", SetProperty(), account);
                item.ShowDialog();
            }
        }
        private void ItemMaster_Load(object sender, EventArgs e)
        {
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
            lbltitle.Text = "دننه د لیږد لړلیک";
            this.Text = "دننه د لیږد لړلیک";

        }
        internal void LoadDataGridView(string state)
        {
            dt.Clear();
            dt = layer.LoadGridView(state);
            bunifuCustomDataGrid1.DataSource = dt;
            DataGridViewColumn column = bunifuCustomDataGrid1.Columns[0];
            column.Width = 60;
            column = bunifuCustomDataGrid1.Columns[1];
            column.Width = 250;
            column = bunifuCustomDataGrid1.Columns[2];
            column.Width = 200;
            column = bunifuCustomDataGrid1.Columns[3];
            column.Width = 80;
        

            bunifuCustomDataGrid1.Columns["sup_id"].Visible = false;

        }
        private TransferInOrderModel SetProperty()
        {
            TransferInOrderModel model = new TransferInOrderModel();
            LoanModel supmode = new LoanModel();
            account = new AccountTempModel();
            model.Transfer_In_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString());
            supmode.Name= bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            supmode.Address1= bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            model.Date = Convert.ToDateTime(bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString());
            model.InvoiceNo= bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            account.Debit= Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString());
            account.Credit= Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString());
            supmode.Lo_ID = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells["sup_id"].Value.ToString());
            model.LoanModels = supmode;
            return model;
            
        }
        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = bunifuCustomDataGrid1.Columns[1].HeaderText + " like '%" + txtsearch.Text + "%'" +
                           "or Convert([" + bunifuCustomDataGrid1.Columns[0].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                           " or " + bunifuCustomDataGrid1.Columns[2].HeaderText + "  like '%" + txtsearch.Text + "%'" +
                           " or  " + bunifuCustomDataGrid1.Columns[4].HeaderText + "  like '%" + txtsearch.Text + "%'" +
                           " or  Convert([" + bunifuCustomDataGrid1.Columns[5].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                           " or  Convert([" + bunifuCustomDataGrid1.Columns[6].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                           " or  Convert([" + bunifuCustomDataGrid1.Columns[7].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'";
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                TransferInMaster item = new TransferInMaster(this, "Update", SetProperty(), account);
                item.LoadDataForprint("MainForm", "Preview");
            }
        }

        private void Btnprint_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                TransferInMaster item = new TransferInMaster(this, "Update", SetProperty(), account);
                item.LoadDataForprint("MainForm", "Print");
            }

        }

        private void Btnword_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                TransferInMaster item = new TransferInMaster(this, "Update", SetProperty(), account);
                item.LoadDataForprint("MainForm", "Word");
            }
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                TransferInMaster item = new TransferInMaster(this, "Update", SetProperty(), account);
                item.LoadDataForprint("MainForm", "Excel");
            }
        }

        private void Txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                    bunifuCustomDataGrid1.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
