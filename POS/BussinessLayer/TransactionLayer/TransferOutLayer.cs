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
    class TransferOutLayer
    {
        private ModelContext db;
        public TransferOutLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, TransferOutOrderModel model)
        {
            int result = 0;
            if (txtcode == string.Empty)
            {
                db.TransferOutOrderModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.Transfer_Out_ID = Convert.ToInt32(txtcode);
                var ItemINDB = db.TransferOutOrderModels.Find(model.Transfer_Out_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                result = db.SaveChanges();
            }
            return result;

        }
        internal int MainCodeIDFor()
        {
            return db.TransferOutOrderModels.Max(x => x.Transfer_Out_ID);
        }
        internal int SaveUpdateFncInvoice(TransferOutInvoiceModel model, int maincode)
        {
            int result = 0;
            model.Transfer_Out_ID = maincode;
            db.TransferOutInvoiceModels.Add(model);
            result = db.SaveChanges();
            var ItemINDB = db.ItemModels.Find(model.Item_id);
            ItemINDB.item_stock = ItemINDB.item_stock - model.Qty;
            db.Entry(ItemINDB).CurrentValues.SetValues(model);
            db.SaveChanges();
            return result;
        }
        internal int InsertAcount(TransferInAccountModel model)
        {
            int result = 0;
            db.TransferInAccountModels.Add(model);
            result = db.SaveChanges();
            return result;
        }
        internal int DeleteFnc(int txtcode)
        {
            int result = 0;
            try
            {
                TransferOutOrderModel model = db.TransferOutOrderModels.Find(txtcode);
                db.TransferOutOrderModels.Remove(model);
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

            var mod = db.TransferOutOrderModels.Include(u => u.UserModels)
                .Include(u => u.LoanModels).ToList().OrderByDescending(x => x.Transfer_Out_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Name);
                da.Columns.Add(Language.Address1);
                da.Columns.Add(Language.Phone1);
                da.Columns.Add(Language.Date);
                da.Columns.Add(Language.recieved);
                da.Columns.Add(Language.BillTotal);
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
                da.Columns.Add("Credit");
                da.Columns.Add("Debit");
                da.Columns.Add("User");
                da.Columns.Add("sup_id");
            }


            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0] = item.Transfer_Out_ID;
                row[1] = item.LoanModels.Name;
                row[2] = item.LoanModels.Address1;
                row[3] = item.LoanModels.phone1;
                row[4] = item.Date.Value.ToShortDateString();
                row[7] = item.UserModels.user_name;
                row["sup_id"] = item.Lo_ID;
                var account = db.TransferInAccountModels.Where(u => u.Transfer_Out_ID == item.Transfer_Out_ID).ToList();
                foreach (var item2 in account)
                {
                    if (item2.Type == "OUT")
                        row[6] = item2.Debit;
                    if (item2.Type == "Cash")
                        row[5] = item2.Credit;
                    else
                        row[5] = 0.0;

                }

                da.Rows.Add(row);
            }
            return da;
        }

        internal List<TransferOutInvoiceTempList> LoadInvoiceDataGrid(int iD)
        {
            List<TransferOutInvoiceTempList> li = new List<TransferOutInvoiceTempList>();


            var tempModel = db.TransferOutInvoiceModels.Include(u => u.itemModel)
                    .Where(u => u.Transfer_Out_ID == iD).ToList().OrderByDescending(u => u.ID);

            foreach (var item in tempModel)
            {
                li.Add(new TransferOutInvoiceTempList()
                {
                    Item_id = (int)item.Item_id,
                    Item_name = item.itemModel.item_name,
                    Bonus = (int)item.Bonus,
                    Disc = (int)item.Disc,
                    Price = (decimal)item.Price,
                    Qty = (int)item.Qty,
                    Tp_Price=(decimal)item.Tp_Price
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
                    TransferOutReportForm obj = new TransferOutReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    TransferOutOtherReport orp = new TransferOutOtherReport(p, ds);

                    break;
                case "Word":
                    TransferOutOtherReport orp2 = new TransferOutOtherReport(p, ds);

                    break;
                case "Excel":
                    TransferOutOtherReport orp3 = new TransferOutOtherReport(p, ds);

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
            var mod = db.TransferInAccountModels.Where(x => x.lo_id == id);
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
                db.TransferOutInvoiceModels.RemoveRange(db.TransferOutInvoiceModels.Where(u => u.Transfer_Out_ID == code));
                db.TransferInAccountModels.RemoveRange(db.TransferInAccountModels.Where(u => u.Transfer_Out_ID == code));
                db.SaveChanges();
            }
            catch (Exception)
            {


            }
        }
    }

}
