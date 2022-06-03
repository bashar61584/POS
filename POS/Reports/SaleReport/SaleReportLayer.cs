using POS.Customer;
using POS.Item;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace POS.Reports.CustomerLedger
{
    class SaleReportLayer
    {
        private readonly ModelContext db;
        public SaleReportLayer()
        {
            db = new ModelContext();

        }
       
        internal void LoadDataForPreview(string decssion,string rdbstring, DateTime fromDate, DateTime toDate)
        {
            DataSet1 ds = new DataSet1(); 

            var itemINDB = db.ItemModels.ToList();
            foreach (var item in itemINDB)
            {
                DataRow dr = ds.Tables["tbl_SalesReport"].NewRow();
                //===================Put item in the table===============
                dr["item_id"] = item.item_id;
                dr["item_name"] = item.item_name;
                switch (rdbstring)
                {
                    case "TP":
                        dr["item_tradeprice"] = item.item_tp;
                        break;
                    case "RP":
                        dr["item_tradeprice"] = item.item_retail;
                        break;
                    case "CP":
                        dr["item_tradeprice"] = item.item_costprice;
                        break;
                    default:
                        break;
                }
            
                //===================Openning stock============
                var purchasStock = db.PurchaseInvoiceModels
                    .Include(x => x.PurchaseOrderModel)
                    .Where(x=>x.PurchaseOrderModel.Date<fromDate && x.Item_id==item.item_id).Sum(x=>x.Qty).GetValueOrDefault(0);

                var purchasReturnStock = db.PurchaseReturnInvoiceModels
                    .Include(x => x.PurchaseReturnOrderModel)
                    .Where(x => x.PurchaseReturnOrderModel.Date < fromDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

                var SaleStock = db.SaleInvoiceModels
                  .Include(x => x.SaleOrderModel)
                  .Where(x => x.SaleOrderModel.Date < fromDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

                var SalereturnStock = db.SaleReturnInvoiceModels
                .Include(x => x.SaleReturnOrderModel)
                .Where(x => x.SaleReturnOrderModel.Date < fromDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

                var TransferInStock = db.TransferInInvoiceModels
             .Include(x => x.TransferInOrderModel)
             .Where(x => x.TransferInOrderModel.Date < fromDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

                var TransferOutStock = db.TransferOutInvoiceModels
             .Include(x => x.TransferOutOrderModel)
             .Where(x => x.TransferOutOrderModel.Date < fromDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);

                dr["Openingstock"] = (purchasStock+SalereturnStock+TransferInStock)-(purchasReturnStock+SaleStock+TransferOutStock);

                //Console.WriteLine(item.item_id+" "+item.item_name+" "+purchasStock.ToString() + " " + purchasReturnStock.ToString()
                //    + " "+SaleStock.ToString()+" "+SalereturnStock.ToString() + " " + TransferInStock.ToString() + " " + TransferOutStock.ToString());
                //===============================For Purchase Stock=================
                int qty = 0, bonus = 0;
                qty =  db.PurchaseInvoiceModels
                     .Include(x => x.PurchaseOrderModel)
                     .Where(x => x.PurchaseOrderModel.Date >= fromDate && x.PurchaseOrderModel.Date<=toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                bonus = db.PurchaseInvoiceModels
                     .Include(x => x.PurchaseOrderModel)
                     .Where(x => x.PurchaseOrderModel.Date >= fromDate && x.PurchaseOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["purchaseQty"] = qty;
                dr["purchaseBonus"] = bonus;
                //===============================For Purchase Return Stock=================
                qty = db.PurchaseReturnInvoiceModels
                     .Include(x => x.PurchaseReturnOrderModel)
                     .Where(x => x.PurchaseReturnOrderModel.Date >= fromDate && x.PurchaseReturnOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                bonus = db.PurchaseReturnInvoiceModels
                     .Include(x => x.PurchaseReturnOrderModel)
                     .Where(x => x.PurchaseReturnOrderModel.Date >= fromDate && x.PurchaseReturnOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["purchaseRetQty"] = qty;
                dr["purchaseRetbonus"] = bonus;
                //===============================For Sale Stock=================
                qty = db.SaleInvoiceModels
                     .Include(x => x.SaleOrderModel)
                     .Where(x => x.SaleOrderModel.Date >= fromDate && x.SaleOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                bonus = db.SaleInvoiceModels
                     .Include(x => x.SaleOrderModel)
                     .Where(x => x.SaleOrderModel.Date >= fromDate && x.SaleOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["tpsaleqty"] = qty;
                dr["tpsalebonus"] = bonus;
                //===============================For SaleReturn Stock=================
                qty = db.SaleReturnInvoiceModels
                     .Include(x => x.SaleReturnOrderModel)
                     .Where(x => x.SaleReturnOrderModel.Date >= fromDate && x.SaleReturnOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                bonus = db.SaleReturnInvoiceModels
                     .Include(x => x.SaleReturnOrderModel)
                     .Where(x => x.SaleReturnOrderModel.Date >= fromDate && x.SaleReturnOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["salereturnqty"] = qty;
                dr["salereturnbonus"] = bonus;
                //===============================For Transfer In Stock=================
                qty = db.TransferInInvoiceModels
                     .Include(x => x.TransferInOrderModel)
                     .Where(x => x.TransferInOrderModel.Date >= fromDate && x.TransferInOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                //bonus = db.TransferInInvoiceModels
                //     .Include(x => x.TransferInOrderModel)
                //     .Where(x => x.TransferInOrderModel.Date >= fromDate && x.TransferInOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["transferinqty"] = qty;
                //===============================For Transfer Out Stock=================
                qty = db.TransferOutInvoiceModels
                     .Include(x => x.TransferOutOrderModel)
                     .Where(x => x.TransferOutOrderModel.Date >= fromDate && x.TransferOutOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Qty).GetValueOrDefault(0);
                //bonus = db.TransferInInvoiceModels
                //     .Include(x => x.TransferInOrderModel)
                //     .Where(x => x.TransferInOrderModel.Date >= fromDate && x.TransferInOrderModel.Date <= toDate && x.Item_id == item.item_id).Sum(x => x.Bonus).GetValueOrDefault(0);
                dr["transferoutqty"] = qty;
                ds.Tables["tbl_SalesReport"].Rows.Add(dr);

            }

            switch (decssion)
            {

                case "Preview":
                    SalesReportReportForm obj = new SalesReportReportForm(ds, fromDate, toDate);
                    obj.Show();
                    break;

                case "Print":
                    SaleReportOtherReport orp = new SaleReportOtherReport(decssion, ds, fromDate, toDate);

                    break;
                case "Word":
                    SaleReportOtherReport orp2 = new SaleReportOtherReport(decssion, ds, fromDate, toDate);
                    break;
                case "Excel":
                    SaleReportOtherReport orp3 = new SaleReportOtherReport(decssion, ds, fromDate, toDate);
                    break;

            }

        }

    }
}
