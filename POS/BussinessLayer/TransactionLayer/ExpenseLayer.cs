using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using POS;
using POS.BussinessModel;
using System.Data.Entity;
using POS.Item;
using POS.BussinessModel.TempList;
using POS.SettingSoft;
using POS.BussinessModel.MasterModel;

namespace MDS.Customer
{
    class ExpenseLayer
    {
        private ModelContext db;
        public ExpenseLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, ExpenseOrderModel model)
        {
            int result = 0;
            if (txtcode == string.Empty)
            {
                db.ExpenseOrderModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.EXP_ID = Convert.ToInt32(txtcode);
                var ItemINDB = db.ExpenseOrderModels.Find(model.EXP_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                result = db.SaveChanges();
            }
            return result;

        }
        internal int MainCodeIDFor()
        {
            return db.ExpenseOrderModels.Max(x => x.EXP_ID);
        }
        internal int SaveUpdateFncInvoice(ExpenseInvoiceModel model, int maincode)
        {
            int result = 0;
            model.EXP_ID = maincode;
            db.ExpenseInvoiceModels.Add(model);
            result = db.SaveChanges();
           
            return result;
        }
      
        internal int DeleteFnc(int txtcode)
        {
            int result = 0;
            try
            {
                ExpenseOrderModel model = db.ExpenseOrderModels.Find(txtcode);
                db.ExpenseOrderModels.Remove(model);
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

            var mod = db.ExpenseOrderModels.Include(u => u.UserModels)
              .ToList().OrderByDescending(x => x.EXP_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Date);
                da.Columns.Add(Language.user);
                da.Columns.Add("user_id");
            }
            else
            {
                da.Columns.Add("Code");
            da.Columns.Add("Date");
            da.Columns.Add("User");
            da.Columns.Add("user_id");
            }


            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0] = item.EXP_ID;
                row[1] = item.Date.Value.ToShortDateString();
                row[2] = item.UserModels.user_name;
                row[3] = item.user_id;

                da.Rows.Add(row);
            }
            return da;
        }

        internal List<ExpenseInvoiceTempList> LoadInvoiceDataGrid(int iD)
        {
            List<ExpenseInvoiceTempList> li = new List<ExpenseInvoiceTempList>();


            var tempModel = db.ExpenseInvoiceModels.Include(u => u.ExpenseMenuModels)
                    .Where(u => u.EXP_ID == iD).ToList().OrderByDescending(u => u.EXP_ID);

            foreach (var item in tempModel)
            {
                li.Add(new ExpenseInvoiceTempList()
                {
                    ExpMenu_ID = (int)item.EXPMENU_ID,
                    ExpMenuName=item.ExpenseMenuModels.Name,
                    Price=(int)item.Price,
                    Remark=item.Remark
                 
                });
            }
            return li;
        }

      
       
     

      
        internal void DeleteInvoiceAndAccount(int code)
        {
            try
            {
                db.ExpenseInvoiceModels.RemoveRange(db.ExpenseInvoiceModels.Where(u => u.EXP_ID== code));
                db.SaveChanges();
            }
            catch (Exception)
            {


            }
        }
    }

}
