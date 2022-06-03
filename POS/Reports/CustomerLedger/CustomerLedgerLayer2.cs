using POS.Customer;
using POS.Item;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace POS.Reports.CustomerLedger
{
    class CustomerLedgerLayer2
    {
        private readonly ModelContext db;
        private DataSet1 ds; 
        public CustomerLedgerLayer2()
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
                var model = db.SaleAccountModels.Where(x => x.Cu_ID == txtcode && x.Date < fromDate);
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
                 model2 = db.SaleAccountModels
                    .Include(x=>x.CustomerModels).Where(x => x.Cu_ID == txtcode);
                foreach (var item in model2)
                {
                    fromDate= item.Date;
                    break; 
                }
                    
            }
            else
            {
      
                model2 = db.SaleAccountModels
                    .Include(x => x.CustomerModels)
                    .Where(x => x.Cu_ID == txtcode && x.Date >= fromDate &&  x.Date <= toDate);
            }
            bool checkfirstvalue = true;
            foreach (var item in model2)
            {
                DataRow dr = ds.Tables["tbl_CustomerLedger"].NewRow();
                dr["Name"] = item.CustomerModels.Name;
                dr["Code"] = item.CustomerModels.Cu_ID;
                dr["Address"] = item.CustomerModels.Address1;
                dr["Date"] = item.Date.ToShortDateString();
                dr["order_id"] = item.Sale_Order_ID;
                dr["Type"] = item.Type;
                dr["Credit"] = item.Credit;
                dr["Debit"] = item.Debit;
                dr["ID"] = item.ID;
                dr["Return_ID"] = item.Sale_Return_ID;
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
                    CustomerLedgerReportForm obj = new CustomerLedgerReportForm(fromDate,toDate,credit,debit,ds);
                    obj.Show();
                    break;

                case "Print":
                    CustomerLedgerOtherReport orp = new CustomerLedgerOtherReport(decssion,fromDate, toDate, credit, debit, ds);

                    break;
                case "Word":
                    CustomerLedgerOtherReport orp2 = new CustomerLedgerOtherReport(decssion, fromDate, toDate, credit, debit, ds);
                    break;
                case "Excel":
                    CustomerLedgerOtherReport orp3 = new CustomerLedgerOtherReport(decssion, fromDate, toDate, credit, debit, ds);
                    break;

            }

        }

    }
}
