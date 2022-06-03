using MDS.Customer;
using POS.BussinessModel;
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
    public partial class PurchaseMaster : Form
    {
        private PurchaseLayer layer = new PurchaseLayer();
        private string message = "Are You Sure To";
        private string Saved = "Record Are Saved";
        private string update = "Record Are Updated";
        private string delete = "Record Are Deleted";
        private PurchaseMain owner;
        private PurchaseOrderModel Model;
        private AccountTempModel account;
        private DataTable tempdtforputdatagridview = new DataTable();
        private string saveupdate { get; set; }

        public PurchaseMaster(PurchaseMain _owner, string save)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (PurchaseMain)_owner;
            txtdate.Value = DateTime.Now;
            txtcode.Select();
        }

        public PurchaseMaster(PurchaseMain _owner, string save, PurchaseOrderModel model,AccountTempModel account)
        {
            InitializeComponent();
            saveupdate = save;
            owner = (PurchaseMain)_owner;
            Model = (PurchaseOrderModel)model;
            this.account = account;
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
            txtcode.Text = Model.SupplierModels.Sup_ID.ToString();
            txtname.Text = Model.SupplierModels.Name;
            txtaddress.Text = Model.SupplierModels.Address1;
            txtmaincode.Text = Model.purchase_order_id.ToString();
            txtinvoice.Text = Model.InvoiceNo;
            txtdate.Value= (DateTime)Model.Date;
            txtrecieved.Text = account.Credit.ToString();
            txtnetamount.Text = account.Debit.ToString();
            if (txtcode.Text != string.Empty)
                txtbalance.Text = layer.SupplierBalance(Convert.ToInt32(txtcode.Text));
            List<PurchaseInvoiceTempList> li = layer.LoadInvoiceDataGrid(Model.purchase_order_id);
            foreach (var item in li)
            {
                bunifuCustomDataGrid1.Rows.Add( bunifuCustomDataGrid1.RowCount,
                                                item.Item_id,
                                                item.Item_name,
                                                item.Price,
                                                item.Qty,
                                                item.Bonus,
                                                item.Disc,
                                                 subTotal(item.Qty.ToString(),
                         item.Price.ToString(),
                         item.Bonus.ToString(),
                         item.Disc.ToString()));
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
                loadTempDatagridviewdatatable();
            }
            setThePriceRadio();
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
            lblinvoice.Text = Language.InvoiceNumber;
            lblbalance.Text = Language.Balance;
            lblbalance.Font = Language.font;
            lblitem.Text = Language.Item;
            lblitem.Font = Language.font;
            lblprice.Text = Language.Price;
            lblprice.Font = Language.font;
            lbluser.Text = Language.user;
            lblqty.Text = Language.quantity;
            lblqty.Font = Language.font;
            lblbonus.Text = Language.Bonus;
            lblbonus.Font = Language.font;
            lbldiscp.Text = Language.Discountper;
            lbldiscp.Font = Language.font;
            lbldiscm.Text = Language.Discount;
            lbldiscm.Font = Language.font;
            btnaddlist.Text = Language.add;
            btndeletelist.Text = Language.delete;
            lblsubtotal.Text = Language.subtotal;
            lblsubtotal.Font = Language.font;
            lbltotaldiscount.Text = Language.totaldiscount;
            lbltotaldiscount.Font = Language.font;
            lbltotalbonus.Text = Language.Bonus;
            lbltotalbonus.Font = Language.font;
            lbltitle.Text = "د پیرودلو د سټاک بیل";
            btnSave.Text = Language.save;
            btnDelete.Text = Language.delete;
            lblnetamount.Text = Language.netamount;
            lblrecieved.Text = Language.payed;
            lbltotalbalance.Text = Language.Balance;

        }
        private PurchaseOrderModel SetProperty()
        {
            PurchaseOrderModel model = new PurchaseOrderModel();
            model.Sup_ID = Convert.ToInt32(txtcode.Text);
            model.Date = txtdate.Value;
            model.Time = DateTime.Now.TimeOfDay;
            model.Dis = Convert.ToDecimal(txttotaldiscount.Text);
            model.Type = "Invoice";
            model.InvoiceNo = txtinvoice.Text;
         
            model.user_id = POS.Properties.Settings.Default.userid;
            return model;


        }
        
        private PurchaseInvoiceModel SetInvoiceProperty(int i)
        {
            PurchaseInvoiceModel model = new PurchaseInvoiceModel();
            model.Item_id = Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString());
            model.Price = Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Price"].Value.ToString());
            model.Qty= Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["QTY"].Value.ToString());
            model.Disc = Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["DISC"].Value.ToString());
            model.Bonus = Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["Bonus"].Value.ToString());
            return model;


        }
        private PurchaseAccountModel SetAccountProperty(int txtmaincode,string txtcode,DateTime date,string type,decimal amount,decimal recieved )
        {
            PurchaseAccountModel model = new PurchaseAccountModel();
            model.purchase_order_id = txtmaincode;
            model.Purchase_ret_ID = 0;
            model.sup_id = Convert.ToInt32(txtcode);
            model.Type = type;
            model.cash_id = 0;
            model.Date = date;
            model.Time = DateTime.Now.TimeOfDay;
            if(type== "Invoice")
            {
                model.Credit = 0;
                model.Debit = amount;
            }
            else
            {
                model.Credit = recieved;
                model.Debit = 0;
            }
            model.user_id = POS.Properties.Settings.Default.userid;

            return model;


        }
        private string CheckNullNumber(string t)
        {
            if (t == string.Empty)
                return "0";
            else
                return t;
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

                            //For Invoice Insert
                            if (layer.InsertAcount(SetAccountProperty(maincode,
                                                                      txtcode.Text,
                                                                       txtdate.Value,
                                                                       "Invoice",
                                                                        Convert.ToDecimal(txtnetamount.Text),
                                                                      Convert.ToDecimal(txtrecieved.Text)
                                                                      )) != 0)
                            {

                            }
                            //For cash insert
                            if (Convert.ToDouble(txtrecieved.Text) != 0)
                            {
                                if (layer.InsertAcount(SetAccountProperty(maincode,
                                                                      txtcode.Text,
                                                                       txtdate.Value,
                                                                       "Cash",
                                                                        Convert.ToDecimal(txtnetamount.Text),
                                                                      Convert.ToDecimal(txtrecieved.Text)
                                                                      )) != 0)
                                {
                                }
                            }
                            MessageBox.Show(Saved);
                            if (owner != null)
                                owner.LoadDataGridView("");
                            //This for show the update balance for the print
                            txtbalance.Text = layer.SupplierBalance(Convert.ToInt32(txtcode.Text));
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
                            if (layer.EditFunct(tempdtforputdatagridview) != 0)
                            {

                            }
                            layer.DeleteInvoiceAndAccount(maincode);

                            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                            {
                                if (layer.SaveUpdateFncInvoice(SetInvoiceProperty(i), maincode) != 0)
                                {

                                }
                            }

                            //For Invoice Insert
                            if (layer.InsertAcount(SetAccountProperty(maincode,
                                                                      txtcode.Text,
                                                                       txtdate.Value,
                                                                       "Invoice",
                                                                        Convert.ToDecimal(txtnetamount.Text),
                                                                      Convert.ToDecimal(txtrecieved.Text)
                                                                      )) != 0)
                            {

                            }
                            //For cash insert
                            if (Convert.ToDouble(txtrecieved.Text) != 0)
                            {
                                if (layer.InsertAcount(SetAccountProperty(maincode,
                                                                      txtcode.Text,
                                                                       txtdate.Value,
                                                                       "Cash",
                                                                        Convert.ToDecimal(txtnetamount.Text),
                                                                      Convert.ToDecimal(txtrecieved.Text)
                                                                      )) != 0)
                                {
                                }
                            }

                            MessageBox.Show(update);
                            if (owner != null)
                                owner.LoadDataGridView("Update");
                            //This for show the update balance for the print
                            txtbalance.Text = layer.SupplierBalance(Convert.ToInt32(txtcode.Text));
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
        private void loadTempDatagridviewdatatable()
        {
            tempdtforputdatagridview.Clear();
            tempdtforputdatagridview.Columns.Clear();
            tempdtforputdatagridview.Columns.Add("Code");
            tempdtforputdatagridview.Columns.Add("QTY");


            for (int i = 0; i < bunifuCustomDataGrid1.RowCount-1; i++)
            {
               
                tempdtforputdatagridview.Rows.Add(bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString(),
                                        Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["QTY"].Value.ToString()));

                
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtmaincode.Text != string.Empty)
            {
                if (Confirm(message + "Delete it?", "Delete Record") == DialogResult.Yes)
                {
                    int maincode = Convert.ToInt32(txtmaincode.Text);
                    if (layer.EditFunct(tempdtforputdatagridview) != 0)
                    {

                    }
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
            
            string m = "is requird";
            if (txtcode.Text == string.Empty)
            {
                MessageBox.Show("Supplier Selection " + m);
                txtcode.Focus();
                return false;
            }
            else if (bunifuCustomDataGrid1.RowCount== 1)
            {
                MessageBox.Show("Please Enter Some Item To Bill");
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
                txtitemname.Focus();

        }

        private void Txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcode.Text != String.Empty)
                if (e.KeyCode == Keys.Enter)
                    txtinvoice.Focus();
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

            }
        }

        private void Rdbtp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtp.Checked)
            {
                rdbtp.Text = "TP";
                POS.Properties.Settings.Default.SetPrice = rdbtp.Text;
                POS.Properties.Settings.Default.Save();
                txtitemname.Focus();
            }
        }

        private void Rdbcp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbcp.Checked)
            {
                rdbcp.Text = "CP";
                POS.Properties.Settings.Default.SetPrice = rdbcp.Text;
                POS.Properties.Settings.Default.Save();
                txtitemname.Focus();
            }
        }

        private void Rdbrp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbrp.Checked)
            {
                rdbrp.Text = "RP";
                POS.Properties.Settings.Default.SetPrice = rdbrp.Text;
                POS.Properties.Settings.Default.Save();
                txtitemname.Focus();
            }
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
            ItemMain obj = new ItemMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.ItemModel != null)
            {
                txtitemcode.Text = obj.ItemModel.item_id.ToString();
                txtitemname.Text = obj.ItemModel.item_name.ToString();
                txtitemqty.Text = obj.ItemModel.item_stock.ToString();
                switch (POS.Properties.Settings.Default.SetPrice)
                {
                    case "TP":
                        txtitemprice.Text = obj.ItemModel.item_tp.ToString();//For the price tp
                        break;
                    case "RP":
                        txtitemprice.Text = obj.ItemModel.item_retail.ToString();//For the price rp
                        break;
                    case "CP":
                        txtitemprice.Text = obj.ItemModel.item_costprice.ToString();//For the price cp
                        break;
                }

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

        private void Txtitemoderqty_Leave(object sender, EventArgs e)
        {
            if (txtitemoderqty.Text == string.Empty)
            {
                txtitemoderqty.Text = "0";
            }
        }

        private void Txtitemoderqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtitemoderqty.Text != string.Empty)
            {
                if (e.KeyCode == Keys.Enter)
                    txtbonus.Focus();
            }
        }

        private void Txtdiscount_Leave(object sender, EventArgs e)
        {
            if (txtdiscount.Text == string.Empty)
            {
                txtdiscount.Text = "0";
            }
        }

        private void Txtbonus_Leave(object sender, EventArgs e)
        {
            if (txtbonus.Text == string.Empty)
            {
                txtbonus.Text = "0";
            }
        }

        private void Txtbonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtdiscount.Focus();
        }

        private void Txtdiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtdiscountmoney.Focus();
        }

        private void Txtdiscountmoney_Leave(object sender, EventArgs e)
        {
            if (txtdiscountmoney.Text == string.Empty)
            {
                txtdiscountmoney.Text = "0";
            }
            else
            {
                if (txtitemprice.Text != string.Empty)
                {
                    decimal price = 1;
                    decimal disc = 0;
                    if (txtitemprice.Text != string.Empty)
                        if (Convert.ToDecimal(txtitemprice.Text) != 0)
                            price = Convert.ToDecimal(txtitemprice.Text);
                    if (txtdiscountmoney.Text != string.Empty)
                        if (Convert.ToDecimal(txtdiscountmoney.Text) != 0)
                            disc = Convert.ToDecimal(txtdiscountmoney.Text);


                    txtdiscount.Text = ((disc * 100) / price).ToString();
                }
                else
                {
                    txtdiscountmoney.Text = "0";
                    txtitemname.Focus();
                }
            }
        }

        private void Txtdiscountmoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnaddlist.Focus();
        }
        private string subTotal(string qty, string price, string bonus, string disc)
        {
            decimal getqty = 0, getprice = 0, getbonus = 0, getdisc, getdiscm;
            getqty = Convert.ToDecimal(qty);
            getprice = Convert.ToDecimal(price);
            getbonus = Convert.ToDecimal(bonus);
            getdisc = Convert.ToDecimal(disc);
            getdiscm = (getprice * getdisc) / 100;
            return ((getqty - getbonus) * (getprice - getdiscm)).ToString();
        }
        private bool CheckSubtextBox()
        {
            
            decimal orderqty = 0;
            if (txtitemoderqty.Text != string.Empty)
                orderqty = Convert.ToDecimal(txtitemoderqty.Text);
           
            string m = " is Required";
            if (txtitemcode.Text == string.Empty)
            {
                MessageBox.Show("Item" + m);
                txtitemname.Focus();
                return false;
            }
            else if (orderqty == 0)
            {
                MessageBox.Show("Quantity" + m);
                txtitemoderqty.Focus();
                return false;
            }
          
            if (bunifuCustomDataGrid1.RowCount != 1)
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                {

                    if (txtitemcode.Text == bunifuCustomDataGrid1.Rows[i].Cells["Code"].Value.ToString())
                    {

                        txtitemname.Focus();
                        MessageBox.Show(txtitemname.Text + " Item already exist");
                        return false;
                    }
                }

            return true;
        }
        private void ResetFormSubTexbox()
        {
            txtitemname.Text = "";
            txtitemcode.Text = "";
            txtitemqty.Text = "";
            txtitemprice.Text = "";
            txtitemoderqty.Text = "";
            txtbonus.Text = "";
            txtdiscount.Text = "";
            txtdiscountmoney.Text = "";
            txtitemname.Focus();
        }
        private void calculateListView()
        {
            //txtitemcount.Text = listView1.Items.Count.ToString();

            int sumBonus = 0;
            decimal netamount = 0;
            decimal sumofDiscout = 0;
            decimal discm = 0;

            for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
            {
                sumBonus += Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells["Bonus"].Value.ToString());
                txttotalbonus.Text = sumBonus.ToString();

                netamount += Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Total"].Value.ToString());
                txtnetamount.Text = netamount.ToString();

                discm = ((Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Price"].Value.ToString())
                                        * Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["DISC"].Value.ToString())) / 100);
                sumofDiscout += (Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["QTY"].Value.ToString()) - Convert.ToDecimal(bunifuCustomDataGrid1.Rows[i].Cells["Bonus"].Value.ToString())) * discm;
            }
            txttotaldiscount.Text = sumofDiscout.ToString();
            txtsubtotal.Text = (Convert.ToDecimal(txtnetamount.Text) + Convert.ToDecimal(txttotaldiscount.Text)).ToString();
            decimal recamount = 0;
            if (txtrecieved.Text != String.Empty)
                recamount = Convert.ToDecimal(txtrecieved.Text);
            txttotalbalance.Text = (netamount - recamount).ToString();
        }
        private void Btnaddlist_Click(object sender, EventArgs e)
        {
            if (CheckSubtextBox())
            {
                bunifuCustomDataGrid1.Rows.Insert(0,bunifuCustomDataGrid1.RowCount,
                txtitemcode.Text,
                txtitemname.Text,
                txtitemprice.Text,
                txtitemoderqty.Text,
                txtbonus.Text,
                txtdiscount.Text,
                subTotal(txtitemoderqty.Text,
                         txtitemprice.Text,
                         txtbonus.Text,
                         txtdiscount.Text));
                ResetFormSubTexbox();
                calculateListView();
            }
          
        }
        private void setThePriceRadio()
        {
            switch (POS.Properties.Settings.Default.SetPrice)
            {
                case "TP":
                    rdbtp.Checked = true;
                    break;
                case "RP":
                    rdbrp.Checked = true;
                    break;
                case "CP":
                    rdbcp.Checked = true;
                    break;
            }
        }

        private void Txtdiscount_TextChange(object sender, EventArgs e)
        {
            if (txtitemprice.Text != string.Empty)
            {
                decimal price = 0;
                decimal disc = 0;
                if (txtitemprice.Text != string.Empty)
                    if (Convert.ToDecimal(txtitemprice.Text) != 0)
                        price = Convert.ToDecimal(txtitemprice.Text);
                if (txtdiscount.Text != string.Empty)
                    if (Convert.ToDecimal(txtdiscount.Text) != 0)
                        disc = Convert.ToDecimal(txtdiscount.Text);


                txtdiscountmoney.Text = ((price * disc) / 100).ToString();
            }
            else
            {
                txtdiscount.Text = "0";
                txtitemname.Focus();
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

        private void Txtitemoderqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);

        }

        private void Txtbonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);

        }

        private void Txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberInteger(sender, e);

        }

        private void Txtdiscountmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumberDecimal(sender, e);

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
                if (txtnetamount.Text != String.Empty)
                    netamount = Convert.ToDecimal(txtnetamount.Text);
                if (txtrecieved.Text != String.Empty)
                    receieved = Convert.ToDecimal(txtrecieved.Text);
                txttotalbalance.Text = (netamount - receieved).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Not in Correct Format. Please enter a valid value");
                txtrecieved.Text = "0";
                txtrecieved.Focus();
                txtrecieved.Select();
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
                    loadTempDatagridviewdatatable();
                }
            }
            DataSet1 ds = new DataSet1();
            for (int i = 0; i < bunifuCustomDataGrid1.RowCount-1; i++)
            {
                DataRow row = ds.Tables["tbl_Invoice"].NewRow();
                row["item_name"] = bunifuCustomDataGrid1.Rows[i].Cells["Product"].Value.ToString();
                row["item_price"] = bunifuCustomDataGrid1.Rows[i].Cells["Price"].Value.ToString();
                row["item_qty"] = bunifuCustomDataGrid1.Rows[i].Cells["QTY"].Value.ToString();
                row["item_bonus"] = bunifuCustomDataGrid1.Rows[i].Cells["Bonus"].Value.ToString();
                row["item_discp"] = bunifuCustomDataGrid1.Rows[i].Cells["DISC"].Value.ToString();
                row["code"] = txtcode.Text;
                row["name"] = txtname.Text;
                row["address"] = txtaddress.Text;
                row["invoice"] = txtinvoice.Text;
                row["order_id"] = txtmaincode.Text;
                row["date"] = txtdate.Value;
                row["balance"] = txtbalance.Text;
                row["recieved"] = txtrecieved.Text;

                ds.Tables["tbl_Invoice"].Rows.Add(row);
            }


            switch (p)
            {

                case "Preview":
                   PurchaseReportForm obj = new PurchaseReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    PurchaseOtherReport obj2 = new PurchaseOtherReport(p, ds);
                    break;
                case "Word":
                    PurchaseOtherReport obj3 = new PurchaseOtherReport(p, ds);
                    break;
                case "Excel":
                    PurchaseOtherReport obj4 = new PurchaseOtherReport(p, ds);
                    break;

            }


        }

       
    }
}
