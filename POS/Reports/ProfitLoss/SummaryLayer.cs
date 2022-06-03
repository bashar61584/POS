using POS.Customer;
using POS.Item;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace POS.Reports.CustomerLedger
{
    class SummaryLayer
    {
        private readonly ModelContext db;
        public SummaryLayer()
        {
            db = new ModelContext();

        }

        internal DataTable LoadSaleRecord(string decssion, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            double saleamount = 0;
            double tpamount = 0;
            double transferoutsale = 0;
            double transferouttpsale = 0;
            double transferoutsumsale = 0;  
            var mode = db.SaleInvoiceModels.Include(x => x.SaleOrderModel).Where(x => x.SaleOrderModel.Date >= fromDate && x.SaleOrderModel.Date <= toDate).ToList();
            foreach (var item in mode)
            {
                saleamount += (double)item.Qty * ((double)item.Price);
                tpamount += (double)item.Qty * ((double)item.Tp_Price);
            }
            ////////////////----------------Expense

            var expense = db.ExpenseInvoiceModels.Include(x => x.ExpenseOrderModels).Where(x => x.ExpenseOrderModels.Date >= fromDate && x.ExpenseOrderModels.Date <= toDate).Sum(x => x.Price).GetValueOrDefault(0); ;
            
            ////////////////       Transfer out
            var transmode= db.TransferOutInvoiceModels.Include(x => x.TransferOutOrderModel).Where(x => x.TransferOutOrderModel.Date >= fromDate && x.TransferOutOrderModel.Date <= toDate).ToList();
            foreach (var item in transmode)
            {
                transferoutsale += (double)item.Qty * ((double)item.Price);
                transferouttpsale+= (double)item.Qty * ((double)item.Tp_Price);
            }
            transferoutsumsale = transferoutsale - transferouttpsale;
            ///----------------------------------------------------

            dt.Columns.Add("Sale");
            dt.Columns.Add("TPsale");
            dt.Columns.Add("Profit");
            dt.Columns.Add("Expense");
            dt.Columns.Add("transfer");


            var row = dt.NewRow();
            row[0] = saleamount;
            row[1] = tpamount;
            row[2] = saleamount-tpamount;
            row[3] = expense;
            row[4] = transferoutsumsale;

            dt.Rows.Add(row);

            return dt; 
            //db.SaleInvoiceModels
            //         .Include(x => x.SaleOrderModel)
            //         .Where(x => x.SaleOrderModel.Date >= fromDate && x.SaleOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

        }

    }
}
