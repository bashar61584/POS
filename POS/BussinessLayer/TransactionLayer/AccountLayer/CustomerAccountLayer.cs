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
using POS.BussinessModel.TransactionModel.AccountModel.TempClassForAccount;
using POS.SettingSoft;

namespace MDS.Customer
{
    class CustomerAccountLayer
    {
        private ModelContext db; 
        public CustomerAccountLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, CustomerAccountOrderModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.CustomerAccountOrderModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.Cash_ID = Convert.ToInt32(txtcode);
                var ItemINDB = db.CustomerAccountOrderModels.Find(model.Cash_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                result = db.SaveChanges();
            }
            return result;
            
        }
        internal int MainCodeIDFor()
        {
            return db.CustomerAccountOrderModels.Max(x => x.Cash_ID);
        }
        internal int SaveUpdateFncInvoice(SaleAccountModel model,int maincode)
        {
            int result = 0;
            model.cash_id = maincode;
            db.SaleAccountModels.Add(model);
            result = db.SaveChanges();
          
            return result;
        }
       
     
        internal DataTable LoadGridView(string state)
        {
            if(state=="Update")
            db = new ModelContext();
            DataTable da = new DataTable();

            var mod = db.CustomerAccountOrderModels.Include(u => u.UserModels)
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
                row[2] = item.Credit;
                row[3] = item.Debit;
                row[4] = item.UserModels.user_name;
              

                da.Rows.Add(row);
            }
            return da;
        }

        internal List<AccountTempList> LoadInvoiceDataGrid(int iD)
        {
          List<AccountTempList> li = new List<AccountTempList>();

            var tempModel = db.SaleAccountModels.Include(u => u.CustomerModels)
                    .Where(u => u.cash_id == iD).ToList().OrderByDescending(u => u.ID);


            foreach (var item in tempModel)
            {
                li.Add(new AccountTempList()
                {
                    Credit=(decimal)item.Credit,
                    Debit=(decimal)item.Debit,
                    Cu_ID=(int)item.Cu_ID,
                    Balance=(decimal)item.Balance,
                    Name=item.CustomerModels.Name
                });
            }
            return li; 
        }


        internal string SupplierBalance(int id)
        {
            var mod = db.SaleAccountModels.Where(x => x.Cu_ID== id);
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
                db.SaleAccountModels.RemoveRange(db.SaleAccountModels.Where(u => u.cash_id == maincode));
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
                db.CustomerAccountOrderModels.RemoveRange(db.CustomerAccountOrderModels.Where(u => u.Cash_ID == code));

                result = db.SaveChanges();
            }
            catch (Exception)
            {


            }
            return result;
        }
    }

}
