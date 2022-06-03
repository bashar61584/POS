using MDS.Customer;
using POS.BussinessModel;
using POS.SettingSoft;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class ItemMain :Form 
    {
        readonly ItemLayer layer = new ItemLayer();
        DataTable dt = new DataTable();
        private string decession = "";
        public ItemMain()
        {
            InitializeComponent();
            txtsearch.Select();
        }
        public ItemMain(string dec)
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
       

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.itemlist)
            {
                ItemMaster2 item = new ItemMaster2(this, "Save");
                item.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry you don't have permession");
            }
          
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.itemlist)
            {
                if (bunifuCustomDataGrid1.RowCount != 1)
                    if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                    {
                        ItemMaster2 item = new ItemMaster2(this, "Update", SetProperty());
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
            lbltitle.Text = "توکی";
            this.Text = "توکی";
        }
        internal void LoadDataGridView(string state)
        {
            dt.Clear();
            dt = layer.LoadGridView(state);
            bunifuCustomDataGrid1.DataSource = dt;
            //ultraGrid1.DataSource = dt;
            //ultraGrid1.DisplayLayout.Bands[0].Columns["user_id"].Hidden = true;
            bunifuCustomDataGrid1.Columns[10].Visible = false;

          
        }


        private ItemModel SetProperty()
        {
            ItemModel model = new ItemModel();
            model.item_id = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[0].Value.ToString());
            //model.item_id= Convert.ToInt32(ultraGrid1.DisplayLayout.ActiveRow.Cells["Code"].Value.ToString());
            model.item_name = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            model.item_retail = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString());
            model.item_costprice = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString());
            model.item_tp = Convert.ToDecimal(bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString());
            model.item_packing = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString());
            model.item_ministock = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString());
            model.item_stock = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString());

            model.item_state = Convert.ToBoolean(bunifuCustomDataGrid1.SelectedRows[0].Cells[8].Value.ToString());
            model.user_id = Convert.ToInt32(bunifuCustomDataGrid1.SelectedRows[0].Cells["user_id"].Value.ToString());

            return model;
       
        }
        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;


            dv.RowFilter = bunifuCustomDataGrid1.Columns[1].HeaderText+" like '%" + txtsearch.Text + "%'"+
                "or Convert(["+ bunifuCustomDataGrid1.Columns[0].HeaderText+"], System.String)  like '%" + txtsearch.Text + "%'"+
                " or  Convert([" + bunifuCustomDataGrid1.Columns[2].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'"+
                " or  Convert([" + bunifuCustomDataGrid1.Columns[3].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'"+
                " or  Convert([" + bunifuCustomDataGrid1.Columns[4].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'"+
                " or  Convert([" + bunifuCustomDataGrid1.Columns[7].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'"+
                      " or  Convert([" + bunifuCustomDataGrid1.Columns[9].HeaderText + "], System.String)  like '%" + txtsearch.Text + "%'" ;
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
        public ItemModel ItemModel;

        private void BunifuCustomDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (decession == "ForSearchOnly")
                if (e.KeyCode == Keys.Enter)
                    if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                    {
                        ItemModel = SetProperty();
                        this.Close();
                    }
        }

        //...........................................

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
