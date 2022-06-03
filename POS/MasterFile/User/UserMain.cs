using MDS.Customer;
using POS.BussinessModel;
using POS.SettingSoft;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class UserMain : Form 
    {
        readonly UserLayer layer = new UserLayer();
        DataTable dt = new DataTable();
        private string decession = "";
        public UserMain()
        {
            InitializeComponent();
            this.Select();
        }
        public UserMain(string dec)
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
            UserMaster item = new UserMaster(this,"Save");
            item.ShowDialog();
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            {
                    UserMaster item = new UserMaster(this, "Update", SetProperty());
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
            lbltitle.Text = "د کاروونکی لیست";
            this.Text = "د کاروونکی لیست";
        } 
        internal void LoadDataGridView(string state)
        {
            dt.Clear();
            dt = layer.LoadGridView(state);
            bunifuCustomDataGrid1.DataSource = dt;
           
        }


        private UserModel SetProperty()
        {
            UserModel model = new UserModel();
            
            
            model.user_id = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString());
            model.user_name = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            model.user_password = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            model.status = Convert.ToBoolean(bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString());
           
            
            return model;
        }
        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = bunifuCustomDataGrid1.Columns[1].HeaderText + " like '%" + txtsearch.Text + "%'" +
                "or Convert([" + bunifuCustomDataGrid1.Columns[0].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" +
                " or [" + bunifuCustomDataGrid1.Columns[2].HeaderText + "]  like '%" + txtsearch.Text + "%'" ;
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
        public CustomerModel customermodel;

        //...........................................
        private void BunifuCustomDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (decession == "ForSearchOnly")
            //    if (e.KeyCode == Keys.Enter)
            //        if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
            //        {
            //            customermodel = SetProperty();
            //            this.Close();
            //        }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
