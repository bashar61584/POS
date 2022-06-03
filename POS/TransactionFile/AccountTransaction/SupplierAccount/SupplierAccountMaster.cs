using MDS.Customer;
using POS.BussinessModel;
using POS.BussinessModel.TempList;
using POS.BussinessModel.TransactionModel.AccountModel.TempClassForAccount;
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
    public partial class SupplierAccountMaster : Form
    {
        private SupplierAccountLayer layer = new SupplierAccountLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";
        private SupplierAccountMain owner;
        private SupplierAccountOrderModel Model;

        private string saveupdate { get; set; }

        public SupplierAccountMaster(SupplierAccountMain _owner, string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (SupplierAccountMain)_owner;
            txtdate.Value = DateTime.Now;
            txtcode.Select();
        }

        public SupplierAccountMaster(SupplierAccountMain _owner, string save, SupplierAccountOrderModel model)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (SupplierAccountMain)_owner;
            Model = (SupplierAccountOrderModel)model;
        
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
                    if (txtcode.Focused)
                        loadSearchFormSupplier();
                    break;
                case Keys.Control | Keys.R:
                    txtrecieved.Focus();
                    break;
                case Keys.F2:
                    txtcode.Focus();
                    break;
                case Keys.F3:
                    txtitemRecieved.Focus();
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
            txtdate.Value =(DateTime) Model.Date;
            txtmaincode.Text = Model.Cash_ID.ToString();
            txtnetamount.Text = Model.Debit.ToString();
            txtrecieved.Text = Model.Credit.ToString(); 
           
            List<AccountTempList> li = layer.LoadInvoiceDataGrid(Model.Cash_ID);
            foreach (var item in li)
            {
                bunifuCustomDataGrid1.Rows.Add(bunifuCustomDataGrid1.RowCount,
                                                item.Cu_ID,
                                                item.Name,
                                                item.Debit,
                                                item.Credit,
                                                item.Balance
                                                );
            }

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

            lblcode.Text = Language.code;
            lblcode.Font = Language.font;
            lblmaincode.Text = Language.code;
            lblmaincode.Font = Language.font;
            lblname.Text = Language.Name;
            lblname.Font = Language.font;
            lbladdress.Text = Language.Address1;
            lbladdress.Font = Language.font;
            lbldate.Text = Language.Date;
            lbldate.Font = Language.font;
            lblbalance.Text = Language.Balance;
            lblbalance.Font = Language.font;
            lblrecieved.Text = Language.recieved;
            lblrecieved.Font = Language.font;
            lblpayed.Text = Language.payed;
            lblpayed.Font = Language.font;
            lbluser.Text = Language.user;
            lblphone.Text = Language.Phone1;
            btnaddlist.Text = Language.add;
            btndeletelist.Text = Language.delete;
            lbltitle.Text = "د وارداتو حساب";
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;
            lbltotalrecieved.Text = Language.recieved;
            lbltotalpayed.Text = Language.payed;

        }

        private SupplierAccountOrderModel SetProperty()
        {
            SupplierAccountOrderModel model = new SupplierAccountOrderModel();
            model.Date = txtdate.Value;
            model.Credit = Convert.ToDecimal(txtnetamount.Text);
            model.Debit = Convert.ToDecimal(txtrecieved.Text);
            model.user_id = POS.Properties.Settings.Default.userid;
            return model;


        }
        
        private PurchaseAccountModel SetInvoiceProperty(int i)
        {
            PurchaseAccountModel model = new PurchaseAccountModel();
            model.sup_id = Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString());
            model.Debit = Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Debit"].Value.ToString());
            model.Credit= Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Credit"].Value.ToString());
            model.Balance = Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Balance"].Value.ToString());
            model.purchase_order_id = 0;
            model.Type = "Cash";
           
            model.Purchase_ret_ID = 0;
            model.Time = DateTime.Now.TimeOfDay;
            model.Date = txtdate.Value;
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
                            if (layer.EditFunct(maincode) != 0)
                            {

                            }
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
                            //txtbalance.Text = layer.SupplierBalance(Convert.ToInt32(txtcode.Text));
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
                    if (layer.EditFunct(maincode) != 0)
                    {

                    }
                    if (layer.DeleteInvoiceAndAccount(maincode) != 0)
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
            
             if (bunifuCustomDataGrid1.RowCount== 1)
            {
                MessageBox.Show("Please Enter Some Item To Bill");
                txtitemRecieved.Focus();
                return false;
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
                    txtaddress.Focus();
        }

        private void Txtaddress1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    txtaddress2.Focus();
        }


        private void Txtphone1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtitemRecieved.Focus();

        }

        private void Txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcode.Text != String.Empty)
                if (e.KeyCode == Keys.Enter)
                    txtitemRecieved.Focus();
        }

        private void loadSearchFormSupplier()
        {
            SupplierMain obj = new SupplierMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.suppliermodel != null)
            {
                txtcode.Text = obj.suppliermodel.Sup_ID.ToString();
                txtname.Text = obj.suppliermodel.Name.ToString();
                txtaddress.Text = obj.suppliermodel.Address1.ToString();
                txtphone.Text = obj.suppliermodel.phone1.ToString();

            }
        }

      


       

        private void Txtitemname_KeyDown(object sender, KeyEventArgs e)
        {

           
                if (e.KeyCode == Keys.Enter)
                {
                    txtitempayed.Focus();
                }
           
        }
        private void loadSearchFormItem()
        {
            //ItemMain obj = new ItemMain("ForSearchOnly");
            //obj.ShowDialog();
            //if (obj.ItemModel != null)
            //{
            //    txtitemcode.Text = obj.ItemModel.item_id.ToString();
            //    txtitemname.Text = obj.ItemModel.item_name.ToString();
            //    txtitemqty.Text = obj.ItemModel.item_stock.ToString();
            //    switch (POS.Properties.Settings.Default.SetPrice)
            //    {
            //        case "TP":
            //            txtitemprice.Text = obj.ItemModel.item_tp.ToString();//For the price tp
            //            break;
            //        case "RP":
            //            txtitemprice.Text = obj.ItemModel.item_retail.ToString();//For the price rp
            //            break;
            //        case "CP":
            //            txtitemprice.Text = obj.ItemModel.item_costprice.ToString();//For the price cp
            //            break;
            //    }

            //}
        }

        private void Txtitemprice_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                    btnaddlist.Focus();
            

        }

        private void Txtitemprice_Leave(object sender, EventArgs e)
        {
            if (txtitempayed.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a valid value");
                txtitempayed.Focus();
            }
        }

      

      

     
        
        private bool CheckSubtextBox()
        {

            decimal recieved = 0,payed=0;
            if (txtitemRecieved.Text != string.Empty)
                recieved = Convert.ToDecimal(txtitemRecieved.Text);
            if (txtitempayed.Text != string.Empty)
                payed = Convert.ToDecimal(txtitempayed.Text);
            string m = " is Required";
          
           if (recieved == 0 && payed==0)
            {
                MessageBox.Show("Recieved" + m);
                txtitemRecieved.Focus();
                return false;
            }

            if (bunifuCustomDataGrid1.RowCount != 1)
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                {

                    if (txtcode.Text == bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString())
                    {

                        txtcode.Focus();
                        MessageBox.Show(txtcode.Text + " Customer already exist");
                        return false;
                    }
                }

            return true;
        }
        private void ResetFormSubTexbox()
        {
            txtitemRecieved.Text = "0";
           
            txtitempayed.Text = "0";
            txtcode.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
         
            txtcode.Focus();
        }
        private void calculateListView()
        {
            //txtitemcount.Text = listView1.Items.Count.ToString();

            decimal recieved = 0;
            decimal payed = 0;

            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
            {
              
                recieved += Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Credit"].Value.ToString());
                txtrecieved.Text = recieved.ToString();

                payed += Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Debit"].Value.ToString());
                txtnetamount.Text = payed.ToString();

            }
           
        }
        private void Btnaddlist_Click(object sender, EventArgs e)
        {
            if (CheckSubtextBox())
            {
                decimal recieved = 0, payed = 0;
                if (txtitemRecieved.Text != string.Empty)
                    recieved = Convert.ToDecimal(txtitemRecieved.Text);
                if (txtitempayed.Text != string.Empty)
                    payed = Convert.ToDecimal(txtitempayed.Text);
                bunifuCustomDataGrid1.Rows.Insert(0, bunifuCustomDataGrid1.RowCount,
                txtcode.Text,
                txtname.Text,
                payed,
                recieved,
                
                subTotal(recieved,
                         payed, Convert.ToDecimal(txtbalance.Text)
                         ));
                ResetFormSubTexbox();
                calculateListView();
            }

        }
        private decimal subTotal(decimal recieved,decimal payed,decimal balance)
        {
            return (balance - recieved + payed);
                
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

       

       

        private void Txtrecieved_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberDecimal(sender, e);
        }

        private void Txtrecieved_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus(); 
           
        }

        private void Txtrecieved_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal netamount = 0, receieved = 0;
                if (txtitempayed.Text != String.Empty)
                    netamount = Convert.ToDecimal(txtitempayed.Text);
                if (txtitemRecieved.Text != String.Empty)
                    receieved = Convert.ToDecimal(txtitemRecieved.Text);
         
            }
            catch (Exception)
            {

                MessageBox.Show("Not in Correct Format. Please enter a valid value");
                txtitemRecieved.Text = "0";
                txtitemRecieved.Focus();
                txtitemRecieved.Select();
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

        private void Txtcode_Leave(object sender, EventArgs e)
        {
            if(txtcode.Text!=string.Empty)
            txtbalance.Text = layer.SupplierBalance(Convert.ToInt32(txtcode.Text));
        }

        //private void BtnPreview_Click(object sender, EventArgs e)
        //{
        //    if(txtmaincode.Text!=string.Empty)
        //    LoadDataForprint(Convert.ToInt32(txtmaincode.Text), "Preview");
        //}
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
                DataRow row = ds.Tables["tbl_Account"].NewRow();
                row["Order_id"] = txtmaincode.Text;
                row["Date"] = txtdate.Value.ToShortDateString();
                row["Code"] = bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString();
                row["Name"] = bunifuCustomDataGrid1.Rows[i].Cells["Customer"].Value.ToString();
                row["Credit"] = bunifuCustomDataGrid1.Rows[i].Cells["Credit"].Value.ToString();
                row["Debit"] = bunifuCustomDataGrid1.Rows[i].Cells["Debit"].Value.ToString();
                row["Balance"] = bunifuCustomDataGrid1.Rows[i].Cells["Balance"].Value.ToString();
               

                ds.Tables["tbl_Account"].Rows.Add(row);
            }


            switch (p)
            {

                case "Preview":
                    SupplierAccountReportForm obj = new SupplierAccountReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    SupplierAccountOtherReport obj2 = new SupplierAccountOtherReport(p, ds);
                    break;
                case "Word":
                    SupplierAccountOtherReport obj3 = new SupplierAccountOtherReport(p, ds);
                    break;
                case "Excel":
                    SupplierAccountOtherReport obj4 = new SupplierAccountOtherReport(p, ds);
                    break;

            }


        }

        private void TxtitemRecieved_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberDecimal(sender, e);
        }

    }
}
