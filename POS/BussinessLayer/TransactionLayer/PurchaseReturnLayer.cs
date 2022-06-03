using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POS;
using POS.BussinessModel;
using System.Data.Entity;
using POS.Item;
using System.Globalization;
using POS.BussinessModel.TempList;
using POS.SettingSoft;

namespace MDS.Customer
{
    class PurchaseReturnLayer
    {
        private ModelContext db;
        public PurchaseReturnLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, PurchaseReturnOrderModel model)
        {
            int result = 0;
            if (txtcode == string.Empty)
            {
                db.purchaseReturnOrderModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.Purchase_ret_ID = Convert.ToInt32(txtcode);
                var ItemINDB = db.purchaseReturnOrderModels.Find(model.Purchase_ret_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                result = db.SaveChanges();
            }
            return result;

        }
        internal int MainCodeIDFor()
        {
            return db.purchaseReturnOrderModels.Max(x => x.Purchase_ret_ID);
        }
        internal int SaveUpdateFncInvoice(PurchaseReturnInvoiceModel model, int maincode)
        {
            int result = 0;
            model.Purchase_ret_ID = maincode;
            db.PurchaseReturnInvoiceModels.Add(model);
            result = db.SaveChanges();
            var ItemINDB = db.ItemModels.Find(model.Item_id);
            ItemINDB.item_stock = ItemINDB.item_stock - model.Qty;
            db.Entry(ItemINDB).CurrentValues.SetValues(model);
            db.SaveChanges();
            return result;
        }
        internal int InsertAcount(PurchaseAccountModel model)
        {
            int result = 0;
            db.PurchaseAccountModels.Add(model);
            result = db.SaveChanges();
            return result;
        }
        internal int DeleteFnc(int txtcode)
        {
            int result = 0;
            try
            {
                PurchaseReturnOrderModel model = db.purchaseReturnOrderModels.Find(txtcode);
                db.purchaseReturnOrderModels.Remove(model);
                result = db.SaveChanges();
            }
            catch (Exception)
            {


            }
            return result;
        }

        internal DataTable LoadGridView(string state)
        {
            if (state == "Update")
                db = new ModelContext();
            DataTable da = new DataTable();

            var mod = db.purchaseReturnOrderModels.Include(u => u.UserModels)
                .Include(u => u.SupplierModels).ToList().OrderByDescending(x => x.Purchase_ret_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Name);
                da.Columns.Add(Language.Address1);
                da.Columns.Add(Language.Phone1);
                da.Columns.Add(Language.Date);
                da.Columns.Add(Language.InvoiceNumber);
                da.Columns.Add(Language.BillTotal);
                da.Columns.Add(Language.recieved);
                da.Columns.Add(Language.user);
                da.Columns.Add("sup_id");
            }
            else
            {
                da.Columns.Add("Code");
                da.Columns.Add("Name");
                da.Columns.Add("Address");
                da.Columns.Add("Phone");
                da.Columns.Add("Date");
                da.Columns.Add("INV#");
                da.Columns.Add("Credit");
                da.Columns.Add("Debit");
                da.Columns.Add("User");
                da.Columns.Add("sup_id");
            }


            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0] = item.Purchase_ret_ID;
                row[1] = item.SupplierModels.Name;
                row[2] = item.SupplierModels.Address1;
                row[3] = item.SupplierModels.phone1;
                row[4] = item.Date.Value.ToShortDateString();
                row[5] = item.InvoiceNo;
                row[8] = item.UserModels.user_name;
                row["sup_id"] = item.Sup_ID;
                var account = db.PurchaseAccountModels.Where(u => u.Purchase_ret_ID == item.Purchase_ret_ID).ToList();
                foreach (var item2 in account)
                {
                    if (item2.Type == "Return")
                        row[6] = item2.Credit;
                    if (item2.Type == "Cash")
                        row[7] = item2.Debit;

                    else
                        row[7] = 0.0;

                }

