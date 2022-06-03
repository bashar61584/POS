using POS.Customer;
using POS.Item;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace POS.Reports.CustomerLedger
{
    class SupplierLedgerLayer
    {
        private readonly ModelContext db;
        private DataSet1 ds; 
        public SupplierLedgerLayer()
        {
            db = new ModelContext();

        }
       
        internal void LoadDataForPreview(string decssion, int txtcode, string getradiobuttonvalue, DateTime fromDate, DateTime toDate)
        {
            decimal previoubalance = 0;
            decimal debit = 0;
            decimal credit = 0;
            ds = new DataSet1();
            if (getradiobuttonvalue == "rdball")
            {
                debit = 0;
                credit = 0;
            }
            else
            {
                var model = db.PurchaseAccountModels.Where(x => x.sup_id == txtcode && x.Date < fromDate);
                foreach (var item in model)
                {
                    debit +=(decimal)item.Debit;
                    credit += (decimal)item.Credit;
                }
                
            }
            previoubalance = debit - credit;
            decimal afterprievious = 0;
            var model2 = (dynamic)null;

            if (getradiobuttonvalue=="rdball")
            {
                 model2 = db.PurchaseAccountModels
                    .Include(x=>x.SupplierModels).Where(x => x.sup_id == txtcode);
                foreach (var item in model2)
                {
                    fromDate= item.Date;
                    break; 
                }
                    
            }
            else
            {
      
                model2 = db.PurchaseAccountModels
                    .Include(x => x.SupplierModels)
                    .Where(x => x.sup_id == txtcode && x.Date >= fromDate && x.Date <= toDate);
            }
            bool checkfirstvalue = true;
            foreach (var item in model2)
            {
                DataRow dr = ds.Tables["tbl_CustomerLedger"].NewRow();
                dr["Name"] = item.SupplierModels.Name;
                dr["Code"] = item.SupplierModels.Sup_ID;
                dr["Address"] = item.SupplierModels.Address1;
                dr["Date"] = item.Date.ToShortDateString();
                dr["order_id"] = item.purchase_order_id;
                dr["Type"] = item.Type;
                dr["Credit"] = item.Credit;
                dr["Debit"] = item.Debit;
                dr["ID"] = item.ID;
                dr["Return_ID"] = item.Purchase_ret_ID;
                if (checkfirstvalue)
                {
                    afterprievious = previoubalance + (decimal)item.Debit - (decimal)item.Credit;
                    checkfirstvalue = false;
                }
                else
                {
                    afterprievious = afterprievious + (decimal)item.Debit - (decimal)item.Credit;
                }
                dr["Balance"] = afterprievious;
                ds.Tables["tbl_CustomerLedger"].Rows.Add(dr);

            }

            switch (decssion)
            {

                case "Preview":
                    SupplierLedgerReportForm obj = new SupplierLedgerReportForm(fromDate,toDate,credit,debit,ds);
                    obj.Show();
                    break;

                case "Print":
                    SupplierLedgerOtherReport orp = new SupplierLedgerOtherReport(decssion,fromDate, toDate, credit, debit, ds);

                    break;
                case "Word":
                    SupplierLedgerOtherReport orp2 = new SupplierLedgerOtherReport(decssion, fromDate, toDate, credit, debit, ds);
                    break;
                case "Excel":
                    SupplierLedgerOtherReport orp3 = new SupplierLedgerOtherReport(decssion, fromDate, toDate, credit, debit, ds);
                    break;

            }

        }

    }
}
