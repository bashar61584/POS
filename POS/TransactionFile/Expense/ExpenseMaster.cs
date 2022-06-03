using MDS.Customer;
using POS.BussinessModel;
using POS.BussinessModel.MasterModel;
using POS.BussinessModel.TempList;
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
    public partial class ExpenseMaster : Form
    {
        private ExpenseLayer layer = new ExpenseLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";
        private ExpenseMain owner;
        private ExpenseOrderModel Model;
        private string saveupdate { get; set; }

        public ExpenseMaster(ExpenseMain _owner, string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (ExpenseMain)_owner;
            txtdate.Value = DateTime.Now;
            txtitemname.Select();
        }

        public ExpenseMaster(ExpenseMain _owner, string save, ExpenseOrderModel model,AccountTempModel account)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (ExpenseMain)_owner;
            Model = (ExpenseOrderModel)model;
            bunifuCustomDataGrid1.Select();

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
                    if (txtitemname.Focused)
                        loadSearchFormItem();
                   
                    break;
               
               
                case Keys.F3:
                    txtitemname.Focus();
                    break;
                case Keys.Delete:
                    Btndeletelist_Click(new object(), new EventArgs());
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
            txtmaincode.Text = Model.EXP_ID.ToString();
            txtdate.Value = (DateTime)Model.Date;

            List<ExpenseInvoiceTempList> li = layer.LoadInvoiceDataGrid(Model.EXP_ID);
            foreach (var item in li)
            {
                bunifuCustomDataGrid1.Rows.Add(bunifuCustomDataGrid1.RowCount,
                                                item.ExpMenu_ID,
                                                item.ExpMenuName,
                                                item.Remark,
                                                item.Price
                                                );
            }

            calculateListView();


        }
        private void ItemMaster2_Load(object sender, EventArgs e)
        {

            txtusername.Text = POS.Properties.Settings.Default.username;
            btnSave.Text = saveupdate;
            if (saveupdate != "Save")
            {
                GetProperty();
            }
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {

           
            lblmaincode.Text = Language.code;
            lblmaincode.Font = Language.font;
          
            lbldate.Text = Language.Date;
            lbldate.Font = Language.font;
          
            lblitem.Text = Language.Menu;
            lblitem.Font = Language.font;
            lblprice.Text = Language.Price;
            lblprice.Font = Language.font;
            lbluser.Text = Language.user;
            lblqty.Text = Language.Remark;
            lblqty.Font = Language.font;
          
            btnaddlist.Text = Language.add;
            btndeletelist.Text = Language.delete;
         
            lbltitle.Text = "د لګښتونو بیل";
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;
            lblnetamount.Text = Language.netamount;
           

        }
        private ExpenseOrderModel SetProperty()
        {
            ExpenseOrderModel model = new ExpenseOrderModel();
            model.Date = txtdate.Value;
            model.user_id = POS.Properties.Settings.Default.userid;
            return model;


        }
        
        private ExpenseInvoiceModel SetInvoiceProperty(int i)
        {
            ExpenseInvoiceModel model = new ExpenseInvoiceModel();
            model.EXPMENU_ID = Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString());
            model.Price = Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Amount"].Value.ToString());
            model.Remark=bunifuCustomDataGrid1.Rows[i].Cells["Remark"].Value.ToString();
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

                            int maincode = layer.MainCodeIDFor();
                            txtmaincode.Text = maincode.ToString();
                            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                            {
                                if (layer.SaveUpdateFncInvoice(SetInvoiceProperty(i), maincode) != 0)
                                {

                                }
                            }


                            MessageBox.Show(Saved);
                            if (owner != null)
                                owner.LoadDataGridView("");
                            //This for show the update balance for the print
                            if (chksaveandprint.Checked)
                                LoadDataForprint("MasterForm", "Print");
                            BtnClose_Click(new object(), new EventArgs());
                        }

                    }
                }
                else
                {
                    if (Confirm(message + " Update it?", "Update Record") == DialogResult.Yes)
                    {
                        if (layer.SaveUpdateFnc(txtmaincode.Text, SetProperty()) != 0)
                        {
                            int maincode = Convert.ToInt32(txtmaincode.Text);

                            layer.DeleteInvoiceAndAccount(maincode);

                            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                            {
                                if (layer.SaveUpdateFncInvoice(SetInvoiceProperty(i), maincode) != 0)
                                {

                                }
                            }

                            MessageBox.Show(update);
                            if (owner != null)
                                owner.LoadDataGridView("Update");
                            //This for show the update balance for the print
                            if (chksaveandprint.Checked)
                                LoadDataForprint("MasterForm", "Print");
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
            if (txtmaincode.Text != string.Empty)
            {
                if (Confirm(message + "Delete it?", "Delete Record") == DialogResult.Yes)
                {
                    int maincode = Convert.ToInt32(txtmaincode.Text);
                   
                    layer.DeleteInvoiceAndAccount(maincode);
                    if (layer.DeleteFnc(maincode) != 0)
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
            if (bunifuCustomDataGrid1.RowCount == 1)
            {
                MessageBox.Show("Please Enter Some Item To Invoice");
                txtitemname.Focus();
                return false;
            }
            return true;
        }
        private DialogResult Confirm(string m, string t)
        {
            DialogResult dr = MessageBox.Show(m, t, MessageBoxButtons.YesNo);
            return dr;
        }
        private void Txtitemname_KeyDown(object sender, KeyEventArgs e)
        {

            if (txtitemname.Text != String.Empty)
                if (e.KeyCode == Keys.Enter)
                {
                    txtitemprice.Focus();
                }
           
        }
        private void loadSearchFormItem()
        {
            ExpenseMenuMain obj = new ExpenseMenuMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.ExpenseMenuModel != null)
            {
                txtitemcode.Text = obj.ExpenseMenuModel.EXPMENU_ID.ToString();
                txtitemname.Text = obj.ExpenseMenuModel.Name.ToString();
               
              

            }
        }

        private void Txtitemprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtitemprice.Text != string.Empty)
            {
                if (e.KeyCode == Keys.Enter)
                    txtitemoderqty.Focus();
            }

        }

        private void Txtitemprice_Leave(object sender, EventArgs e)
        {
            if (txtitemprice.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a valid value");
                txtitemprice.Focus();
            }
        }

       

        private void Txtitemoderqty_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                btnaddlist.Focus();

        }

      
     

      
        private bool CheckSubtextBox()
        {
            
        
           
            string m = " is Required";
            if (txtitemcode.Text == string.Empty)
            {
                MessageBox.Show("Item" + m);
                txtitemname.Focus();
                return false;
            }
          
          
            if (bunifuCustomDataGrid1.RowCount != 1)
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                {

                    if (txtitemcode.Text == bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString())
                    {

                        txtitemname.Focus();
                        MessageBox.Show(txtitemname.Text + " Menu already exist");
                        return false;
                    }
                }

            return true;
        }
        private void ResetFormSubTexbox()
        {
            txtitemname.Text = "";
            txtitemcode.Text = "";
            txtitemprice.Text = "";
            txtitemoderqty.Text = "";
            txtitemname.Focus();
        }
        private void calculateListView()
        {
            //txtitemcount.Text = listView1.Items.Count.ToString();

            decimal netamount = 0;

            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
            {
              

                netamount += Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Amount"].Value.ToString());
                txtnetamount.Text = netamount.ToString();

            }
           
         
        }
        private void Btnaddlist_Click(object sender, EventArgs e)
        {
            if (CheckSubtextBox())
            {
                bunifuCustomDataGrid1.Rows.Insert(0, bunifuCustomDataGrid1.RowCount,
                txtitemcode.Text,
                txtitemname.Text,
                                txtitemoderqty.Text,
                txtitemprice.Text);



                ResetFormSubTexbox();
                calculateListView();
            }

        }
       

        private void Txtitemprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberDecimal(sender, e);

        }

        private void AllowNumberInteger(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 )
            {
                e.Handled = true;
            }
        }
        private void AllowNumberDecimal(object sender, KeyPressEventArgs e)
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


     

      

        private void Btndeletelist_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.RowCount != 1)
            {
                if (bunifuCustomDataGrid1.Rows.Count - 1 != bunifuCustomDataGrid1.SelectedRows[0].Index)
                {
                    bunifuCustomDataGrid1.Rows.RemoveAt(bunifuCustomDataGrid1.CurrentRow.Index);
                    calculateListView();
                }
            }
        }

     

        internal void LoadDataForprint(string fromform,string p)
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
            for (int i = 0; i < bunifuCustomDataGrid1.RowCount-1; i++)
            {
                DataRow row = ds.Tables["tbl_Expense"].NewRow();
                row["Code"] = txtmaincode.Text;
                row["Date"] = txtdate.Value.ToShortDateString();
                row["Menu"] = bunifuCustomDataGrid1.Rows[i].Cells["Menu"].Value.ToString();
                row["Remark"] = bunifuCustomDataGrid1.Rows[i].Cells["Remark"].Value.ToString(); ;
                row["Amount"] = bunifuCustomDataGrid1.Rows[i].Cells["Amount"].Value.ToString(); ;
               
                ds.Tables["tbl_Expense"].Rows.Add(row);
            }


            switch (p)
            {

                case "Preview":
                   ExpenseReportForm obj = new ExpenseReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    ExpenseOtherReport obj2 = new ExpenseOtherReport(p, ds);
                    break;
                case "Word":
                    ExpenseOtherReport obj3 = new ExpenseOtherReport(p, ds);
                    break;
                case "Excel":
                    ExpenseOtherReport obj4 = new ExpenseOtherReport(p, ds);
                    break;

            }


        }

     
    }
}
