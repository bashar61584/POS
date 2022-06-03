using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using POS;
using POS.BussinessModel;
using System.Data.Entity;
using POS.Item;
using POS.BussinessModel.TransactionModel.AccountModel.TempClassForAccount;
using POS.SettingSoft;

namespace MDS.Customer
{
    class SupplierAccountLayer
    {
        private ModelContext db; 
        public SupplierAccountLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, SupplierAccountOrderModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.SupplierAccountOrderModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.Cash_ID = Convert.ToInt32(txtcode);
                var ItemINDB = db.SupplierAccountOrderModels.Find(model.Cash_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                result = db.SaveChanges();
            }
            return result;
            
        }
        internal int MainCodeIDFor()
        {
            return db.SupplierAccountOrderModels.Max(x => x.Cash_ID);
        }
        internal int SaveUpdateFncInvoice(PurchaseAccountModel model,int maincode)
        {
            int result = 0;
            model.cash_id = maincode;
            db.PurchaseAccountModels.Add(model);
            result = db.SaveChanges();
          
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
                PurchaseOrderModel model = db.purchaseOrderModels.Find(txtcode);
                db.purchaseOrderModels.Remove(model);
                result = db.SaveChanges();
            }
            catch (Exception)
            {


            }
            return result;
        }
     
        internal DataTable LoadGridView(string state)
        {
            if(state=="Update")
            db = new ModelContext();
            DataTable da = new DataTable();

            var mod = db.SupplierAccountOrderModels.Include(u => u.UserModels)
                .ToList().OrderByDescending(x => x.Cash_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Date);
                da.Columns.Add(Language.recieved);
                da.Columns.Add(Language.payed);
                da.Columns.Add(Language.user);

            }
            else
            {
                da.Columns.Add("Code");
                da.Columns.Add("Date");
                da.Columns.Add("Total Recieved");
                da.Columns.Add("Total Payed");
                da.Columns.Add("User");


            }
            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0]     = item.Cash_ID;
                row[1] = item.Date.Value.ToShortDateString();
                row[2] = item.Debit; 
                row[3] = item.Credit;
                row[4] = item.UserModels.user_name;
              

                da.Rows.Add(row);
            }
            return da;
        }

        internal List<AccountTempList> LoadInvoiceDataGrid(int iD)
        {
          List<AccountTempList> li = new List<AccountTempList>();

            var tempModel = db.PurchaseAccountModels.Include(u => u.SupplierModels)
                    .Where(u => u.cash_id == iD).ToList().OrderByDescending(u => u.ID);


            foreach (var item in tempModel)
            {
                li.Add(new AccountTempList()
                {
                    Credit=(decimal)item.Credit,
                    Debit=(decimal)item.Debit,
                    Cu_ID=(int)item.sup_id,
                    Balance=(decimal)item.Balance,
                    Name=item.SupplierModels.Name
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
                    SupplierOtherReport orp = new SupplierOtherReport(p,ds);

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
            var mod = db.SupplierModels.SingleOrDefault(x=>x.Name==name);
            if(mod!=null)
            {
                da = 1;
            }
            return da;
        }

        internal string SupplierBalance(int id)
        {
            var mod = db.PurchaseAccountModels.Where(x => x.sup_id== id);
            decimal credit = 0, debit = 0;
            foreach (var item in mod)
            {
                if (item.Credit != 0)
                    credit += (decimal)item.Credit;
                if (item.Debit != 0)
                    debit += (decimal)item.Debit;
            }
            return (debit-credit).ToString();
        }

        internal int EditFunct(int maincode)
        {
            int result = 0;
            try
            {
                db.PurchaseAccountModels.RemoveRange(db.PurchaseAccountModels.Where(u => u.cash_id == maincode));
            }
            catch (Exception)
            {


            }
            return result;
        }
        internal int DeleteInvoiceAndAccount(int code)
        {
            int result = 0;
            try
            {
                db.SupplierAccountOrderModels.RemoveRange(db.SupplierAccountOrderModels.Where(u => u.Cash_ID == code));

                result = db.SaveChanges();
            }
            catch (Exception)
            {


            }
            return result;
        }
    }

}
