using POS.Customer;
using POS.Item;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace POS.Reports.CustomerLedger
{
    class ExpenseReportLayer
    {
        private readonly ModelContext db;
        private DataSet1 ds; 
        public ExpenseReportLayer()
        {
            db = new ModelContext();

        } 
       
        internal void LoadDataForPreview(string decssion, int txtcode, string getradiobuttonvalue, DateTime fromDate, DateTime toDate)
        {
            var model = (dynamic)null;

            if (txtcode == 0)
            {
                if (getradiobuttonvalue == "rdball")
                {
                     model = db.ExpenseInvoiceModels
                   .Include(x => x.ExpenseOrderModels)
                   .Include(x => x.ExpenseMenuModels)
                   .OrderBy(x => x.ExpenseOrderModels.Date);
                }
                else
                {
                     model = db.ExpenseInvoiceModels
                  .Include(x => x.ExpenseOrderModels)
                  .Include(x => x.ExpenseMenuModels)
                  .Where(x => x.ExpenseOrderModels.Date >= fromDate && x.ExpenseOrderModels.Date <= toDate )
                  .OrderBy(x => x.ExpenseOrderModels.Date);
                }
            }
            else
            {
                if (getradiobuttonvalue == "rdball")
                {
                     model = db.ExpenseInvoiceModels
                   .Include(x => x.ExpenseOrderModels)
                   .Include(x => x.ExpenseMenuModels)
                   .Where(x=>x.EXPMENU_ID==txtcode)
                   .OrderBy(x => x.ExpenseOrderModels.Date);
                }
                else
                {
                     model = db.ExpenseInvoiceModels
                  .Include(x => x.ExpenseOrderModels)
                  .Include(x => x.ExpenseMenuModels)
                  .Where(x => x.ExpenseOrderModels.Date >= fromDate && x.ExpenseOrderModels.Date <= toDate && x.EXPMENU_ID==txtcode)
                  .OrderBy(x => x.ExpenseOrderModels.Date);
                }
            }
           
           
            ds = new DataSet1();
          
            foreach (var item in model)
            {
                DataRow dr = ds.Tables["tbl_ExpenseReport"].NewRow();
                dr["Code"] = item.EXP_ID;
                dr["Date"] = item.ExpenseOrderModels.Date.ToShortDateString();
                dr["Menu"] = item.ExpenseMenuModels.Name;
                dr["Remark"] = item.Remark;
                dr["Amount"] = item.Price;
                dr["FromDate"] = fromDate;
                dr["ToDate"] = toDate;
               
                ds.Tables["tbl_ExpenseReport"].Rows.Add(dr);

            }

            switch (decssion)
            {

                case "Preview":
                    ExpenseReportReportForm obj = new ExpenseReportReportForm(fromDate, toDate, ds);
                    obj.Show();
                    break;

                case "Print":
                    ExpenseReportOtherReport orp = new ExpenseReportOtherReport(decssion, fromDate, toDate, ds);
                    break;
                case "Word":
                    ExpenseReportOtherReport orp2 = new ExpenseReportOtherReport(decssion, fromDate, toDate, ds);

                    break;
                case "Excel":
                    ExpenseReportOtherReport orp3 = new ExpenseReportOtherReport(decssion, fromDate, toDate, ds);

                    break;

            }

        }

    }
}