                da.Rows.Add(row);
            }
            return da;
        }

        internal List<PurchaseReturnInvoiceTempList> LoadInvoiceDataGrid(int iD)
        {
            List<PurchaseReturnInvoiceTempList> li = new List<PurchaseReturnInvoiceTempList>();


            var tempModel = db.PurchaseReturnInvoiceModels.Include(u => u.itemModel)
                    .Where(u => u.Purchase_ret_ID == iD).ToList().OrderByDescending(u => u.ID);

            foreach (var item in tempModel)
            {
                li.Add(new PurchaseReturnInvoiceTempList()
                {
                    Item_id = (int)item.Item_id,
                    Item_name = item.itemModel.item_name,
                    Bonus = (int)item.Bonus,
                    Disc = (int)item.Disc,
                    Price = (decimal)item.Price,
                    Qty = (int)item.Qty
                });
            }
            return li;
        }

        internal void RetrieveReport(string p)
        {

            DataSet1 ds = new DataSet1();
            var mod = db.SupplierModels.ToList();
            foreach (var item in mod)
            {
                DataRow row = ds.Tables["tbl_Invoice"].NewRow();
                row["item_id"] = item.Sup_ID;
                row["item_name"] = item.Sup_ID;
                row["item_price"] = item.Name;
                row["item_qty"] = item.Name;
                row["item_bonus"] = item.Name;
                row["item_discm"] = item.Address1;
                row["item_amount"] = item.Address1;
                row["item_amount"] = item.Address1;
                row["code"] = item.phone1;
                row["name"] = item.phone1;
                row["address"] = item.phone1;
                row["invoice"] = item.phone1;
                row["order_id"] = item.phone1;
                row["date"] = item.phone1;
                row["balance"] = item.phone1;
                row["recieved"] = item.phone1;
                row["gross"] = item.phone1;

                ds.Tables["tbl_Invoice"].Rows.Add(row);
            }
            switch (p)
            {

                case "Preview":
                    PurchaseReportForm obj = new PurchaseReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    SupplierOtherReport orp = new SupplierOtherReport(p, ds);

                    break;
                case "Word":
                    SupplierOtherReport orp2 = new SupplierOtherReport(p, ds);

                    break;
                case "Excel":
                    SupplierOtherReport orp3 = new SupplierOtherReport(p, ds);

                    break;
                    //case "Email":
                    //    EmailForm obj3 = new EmailForm(ds, this.Text);
                    //    obj3.ShowDialog();
                    //    break;
                    //case "Word":
                    //    MDS.Formula.OrderOtherReport obj4 = new MDS.Formula.OrderOtherReport(ds, p);
                    //    break;

            }
        }
        internal int CheckDuplication(string name)
        {
            int da = 0;
            var mod = db.SupplierModels.SingleOrDefault(x => x.Name == name);
            if (mod != null)
            {
                da = 1;
            }
            return da;
        }

        internal string SupplierBalance(int id)
        {
            var mod = db.PurchaseAccountModels.Where(x => x.sup_id == id);
            decimal credit = 0, debit = 0;
            foreach (var item in mod)
            {
                if (item.Credit != 0)
                    credit += (decimal)item.Credit;
                if (item.Debit != 0)
                    debit += (decimal)item.Debit;
            }
            return (debit - credit).ToString();
        }

        internal int EditFunct(DataTable tempdtforputdatagridview)
        {
            int result = 0;
            for (int i = 0; i < tempdtforputdatagridview.Rows.Count; i++)
            {
                var ItemINDB = db.ItemModels.Find(Convert.ToInt32(tempdtforputdatagridview.Rows[i]["Code"].ToString()));
                ItemINDB.item_stock = ItemINDB.item_stock + Convert.ToInt32(tempdtforputdatagridview.Rows[i]["QTY"].ToString());
                db.Entry(ItemINDB).State = EntityState.Modified;
                result = db.SaveChanges();
            }
            return result;
        }
        internal void DeleteInvoiceAndAccount(int code)
        {
            try
            {
                db.PurchaseReturnInvoiceModels.RemoveRange(db.PurchaseReturnInvoiceModels.Where(u => u.Purchase_ret_ID == code));
                db.PurchaseAccountModels.RemoveRange(db.PurchaseAccountModels.Where(u => u.Purchase_ret_ID == code));
                db.SaveChanges();
            }
            catch (Exception)
            {


            }
        }
    }

}
